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

        Dim program = AppSettingHelper.Settings.ActiveProgram

        If ProgramPlayHelper.RunningState = ProgramPlayHelper.OperationState.NoOperation Then
            If String.IsNullOrWhiteSpace(PreviewStr) Then
                '清屏
                e.Graphics.Clear(Color.Black)

            Else
                '显示预览字符
                e.Graphics.Clear(program.PrintBackColor)
                If AppSettingHelper.Settings.ActiveProgram.PrintMirror Then
                    '平移原点坐标
                    e.Graphics.TranslateTransform(Me.Width, 0)
                    '镜像显示
                    e.Graphics.ScaleTransform(-1, 1)
                End If
                e.Graphics.DrawString(PreviewStr,
                                      AppSettingHelper.Settings.ActiveProgram.PrintFont,
                                      New SolidBrush(AppSettingHelper.Settings.ActiveProgram.PrintFontColor),
                                      0,
                                      0)

            End If

            Exit Sub
        End If

        e.Graphics.Clear(program.PrintBackColor)
        Dim fontHeight = e.Graphics.MeasureString("测", AppSettingHelper.Settings.ActiveProgram.PrintFont).Height

        If AppSettingHelper.Settings.ActiveProgram.PrintMirror Then
            '平移原点坐标
            e.Graphics.TranslateTransform(Me.Width, 0)
            '镜像显示
            e.Graphics.ScaleTransform(-1, 1)
        End If

        Try

            Dim rowID = 0
            Do

                e.Graphics.DrawString(program.ParagraphItems(ProgramPlayHelper.NowPlayParagraphID + rowID).value,
                                      AppSettingHelper.Settings.ActiveProgram.PrintFont,
                                      New SolidBrush(AppSettingHelper.Settings.ActiveProgram.PrintFontColor),
                                      0,
                                      rowID * fontHeight)
                rowID += 1

            Loop While rowID * fontHeight < Me.Height AndAlso
                (ProgramPlayHelper.NowPlayParagraphID + rowID) < AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count

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