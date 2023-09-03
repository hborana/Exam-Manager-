
Partial Class PrintExamAttendance
    Inherits System.Web.UI.Page
    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            sql = "select id,Class_No from Class_Master "
            Fun.FillCombo(sql, ddlClass)
            ddlClass.Items.Insert(0, "---Select Class---")
            sql = "select id,Name from Exam_Master "
            Fun.FillCombo(sql, ddlExam)
            ddlExam.Items.Insert(0, "---Select Exam---")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If (Session.Item("UserName") Is Nothing) Or (Session.Item("UserName") = "") Then
                Response.Redirect("Login2.aspx")
            End If
            If (Not IsPostBack) Then
                hdnId.Value = 0
                LoadCombo()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        Dim x As Integer

        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            Dim m_Id As Long
            Dim i As Long
            sql = "Select sa.*,s.*,b.Name as Branch"
            sql = sql & " from Student_Allocation sa,student_Master s,branch_Master b"
            sql = sql & " Where sa.Class_ID=" & Fun.SQLNumber(ddlClass.SelectedValue)
            sql = sql & " and sa.Exam_ID=" & Fun.SQLNumber(ddlExam.SelectedValue)
            sql = sql & " and sa.Student_ID=s.Id"
            sql = sql & " and s.Branch_ID=b.Id"
            sql = sql & " order by sa.Seat_No,s.Enrolment"
            Dt = con.GetDataTable(sql)
            sql = "Delete from rptExamAttendance"
            con.ExecQuery(sql)
            For i = 0 To Dt.Rows.Count - 2
                x = Dt.Rows(0).Item("Id")
                If Dt.Rows(i).Item("Seat_No") = Dt.Rows(i + 1).Item("Seat_No") Then
                    If m_Id = 0 Then
                        sql = "insert into rptExamAttendance ("
                        sql = sql & "Student1, "
                        sql = sql & "Seat_No1, "
                        sql = sql & "Student2, "
                        sql = sql & "Seat_No2,"
                        sql = sql & "Branch1,"
                        sql = sql & "Branch2"
                        sql = sql & ") Values ("
                        sql = sql & Fun.SQLString(Dt.Rows(i).Item("Enrolment")) & ","
                        sql = sql & Fun.SQLString(Dt.Rows(i).Item("Seat_No")) & ","
                        sql = sql & Fun.SQLString(Dt.Rows(i + 1).Item("Enrolment")) & ","
                        sql = sql & Fun.SQLString(Dt.Rows(i + 1).Item("Seat_No")) & ","
                        sql = sql & Fun.SQLString(Dt.Rows(i).Item("Branch")) & ","
                        sql = sql & Fun.SQLString(Dt.Rows(i + 1).Item("Branch")) & ")"
                        If (con.ExecQuery(sql) >= 1) Then
                            'Save = True
                            'sql = "select max(id) from branch_Master"
                            ' m_Id = con.ExecQuery(sql)
                        Else
                            'm_strErr = sql
                            'Save = False
                        End If
                    End If
                End If
            Next
            'sql = "SElect * from "
            Response.Redirect("~/ReportsPrint/rpExamAttendance.aspx?sid=" & x)
        Catch ex As Exception

        End Try

    End Sub
End Class
