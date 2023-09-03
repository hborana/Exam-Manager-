
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Response.Redirect("Dashboard.aspx")
    End Sub
End Class
