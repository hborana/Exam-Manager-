
Partial Class ResultSummary
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If (Session.Item("UserName") Is Nothing) Or (Session.Item("UserName") = "") Then
                Response.Redirect("Login2.aspx")
            End If
            If Not IsPostBack Then
                hdnId.Value = 0
            End If
            If (Not IsPostBack) Then
                hdnId.Value = 0
                LoadCombo()
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
        Catch ex As Exception

        End Try
    End Sub
    
    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlCourse.SelectedIndex = 0
        ddlSem.SelectedIndex = 0
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
    End Sub




    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "select r.Marks, s.Name,s.Id,s.Enrolment ,e.Name as Exam "
            sql = sql & " from Student_Master s,Exam_Master e, Result_Master r "
            sql = sql & " Where s.Id=r.Student_Id "
            sql = sql & " And r.Exam_Id=e.Id "
            sql = sql & "And s.Enrolment=" & txtEnrol.Text

            'sql = "Select i.*,s.* from Intermediate i,Student_Master s"
            'sql = sql & " where i.Exam_ID= " & ddlExam.SelectedValue
            'sql = sql & " and i.Course_ID=" & ddlCourse.SelectedValue
            'sql = sql & " and i.Branch_ID= " & ddlBranch.SelectedValue
            'sql = sql & " and i.Sem_ID=" & ddlSem.SelectedValue
            'sql = sql & " and s.Id=i.Student_ID"
            'sql = sql & " order by i.Student_ID"
            Dt = con.GetDataTable(sql)
            gvResultEntry.DataSource = Dt
            gvResultEntry.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVeiw_Click(sender As Object, e As EventArgs) Handles btnVeiw.Click
        ShowGrid()
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
