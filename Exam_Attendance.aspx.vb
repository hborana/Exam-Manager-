
Partial Class Exam_Attendance
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        '   Dim Sql As String
        Dim Con As New clsConnection
        Try
            Dim ExamAttendance As New clsExam_Attendence
            Dim i As Integer

            For i = 0 To gvExamAttendance.Rows.Count - 1 ' Step +1

                ExamAttendance.init()
                'ResultEntry.Id = hdnId.Value
                'ResultEntry.Branch_ID = ddlBranch.SelectedValue
                Dim s_Id As Label
                s_Id = DirectCast(gvExamAttendance.Rows(i).FindControl("lblId"), Label)
                ExamAttendance.Student_Id = Val(s_Id.Text)

                Dim Present As CheckBox
                Present = DirectCast(gvExamAttendance.Rows(i).FindControl("chkIsPresent"), CheckBox)
                ExamAttendance.Is_Present = Present.Checked



                ExamAttendance.Id = hdnId.Value
                ExamAttendance.Branch_Id = ddlBranch.SelectedValue
                ExamAttendance.Exam_Id = ddlExam.SelectedValue
                ExamAttendance.Sem_Id = ddlSem.SelectedValue

                If ExamAttendance.Save = True Then
                    '  MsgBox("Exam Attendance saved successfully", MsgBoxStyle.Information, "ExamAttendance")
                    ClearAll()
                Else
                    MesgBox("Error while saving record")
                End If
            Next
        Catch ex As Exception
            MesgBox("Error:" & ex.Message)
        End Try
    End Sub
    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            sql = "select id,Name from Branch_Master "
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch---")
            sql = "select id,Sem from Semester_Master "
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")
            sql = "select id,Name from Exam_Master "
            Fun.FillCombo(sql, ddlExam)
            ddlExam.Items.Insert(0, "---Select Exam---")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim ExamAttendance As New clsExam_Attendence
            ExamAttendance.Id = ID
            ExamAttendance.GetById()
            hdnId.Value = ID
            ddlBranch.SelectedValue = ExamAttendance.Branch_Id
            ddlSem.SelectedValue = ExamAttendance.Sem_Id
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClearAll()

        ddlExam.SelectedIndex = 0
        ddlBranch.SelectedIndex = 0
        ddlSem.SelectedValue = 0

    End Sub


    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select i.*,s.* from Intermediate i,Student_Master s"
            sql = sql & " where i.Exam_ID= " & ddlExam.SelectedValue
            sql = sql & " and i.Branch_ID= " & ddlBranch.SelectedValue
            sql = sql & " and i.Sem_ID= " & ddlSem.SelectedValue
            sql = sql & " and s.Id = i.Student_ID"
            sql = sql & " order by i.Student_ID"
            Dt = con.GetDataTable(sql)
            gvExamAttendance.DataSource = Dt
            gvExamAttendance.DataBind()

        Catch ex As Exception

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


    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select id,Sem from Semester_Master where Branch_ID= " & ddlBranch.SelectedValue
        Fun.FillCombo(sql, ddlSem)
        
    End Sub

    Protected Sub ddlSem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSem.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select id,Name from Exam_Master where Branch_ID= " & ddlBranch.SelectedValue
        sql = sql & "and Sem_ID=" & ddlSem.SelectedValue
        Fun.FillCombo(Sql, ddlExam)
    End Sub

    Protected Sub ddlExam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExam.SelectedIndexChanged
        ShowGrid()
    End Sub

    Protected Sub chkHeader_CheckedChanged(sender As Object, e As EventArgs)
        ' Dim sql As String
        Dim Fun As New clsFunctions
        Dim chkHead As New CheckBox
        Dim chkStud As New CheckBox
        chkHead = DirectCast(sender, CheckBox)

        'MsgBox("hi")
        For i = 0 To gvExamAttendance.Rows.Count - 1
            chkStud = DirectCast(gvExamAttendance.Rows(i).FindControl("chkIsPresent"), CheckBox)
            chkStud.Checked = chkHead.Checked
        Next
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub

End Class
