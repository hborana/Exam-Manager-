
Partial Class FacultyAllocation
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If (Not IsPostBack) Then
                hdnId.Value = 0
                LoadCombo()
                ShowGrid()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            sql = "select id,Name from Exam_Master "
            Fun.FillCombo(sql, ddlExam)
            ddlExam.Items.Insert(0, "---Select Exam---")


        Catch ex As Exception

        End Try
    End Sub
    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select *,b.Name as Branch "
            sql = sql & " from Faculty_Master f,Branch_Master b"
            sql = sql & " where f.Branch_ID=b.Id"
            sql = sql & " order by Enrolment"
            Dt = con.GetDataTable(sql)
            gvFaculty.DataSource = Dt
            gvFaculty.DataBind()


            sql = " Select Id,Class_No as Class from Class_Master where Id in (select distinct(Class_Id) from student_Allocation "
            sql = sql & " Where Exam_Id=" & Fun.SQLNumber(ddlExam.SelectedValue) & " )"

            Dt = con.GetDataTable(sql)
            gvClass.DataSource = Dt
            gvClass.DataBind()

            '
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub ddlExam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExam.SelectedIndexChanged
        Try
            Dim sql As String
            Dim Con As New clsConnection
            Dim Fun As New clsFunctions
            Dim DtTmp As New DataTable
            Dim dtExam As New DataTable
            sql = "Select e.Name as Exam,format(t.Tt_Date,'dd-MM-yyyy') As tt_Date,b.Name as Branch,s.Name as Subject "
            sql = sql & " from Exam_Master e, timetable_master t, Branch_Master b, Subject_Master s "
            sql = sql & " where t.Exam_ID=e.Id "
            sql = sql & " and t.Exam_Id=" & Fun.SQLNumber(ddlExam.SelectedValue)
            sql = sql & " and b.Id=t.Branch_Id "
            sql = sql & " and  s.Id=t.Subject_Id"
            sql = sql & " Order by t.tt_date"
            lbExam.Visible = True
            DtTmp = Con.GetDataTable(sql)
            gvExam.DataSource = DtTmp
            gvExam.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClearAll()

        ddlExam.SelectedIndex = 0

    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim cntStaff As String = ""
            Dim cntClass As String = ""
            Dim total As Integer = 0
            Dim Dt As New DataTable
            Dim NoOfSeats As Long = 0
            Dim NoOfStud As Long
            Dim NoOfClass As Integer = 0
            Dim sql As String
            Dim Con As New clsConnection
            Dim Fun As New clsFunctions
            Dim strTmp1 As String = ""
            Dim strExam As String = ""
            Dim strClass As String = ""
            Dim cnt As String = ""
            Dim k As Integer
            Dim j As Integer
            Dim chk As New CheckBox
            Dim lbl As New Label
            Dim DtAllocation As New DataTable
            Dim ExamCount As Integer = 0
            Dim Exam1 As Long = 0
            Dim Exam2 As Long = 0
            Dim dtTmp2 As New DataTable
            ''code to find the no. of faculty & no. of class
            For i = 0 To gvFaculty.Rows.Count - 1
                chk = DirectCast(gvFaculty.Rows(i).FindControl("ChkFaculty"), CheckBox)
                If chk.Checked = True Then
                    lbl = DirectCast(gvFaculty.Rows(i).FindControl("lblFaculty"), Label)

                    If cntStaff = "" Then
                        cntStaff = lbl.Text
                    Else
                        cntStaff = cntStaff & "," & lbl.Text
                    End If
                    ExamCount += 1

                End If
            Next

            sql = "Select count(*) from Intermediate where Exam_Id in (" & strTmp1 & ")"
            NoOfStud = Con.GetValue(sql)

            For i = 0 To gvClass.Rows.Count - 1
                chk = DirectCast(gvClass.Rows(i).FindControl("ChkClass"), CheckBox)
                If chk.Checked = True Then
                    lbl = DirectCast(gvClass.Rows(i).FindControl("lblClassId"), Label)
                    NoOfClass = NoOfClass + 1

                    If cntClass = "" Then
                        cntClass = lbl.Text
                    Else
                        cntClass = cntClass & "," & lbl.Text
                    End If
                    ' NoOfClass = NoOfClass + 1
                End If
            Next

            total = Math.Floor(ExamCount / NoOfClass)
            '' for all classes in grid set "Total" staff for each class (Add record in database)
            '' if there are 10 staff & 3 classes then Total=3
            '' set 3 staff in each class. one by one (Total 9 records in database)
            '' Then diduct assigned staff (9) from Total Staff (10). So set all the remaining staff in one by one class and set it indatabase

            ''
            ''   cntClass = " "
            ''   cntStaff = " "
            Dim dtClass As New DataTable
            Dim dtFaculty As New DataTable
            sql = "Select * from class_Master where id in (" & cntClass & ")"
            dtClass = Con.GetDataTable(sql)
            sql = "Select * from Faculty_Master where id in(" & cntStaff & ")"
            dtFaculty = Con.GetDataTable(sql)
            k = 0
            For j = 0 To dtClass.Rows.Count - 1
                For i = 0 To total - 1

                    Dim FacultyAllocation As New clsFaculty_Allocation
                    FacultyAllocation.init()
                    FacultyAllocation.Exam_Id = ddlExam.SelectedValue
                    FacultyAllocation.Class_Id = dtClass.Rows(j).Item("ID")
                    FacultyAllocation.Faculty_Id = dtFaculty.Rows(k).Item("Id")
                    If Not IsValid() Then Exit Sub
                    If FacultyAllocation.Save = True Then
                        MesgBox("Faculty Allocation   successfully")
                    Else
                        MesgBox("Error while saving record")
                    End If
                    k = k + 1
                Next
            Next
            For i = 0 To dtClass.Rows.Count - 1
                If k >= ExamCount Then
                    Exit For
                End If
                Dim FacultyAllocation As New clsFaculty_Allocation
                FacultyAllocation.init()
                FacultyAllocation.Exam_Id = ddlExam.SelectedValue
                FacultyAllocation.Class_Id = dtClass.Rows(i).Item("ID")
                FacultyAllocation.Faculty_Id = dtFaculty.Rows(k).Item("Id")
                If Not IsValid() Then Exit Sub
                If FacultyAllocation.Save = True Then
                    MesgBox("Faculty Allocation   successfully")
                Else
                    MesgBox("Error while saving record")
                End If
                k = k + 1
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
