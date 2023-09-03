
Partial Class ChapterEntry
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If (Session.Item("UserName") Is Nothing) Or (Session.Item("UserName") = "") Then
                Response.Redirect("Login2.aspx")
            End If
            If Not IsPostBack Then
                hdnId.Value = 0
                loadData()
            End If
            If (Not IsPostBack) Then
                hdnId.Value = 0
                LoadCombo()
                loadData()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            sql = "select id,Name from Subject_Master "
            Fun.FillCombo(sql, ddlSubject)
            ddlSubject.Items.Insert(0, "---Select Subject---")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Chapter As New clsChapter_Master
            Chapter.init()
            Chapter.Id = hdnId.Value
            Chapter.Name = txtName.Text
            Chapter.Subject_Id = ddlSubject.Text
            If Not is_Valid() Then Exit Sub
            If Chapter.Save = True Then
                MesgBox("Chapter saved successfully")
                ClearAll()
            Else
                MesgBox("Error while saving record")
            End If
        Catch ex As Exception
            MesgBox("Error:" & ex.Message)
        End Try
    End Sub


    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim Chapter As New clsChapter_Master
            Chapter.Id = ID
            Chapter.GetById()
            ddlSubject.SelectedValue = Chapter.Subject_Id
            hdnId.Value = ID
            txtName.Text = Chapter.Name

        Catch ex As Exception

        End Try
    End Sub
    Private Function is_Valid() As Boolean
        Try
            Dim sql As String
            Dim con As New clsConnection
            Dim Fun As New clsFunctions
            is_Valid = True
            If hdnId.Value <> 0 Then
                sql = "select count(*) from Chapter_Master where Subject_ID=" & Fun.SQLString(ddlSubject.Text)
                sql = sql & " and Name=" & Fun.SQLString(txtName.Text)
                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Chapter_Master where Subject_ID=" & Fun.SQLString(ddlSubject.Text)
                sql = sql & " and Name=" & Fun.SQLString(txtName.Text)
            End If
            If con.GetValue(sql) >= 1 Then
                MesgBox("Chapter Already Available")
                txtName.Focus()
                is_Valid = False
            End If
        Catch ex As Exception
            is_Valid = False
        End Try
    End Function

    Private Sub ClearAll()

        ddlSubject.SelectedIndex = 0
        txtName.Text = " "
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
