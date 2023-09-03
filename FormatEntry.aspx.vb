
Partial Class FormatEntry
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Format As New clsPaperFormat
            Format.init()
            Format.Id = hdnId.Value
            Format.Name = txtName.Text
            Format.Total_Marks = txtMarks.Text
            If Not is_Valid() Then Exit Sub
            If Format.Save = True Then
                MesgBox("Format saved successfully")
                ClearAll()
            Else
                MesgBox("Error while saving record")
            End If
        Catch ex As Exception
            MesgBox("Error:" & ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If (Session.Item("UserName") Is Nothing) Or (Session.Item("UserName") = "") Then
                Response.Redirect("Login2.aspx")
            End If
            If Not IsPostBack Then
                hdnId.Value = 0
                loadData()
            End If
            If Not (IsPostBack) Then

                hdnId.Value = 0
                loadData()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim Format As New clsPaperFormat
            Format.Id = ID
            Format.GetById()
            hdnId.Value = ID
            txtName.Text = Format.Name
            txtMarks.Text = Format.total_Marks

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
                sql = "select count(*) from Format_Master where Name=" & Fun.SQLString(txtName.Text)
                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Format_Master where Name=" & Fun.SQLString(txtName.Text)
            End If
            If con.GetValue(sql) >= 1 Then
                MesgBox("Format already available")
                txtName.Focus()
                is_Valid = False
            End If

        Catch ex As Exception
            is_Valid = False
        End Try
    End Function
    Private Sub ClearAll()

        txtName.Text = " "
        txtMarks.Text = " "

    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
