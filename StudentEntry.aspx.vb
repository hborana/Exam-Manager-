
Partial Class StudentEntry
    Inherits System.Web.UI.Page
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Student As New clsStudent_Master
            Student.init()
            Student.Name = txtName.Text
            Student.Id = hdnId.Value
            Student.Branch_Id = ddlBranch.SelectedValue
            Student.Contact_No = txtContact_No.Text
            Student.EMail = txtEMail.Text
            Student.Enrolment = txtEnroll.Text
            Student.Sem = ddlSem.Text
            If Student.Save = True Then
                MesgBox("Student saved successfully")
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
            sql = "select id,Name from Course_Master"
            Fun.FillCombo(sql, ddlCourse)
            ddlCourse.Items.Insert(0, "---Select Course---")
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
            Dim Student As New clsStudent_Master
            Student.Id = ID
            Student.GetById()
            ddlBranch.SelectedValue = Student.Branch_Id
            hdnId.Value = ID
            ddlSem.Text = Student.Sem
            txtName.Text = Student.Name
            txtEnroll.Text = Student.Enrolment
            txtContact_No.Text = Student.Contact_No
            txtEMail.Text = Student.EMail

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlSem.SelectedIndex = 0
        txtName.Text = " "
        txtEnroll.Text = " "
        txtEMail.Text = " "
        txtContact_No.Text = " "

    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCourse.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Name from Branch_Master where Course_ID=" & ddlCourse.SelectedValue & " "
        Fun.FillCombo(sql, ddlBranch)

    End Sub

    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Sem from Semester_Master where Branch_ID =" & ddlBranch.SelectedValue & " "
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



