Public Class PlayForm

    Public Delegate Sub UpdateSizeAndLocationCallback()
    ''' <summary>
    ''' 更新尺寸和位置
    ''' </summary>
    Public Sub UpdateSizeAndLocation()
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateSizeAndLocationCallback(AddressOf UpdateSizeAndLocation))
            Exit Sub
        End If

        Dim program = AppSettingHelper.Settings.ActiveProgram

        Me.WindowState = If(program.IsFullScreen, FormWindowState.Maximized, FormWindowState.Normal)

        Me.Size = program.WindowSize
        Me.Location = program.WindowLocation

    End Sub

    Public Delegate Sub PaintParagraphCallback()
    ''' <summary>
    ''' 更新画面
    ''' </summary>
    Public Sub PaintParagraph()
        If Me.InvokeRequired Then
            Me.Invoke(New PaintParagraphCallback(AddressOf PaintParagraph))
            Exit Sub
        End If

        Me.Refresh()

    End Sub

    Private Sub PlayForm_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        If ProgramPlayHelper.RunningState = ProgramPlayHelper.OperationState.NoOperation Then
            e.Graphics.Clear(Color.Black)
            Exit Sub
        End If

        Dim program = AppSettingHelper.Settings.ActiveProgram

        e.Graphics.Clear(program.PrintBackColor)
        Dim fontHeight = e.Graphics.MeasureString("测", AppSettingHelper.Settings.ActiveProgram.PrintFont).Height

        If AppSettingHelper.Settings.ActiveProgram.PrintMirror Then
            '平移原点坐标
            e.Graphics.TranslateTransform(Me.Width, 0)
            '镜像显示
            e.Graphics.ScaleTransform(-1, 1)
        End If

        Dim rowID = 0
        Do

            e.Graphics.DrawString(program.ParagraphItems(ProgramPlayHelper.NowPlayParagraphID + rowID).value,
                                 AppSettingHelper.Settings.ActiveProgram.PrintFont,
                                 New SolidBrush(AppSettingHelper.Settings.ActiveProgram.PrintFontColor),
                                 0,
                                 rowID * fontHeight)
            rowID += 1

        Loop While (rowID * fontHeight < Me.Height AndAlso
            (ProgramPlayHelper.NowPlayParagraphID + rowID) < AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count)

    End Sub

    Private Sub PlayForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
    End Sub

End Class