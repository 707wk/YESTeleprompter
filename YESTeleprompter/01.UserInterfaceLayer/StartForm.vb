Public Class StartForm
    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TitleLable.Text = My.Application.Info.Title
        ProductVersionLable.Text = $"V{AppSettingHelper.GetInstance.ProductVersion}
{My.Application.Info.Copyright}"

    End Sub

End Class