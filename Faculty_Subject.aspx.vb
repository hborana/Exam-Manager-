
Partial Class Faculty_Subject
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim FacSub As New clsFaculty_Subject
            FacSub.init()
            FacSub.Id = hdnId.Value
            ' FacSub.Branch_Id = ddlBranch.SelectedValue
            'FacSub.Course_ID = ddlCourse.SelectedValue
            'FacSub.Sem = ddlSem.SelectedValue
            FacSub.Subject_ID = ddlSubject.SelectedValue
            FacSub.Faculty_ID = ddlFaculty.SelectedValue

            If FacSub.Save = True Then
                MesgBox("Relation saved successfully")
                '' MsgBox("Relation saved successfully", MsgBoxStyle.Information, "Faculty_Subject")
                ClearAll()
            Else
                MesgBox("Error while saving record")
                ''  MsgBox("Error while saving record", MsgBoxStyle.Critical, "Faculty_Subject")
            End If
        Catch ex As Exception
            MesgBox("Error")
            '' MsgBox("Error:" & ex.Message, MsgBoxStyle.Critical, "Faculty_Subject")
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
            sql = "select id,Sem from Semester_Master "
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")
            sql = "select id,Name from Subject_Master "
            Fun.FillCombo(sql, ddlSubject)
            ddlSubject.Items.Insert(0, "---Select Subject---")
            sql = "select id,Name from Faculty_Master "
            Fun.FillCombo(sql, ddlFaculty)
            ddlFaculty.Items.Insert(0, "---Select Faculty---")
        Catch ex As Exception

        End Try

    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim FacuSub As New clsFaculty_Subject
            FacuSub.Id = ID
            FacuSub.GetById()
            'ddlBranch.SelectedValue = FacuSub.Branch_Id
            'ddlCourse.SelectedValue = Faculty.course_Id
            'ddlSem.SelectedValue = FacuSub.Sem_Id
            ddlSubject.SelectedValue = FacuSub.Subject_ID
            ddlFaculty.SelectedValue = FacuSub.Faculty_ID
            hdnId.Value = ID
           

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlCourse.SelectedIndex = 0
        ddlSem.SelectedIndex = 0
        ddlSubject.SelectedIndex = 0
        ddlFaculty.SelectedIndex = 0


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
        sql = "select Id,Sem from Semester_Master where Branch_ID=" & ddlBranch.SelectedValue & " "
        Fun.FillCombo(sql, ddlSem)
        sql = "select Id,Name from Faculty_Master where Branch_ID=" & ddlBranch.SelectedValue & ""
        Fun.FillCombo(sql, ddlFaculty)
    End Sub

    Protected Sub ddlSem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSem.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Name from Subject_Master where Branch_ID=" & ddlBranch.SelectedValue
        sql = sql & " And Sem_ID=" & ddlSem.SelectedValue & ""
        Fun.FillCombo(sql, ddlSubject)

    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class

