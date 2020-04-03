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
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
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
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .RowTemplate.Height = 30
            .MultiSelect = True
            .ReadOnly = False
        End With

        For Each item As DataGridViewColumn In CheckBoxDataGridView2.Columns
            item.SortMode = DataGridViewColumnSortMode.NotSortable
            item.ReadOnly = True
        Next
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
                CheckBoxDataGridView2.Rows.Add({False, If(item.Timestamp = Nothing, "-", item.Timestamp.ToString("mm:ss")), item.value})
            Next

        Next
    End Sub
End Class