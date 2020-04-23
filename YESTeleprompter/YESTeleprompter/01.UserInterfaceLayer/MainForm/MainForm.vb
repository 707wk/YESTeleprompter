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
        With CheckBoxDataGridView1
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

        For Each item As DataGridViewColumn In CheckBoxDataGridView1.Columns
            item.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
#End Region

#Region "素材内容列表"
        With CheckBoxDataGridView2
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

        For Each item As DataGridViewColumn In CheckBoxDataGridView2.Columns
            item.SortMode = DataGridViewColumnSortMode.NotSortable
            item.ReadOnly = True
        Next
        CheckBoxDataGridView2.Columns(1).ReadOnly = False
        CheckBoxDataGridView2.Columns(2).ReadOnly = False
#End Region

        ChildPlayWindow.Show()
        ProgramPlayHelper.UIPlayForm = ChildPlayWindow

        For Each item In AppSettingHelper.Settings.ProgramItems
            Dim addRowID = CheckBoxDataGridView1.Rows.Add({False, item.Name})
            CheckBoxDataGridView1.Rows(addRowID).Tag = item.ID
        Next

        CheckBoxDataGridView1.Sort(CheckBoxDataGridView1.Columns(1), ListSortDirection.Ascending)
        If CheckBoxDataGridView1.Rows.Count > 0 Then
            CheckBoxDataGridView1.CurrentCell = CheckBoxDataGridView1.Rows(0).Cells(1)
        End If

        Label6.DataBindings.Add(NameOf(Label6.ForeColor), Label13, NameOf(Label13.BackColor))
        Label6.DataBindings.Add(NameOf(Label6.BackColor), Label14, NameOf(Label14.BackColor))

        '注册全局快捷键
        RegisterHotKey()
        WindowsHotKeyHelper.RegisterHotKey(Me.Handle.ToInt32, 5, 0, Keys.PageUp)
        WindowsHotKeyHelper.RegisterHotKey(Me.Handle.ToInt32, 6, 0, Keys.PageDown)

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
        AppSettingHelper.SaveToLocaltion()

    End Sub
#End Region

#Region "新建素材"
    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        Using tmpDialog As New Wangk.Resource.InputTextDialog With {.Text = "新建素材名"}
            If tmpDialog.ShowDialog("新建", "取消") <> DialogResult.OK Then
                Exit Sub
            End If

            Dim tmpAddProgramInfo As New ProgramInfo With {
                .Name = tmpDialog.Value
            }

            Dim addRowID = CheckBoxDataGridView1.Rows.Add({False, tmpAddProgramInfo.Name})
            CheckBoxDataGridView1.Rows(addRowID).Tag = tmpAddProgramInfo.ID
            CheckBoxDataGridView1.CurrentCell = CheckBoxDataGridView1.Rows(addRowID).Cells(1)

            AppSettingHelper.Settings.ActiveProgram = Nothing
            CheckBoxDataGridView2.Rows.Clear()
            CheckBoxDataGridView2.RowCount = tmpAddProgramInfo.ParagraphItems.Count
            AppSettingHelper.Settings.ActiveProgram = tmpAddProgramInfo

            AppSettingHelper.Settings.ProgramItems.Add(tmpAddProgramInfo)

        End Using

        CheckBoxDataGridView1.Sort(CheckBoxDataGridView1.Columns(1), ListSortDirection.Ascending)

    End Sub
#End Region

#Region "导入素材"
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
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
                MsgBox(ex.Message, MsgBoxStyle.Information, ButtonItem1.Text)
                Exit Sub
            End Try

            Dim addRowID = CheckBoxDataGridView1.Rows.Add({False, tmpAddProgramInfo.Name})
            CheckBoxDataGridView1.Rows(addRowID).Tag = tmpAddProgramInfo.ID
            CheckBoxDataGridView1.CurrentCell = CheckBoxDataGridView1.Rows(addRowID).Cells(1)

            AppSettingHelper.Settings.ActiveProgram = Nothing
            CheckBoxDataGridView2.Rows.Clear()
            CheckBoxDataGridView2.RowCount = tmpAddProgramInfo.ParagraphItems.Count
            AppSettingHelper.Settings.ActiveProgram = tmpAddProgramInfo

            AppSettingHelper.Settings.ProgramItems.Add(tmpAddProgramInfo)

        Next

        CheckBoxDataGridView1.Sort(CheckBoxDataGridView1.Columns(1), ListSortDirection.Ascending)

    End Sub
#End Region

#Region "导出素材"
    Private Sub ButtonItem10_Click(sender As Object, e As EventArgs) Handles ButtonItem10.Click
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
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        '删除
        For rowID = CheckBoxDataGridView1.Rows.Count - 1 To 0 Step -1
            If CheckBoxDataGridView1.Rows(rowID).Cells(0).EditedFormattedValue Then

                If AppSettingHelper.Settings.ProgramItems(rowID) Is AppSettingHelper.Settings.ActiveProgram Then
                    AppSettingHelper.Settings.ActiveProgram = Nothing
                    CheckBoxDataGridView2.Rows.Clear()
                End If

                Dim id As Guid = CheckBoxDataGridView1.Rows(rowID).Tag
                Dim findProgramInfo = AppSettingHelper.Settings.ProgramItems.Find(Function(value As ProgramInfo)
                                                                                      Return value.ID = id
                                                                                  End Function)
                IO.File.Delete($"./Data/{id}")
                AppSettingHelper.Settings.ProgramItems.Remove(findProgramInfo)

                CheckBoxDataGridView1.Rows.RemoveAt(rowID)
            End If

        Next

        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            CheckBoxDataGridView1.ClearSelection()
        End If

    End Sub
#End Region

#Region "显示素材内容及配置"
    Private Sub CheckBoxDataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles CheckBoxDataGridView1.CurrentCellChanged
        If CheckBoxDataGridView1.CurrentCell Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram = Nothing
        CheckBoxDataGridView2.Rows.Clear()

        Dim id As Guid = CheckBoxDataGridView1.Rows(CheckBoxDataGridView1.CurrentCell.RowIndex).Tag

        Dim findProgramInfo = AppSettingHelper.Settings.ProgramItems.Find(Function(value As ProgramInfo)
                                                                              Return value.ID = id
                                                                          End Function)
        If findProgramInfo Is Nothing Then
            Exit Sub
        End If

        CheckBoxDataGridView2.RowCount = findProgramInfo.ParagraphItems.Count
        AppSettingHelper.Settings.ActiveProgram = findProgramInfo

        If AppSettingHelper.Settings.ActiveProgram.PrintFont Is Nothing Then
            AppSettingHelper.Settings.ActiveProgram.PrintFont = Me.Font
        End If
        TextBox1.Text = $"{AppSettingHelper.Settings.ActiveProgram.PrintFont.Name}, {AppSettingHelper.Settings.ActiveProgram.PrintFont.Size}, {AppSettingHelper.Settings.ActiveProgram.PrintFont.Style}"
        Label6.Font = AppSettingHelper.Settings.ActiveProgram.PrintFont

        Label13.BackColor = AppSettingHelper.Settings.ActiveProgram.PrintFontColor
        Label14.BackColor = AppSettingHelper.Settings.ActiveProgram.PrintBackColor

        Label6.ForeColor = Label13.BackColor
        Label6.BackColor = Label14.BackColor
        Label6.Refresh()

        NumericUpDown1.Value = AppSettingHelper.Settings.ActiveProgram.PrintDefaultShowTimestamp.ToString("ss\.ff")
        CheckBox1.Checked = AppSettingHelper.Settings.ActiveProgram.PrintMirror

        NumericUpDown5.Value = AppSettingHelper.Settings.ActiveProgram.WindowSize.Width
        NumericUpDown2.Value = AppSettingHelper.Settings.ActiveProgram.WindowSize.Height

        NumericUpDown3.Value = AppSettingHelper.Settings.ActiveProgram.WindowLocation.X
        NumericUpDown4.Value = AppSettingHelper.Settings.ActiveProgram.WindowLocation.Y

        CheckBox2.Checked = AppSettingHelper.Settings.ActiveProgram.IsFullScreen

        ChildPlayWindow.UpdateSizeAndLocation()
        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "素材内容编辑"

#Region "插入新行"
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        If AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count > 0 Then

            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Insert(CheckBoxDataGridView2.CurrentCell.RowIndex,
                                                New ParagraphInfo With {
                                                .ShowTimestamp = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(CheckBoxDataGridView2.CurrentCell.RowIndex).ShowTimestamp
                                                })

            CheckBoxDataGridView2.Rows.Insert(CheckBoxDataGridView2.CurrentCell.RowIndex, 1)

        Else

            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Add(New ParagraphInfo)
            CheckBoxDataGridView2.Rows.Add(1)
        End If

    End Sub
#End Region

#Region "删除勾选行"
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        '删除
        For rowID = AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count - 1 To 0 Step -1
            If AppSettingHelper.Settings.ActiveProgram.ParagraphItems(rowID).Checked Then
                CheckBoxDataGridView2.Rows.RemoveAt(rowID)
            End If
        Next

    End Sub
#End Region

#Region "虚拟表操作"
    Private Sub CheckBoxDataGridView2_NewRowNeeded(sender As Object,
                                                   e As DataGridViewRowEventArgs
                                                   ) Handles CheckBoxDataGridView2.NewRowNeeded

    End Sub

    Private Sub CheckBoxDataGridView2_RowsAdded(sender As Object,
                                                e As DataGridViewRowsAddedEventArgs
                                                ) Handles CheckBoxDataGridView2.RowsAdded

    End Sub

    Private Sub CheckBoxDataGridView2_CellValidating(sender As Object,
                                                     e As DataGridViewCellValidatingEventArgs
                                                     ) Handles CheckBoxDataGridView2.CellValidating
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

                    CheckBoxDataGridView2.Rows(e.RowIndex).ErrorText = ""

                Catch ex As Exception
                    e.Cancel = True

                    CheckBoxDataGridView2.Rows(e.RowIndex).ErrorText = ex.Message
                    MsgBox(ex.Message, MsgBoxStyle.Information, "输入校验")
                End Try

            Case 2

        End Select

    End Sub

    Private Sub CheckBoxDataGridView2_CellValueNeeded(sender As Object,
                                                      e As DataGridViewCellValueEventArgs
                                                      ) Handles CheckBoxDataGridView2.CellValueNeeded
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
                                                      ) Handles CheckBoxDataGridView2.CellValuePushed
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
                                                  ) Handles CheckBoxDataGridView2.RowsRemoved
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.ParagraphItems.RemoveAt(e.RowIndex)

    End Sub
#End Region

#End Region

#Region "素材配置编辑"

#Region "字体"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New FontDialog With {
            .ShowEffects = False,
            .ShowColor = False,
            .Font = AppSettingHelper.Settings.ActiveProgram.PrintFont
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            TextBox1.Text = $"{tmpDialog.Font.Name}, {tmpDialog.Font.Size}, {tmpDialog.Font.Style}"
            Label6.Font = tmpDialog.Font
            AppSettingHelper.Settings.ActiveProgram.PrintFont = tmpDialog.Font

        End Using

        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "字体颜色"
    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New ColorDialog With {
            .Color = AppSettingHelper.Settings.ActiveProgram.PrintFontColor
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            Label13.BackColor = tmpDialog.Color
            AppSettingHelper.Settings.ActiveProgram.PrintFontColor = tmpDialog.Color

        End Using

        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "背景颜色"
    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New ColorDialog With {
            .Color = AppSettingHelper.Settings.ActiveProgram.PrintBackColor
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            Label14.BackColor = tmpDialog.Color
            AppSettingHelper.Settings.ActiveProgram.PrintBackColor = tmpDialog.Color

        End Using

        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "每行默认显示秒数"
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.PrintDefaultShowTimestamp = DateTime.ParseExact($"{NumericUpDown1.Value:00.00}", "ss.ff", Nothing).TimeOfDay

    End Sub
#End Region

#Region "镜像显示"
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.PrintMirror = CheckBox1.Checked
        Label6.Refresh()

        ChildPlayWindow.Refresh()

    End Sub
#End Region

#Region "播放窗口尺寸"
    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown5.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.WindowSize.Width = NumericUpDown5.Value

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.WindowSize.Height = NumericUpDown2.Value

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub
#End Region

#Region "播放窗口位置"
    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.WindowLocation.X = NumericUpDown3.Value

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.ValueChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.WindowLocation.Y = NumericUpDown4.Value

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub
#End Region

#Region "全屏显示"
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        AppSettingHelper.Settings.ActiveProgram.IsFullScreen = CheckBox2.Checked

        ChildPlayWindow.UpdateSizeAndLocation()
        Me.Activate()

    End Sub
#End Region

#Region "播放效果预览"
    Private Sub Label6_Paint(sender As Object, e As PaintEventArgs) Handles Label6.Paint
        If AppSettingHelper.Settings.ActiveProgram Is Nothing Then
            Exit Sub
        End If

        e.Graphics.TranslateTransform(Label6.Width / 2,
                                      (Label6.Height - e.Graphics.MeasureString("测试文字 Test string", AppSettingHelper.Settings.ActiveProgram.PrintFont).Height) / 2)

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
    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs) Handles ButtonItem7.Click
        Using tmpDialog As New HotKeysSettingForm With {
            .UIForm = Me,
            .Text = ButtonItem7.Text
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

                Case 2

                Case 3

                Case 4

                Case 5

                Case 6

            End Select
        End If

        MyBase.WndProc(m)
    End Sub
#End Region

    Private Sub ButtonItem8_Click(sender As Object, e As EventArgs) Handles ButtonItem8.Click

        RecordWindow?.Dispose()
        RecordWindow = Nothing

        RecordWindow = New RecordShowForm With {
            .Text = ButtonItem8.Text
        }
        RecordWindow.Show()

    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        ProgramPlayHelper.Play()
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        ProgramPlayHelper.StopPlay()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        ProgramPlayHelper.PageUp()
    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        ProgramPlayHelper.PageDn()
    End Sub

    Private Sub ButtonItem11_Click(sender As Object, e As EventArgs) Handles ButtonItem11.Click

        If ProgramPlayHelper.IsPause Then
            ProgramPlayHelper.GoOn()
            ButtonItem11.Image = My.Resources.pause_32px
            ButtonItem11.Text = "暂停"
        Else
            ProgramPlayHelper.Pause()
            ButtonItem11.Image = My.Resources.goOn_32px
            ButtonItem11.Text = "继续"
        End If

    End Sub

    Private Sub SwitchButtonItem1_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButtonItem1.ValueChanged
        ChildPlayWindow.Visible = Not SwitchButtonItem1.Value
    End Sub

End Class