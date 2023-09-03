
Partial Class FacultyEntry
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Faculty As New clsFaculty_Master
            Faculty.init()
            Faculty.Id = hdnId.Value
            Faculty.Name = txtName.Text
            Faculty.Branch_Id = ddlBranch.SelectedValue
            Faculty.Contact_No = txtContact_No.Text
            Faculty.Designation = ddlDesignation.Text
            Faculty.EMail = txtEMail.Text
            Faculty.Enrolment = txtEnrl.Text
            If Faculty.Save = True Then
                MesgBox("Faculty saved successfully")
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
            sql = "select id,Name from Course_Master "
            Fun.FillCombo(sql, ddlCourse)
            ddlCourse.Items.Insert(0, "---Select Course---")
            sql = "select id,Name from Branch_Master "
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch---")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim Faculty As New clsFaculty_Master
            Faculty.Id = ID
            Faculty.GetById()
            ddlBranch.SelectedValue = Faculty.Branch_Id
            'ddlCourse.SelectedValue = Faculty.course_Id
            hdnId.Value = ID
            txtName.Text = Faculty.Name
            txtEnrl.Text = Faculty.Enrolment
            ddlDesignation.SelectedValue = Faculty.Designation
            txtContact_No.Text = Faculty.Contact_No
            txtEMail.Text = Faculty.EMail

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlCourse.SelectedIndex = 0
        txtName.Text = ""
        txtEnrl.Text = ""
        ddlDesignation.SelectedIndex = ""
        txtContact_No.Text = " "
        txtEMail.Text = " "

    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCourse.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Name from Branch_Master where Course_ID=" & ddlCourse.SelectedValue & " "
        Fun.FillCombo(sql, ddlBranch)

    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class

