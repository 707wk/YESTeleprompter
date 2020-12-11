Public Class HotKeysSettingForm

    Public UIForm As MainForm

    Private Sub HotKeysSettingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With PlayComboBox
            .DropDownStyle = ComboBoxStyle.DropDownList
            For i001 = 1 To 11
                .Items.Add($"F{i001}")
            Next

            .Text = AppSettingHelper.GetInstance.HotKeyForPlay.ToString
        End With

        With PauseComboBox
            .DropDownStyle = ComboBoxStyle.DropDownList
            For i001 = 1 To 11
                .Items.Add($"F{i001}")
            Next

            .Text = AppSettingHelper.GetInstance.HotKeyForPause.ToString
        End With

        With StopComboBox
            .DropDownStyle = ComboBoxStyle.DropDownList
            For i001 = 1 To 11
                .Items.Add($"F{i001}")
            Next

            .Text = AppSettingHelper.GetInstance.HotKeyForStop.ToString
        End With

        With HideComboBox
            .DropDownStyle = ComboBoxStyle.DropDownList
            For i001 = 1 To 11
                .Items.Add($"F{i001}")
            Next

            .Text = AppSettingHelper.GetInstance.HotKeyForHideWindow.ToString
        End With

        AddOrSaveButton.Enabled = False

    End Sub

    Private Sub PlayComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PlayComboBox.SelectedIndexChanged
        CheckHotKeyDuplicateValue()

    End Sub

    Private Sub PauseComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PauseComboBox.SelectedIndexChanged
        CheckHotKeyDuplicateValue()
    End Sub

    Private Sub StopComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StopComboBox.SelectedIndexChanged
        CheckHotKeyDuplicateValue()

    End Sub

    Private Sub HideComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HideComboBox.SelectedIndexChanged
        CheckHotKeyDuplicateValue()

    End Sub

    Public Sub CheckHotKeyDuplicateValue()
        Dim comboBoxArray() = {PlayComboBox, PauseComboBox, StopComboBox, HideComboBox}
        Dim labelArray() = {PlayLabel, PauseLabel, StopLabel, HideLabel}

        For i001 = 0 To comboBoxArray.Count - 1
            labelArray(i001).Image = My.Resources.yes_16px
        Next

        Dim errorCount = 0

        For i001 = 0 To comboBoxArray.Count - 1
            For j001 = i001 + 1 To comboBoxArray.Count - 1

                If comboBoxArray(i001).Text = comboBoxArray(j001).Text Then
                    labelArray(i001).Image = My.Resources.no_16px
                    labelArray(j001).Image = My.Resources.no_16px

                    errorCount += 1
                End If

            Next
        Next

        AddOrSaveButton.Enabled = (errorCount = 0)

    End Sub

    Private Sub AddOrSaveButton_Click(sender As Object, e As EventArgs) Handles AddOrSaveButton.Click

        UIForm.UnregisterHotKey()

        AppSettingHelper.GetInstance.HotKeyForPlay = Keys.F1 + PlayComboBox.SelectedIndex
        AppSettingHelper.GetInstance.HotKeyForPause = Keys.F1 + PauseComboBox.SelectedIndex
        AppSettingHelper.GetInstance.HotKeyForStop = Keys.F1 + StopComboBox.SelectedIndex
        AppSettingHelper.GetInstance.HotKeyForHideWindow = Keys.F1 + HideComboBox.SelectedIndex

        UIForm.RegisterHotKey()

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

End Class