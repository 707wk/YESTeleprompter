Public Class HotKeysSettingForm

    Public UIForm As MainForm

    Private Sub HotKeysSettingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ComboBox1
            .DropDownStyle = ComboBoxStyle.DropDownList
            For i001 = 1 To 11
                .Items.Add($"F{i001}")
            Next

            .Text = AppSettingHelper.Settings.HotKeyForPlay.ToString
        End With

        With ComboBox2
            .DropDownStyle = ComboBoxStyle.DropDownList
            For i001 = 1 To 11
                .Items.Add($"F{i001}")
            Next

            .Text = AppSettingHelper.Settings.HotKeyForStop.ToString
        End With

        With ComboBox3
            .DropDownStyle = ComboBoxStyle.DropDownList
            For i001 = 1 To 11
                .Items.Add($"F{i001}")
            Next

            .Text = AppSettingHelper.Settings.HotKeyForHideWindow.ToString
        End With

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        CheckHotKeyDuplicateValue()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        CheckHotKeyDuplicateValue()

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        CheckHotKeyDuplicateValue()

    End Sub

    Public Sub CheckHotKeyDuplicateValue()
        Label2.Image = If(ComboBox1.Text <> ComboBox2.Text AndAlso ComboBox1.Text <> ComboBox3.Text, My.Resources.yes_16px, My.Resources.no_16px)
        Label5.Image = If(ComboBox1.Text <> ComboBox2.Text AndAlso ComboBox2.Text <> ComboBox3.Text, My.Resources.yes_16px, My.Resources.no_16px)
        Label6.Image = If(ComboBox1.Text <> ComboBox3.Text AndAlso ComboBox2.Text <> ComboBox3.Text, My.Resources.yes_16px, My.Resources.no_16px)

    End Sub

    Private Sub AddOrSaveButton_Click(sender As Object, e As EventArgs) Handles AddOrSaveButton.Click
        If ComboBox1.Text = ComboBox2.Text OrElse
            ComboBox1.Text = ComboBox3.Text OrElse
            ComboBox2.Text = ComboBox3.Text Then

            MsgBox("快捷键重复", MsgBoxStyle.Information, AddOrSaveButton.Text)
            Exit Sub
        End If

        UIForm.UnregisterHotKey()

        AppSettingHelper.Settings.HotKeyForPlay = Keys.F1 + ComboBox1.SelectedIndex
        AppSettingHelper.Settings.HotKeyForStop = Keys.F1 + ComboBox2.SelectedIndex
        AppSettingHelper.Settings.HotKeyForHideWindow = Keys.F1 + ComboBox3.SelectedIndex

        UIForm.RegisterHotKey()

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub
End Class