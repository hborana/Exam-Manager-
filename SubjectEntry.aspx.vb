
Partial Class SubjectEntry
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
            sql = "select id,Name from Branch_Master"
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch---")
            sql = "select id,Sem from Semester_Master"
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim Subject As New clsSubject_Master
            Subject.Id = ID
            Subject.GetById()
            ddlBranch.SelectedValue = Subject.Branch_Id
            hdnId.Value = ID
            ddlSem.SelectedValue = Subject.Sem
            txtName.Text = Subject.Name
            txtCode.Text = Subject.Code

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Subject As New clsSubject_Master
            Subject.init()
            Subject.Id = hdnId.Value
            Subject.Name = txtName.Text
            Subject.Branch_Id = ddlBranch.SelectedValue
            Subject.Code = txtCode.Text
            Subject.Sem = ddlSem.SelectedValue
            If Not is_Valid() Then Exit Sub
            If Subject.Save = True Then
                MesgBox("Subject saved successfully")
                ClearAll()
            Else
                MesgBox("Error while saving record")
            End If
        Catch ex As Exception
            MesgBox("Error:" & ex.Message)
        End Try
    End Sub
    Private Function is_Valid() As Boolean
        Try
            Dim sql As String
            Dim con As New clsConnection
            Dim Fun As New clsFunctions
            is_Valid = True
            If hdnId.Value <> 0 Then
                sql = "select count(*) from Subject_Master where Name=" & Fun.SQLString(txtName.Text)
                sql = sql & " and Branch_ID=" & Fun.SQLString(ddlBranch.Text)
                sql = sql & " and Code=" & Fun.SQLString(txtCode.Text)
                sql = sql & " and Sem_ID=" & Fun.SQLString(ddlSem.Text)
                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Subject_Master where Name=" & Fun.SQLString(txtName.Text)
                sql = sql & " and Branch_ID=" & Fun.SQLString(ddlBranch.Text)
                sql = sql & " and Code=" & Fun.SQLString(txtCode.Text)
                sql = sql & " and Sem=" & Fun.SQLString(ddlSem.Text)
            End If
            If con.GetValue(sql) >= 1 Then
                MesgBox("Student already Exist")
                txtName.Focus()
                is_Valid = False
            End If

        Catch ex As Exception
            is_Valid = False
        End Try
    End Function
    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlSem.SelectedIndex = 0
        txtName.Text = " "
        txtCode.Text = " "

    End Sub

    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Sem from Semester_Master where Branch_ID=" & ddlBranch.SelectedValue & " "
        Fun.FillCombo(sql, ddlSem)
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
