Imports System.ComponentModel

Public Class MainForm

    Private ChildPlayWindow As New PlayForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppSettingHelper.Logger.Info("程序启动")

        Me.Text = $"{My.Application.Info.Title} V{AppSettingHelper.ProductVersion}"

        If AppSettingHelper.Settings.WindowSize.Width <> 0 AndAlso
            AppSettingHelper.Settings.WindowSize.Height <> 0 Then

            'Me.Size = AppSettingHelper.Settings.WindowSize
            Me.Location = AppSettingHelper.Settings.WindowLocation
        End If

        With CheckBoxDataGridView1
            .BackgroundColor = Color.FromArgb(71, 71, 71)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
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

        ChildPlayWindow.Show()

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

            'Dim tmp As New Stopwatch
            'tmp.Restart()

            'Dim tmpFileBaseInfo As ProgramInfo
            Try
                AppSettingHelper.Settings.ActiveProgram = ProgramFactory.Create(filePath)
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, ButtonItem1.Text)
                Exit Sub
            End Try

            'Debug.WriteLine(tmp.ElapsedMilliseconds)
            'tmp.Restart()

            CheckBoxDataGridView1.Rows.Add({False, IO.Path.GetFileNameWithoutExtension(filePath)})

            CheckBoxDataGridView2.Rows.Clear()
            CheckBoxDataGridView2.RowCount = AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count

            'For Each item In tmpFileBaseInfo.ParagraphItems
            '    'CheckBoxDataGridView2.Rows.Add({False, If(item.Timestamp = Nothing, "00:00.00", item.Timestamp.ToString), item.value})
            '    Dim addID = CheckBoxDataGridView2.Rows.Add({False, item.Timestamp.ToString("mm\:ss\.ff"), item.value})
            '    CheckBoxDataGridView2.Rows(addID).Cells(1).Tag = CheckBoxDataGridView2.Rows(addID).Cells(1).Value
            'Next
            'Debug.WriteLine(tmp.ElapsedMilliseconds)
        Next
    End Sub

    'Private Sub CheckBoxDataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles CheckBoxDataGridView2.CellValueChanged
    '    If e.ColumnIndex <> 1 OrElse
    '        e.RowIndex < 0 Then
    '        Exit Sub
    '    End If

    '    Dim tmpCell = CheckBoxDataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex)

    '    Try
    '        If String.IsNullOrWhiteSpace(tmpCell.Value) Then
    '            Throw New Exception("时间戳不能为空")
    '        End If

    '        Dim tmpValueStr = tmpCell.Value.ToString

    '        Dim mID = tmpValueStr.IndexOf(":")
    '        If mID = -1 Then
    '            Throw New Exception("时间格式错误")
    '        End If

    '        Dim mStr = tmpValueStr.Substring(0, mID)
    '        Dim mValue As Integer = Val(mStr)

    '        Dim sStr = tmpValueStr.Substring(mID + 1)
    '        Dim sValue As Double = CDbl(sStr)

    '        Dim tmpTimeSpan = DateTime.ParseExact($"{mValue:00}:{sValue:00.00}", "mm:ss.ff", Nothing).TimeOfDay
    '        tmpCell.Value = tmpTimeSpan.ToString("mm\:ss\.ff")
    '        tmpCell.Tag = tmpCell.Value

    '    Catch ex As Exception
    '        tmpCell.Value = $"{tmpCell.Tag}"
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    Private Sub addFirstRow()
        If AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count = 0 Then
            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Add(New ParagraphInfo)
            CheckBoxDataGridView2.RowCount += 1
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If CheckBoxDataGridView2.CurrentCell Is Nothing Then
            CheckBoxDataGridView2.Rows.Add(1)
            Exit Sub
        End If

        CheckBoxDataGridView2.Rows.Insert(CheckBoxDataGridView2.CurrentCell.RowIndex, 1)

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If CheckBoxDataGridView2.CurrentCell Is Nothing Then
            CheckBoxDataGridView2.Rows.Add(1)
            Exit Sub
        End If

        CheckBoxDataGridView2.Rows.Insert(CheckBoxDataGridView2.CurrentCell.RowIndex + 1, 1)

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        '删除
        For rowID = AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count - 1 To 0 Step -1
            If AppSettingHelper.Settings.ActiveProgram.ParagraphItems(rowID).Checked Then
                CheckBoxDataGridView2.Rows.RemoveAt(rowID)
            End If
        Next

    End Sub

    Private Sub CheckBoxDataGridView2_NewRowNeeded(sender As Object,
                                                   e As DataGridViewRowEventArgs
                                                   ) Handles CheckBoxDataGridView2.NewRowNeeded

    End Sub

    Private Sub CheckBoxDataGridView2_RowsAdded(sender As Object,
                                                e As DataGridViewRowsAddedEventArgs
                                                ) Handles CheckBoxDataGridView2.RowsAdded

        If AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Count > 0 Then

            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Insert(e.RowIndex,
                                                                      New ParagraphInfo With {
                                                                      .Timestamp = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).Timestamp
                                                                      })

        Else

            AppSettingHelper.Settings.ActiveProgram.ParagraphItems.Add(New ParagraphInfo)

        End If

    End Sub

    Private Sub CheckBoxDataGridView2_CellValidating(sender As Object,
                                                     e As DataGridViewCellValidatingEventArgs
                                                     ) Handles CheckBoxDataGridView2.CellValidating

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

        Select Case e.ColumnIndex
            Case 0
                e.Value = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).Checked
            Case 1
                e.Value = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).Timestamp.ToString("mm\:ss\.ff")
            Case 2
                e.Value = AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).value
        End Select

    End Sub

    Private Sub CheckBoxDataGridView2_CellValuePushed(sender As Object,
                                                      e As DataGridViewCellValueEventArgs
                                                      ) Handles CheckBoxDataGridView2.CellValuePushed

        Select Case e.ColumnIndex
            Case 0
                AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).Checked = e.Value
            Case 1
                Dim tmpValueStr = e.Value.ToString

                Dim mID = tmpValueStr.IndexOf(":")

                Dim mStr = tmpValueStr.Substring(0, mID)
                Dim mValue As Integer = Val(mStr)

                Dim sStr = tmpValueStr.Substring(mID + 1)
                Dim sValue As Double = CDbl(sStr)

                AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).Timestamp =
                DateTime.ParseExact($"{mValue:00}:{sValue:00.00}", "mm:ss.ff", Nothing).TimeOfDay
            Case 2
                AppSettingHelper.Settings.ActiveProgram.ParagraphItems(e.RowIndex).value = e.Value
        End Select

    End Sub

    Private Sub CheckBoxDataGridView2_RowsRemoved(sender As Object,
                                                  e As DataGridViewRowsRemovedEventArgs
                                                  ) Handles CheckBoxDataGridView2.RowsRemoved

        AppSettingHelper.Settings.ActiveProgram.ParagraphItems.RemoveAt(e.RowIndex)

    End Sub

End Class