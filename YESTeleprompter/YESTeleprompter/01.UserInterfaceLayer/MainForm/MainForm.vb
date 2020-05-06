Imports System.ComponentModel
Imports Newtonsoft.Json

Public Class MainForm

    ''' <summary>
    ''' 播放窗口
    ''' </summary>
    Public ChildPlayWindow As New PlayForm

    ''' <summary>
    ''' 录制工具栏
    ''' </summary>
    Public RecordWindow As RecordShowForm

#Region "窗口显示"
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppSettingHelper.Logger.Info("程序启动")

        Me.Text = $"{My.Application.Info.Title} V{AppSettingHelper.ProductVersion}"

        If AppSettingHelper.Settings.WindowSize.Width <> 0 AndAlso
            AppSettingHelper.Settings.WindowSize.Height <> 0 Then

            'Me.Size = AppSettingHelper.Settings.WindowSize
            Me.Location = AppSettingHelper.Settings.WindowLocation
        End If

#Region "素材列表"
        With ProgramList
            .BackgroundColor = Color.FromArgb(71, 71, 71)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            '.RowHeadersVisible = False
            .EnableHeadersVisualStyles = False
            .RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(71, 71, 71)
            .RowHeadersDefaultCellStyle.ForeColor = SystemColors.Window
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .RowHeadersWidth = 60
            '.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
            .DefaultCellStyle.BackColor = Color.FromArgb(71, 71, 71)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(56, 56, 60)
            .EditMode = DataGridViewEditMode.EditOnEnter
            .GridColor = Color.FromArgb(45, 45, 48)
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .RowTemplate.Height = 30
            .RowTemplate.MinimumHeight = 30

            .MultiSelect = False
        End With

        For Each item As DataGridViewColumn In ProgramList.Columns
            item.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
#End Region

#Region "素材内容列表"
        With ParagraphList
            .BackgroundColor = Color.FromArgb(71, 71, 71)
            .SelectionMode = DataGridViewSelectionMode.CellSelect

            '.RowHeadersVisible = False
            .EnableHeadersVisualStyles = False
            .RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(71, 71, 71)
            .RowHeadersDefaultCellStyle.ForeColor = SystemColors.Window
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .RowHeadersWidth = 90
            '.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
            .DefaultCellStyle.BackColor = Color.FromArgb(71, 71, 71)

            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders

            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(56, 56, 60)
            .EditMode = DataGridViewEditMode.EditOnEnter
            .GridColor = Color.FromArgb(45, 45, 48)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
            .RowTemplate.Height = 30
            .RowTemplate.MinimumHeight = 30

            .MultiSelect = True
            .ReadOnly = False

            .VirtualMode = True
        End With

        For Each item As DataGridViewColumn In ParagraphList.Columns
            item.SortMode = DataGridViewColumnSortMode.NotSortable
            item.ReadOnly = True
        Next
        ParagraphList.Columns(1).ReadOnly = False
        ParagraphList.Columns(2).ReadOnly = False
#End Region

        ChildPlayWindow.Show()
        ProgramPlayHelper.UIPlayForm = ChildPlayWindow
        ProgramPlayHelper.UIMainForm = Me

        For Each item In AppSettingHelper.Settings.ProgramItems
            Dim addRowID = ProgramList.Rows.Add({False, item.Name})
            ProgramList.Rows(addRowID).Tag = item.ID
        Next

        ProgramList.Sort(ProgramList.Columns(1), ListSortDirection.Ascending)
        If ProgramList.Rows.Count > 0 Then
            ProgramList.CurrentCell = ProgramList.Rows(0).Cells(1)
        End If

        PreviewLabel.DataBindings.Add(NameOf(PreviewLabel.ForeColor), PrintFontColor, NameOf(PrintFontColor.BackColor))
        PreviewLabel.DataBindings.Add(NameOf(PreviewLabel.BackColor), PrintBackColor, NameOf(PrintBackColor.BackColor))

        '注册全局快捷键
        RegisterHotKey()
        WindowsHotKeyHelper.RegisterHotKey(Me.Handle.ToInt32, 5, 0, Keys.PageUp)
        WindowsHotKeyHelper.RegisterHotKey(Me.Handle.ToInt32, 6, 0, Keys.PageDown)

        ControlEnabledToStop()

    End Sub
#End Region

#Region "窗口关闭"
    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '未停止则不能退出程序
        If ProgramPlayHelper.RunningState <> ProgramPlayHelper.OperationState.NoOperation Then
            e.Cancel = True
            Exit Sub
        End If

        '注销全局快捷键
        UnregisterHotKey()
        WindowsHotKeyHelper.UnregisterHotKey(Me.Handle.ToInt32, Keys.PageUp)
        WindowsHotKeyHelper.UnregisterHotKey(Me.Handle.ToInt32, Keys.PageDown)

        '存储设置
        AppSettingHelper.Settings.WindowSize = Me.Size
        AppSettingHelper.Settings.WindowLocation = Me.Location
        'AppSettingHelper.SaveToLocaltion()

        ChildPlayWindow.NeedClose = True

    End Sub
#End Region

#Region "新建素材"
    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles NewProgramButton.Click
        Using tmpDialog As New Wangk.Resource.InputTextDialog With {.Text = "新建素材名"}
            If tmpDialog.ShowDialog("新建", "取消") <> DialogResult.OK Then
                Exit Sub
            End If

            Dim tmpAddProgramInfo As New ProgramInfo With {
                .Name = tmpDialog.Value
            }

            Dim addRowID = ProgramList.Rows.Add({False, tmpAddProgramInfo.Name})
            ProgramList.Rows(addRowID).Tag = tmpAddProgramInfo.ID
            ProgramList.CurrentCell = ProgramList.Rows(addRowID).Cells(1)

            AppSettingHelper.Settings.ActiveProgram = Nothing
            ParagraphList.Rows.Clear()
            ParagraphList.RowCount = tmpAddProgramInfo.ParagraphItems.Count
            AppSettingHelper.Settings.ActiveProgram = tmpAddProgramInfo

            AppSettingHelper.Settings.ProgramItems.Add(tmpAddProgramInfo)

        End Using

        ProgramList.Sort(ProgramList.Columns(1), ListSortDirection.Ascending)

    End Sub
#End Region

#Region "导入素材"
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ImportProgramButton.Click
        Dim tmpDialog As New OpenFileDialog With {
                   .Filter = "素材文件|*.txt;*.lrc;*.docx;*.lrcy",
                   .Multiselect = True
               }
        If tmpDialog.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        For Each filePath In tmpDialog.FileNames

            Dim tmpAddProgramInfo As ProgramInfo

            Try
                tmpAddProgramInfo = ProgramFactory.Create(filePath)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, ImportProgramButton.Text)
                Exit Sub
            End Try

            Dim addRowID = ProgramList.Rows.Add({False, tmpAddProgramInfo.Name})
            ProgramList.Rows(addRowID).Tag = tmpAddProgramInfo.ID
            ProgramList.CurrentCell = ProgramList.Rows(addRowID).Cells(1)

            AppSettingHelper.Settings.ActiveProgram = Nothing
            ParagraphList.Rows.Clear()
            ParagraphList.RowCount = tmpAddProgramInfo.ParagraphItems.Count
            AppSettingHelper.Settings.ActiveProgram = tmpAddProgramInfo

            AppSettingHelper.Settings.ProgramItems.Add(tmpAddProgramInfo)

        Next

        ProgramList.Sort(ProgramList.Columns(1), ListSortDirection.Ascending)

    End Sub
#End Region

#Region "导出素材"
    Private Sub ButtonItem10_Click(sender As Object, e As EventArgs) Handles ExportProgramButton.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New SaveFileDialog With {
            .FileName = AppSettingHelper.Settings.ActiveProgram.Name,
            .Filter = "素材文件|*.lrcy"
        }
            If tmpDialog.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            Using t As System.IO.StreamWriter = New System.IO.StreamWriter(
                    tmpDialog.FileName,
                    False,
                    System.Text.Encoding.UTF8)

                t.Write(JsonConvert.SerializeObject(AppSettingHelper.Settings.ActiveProgram))
            End Using

        End Using

    End Sub
#End Region

#Region "删除勾选素材"
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles DeleteProgramButton.Click
        For rowID = ProgramList.Rows.Count - 1 To 0 Step -1
            If ProgramList.Rows(rowID).Cells(0).EditedFormattedValue Then
                If MsgBox("确定删除选中素材?",
                                          MsgBoxStyle.YesNo,
                                          DeleteProgramButton.Text) <> MsgBoxResult.Yes Then
                    Exit Sub
                Else
                    Exit For
                End If
            End If
        Next

        '删除
        For rowID = ProgramList.Rows.Count - 1 To 0 Step -1
            If ProgramList.Rows(rowID).Cells(0).EditedFormattedValue Then

                If AppSettingHelper.Settings.ProgramItems(rowID) Is AppSettingHelper.Settings.ActiveProgram Then
                    AppSettingHelper.Settings.ActiveProgram = Nothing
                    ParagraphList.Rows.Clear()
                End If

                Dim id As Guid = ProgramList.Rows(rowID).Tag
                Dim findProgramInfo = AppSettingHelper.Settings.ProgramItems.Find(Function(value As ProgramInfo)
                                                                                      Return value.ID = id
                                                                                  End Function)
                IO.File.Delete($"./Data/{id}")
                AppSettingHelper.Settings.ProgramItems.Remove(findProgramInfo)

                ProgramList.Rows.RemoveAt(rowID)
            End If

        Next

        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            ProgramList.ClearSelection()
        End If

    End Sub
#End Region

#Region "显示素材内容及配置"
    Private Sub CheckBoxDataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles ProgramList.CurrentCellChanged
        If ProgramList.CurrentCell Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram = Nothing
        ParagraphList.Rows.Clear()

        Dim id As Guid = ProgramList.Rows(ProgramList.CurrentCell.RowIndex).Tag

        Dim findProgramInfo = AppSettingHelper.Settings.ProgramItems.Find(Function(value As ProgramInfo)
                                                                              Return value.ID = id
                                                                          End Function)
        If findProgramInfo Is Nothing Then
            Exit Sub
        End If

        ParagraphList.RowCount = findProgramInfo.ParagraphItems.Count
        AppSettingHelper.Settings.ActiveProgram = findProgramInfo

        If AppSettingHelper.Settings.ActiveProgram.PrintFont Is Nothing Then
            AppSettingHelper.Settings.ActiveProgram.PrintFont = Me.Font
        End If
        PrintFontText.Text = $"{AppSettingHelper.Settings.ActiveProgram.PrintFont.Name}, {AppSettingHelper.Settings.ActiveProgram.PrintFont.Size}, {AppSettingHelper.Settings.ActiveProgram.PrintFont.Style}"
        PreviewLabel.Font = AppSettingHelper.Settings.ActiveProgram.PrintFont

        PrintFontColor.BackColor = AppSettingHelper.Settings.ActiveProgram.PrintFontColor
        PrintBackColor.BackColor = AppSettingHelper.Settings.ActiveProgram.PrintBackColor

        PreviewLabel.ForeColor = PrintFontColor.BackColor
        PreviewLabel.BackColor = PrintBackColor.BackColor
        PreviewLabel.Refresh()

        PrintDefaultShowTimestamp.Value = AppSettingHelper.Settings.ActiveProgram.PrintDefaultShowTimestamp.ToString("ss\.ff")
        PrintMirror.Checked = AppSettingHelper.Settings.ActiveProgram.PrintMirror

        WindowSizeWidth.Value = AppSettingHelper.Settings.ActiveProgram.WindowSize.Width
        WindowSizeHeight.Value = AppSettingHelper.Settings.ActiveProgram.WindowSize.Height

        WindowLocationX.Value = AppSettingHelper.Settings.ActiveProgram.WindowLocation.X
        WindowLocationY.Value = AppSettingHelper.Settings.ActiveProgram.WindowLocation.Y

        IsFullScreen.Checked = AppSettingHelper.Settings.ActiveProgram.IsFullScreen

        ChildPlayWindow.UpdateSizeAndLocation()
        ChildPlayWindow.PreviewStr = Nothing
        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "清除播放时长"
    Private Sub ClearTranscribeButton_Click(sender As Object, e As EventArgs) Handles ClearTranscribeButton.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        If MsgBox("确定清除当前素材录制信息?",
                  MsgBoxStyle.YesNo,
                  ClearTranscribeButton.Text) <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        For Each item In AppSettingHelper.Settings.ActiveProgram.ParagraphItems
            item.HaveTimestamp = False
        Next

        ParagraphList.Refresh()

    End Sub
#End Region

#Region "素材内容编辑"

#Region "插入新行"
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles InsertParagraphButton.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        If AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count > 0 Then

            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Insert(ParagraphList.CurrentCell.RowIndex,
                                                New ParagraphInfo With {
                                                .ShowTimestamp = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(ParagraphList.CurrentCell.RowIndex).ShowTimestamp
                                                })

            ParagraphList.Rows.Insert(ParagraphList.CurrentCell.RowIndex, 1)

        Else

            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Add(New ParagraphInfo)
            ParagraphList.Rows.Add(1)
        End If

    End Sub
#End Region

#Region "删除勾选行"
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles DeleteParagraphButton.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        For rowID = AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count - 1 To 0 Step -1
            If AppSettingHelper.Settings.ActiveProgram.ParagraphItems(rowID).Checked Then
                If MsgBox("确定删除选中行?",
                          MsgBoxStyle.YesNo,
                          DeleteParagraphButton.Text) <> MsgBoxResult.Yes Then
                    Exit Sub
                Else
                    Exit For
                End If
            End If
        Next

        '删除
        For rowID = AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count - 1 To 0 Step -1
            If AppSettingHelper.Settings.ActiveProgram.ParagraphItems(rowID).Checked Then
                ParagraphList.Rows.RemoveAt(rowID)
            End If
        Next

    End Sub
#End Region

#Region "虚拟表操作"
    Private Sub CheckBoxDataGridView2_NewRowNeeded(sender As Object,
                                                   e As DataGridViewRowEventArgs
                                                   ) Handles ParagraphList.NewRowNeeded

    End Sub

    Private Sub CheckBoxDataGridView2_RowsAdded(sender As Object,
                                                e As DataGridViewRowsAddedEventArgs
                                                ) Handles ParagraphList.RowsAdded

    End Sub

    Private Sub CheckBoxDataGridView2_CellValidating(sender As Object,
                                                     e As DataGridViewCellValidatingEventArgs
                                                     ) Handles ParagraphList.CellValidating
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0


            Case 1
                Try
                    Dim tmpValueStr = $"{e.FormattedValue}"

                    If tmpValueStr = "" OrElse
                        tmpValueStr = "-" Then
                        Exit Sub
                    End If

                    Dim mID = tmpValueStr.IndexOf(":")
                    If mID = -1 Then
                        Throw New Exception("时间格式错误")
                    End If

                    Dim mStr = tmpValueStr.Substring(0, mID)
                    Dim mValue As Integer = Val(mStr)
                    If mValue > 59 OrElse mValue < 0 Then
                        Throw New Exception("分钟取值范围为 0 - 59")
                    End If

                    Dim sStr = tmpValueStr.Substring(mID + 1)
                    Dim sValue As Double = CDbl(sStr)
                    If sValue > 59.99 OrElse sValue < 0 Then
                        Throw New Exception("秒取值范围为为 0.00 - 59.99")
                    End If

                    ParagraphList.Rows(e.RowIndex).ErrorText = ""

                Catch ex As Exception
                    e.Cancel = True

                    ParagraphList.Rows(e.RowIndex).ErrorText = ex.Message
                    MsgBox(ex.Message, MsgBoxStyle.Information, "输入校验")
                End Try

            Case 2

        End Select

    End Sub

    Private Sub CheckBoxDataGridView2_CellValueNeeded(sender As Object,
                                                      e As DataGridViewCellValueEventArgs
                                                      ) Handles ParagraphList.CellValueNeeded
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0
                e.Value = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).Checked

            Case 1
                If AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).HaveTimestamp Then
                    e.Value = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).ShowTimestamp.ToString("mm\:ss\.ff")
                Else
                    e.Value = "-"
                End If

            Case 2
                e.Value = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).value

        End Select

    End Sub

    Private Sub CheckBoxDataGridView2_CellValuePushed(sender As Object,
                                                      e As DataGridViewCellValueEventArgs
                                                      ) Handles ParagraphList.CellValuePushed
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0
                AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).Checked = e.Value

            Case 1
                Dim tmpValueStr = $"{e.Value}"

                If tmpValueStr = "" OrElse
                    tmpValueStr = "-" Then
                    AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).HaveTimestamp = False
                    Exit Sub
                Else
                    AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).HaveTimestamp = True
                End If

                Dim mID = tmpValueStr.IndexOf(":")

                Dim mStr = tmpValueStr.Substring(0, mID)
                Dim mValue As Integer = Val(mStr)

                Dim sStr = tmpValueStr.Substring(mID + 1)
                Dim sValue As Double = CDbl(sStr)

                AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).ShowTimestamp =
                DateTime.ParseExact($"{mValue:00}:{sValue:00.00}", "mm:ss.ff", Nothing).TimeOfDay

            Case 2
                AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).value = e.Value

        End Select

    End Sub

    Private Sub CheckBoxDataGridView2_RowsRemoved(sender As Object,
                                                  e As DataGridViewRowsRemovedEventArgs
                                                  ) Handles ParagraphList.RowsRemoved
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.ParagraphItems.RemoveAt(e.RowIndex)

    End Sub

    Private Sub ParagraphList_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ParagraphList.RowEnter
        If AppSettingHelper.Settings.ActiveProgram IsNot Nothing Then
            ChildPlayWindow.PreviewStr = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).value
            ChildPlayWindow.Refresh()
        End If
    End Sub

#End Region

#End Region

#Region "素材配置编辑"

#Region "字体"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles SelectPrintFontButton.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New FontDialog With {
            .ShowEffects = False,
            .ShowColor = False,
            .Font = AppSettingHelper.Settings.ActiveProgram.PrintFont,
            .AllowVerticalFonts = False
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            PrintFontText.Text = $"{tmpDialog.Font.Name}, {tmpDialog.Font.Size}, {tmpDialog.Font.Style}"
            PreviewLabel.Font = tmpDialog.Font
            AppSettingHelper.Settings.ActiveProgram.PrintFont = tmpDialog.Font

        End Using

        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "字体颜色"
    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles PrintFontColor.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New ColorDialog With {
            .Color = AppSettingHelper.Settings.ActiveProgram.PrintFontColor
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            PrintFontColor.BackColor = tmpDialog.Color
            AppSettingHelper.Settings.ActiveProgram.PrintFontColor = tmpDialog.Color

        End Using

        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "背景颜色"
    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles PrintBackColor.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New ColorDialog With {
            .Color = AppSettingHelper.Settings.ActiveProgram.PrintBackColor
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            PrintBackColor.BackColor = tmpDialog.Color
            AppSettingHelper.Settings.ActiveProgram.PrintBackColor = tmpDialog.Color

        End Using

        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "每行默认显示秒数"
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles PrintDefaultShowTimestamp.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.PrintDefaultShowTimestamp = DateTime.ParseExact($"{PrintDefaultShowTimestamp.Value:00.00}", "ss.ff", Nothing).TimeOfDay

    End Sub
#End Region

#Region "镜像显示"
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles PrintMirror.CheckedChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.PrintMirror = PrintMirror.Checked
        PreviewLabel.Refresh()

        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "播放窗口尺寸"
    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles WindowSizeWidth.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.WindowSize.Width = WindowSizeWidth.Value

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles WindowSizeHeight.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.WindowSize.Height = WindowSizeHeight.Value

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub
#End Region

#Region "播放窗口位置"
    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles WindowLocationX.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.WindowLocation.X = WindowLocationX.Value

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles WindowLocationY.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.WindowLocation.Y = WindowLocationY.Value

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub
#End Region

#Region "全屏显示"
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles IsFullScreen.CheckedChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.IsFullScreen = IsFullScreen.Checked

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub
#End Region

#Region "播放效果预览"
    Private Sub Label6_Paint(sender As Object, e As PaintEventArgs) Handles PreviewLabel.Paint
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        e.Graphics.TranslateTransform(PreviewLabel.Width / 2,
                                      (PreviewLabel.Height - e.Graphics.MeasureString("测试文字 Test string", AppSettingHelper.Settings.ActiveProgram.PrintFont).Height) / 2)

        If AppSettingHelper.Settings.ActiveProgram.PrintMirror Then
            '镜像显示
            e.Graphics.ScaleTransform(-1, 1)
        End If

        e.Graphics.DrawString("测试文字 Test string",
                                  AppSettingHelper.Settings.ActiveProgram.PrintFont,
                                  New SolidBrush(AppSettingHelper.Settings.ActiveProgram.PrintFontColor),
                                  0,
                                  0,
                                  New StringFormat With {
                                  .Alignment = StringAlignment.Center
                                  })
        e.Graphics.ResetTransform()

    End Sub
#End Region

#End Region

#Region "快捷键设置"
    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs) Handles HotkeysButton.Click
        Using tmpDialog As New HotKeysSettingForm With {
            .UIForm = Me,
            .Text = HotkeysButton.Text
        }

            tmpDialog.ShowDialog()

        End Using

    End Sub

#Region "全局快捷键"
    ''' <summary>
    ''' 注册全局快捷键
    ''' </summary>
    Public Sub RegisterHotKey()
        WindowsHotKeyHelper.RegisterHotKey(Me.Handle.ToInt32, 1, 0, AppSettingHelper.Settings.HotKeyForPlay)
        WindowsHotKeyHelper.RegisterHotKey(Me.Handle.ToInt32, 2, 0, AppSettingHelper.Settings.HotKeyForPause)
        WindowsHotKeyHelper.RegisterHotKey(Me.Handle.ToInt32, 3, 0, AppSettingHelper.Settings.HotKeyForStop)
        WindowsHotKeyHelper.RegisterHotKey(Me.Handle.ToInt32, 4, 0, AppSettingHelper.Settings.HotKeyForHideWindow)

    End Sub

    ''' <summary>
    ''' 注销全局快捷键
    ''' </summary>
    Public Sub UnregisterHotKey()
        WindowsHotKeyHelper.UnregisterHotKey(Me.Handle.ToInt32, AppSettingHelper.Settings.HotKeyForPlay)
        WindowsHotKeyHelper.UnregisterHotKey(Me.Handle.ToInt32, AppSettingHelper.Settings.HotKeyForPause)
        WindowsHotKeyHelper.UnregisterHotKey(Me.Handle.ToInt32, AppSettingHelper.Settings.HotKeyForStop)
        WindowsHotKeyHelper.UnregisterHotKey(Me.Handle.ToInt32, AppSettingHelper.Settings.HotKeyForHideWindow)

    End Sub
#End Region

#End Region

#Region "快捷键处理"
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        If keyData = Keys.PageUp OrElse keyData = Keys.PageDown Then
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WindowsHotKeyHelper.WM_HOTKEY Then
            Select Case m.WParam.ToInt32
                Case 1
                    '播放
                    If PlayButton.Enabled Then
                        PlayButton_Click()
                    End If

                Case 2
                    '暂停
                    If PauseButton.Enabled Then
                        PauseButton_Click()
                    End If

                Case 3
                    '停止
                    If StopButton.Enabled Then
                        StopButton_Click()
                    End If

                Case 4
                    '隐藏
                    HidePlayWindowButton.Value = Not HidePlayWindowButton.Value

                Case 5
                    '上一行
                    If PageUpButton.Enabled Then
                        PageUpButton_Click()
                    End If

                Case 6
                    '下一行
                    If PageDnButton.Enabled Then
                        PageDnButton_Click()
                    End If

            End Select
        End If

        MyBase.WndProc(m)
    End Sub
#End Region

    Private Sub TranscribeButton_Click(Optional sender As Object = Nothing,
                                       Optional e As EventArgs = Nothing) Handles TranscribeButton.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing OrElse
            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count < 1 Then
            Exit Sub
        End If

        RecordWindow?.Dispose()
        RecordWindow = Nothing

        RecordWindow = New RecordShowForm With {
            .Text = TranscribeButton.Text,
            .UIMainForm = Me
        }
        RecordWindow.Show()

    End Sub

    Private Sub PlayButton_Click(Optional sender As Object = Nothing,
                                 Optional e As EventArgs = Nothing) Handles PlayButton.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing OrElse
            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count < 1 Then
            Exit Sub
        End If

        'Throw New Exception("测试异常")

        ProgramPlayHelper.Play()

        ControlEnabledToPlay()

    End Sub

    Private Sub ManualPlayButton_Click(sender As Object, e As EventArgs) Handles ManualPlayButton.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing OrElse
            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count < 1 Then
            Exit Sub
        End If

        ProgramPlayHelper.ManualPlay()

        ControlEnabledToManualPlay()

    End Sub

    Public Delegate Sub StopButton_ClickCallback(sender As Object, e As EventArgs)
    ''' <summary>
    ''' 更新画面
    ''' </summary>
    Friend Sub StopButton_Click(Optional sender As Object = Nothing,
                                Optional e As EventArgs = Nothing) Handles StopButton.Click
        If Me.InvokeRequired Then
            Me.Invoke(New StopButton_ClickCallback(AddressOf StopButton_Click),
                      New Object() {sender, e})
            Exit Sub
        End If

        ProgramPlayHelper.StopPlay()

        ControlEnabledToStop()

        ChildPlayWindow.Refresh()

    End Sub

    Private Sub PageUpButton_Click(Optional sender As Object = Nothing,
                                   Optional e As EventArgs = Nothing) Handles PageUpButton.Click
        ProgramPlayHelper.PageUp()
    End Sub

    Private Sub PageDnButton_Click(Optional sender As Object = Nothing,
                                   Optional e As EventArgs = Nothing) Handles PageDnButton.Click
        ProgramPlayHelper.PageDn()
    End Sub

    Private Sub PauseButton_Click(Optional sender As Object = Nothing,
                                  Optional e As EventArgs = Nothing) Handles PauseButton.Click

        If ProgramPlayHelper.IsPause Then
            ProgramPlayHelper.GoOn()
            PauseButton.Image = My.Resources.pause_32px
            PauseButton.Text = "暂停"
        Else
            ProgramPlayHelper.Pause()
            PauseButton.Image = My.Resources.goOn_32px
            PauseButton.Text = "继续"
        End If

    End Sub

    Private Sub HidePlayWindowButton_ValueChanged(Optional sender As Object = Nothing,
                                                  Optional e As EventArgs = Nothing) Handles HidePlayWindowButton.ValueChanged
        ChildPlayWindow.Visible = Not HidePlayWindowButton.Value
    End Sub

#Region "控件状态"
    ''' <summary>
    ''' 播放时控件状态
    ''' </summary>
    Public Sub ControlEnabledToPlay()
        If ProgramPlayHelper.RunningState <> ProgramPlayHelper.OperationState.Playing Then
            Exit Sub
        End If

        NewProgramButton.Enabled = False
        ImportProgramButton.Enabled = False
        ExportProgramButton.Enabled = False
        PlayButton.Enabled = False

        PauseButton.Enabled = True
        StopButton.Enabled = True
        PageUpButton.Enabled = True
        PageDnButton.Enabled = True

        TranscribeButton.Enabled = False
        ClearTranscribeButton.Enabled = False
        HotkeysButton.Enabled = False

        ProgramList.Enabled = False
        DeleteProgramButton.Enabled = False

    End Sub

    ''' <summary>
    ''' 手动播放时控件状态
    ''' </summary>
    Public Sub ControlEnabledToManualPlay()
        If ProgramPlayHelper.RunningState <> ProgramPlayHelper.OperationState.ManualPlaying Then
            Exit Sub
        End If

        NewProgramButton.Enabled = False
        ImportProgramButton.Enabled = False
        ExportProgramButton.Enabled = False
        PlayButton.Enabled = False

        PauseButton.Enabled = False
        StopButton.Enabled = True
        PageUpButton.Enabled = True
        PageDnButton.Enabled = True

        TranscribeButton.Enabled = False
        ClearTranscribeButton.Enabled = False
        HotkeysButton.Enabled = False

        ProgramList.Enabled = False
        DeleteProgramButton.Enabled = False

    End Sub

    ''' <summary>
    ''' 停止时控件状态
    ''' </summary>
    Public Sub ControlEnabledToStop()
        If ProgramPlayHelper.RunningState <> ProgramPlayHelper.OperationState.NoOperation Then
            Exit Sub
        End If

        NewProgramButton.Enabled = True
        ImportProgramButton.Enabled = True
        ExportProgramButton.Enabled = True
        PlayButton.Enabled = True

        PauseButton.Enabled = False
        PauseButton.Image = My.Resources.pause_32px
        PauseButton.Text = "暂停"

        StopButton.Enabled = False
        PageUpButton.Enabled = False
        PageDnButton.Enabled = False

        TranscribeButton.Enabled = True
        ClearTranscribeButton.Enabled = True
        HotkeysButton.Enabled = True

        ProgramList.Enabled = True
        DeleteProgramButton.Enabled = True

    End Sub

    ''' <summary>
    ''' 录制时控件状态
    ''' </summary>
    Public Sub ControlEnabledToRecord()
        If ProgramPlayHelper.RunningState <> ProgramPlayHelper.OperationState.Recording Then
            Exit Sub
        End If

        NewProgramButton.Enabled = False
        ImportProgramButton.Enabled = False
        ExportProgramButton.Enabled = False
        PlayButton.Enabled = False

        PauseButton.Enabled = False
        StopButton.Enabled = False
        PageUpButton.Enabled = False
        PageDnButton.Enabled = False

        TranscribeButton.Enabled = False
        ClearTranscribeButton.Enabled = False
        HotkeysButton.Enabled = False

        ProgramList.Enabled = False
        DeleteProgramButton.Enabled = False

    End Sub

#End Region

    Public Delegate Sub InfoCallback(value As String)
    ''' <summary>
    ''' 提示信息
    ''' </summary>
    Friend Sub Info(value As String)
        If Me.InvokeRequired Then
            Me.Invoke(New InfoCallback(AddressOf Info),
                      value)
            Exit Sub
        End If

        InfoLabel.Text = value

    End Sub

End Class