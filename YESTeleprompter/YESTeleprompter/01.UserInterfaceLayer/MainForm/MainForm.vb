Imports System.ComponentModel

Public Class MainForm

    ''' <summary>
    ''' 播放窗口
    ''' </summary>
    Private ChildPlayWindow As New PlayForm

    ''' <summary>
    ''' 当前编辑的素材
    ''' </summary>
    Private ActiveProgram As ProgramInfo

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

    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        AppSettingHelper.Settings.WindowSize = Me.Size
        AppSettingHelper.Settings.WindowLocation = Me.Location
        AppSettingHelper.SaveToLocaltion()
    End Sub

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
                MsgBox(ex.ToString, MsgBoxStyle.Information, ButtonItem1.Text)
                Exit Sub
            End Try

            Dim addRowID = CheckBoxDataGridView1.Rows.Add({False, tmpAddProgramInfo.Name})
            CheckBoxDataGridView1.Rows(addRowID).Tag = tmpAddProgramInfo.ID
            CheckBoxDataGridView1.CurrentCell = CheckBoxDataGridView1.Rows(addRowID).Cells(1)

            ActiveProgram = Nothing
            CheckBoxDataGridView2.Rows.Clear()
            CheckBoxDataGridView2.RowCount = tmpAddProgramInfo.ParagraphItems.Count
            ActiveProgram = tmpAddProgramInfo

            AppSettingHelper.Settings.ProgramItems.Add(tmpAddProgramInfo)

        Next

        CheckBoxDataGridView1.Sort(CheckBoxDataGridView1.Columns(1), ListSortDirection.Ascending)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        If ActiveProgram.ParagraphItems.Count > 0 Then

            ActiveProgram.ParagraphItems.Insert(CheckBoxDataGridView2.CurrentCell.RowIndex,
                                                New ParagraphInfo With {
                                                .Timestamp = ActiveProgram.ParagraphItems(CheckBoxDataGridView2.CurrentCell.RowIndex).Timestamp
                                                })

            CheckBoxDataGridView2.Rows.Insert(CheckBoxDataGridView2.CurrentCell.RowIndex, 1)

        Else

            ActiveProgram.ParagraphItems.Add(New ParagraphInfo)
            CheckBoxDataGridView2.Rows.Add(1)
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        '删除
        For rowID = ActiveProgram.ParagraphItems.Count - 1 To 0 Step -1
            If ActiveProgram.ParagraphItems(rowID).Checked Then
                CheckBoxDataGridView2.Rows.RemoveAt(rowID)
            End If
        Next

    End Sub

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
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0


            Case 1
                Try
                    Dim tmpValueStr = e.FormattedValue.ToString

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
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0
                e.Value = ActiveProgram.ParagraphItems(e.RowIndex).Checked
            Case 1
                e.Value = ActiveProgram.ParagraphItems(e.RowIndex).Timestamp.ToString("mm\:ss\.ff")
            Case 2
                e.Value = ActiveProgram.ParagraphItems(e.RowIndex).value
        End Select

    End Sub

    Private Sub CheckBoxDataGridView2_CellValuePushed(sender As Object,
                                                      e As DataGridViewCellValueEventArgs
                                                      ) Handles CheckBoxDataGridView2.CellValuePushed
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0
                ActiveProgram.ParagraphItems(e.RowIndex).Checked = e.Value
            Case 1
                Dim tmpValueStr = e.Value.ToString

                Dim mID = tmpValueStr.IndexOf(":")

                Dim mStr = tmpValueStr.Substring(0, mID)
                Dim mValue As Integer = Val(mStr)

                Dim sStr = tmpValueStr.Substring(mID + 1)
                Dim sValue As Double = CDbl(sStr)

                ActiveProgram.ParagraphItems(e.RowIndex).Timestamp =
                DateTime.ParseExact($"{mValue:00}:{sValue:00.00}", "mm:ss.ff", Nothing).TimeOfDay
            Case 2
                ActiveProgram.ParagraphItems(e.RowIndex).value = e.Value
        End Select

    End Sub

    Private Sub CheckBoxDataGridView2_RowsRemoved(sender As Object,
                                                  e As DataGridViewRowsRemovedEventArgs
                                                  ) Handles CheckBoxDataGridView2.RowsRemoved
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        ActiveProgram.ParagraphItems.RemoveAt(e.RowIndex)

    End Sub
#End Region

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        '删除
        For rowID = CheckBoxDataGridView1.Rows.Count - 1 To 0 Step -1
            If CheckBoxDataGridView1.Rows(rowID).Cells(0).EditedFormattedValue Then

                If AppSettingHelper.Settings.ProgramItems(rowID) Is ActiveProgram Then
                    ActiveProgram = Nothing
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

        If ActiveProgram Is Nothing Then
            CheckBoxDataGridView1.ClearSelection()
        End If

    End Sub

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

            ActiveProgram = Nothing
            CheckBoxDataGridView2.Rows.Clear()
            CheckBoxDataGridView2.RowCount = tmpAddProgramInfo.ParagraphItems.Count
            ActiveProgram = tmpAddProgramInfo

            AppSettingHelper.Settings.ProgramItems.Add(tmpAddProgramInfo)

        End Using

        CheckBoxDataGridView1.Sort(CheckBoxDataGridView1.Columns(1), ListSortDirection.Ascending)

    End Sub

    Private Sub CheckBoxDataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles CheckBoxDataGridView1.CurrentCellChanged
        If CheckBoxDataGridView1.CurrentCell Is Nothing Then
            Exit Sub
        End If

        ActiveProgram = Nothing
        CheckBoxDataGridView2.Rows.Clear()

        Dim id As Guid = CheckBoxDataGridView1.Rows(CheckBoxDataGridView1.CurrentCell.RowIndex).Tag

        Dim findProgramInfo = AppSettingHelper.Settings.ProgramItems.Find(Function(value As ProgramInfo)
                                                                              Return value.ID = id
                                                                          End Function)
        If findProgramInfo Is Nothing Then
            Exit Sub
        End If

        CheckBoxDataGridView2.RowCount = findProgramInfo.ParagraphItems.Count
        ActiveProgram = findProgramInfo

        If ActiveProgram.PrintFont Is Nothing Then
            ActiveProgram.PrintFont = Me.Font
        End If
        TextBox1.Text = $"{ActiveProgram.PrintFont.Name}, {ActiveProgram.PrintFont.Size}, {ActiveProgram.PrintFont.Style}"
        Label6.Font = ActiveProgram.PrintFont

        Label13.BackColor = ActiveProgram.PrintFontColor
        Label14.BackColor = ActiveProgram.PrintBackColor

        Label6.ForeColor = Label13.BackColor
        Label6.BackColor = Label14.BackColor
        Label6.Refresh()

        NumericUpDown1.Value = ActiveProgram.PrintDefaultIntervalSec
        CheckBox1.Checked = ActiveProgram.PrintMirror

        NumericUpDown5.Value = ActiveProgram.WindowSize.Width
        NumericUpDown2.Value = ActiveProgram.WindowSize.Height

        NumericUpDown3.Value = ActiveProgram.WindowLocation.X
        NumericUpDown4.Value = ActiveProgram.WindowLocation.Y

        CheckBox2.Checked = ActiveProgram.IsFullScreen

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New FontDialog With {
            .ShowEffects = False,
            .ShowColor = False,
            .Font = ActiveProgram.PrintFont
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            TextBox1.Text = $"{tmpDialog.Font.Name}, {tmpDialog.Font.Size}, {tmpDialog.Font.Style}"
            Label6.Font = tmpDialog.Font
            ActiveProgram.PrintFont = tmpDialog.Font

        End Using

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New ColorDialog With {
            .Color = ActiveProgram.PrintFontColor
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            Label13.BackColor = tmpDialog.Color
            ActiveProgram.PrintFontColor = tmpDialog.Color

        End Using

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        Using tmpDialog As New ColorDialog With {
            .Color = ActiveProgram.PrintBackColor
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            Label14.BackColor = tmpDialog.Color
            ActiveProgram.PrintBackColor = tmpDialog.Color

        End Using

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        ActiveProgram.PrintDefaultIntervalSec = NumericUpDown1.Value

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        ActiveProgram.PrintMirror = CheckBox1.Checked
        Label6.Refresh()

    End Sub

    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown5.ValueChanged
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        ActiveProgram.WindowSize.Width = NumericUpDown5.Value

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        ActiveProgram.WindowSize.Height = NumericUpDown2.Value

    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        ActiveProgram.WindowLocation.X = NumericUpDown3.Value

    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.ValueChanged
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        ActiveProgram.WindowLocation.Y = NumericUpDown4.Value

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        ActiveProgram.IsFullScreen = CheckBox2.Checked

    End Sub

    Private Sub Label6_Paint(sender As Object, e As PaintEventArgs) Handles Label6.Paint
        If ActiveProgram Is Nothing Then
            Exit Sub
        End If

        e.Graphics.TranslateTransform(Label6.Width / 2,
                                      (Label6.Height - e.Graphics.MeasureString("测试文字 Test string", ActiveProgram.PrintFont).Height) / 2)

        If ActiveProgram.PrintMirror Then
            '镜像显示
            e.Graphics.ScaleTransform(-1, 1)
        End If

        e.Graphics.DrawString("测试文字 Test string",
                                  ActiveProgram.PrintFont,
                                  New SolidBrush(ActiveProgram.PrintFontColor),
                                  0,
                                  0,
                                  New StringFormat With {
                                  .Alignment = StringAlignment.Center
                                  })
        e.Graphics.ResetTransform()

    End Sub

End Class