
Partial Class Q1
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim str As String = CKEditor1.Text
        Dim str1 As String = Server.HtmlEncode(str)
        ' lblpre.Text = str1
    End Sub
End Class
