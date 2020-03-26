Imports System.ComponentModel
Imports System.IO
Imports NPOI.XWPF.Usermodel

Public Class MainForm
    Private ChildPlayWindow As New PlayForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = $"{My.Application.Info.Title} V{AppSettingHelper.ProductVersion}"

        If AppSettingHelper.Settings.WindowSize.Width <> 0 AndAlso
            AppSettingHelper.Settings.WindowSize.Height <> 0 Then

            'Me.Size = AppSettingHelper.Settings.WindowSize
            Me.Location = AppSettingHelper.Settings.WindowLocation
        End If

        CheckBoxDataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
        CheckBoxDataGridView1.RowHeadersVisible = False
        CheckBoxDataGridView1.AllowUserToResizeRows = False
        CheckBoxDataGridView1.AllowUserToOrderColumns = False
        CheckBoxDataGridView1.AllowUserToResizeColumns = False
        CheckBoxDataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(56, 56, 60)
        CheckBoxDataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
        CheckBoxDataGridView1.GridColor = Color.FromArgb(45, 45, 48)
        CheckBoxDataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        CheckBoxDataGridView1.RowTemplate.Height = 30

        For Each item As DataGridViewColumn In CheckBoxDataGridView1.Columns
            item.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        'For i001 = 0 To 500 - 1
        '    CheckBoxDataGridView1.Rows.Add({False, $"段落内容{i001}"})
        'Next

        ChildPlayWindow.Show()

    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        AppSettingHelper.Settings.WindowSize = Me.Size
        AppSettingHelper.Settings.WindowLocation = Me.Location
        AppSettingHelper.SaveToLocaltion()
    End Sub

    Private Sub ImportTextButton_Click(sender As Object, e As EventArgs) Handles ImportTextButton.Click
        Dim tmpDialog As New OpenFileDialog With {
            .Filter = "素材文件|*.txt;*.lrc;*.docx",
            .Multiselect = False
        }
        If tmpDialog.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        CheckBoxDataGridView1.Rows.Clear()

        Select Case IO.Path.GetExtension(tmpDialog.FileName).ToLower
            Case ".txt"
                Dim tmpDetectionResult = UtfUnknown.CharsetDetector.DetectFromFile(tmpDialog.FileName)
                If tmpDetectionResult.Detected.Encoding Is Nothing Then
                    MsgBox("不支持的文本编码", MsgBoxStyle.Information, ImportTextButton.Text)
                    Exit Sub
                End If

                Using reader As New IO.StreamReader(tmpDialog.FileName, tmpDetectionResult.Detected.Encoding)
                    Do

                        Dim tmpStr = reader.ReadLine()
                        If tmpStr Is Nothing Then
                            Exit Do
                        End If

                        CheckBoxDataGridView1.Rows.Add({False, "-", tmpStr})

                    Loop
                End Using

            Case ".lrc"
                Dim tmpDetectionResult = UtfUnknown.CharsetDetector.DetectFromFile(tmpDialog.FileName)
                If tmpDetectionResult.Detected.Encoding Is Nothing Then
                    MsgBox("不支持的文本编码", MsgBoxStyle.Information, ImportTextButton.Text)
                    Exit Sub
                End If

                Using reader As New IO.StreamReader(tmpDialog.FileName, tmpDetectionResult.Detected.Encoding)
                    Do

                        Dim tmpStrArray = reader.ReadLine()?.Split("]")
                        If tmpStrArray Is Nothing Then
                            Exit Do
                        End If

                        Dim timeStr = tmpStrArray(0).Substring(1, 5)

                        Try
                            DateTime.Parse(timeStr)
                        Catch ex As Exception
                            Continue Do
                        End Try

                        CheckBoxDataGridView1.Rows.Add({False, timeStr, tmpStrArray(1)})

                    Loop
                End Using

            Case ".docx"
                Using tmpFS = File.OpenRead(tmpDialog.FileName)
                    Dim docx As XWPFDocument = New XWPFDocument(tmpFS)
                    For Each paragraph In docx.Paragraphs
                        CheckBoxDataGridView1.Rows.Add({False, "-", paragraph.ParagraphText})
                    Next
                    docx.Close()
                End Using

        End Select

    End Sub

    Private Sub TextEffectsButton_Click(sender As Object, e As EventArgs) Handles TextEffectsButton.Click
        Using tmpDialog As New TextEffectsForm
            tmpDialog.ShowDialog()
        End Using
    End Sub

    Private Sub WindowButton_Click(sender As Object, e As EventArgs) Handles WindowButton.Click
        Using tmpDialog As New WindowForm
            tmpDialog.ShowDialog()
        End Using
    End Sub

    Private Sub HotKeysButton_Click(sender As Object, e As EventArgs) Handles HotKeysButton.Click
        Using tmpDialog As New HotKeysForm
            tmpDialog.ShowDialog()
        End Using
    End Sub
End Class