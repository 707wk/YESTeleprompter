Public Class TextEffectsForm
    Private Sub FontButton_Click(sender As Object, e As EventArgs) Handles FontButton.Click
        Using tmpDialog As New FontDialog With {
            .ShowEffects = False,
            .ShowColor = False
        }

            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            TextBox1.Text = $"{tmpDialog.Font.Name}, {tmpDialog.Font.Size}, {tmpDialog.Font.Style}"

        End Using
    End Sub

    Private Sub FontColorButton_Click(sender As Object, e As EventArgs) Handles FontColorButton.Click
        Using tmpDialog As New ColorDialog
            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            FontColorButton.BackColor = tmpDialog.Color

        End Using
    End Sub

    Private Sub BackgroundColorButton_Click(sender As Object, e As EventArgs) Handles BackgroundColorButton.Click
        Using tmpDialog As New ColorDialog
            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            BackgroundColorButton.BackColor = tmpDialog.Color

        End Using
    End Sub

End Class