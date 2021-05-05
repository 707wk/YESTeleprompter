Imports System.ComponentModel

Public Class PlayForm

    ''' <summary>
    ''' 是否需要关闭
    ''' </summary>
    Public NeedClose As Boolean

    ''' <summary>
    ''' 预览字符
    ''' </summary>
    Public PreviewStr As String

    Public Delegate Sub UpdateSizeAndLocationCallback()
    ''' <summary>
    ''' 更新尺寸和位置
    ''' </summary>
    Public Sub UpdateSizeAndLocation()
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateSizeAndLocationCallback(AddressOf UpdateSizeAndLocation))
            Exit Sub
        End If

        Dim program = AppSettingHelper.GetInstance.ActiveProgram

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
        If AppSettingHelper.GetInstance.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Dim program = AppSettingHelper.GetInstance.ActiveProgram

        If ProgramPlayHelper.RunningState = ProgramPlayHelper.OperationState.NoOperation Then
            If String.IsNullOrWhiteSpace(PreviewStr) Then
                '清屏
                e.Graphics.Clear(Color.Black)

            Else
                '显示预览字符
                e.Graphics.Clear(program.PrintBackColor)
                If AppSettingHelper.GetInstance.ActiveProgram.PrintMirror Then
                    '平移原点坐标
                    e.Graphics.TranslateTransform(Me.Width, 0)
                    '镜像显示
                    e.Graphics.ScaleTransform(-1, 1)
                End If
                e.Graphics.DrawString(PreviewStr,
                                      AppSettingHelper.GetInstance.ActiveProgram.PrintFont,
                                      New SolidBrush(AppSettingHelper.GetInstance.ActiveProgram.PrintFontColor),
                                      New RectangleF(0, 0, Me.Width, Me.Height))

            End If

            Exit Sub
        End If

        e.Graphics.Clear(program.PrintBackColor)
        'Dim fontHeight = e.Graphics.MeasureString("测", AppSettingHelper.GetInstance.ActiveProgram.PrintFont).Height

        If AppSettingHelper.GetInstance.ActiveProgram.PrintMirror Then
            '平移原点坐标
            e.Graphics.TranslateTransform(Me.Width, 0)
            '镜像显示
            e.Graphics.ScaleTransform(-1, 1)
        End If

        Try

            Dim nowStrPointY As Integer = 0
            Dim rowID = 0
            Do

                e.Graphics.DrawString(program.ParagraphItems(ProgramPlayHelper.NowPlayParagraphID + rowID).value,
                                      AppSettingHelper.GetInstance.ActiveProgram.PrintFont,
                                      New SolidBrush(AppSettingHelper.GetInstance.ActiveProgram.PrintFontColor),
                                      New RectangleF(0, nowStrPointY, Me.Width, Me.Height))

                If String.IsNullOrWhiteSpace(program.ParagraphItems(ProgramPlayHelper.NowPlayParagraphID + rowID).value) Then
                    nowStrPointY += e.Graphics.MeasureString("输出",
                                                             AppSettingHelper.GetInstance.ActiveProgram.PrintFont,
                                                             Me.Width).Height

                Else
                    nowStrPointY += e.Graphics.MeasureString(program.ParagraphItems(ProgramPlayHelper.NowPlayParagraphID + rowID).value,
                                                             AppSettingHelper.GetInstance.ActiveProgram.PrintFont,
                                                             Me.Width).Height

                End If

                rowID += 1

            Loop While nowStrPointY < Me.Height AndAlso
                (ProgramPlayHelper.NowPlayParagraphID + rowID) < AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PlayForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
    End Sub

    Private Sub PlayForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not NeedClose Then
            e.Cancel = True
        End If

    End Sub
End Class