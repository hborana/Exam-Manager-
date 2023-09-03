
Partial Class ResultEntry
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '        Dim Sql As String
        Dim Con As New clsConnection
        Try
            Dim ResultEntry As New clsResult_Master

            'Dim Sql As String
            'Dim Con As New clsConnection
            Dim i As Integer

            For i = 0 To gvResultEntry.Rows.Count - 1 ' Step +1

                ResultEntry.init()
                'ResultEntry.Id = hdnId.Value
                'ResultEntry.Branch_ID = ddlBranch.SelectedValue
                ResultEntry.Exam_Id = ddlExam.SelectedValue
                ResultEntry.Sem_Id = ddlSem.SelectedValue
                'ResultEntry.Course_ID = ddlCourse.SelectedValue
                ResultEntry.Subject_Id = ddlSubject.SelectedValue

                Dim s_Id As Label
                s_Id = DirectCast(gvResultEntry.Rows(i).FindControl("lblId"), Label)
                ResultEntry.Student_Id = Val(s_Id.Text)

                Dim Marks As TextBox
                Marks = DirectCast(gvResultEntry.Rows(i).FindControl("txtMarks"), TextBox)
                ResultEntry.Marks = Marks.Text
                If ResultEntry.Save = True Then
                    MesgBox("Result saved successfully")

                Else
                    MesgBox("Error while saving record")
                End If
            Next
            ClearAll()
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
            sql = "select id,Sem from Semester_Master "
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")
            sql = "select id,Name from Exam_Master "
            Fun.FillCombo(sql, ddlExam)
            ddlExam.Items.Insert(0, "---Select Exam---")
            sql = "select id,Name from Subject_Master "
            Fun.FillCombo(sql, ddlSubject)
            ddlSubject.Items.Insert(0, "---Select Subject---")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim ResultEntry As New clsResult_Master
            ResultEntry.Id = ID
            ResultEntry.GetById()
            hdnId.Value = ID
            ddlBranch.SelectedValue = ResultEntry.Branch_ID
            'ddlCourse.SelectedValue = ResultEntry.Course_ID
            ddlExam.SelectedValue = ResultEntry.Exam_Id
            ddlSem.SelectedValue = ResultEntry.Sem_Id
            ddlSubject.SelectedValue = ResultEntry.Subject_Id
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlCourse.SelectedIndex = 0
        ddlSem.SelectedIndex = 0
        ddlExam.SelectedIndex = 0
        ddlSubject.SelectedIndex = 0
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
        sql = "select Id,Name from Exam_Master where Branch_ID=" & ddlBranch.SelectedValue & " "
        Fun.FillCombo(sql, ddlExam)

    End Sub

    Protected Sub ddlSem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSem.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Subject from Subject_Master where Branch_ID=" & ddlBranch.SelectedValue & ""
        sql = "and Sem_ID= " & ddlSem.SelectedValue & " "
        Fun.FillCombo(sql, ddlSubject)
    End Sub

    Protected Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        ShowGrid()
    End Sub
    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select i.*,s.*,'' as Marks from Intermediate i,Student_Master s, Exam_Attendence t"
            sql = sql & " where i.Exam_ID= " & ddlExam.SelectedValue
            sql = sql & " and i.Course_ID=" & ddlCourse.SelectedValue
            sql = sql & " and i.Branch_ID= " & ddlBranch.SelectedValue
            sql = sql & " and i.Sem_ID=" & ddlSem.SelectedValue
            sql = sql & " and s.Id=i.Student_ID"
            sql = sql & " and s.Id=t.Student_ID"
            sql = sql & " and t.isPresent=1 "
            sql = sql & " Union "
            sql = sql & " Select i.*,s.*,'AB' as Marks from Intermediate i,Student_Master s, Exam_Attendence t"
            sql = sql & " where i.Exam_ID= " & ddlExam.SelectedValue
            sql = sql & " and i.Course_ID=" & ddlCourse.SelectedValue
            sql = sql & " and i.Branch_ID= " & ddlBranch.SelectedValue
            sql = sql & " and i.Sem_ID=" & ddlSem.SelectedValue
            sql = sql & " and s.Id=i.Student_ID"
            sql = sql & " and s.Id=t.Student_ID"
            sql = sql & " and t.isPresent=0 "

            sql = sql & " order by i.Student_ID"
            Dt = con.GetDataTable(sql)
            gvResultEntry.DataSource = Dt
            gvResultEntry.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtMarks_TextChanged(sender As Object, e As EventArgs)

        Dim sql As String
        Dim Fun As New clsFunctions
        Dim Con As New clsConnection
        Dim Pass As Integer = 0
        sql = "select q.Passing_Marks,t.Exam_ID from Questionpaper_Master q,Timetable_Master t"
        sql = sql & " where t.Exam_ID=2" '& ddlExam.SelectedValue
        sql = sql & " and q.Branch_ID=20" ' & ddlBranch.SelectedValue
        sql = sql & " and q.Sem_ID=17" '& ddlSem.SelectedValue
        sql = sql & " and q.Subject_ID=25" ' & ddlSubject.SelectedValue
        sql = sql & " and q.Timetable_ID=t.Id"
        Pass = Con.GetValue(sql)
        Dim txt As New TextBox
        txt = DirectCast(sender, TextBox)
        If txt.Text <= Pass Then
            txt.ForeColor = Drawing.Color.Red
        Else
            txt.ForeColor = Drawing.Color.Green
        End If

    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
    Private Sub ExamAttendance()
        Dim sql As String
        Dim Fun As New clsFunctions
        Dim Con As New clsConnection
        sql = "select isPresent from Exam_Attendance"
        sql = sql & " where i.Exam_ID= " & ddlExam.SelectedValue
        sql = sql & " and i.Course_ID=" & ddlCourse.SelectedValue
        sql = sql & " and i.Branch_ID= " & ddlBranch.SelectedValue
        sql = sql & " and i.Sem_ID=" & ddlSem.SelectedValue
        sql = sql & " and s.Id=i.Student_ID"
        sql = sql & " order by i.Student_ID"
    End Sub
End Class
