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
            .MultiSelect = False
        End With

        With CheckBoxDataGridView2
            .BackgroundColor = Color.FromArgb(71, 71, 71)
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersVisible = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
            .DefaultCellStyle.BackColor = Color.FromArgb(71, 71, 71)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(56, 56, 60)
            .EditMode = DataGridViewEditMode.EditOnEnter
            .GridColor = Color.FromArgb(45, 45, 48)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
            .RowTemplate.Height = 30
            .MultiSelect = True
            .ReadOnly = False
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
                   .Filter = "素材文件|*.txt;*.lrc;*.docx",
                   .Multiselect = True
               }
        If tmpDialog.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        For Each filePath In tmpDialog.FileNames

            CheckBoxDataGridView2.Rows.Clear()

            Dim tmpFileBaseInfo As FileBaseInfo
            Try
                tmpFileBaseInfo = FileTypeFactory.Create(filePath)
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, ButtonItem1.Text)
                Exit Sub
            End Try

            CheckBoxDataGridView1.Rows.Add({False, IO.Path.GetFileNameWithoutExtension(filePath)})

            For Each item In tmpFileBaseInfo.ParagraphItems
                'CheckBoxDataGridView2.Rows.Add({False, If(item.Timestamp = Nothing, "00:00.00", item.Timestamp.ToString), item.value})
                Dim addID = CheckBoxDataGridView2.Rows.Add({False, item.Timestamp.ToString("mm\:ss\.ff"), item.value})
                CheckBoxDataGridView2.Rows(addID).Cells(1).Tag = CheckBoxDataGridView2.Rows(addID).Cells(1).Value
            Next

        Next
    End Sub

    Private Sub CheckBoxDataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles CheckBoxDataGridView2.CellValueChanged
        If e.ColumnIndex <> 1 OrElse
            e.RowIndex < 0 Then
            Exit Sub
        End If

        Dim tmpCell = CheckBoxDataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex)

        Try
            If String.IsNullOrWhiteSpace(tmpCell.Value) Then
                Throw New Exception("时间戳不能为空")
            End If

            Dim tmpValueStr = tmpCell.Value.ToString

            Dim mID = tmpValueStr.IndexOf(":")
            If mID = -1 Then
                Throw New Exception("时间格式错误")
            End If

            Dim mStr = tmpValueStr.Substring(0, mID)
            Dim mValue As Integer = Val(mStr)

            Dim sStr = tmpValueStr.Substring(mID + 1)
            Dim sValue As Double = CDbl(sStr)

            Dim tmpTimeSpan = DateTime.ParseExact($"{mValue:00}:{sValue:00.00}", "mm:ss.ff", Nothing).TimeOfDay
            tmpCell.Value = tmpTimeSpan.ToString("mm\:ss\.ff")
            tmpCell.Tag = tmpCell.Value

        Catch ex As Exception
            tmpCell.Value = $"{tmpCell.Tag}"
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If CheckBoxDataGridView2.CurrentCell Is Nothing Then
            Exit Sub
        End If

        CheckBoxDataGridView2.Rows.Insert(CheckBoxDataGridView2.CurrentCell.RowIndex, {False, CheckBoxDataGridView2.Rows(CheckBoxDataGridView2.CurrentCell.RowIndex).Cells(1).Value, ""})

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub
End Class