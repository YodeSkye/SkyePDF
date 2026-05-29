
Public Class About

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "About " + My.Application.Info.ProductName
        LblAbout.Text = My.Application.Info.Description
        LblVersion.Text = "v" + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString + "." + My.Application.Info.Version.Build.ToString
    End Sub

End Class
