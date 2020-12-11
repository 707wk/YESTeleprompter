Imports System.Timers
''' <summary>
''' 素材播放辅助模块
''' </summary>
Public Class ProgramPlayHelper

    Private Sub New()
    End Sub

#Region "操作状态类型"
    ''' <summary>
    ''' 操作状态类型
    ''' </summary>
    Public Enum OperationState
        ''' <summary>
        ''' 无操作
        ''' </summary>
        NoOperation

        ''' <summary>
        ''' 播放
        ''' </summary>
        Playing

        ''' <summary>
        ''' 手动播放
        ''' </summary>
        ManualPlaying

        ''' <summary>
        ''' 录制
        ''' </summary>
        Recording

    End Enum
#End Region

#Region "运行状态"
    ''' <summary>
    ''' 运行状态
    ''' </summary>
    Private Shared _RunningState As OperationState
    ''' <summary>
    ''' 运行状态
    ''' </summary>
    Public Shared ReadOnly Property RunningState As OperationState
        Get
            Return _RunningState
        End Get
    End Property
#End Region

#Region "是否暂停"
    ''' <summary>
    ''' 是否暂停
    ''' </summary>
    Private Shared _IsPause As Boolean
    ''' <summary>
    ''' 是否暂停
    ''' </summary>
    Public Shared ReadOnly Property IsPause As Boolean
        Get
            Return _IsPause
        End Get
    End Property
#End Region

    ''' <summary>
    ''' 画面更新定时器
    ''' </summary>
    Private Shared UpdateTimer As System.Timers.Timer

    ''' <summary>
    ''' 播放窗口
    ''' </summary>
    Public Shared UIPlayForm As PlayForm
    ''' <summary>
    ''' 主窗体
    ''' </summary>
    Public Shared UIMainForm As MainForm

    ''' <summary>
    ''' 当前播放的段落ID
    ''' </summary>
    Public Shared NowPlayParagraphID As Integer
    ''' <summary>
    ''' 当前段落已播放的时间
    ''' </summary>
    Public Shared NowPlayParagraphRunTime As TimeSpan
    ''' <summary>
    ''' 当前段落开始播放的时间
    ''' </summary>
    Public Shared NowPlayParagraphStartTime As DateTime

#Region "播放"
    ''' <summary>
    ''' 播放
    ''' </summary>
    Public Shared Sub Play()
        If RunningState <> OperationState.NoOperation Then
            Exit Sub
        End If

        '开始播放
        _RunningState = OperationState.Playing
        _IsPause = False

        NowPlayParagraphID = 0
        NowPlayParagraphRunTime = New TimeSpan
        NowPlayParagraphStartTime = Now

        IsPaintEnd = True

        '设置定时器
        UpdateTimer = New Timers.Timer
        UpdateTimer.AutoReset = True
        UpdateTimer.Enabled = True
        UpdateTimer.Interval = 10
        AddHandler UpdateTimer.Elapsed, AddressOf Paint
        '开启定时器
        UpdateTimer.Start()

        UIPlayForm.PaintParagraph()

    End Sub
#End Region

#Region "手动播放"
    ''' <summary>
    ''' 手动播放
    ''' </summary>
    Public Shared Sub ManualPlay()
        If RunningState <> OperationState.NoOperation Then
            Exit Sub
        End If

        '开始播放
        _RunningState = OperationState.ManualPlaying

        NowPlayParagraphID = 0

        UIPlayForm.PaintParagraph()

    End Sub
#End Region

#Region "录制"
    ''' <summary>
    ''' 录制
    ''' </summary>
    Public Shared Sub Record()
        If RunningState <> OperationState.NoOperation Then
            Exit Sub
        End If

        _RunningState = OperationState.Recording
        _IsPause = False

        NowPlayParagraphID = 0

        IsPaintEnd = True

    End Sub
#End Region

    '#Region "更新修改"
    '    ''' <summary>
    '    ''' 更新修改
    '    ''' </summary>
    '    Public Shared Sub UpdateChange()
    '        If AppSettingHelper.GetInstance.ActiveProgram Is Nothing Then
    '            Exit Sub
    '        End If

    '        UIPlayForm.UpdateSizeAndLocation()

    '    End Sub
    '#End Region

#Region "更新画面"
    ''' <summary>
    ''' 更新画面
    ''' </summary>
    Private Shared IsPaintEnd As Boolean
    ''' <summary>
    ''' 更新画面
    ''' </summary>
    Public Shared Sub Paint(Optional sender As Object = Nothing,
                            Optional e As ElapsedEventArgs = Nothing)

        '暂停则不处理
        If _IsPause Then
            Exit Sub
        End If



        '上一次更新没完成则不处理
        If Not IsPaintEnd Then
            Exit Sub
        End If
        IsPaintEnd = False

        '计算时间间隔
        Dim runTime = NowPlayParagraphRunTime + (Now - NowPlayParagraphStartTime)

        UIMainForm.Info($"播放 第 {NowPlayParagraphID + 1} 段: {runTime:mm\:ss\.ff}")

        Try

            Dim tmpShowTimestamp = If(AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems(NowPlayParagraphID).HaveTimestamp,
                        AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems(NowPlayParagraphID).ShowTimestamp,
                        AppSettingHelper.GetInstance.ActiveProgram.PrintDefaultShowTimestamp)
            If runTime >= tmpShowTimestamp Then

                If NowPlayParagraphID = AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count - 1 Then
                    'StopPlay()
                    'UIMainForm.Info($"播放完毕")
                    Throw New Exception("播放完毕")
                End If

                '切换到下一段
                NowPlayParagraphID += 1
                NowPlayParagraphRunTime = Now - Now
                NowPlayParagraphStartTime = Now
                '更新画面
                UIPlayForm.PaintParagraph()

            End If

        Catch ex As Exception

            StopPlay()
            UIMainForm.Info($"播放完毕")
        End Try

        IsPaintEnd = True

    End Sub
#End Region

#Region "上一行"
    ''' <summary>
    ''' 上一行
    ''' </summary>
    Public Shared Sub PageUp()
        If RunningState = OperationState.NoOperation Then
            Exit Sub
        End If

        If NowPlayParagraphID - 1 >= 0 Then

            If NowPlayParagraphID + 1 > AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count Then
                NowPlayParagraphID = AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count - 1
            End If

            '切换到下一段
            NowPlayParagraphID -= 1
            NowPlayParagraphRunTime = Now - Now
            NowPlayParagraphStartTime = Now
            '更新画面
            UIPlayForm.PaintParagraph()
        End If

    End Sub
#End Region

#Region "下一行(播放)"
    ''' <summary>
    ''' 下一行
    ''' </summary>
    Public Shared Sub PageDn()
        If RunningState = OperationState.NoOperation Then
            Exit Sub
        End If

        If NowPlayParagraphID + 1 < AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count Then
            '切换到下一段
            NowPlayParagraphID += 1
            NowPlayParagraphRunTime = Now - Now
            NowPlayParagraphStartTime = Now

        Else
            NowPlayParagraphID = AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count - 1

        End If

        '更新画面
        UIPlayForm.PaintParagraph()

    End Sub
#End Region

#Region "下一行(录制)"
    ''' <summary>
    ''' 下一行
    ''' </summary>
    Public Shared Sub PageDn(value As TimeSpan)
        If RunningState = OperationState.NoOperation Then
            Exit Sub
        End If

        If NowPlayParagraphID + 1 <= AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count Then
            AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems(NowPlayParagraphID).TranscribeTimestamp = value
        End If

        '录制
        If NowPlayParagraphID + 1 < AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count Then
            '切换到下一段
            NowPlayParagraphID += 1
            '更新画面
            UIPlayForm.PaintParagraph()
        End If

    End Sub
#End Region

#Region "暂停"
    ''' <summary>
    ''' 暂停
    ''' </summary>
    Public Shared Sub Pause()
        If RunningState = OperationState.NoOperation Then
            Exit Sub
        End If

        If _IsPause Then
            Exit Sub
        End If

        _IsPause = True

        NowPlayParagraphRunTime += Now - NowPlayParagraphStartTime

    End Sub
#End Region

#Region "继续"
    ''' <summary>
    ''' 继续
    ''' </summary>
    Public Shared Sub GoOn()
        If RunningState = OperationState.NoOperation Then
            Exit Sub
        End If

        If Not _IsPause Then
            Exit Sub
        End If

        NowPlayParagraphStartTime = Now

        _IsPause = False

    End Sub
#End Region

#Region "停止播放"
    ''' <summary>
    ''' 停止播放
    ''' </summary>
    Public Shared Sub StopPlay()
        If RunningState = OperationState.NoOperation Then
            Exit Sub
        End If

        UpdateTimer?.Stop()
        UpdateTimer = Nothing

        _RunningState = OperationState.NoOperation

        UIMainForm.StopButton_Click()

    End Sub
#End Region

End Class
