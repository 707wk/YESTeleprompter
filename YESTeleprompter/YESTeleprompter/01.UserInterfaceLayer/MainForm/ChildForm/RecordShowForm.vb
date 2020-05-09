Imports System.ComponentModel

Public Class RecordShowForm

    ''' <summary>
    ''' 主窗体
    ''' </summary>
    Public UIMainForm As MainForm

    ''' <summary>
    ''' 当前段落已播放的时间
    ''' </summary>
    Private NowPlayParagraphRunTime As TimeSpan
    ''' <summary>
    ''' 当前段落开始播放的时间
    ''' </summary>
    Private NowPlayParagraphStartTime As DateTime
    ''' <summary>
    ''' 总播放时间
    ''' </summary>
    Private ProgramSumTime As TimeSpan

    ''' <summary>
    ''' 是否暂停
    ''' </summary>
    Private IsPause As Boolean

    Private Sub RecordShowForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(Optional sender As Object = Nothing,
                            Optional e As EventArgs = Nothing) Handles Timer1.Tick
        If Not IsPause AndAlso
            (NowPlayParagraphRunTime + (Now - NowPlayParagraphStartTime)).TotalSeconds < 3600 Then

            ToolStripLabel2.Text = (NowPlayParagraphRunTime + (Now - NowPlayParagraphStartTime)).ToString("mm\:ss\.ff")
            ToolStripLabel1.Text = (ProgramSumTime + NowPlayParagraphRunTime + (Now - NowPlayParagraphStartTime)).ToString("hh\:mm\:ss\.ff")
        End If

    End Sub

    Private Sub RecordShowForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Timer1.Interval = 10
        IsPause = False
        ProgramPlayHelper.Record()

        NowPlayParagraphStartTime = Now
        Timer1.Start()

        ProgramPlayHelper.UIPlayForm.Refresh()

        UIMainForm.ControlEnabledToRecord()

        ToolStripLabel3.Text = $"第 {ProgramPlayHelper.NowPlayParagraphID + 1 } 段"

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles PageDnButton.Click

        NowPlayParagraphRunTime += If((Now - NowPlayParagraphStartTime).TotalSeconds >= 3600,
            New TimeSpan(0, 59, 59),
            Now - NowPlayParagraphStartTime)

        ProgramSumTime += NowPlayParagraphRunTime

        If ProgramPlayHelper.NowPlayParagraphID >= AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count - 1 Then
            ProgramPlayHelper.PageDn(NowPlayParagraphRunTime)
            Me.Close()
            Exit Sub
        End If

        ProgramPlayHelper.PageDn(NowPlayParagraphRunTime)

        NowPlayParagraphRunTime -= NowPlayParagraphRunTime
        NowPlayParagraphStartTime = Now

        ToolStripLabel3.Text = $"第 {ProgramPlayHelper.NowPlayParagraphID + 1 } 段"

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles PauseButton.Click
        If IsPause Then
            IsPause = False
            NowPlayParagraphStartTime = Now

            PauseButton.Image = My.Resources.pause_20px
            PauseButton.Text = "暂停"
        Else
            IsPause = True
            NowPlayParagraphRunTime += (Now - NowPlayParagraphStartTime)

            PauseButton.Image = My.Resources.goOn_20px
            PauseButton.Text = "继续"
        End If

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        NowPlayParagraphRunTime -= NowPlayParagraphRunTime
        NowPlayParagraphStartTime = Now

        ToolStripLabel2.Text = (NowPlayParagraphRunTime + (Now - NowPlayParagraphStartTime)).ToString("mm\:ss\.ff")

    End Sub

    Private Sub RecordShowForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Timer1.Stop()

        ProgramPlayHelper.StopPlay()

        If ProgramPlayHelper.NowPlayParagraphID < AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems.Count - 1 Then
            UIMainForm.ControlEnabledToStop()
            Exit Sub
        End If

        If MsgBox($"播放演示共需 {ProgramSumTime:hh\:mm\:ss\.ff} ,是否保留新的播放计时?", MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.Yes Then
            UIMainForm.ControlEnabledToStop()
            Exit Sub
        End If

        For Each item In AppSettingHelper.GetInstance.ActiveProgram.ParagraphItems
            item.HaveTimestamp = True
            item.ShowTimestamp = item.TranscribeTimestamp
        Next

        UIMainForm.ControlEnabledToStop()
        UIMainForm.ParagraphList.Refresh()

    End Sub

End Class