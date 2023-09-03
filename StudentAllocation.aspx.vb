
Partial Class StudentAllocation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            
                If (Not IsPostBack) Then
                    hdnId.Value = 0
                    LoadCombo()
                    HideNoti()

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
            ddlExam.Items.Insert(0, "---Select  Exam---")
            sql = "select b.id,b.Name + ' - ' + c.Name as Branch  from Branch_Master b, Course_Master c where b.Course_Id=c.Id "
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch-Course---")


        Catch ex As Exception

        End Try
    End Sub


    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select *,Number_Of_Benches* Student_Per_Benches as Stud_Cnt "
            sql = sql & " from Class_Master "
            sql = sql & " order by class_No"
            Dt = con.GetDataTable(sql)
            gvClass.DataSource = Dt
            gvClass.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    'Private Function isValid() As Boolean
    '    Try
    '        Dim sql As String
    '        Dim con As New clsConnection
    '        Dim Fun As New clsFunctions
    '        isValid = True
    '        If hdnId.Value <> 0 Then
    '            sql = "select count(*) from Branch_Master where Name=" & Fun.SQLString(ddlBranch.Text)

    '        Else
    '            sql = "select count(*) from Exam_Master where Name=" & Fun.SQLString(ddlBranch.Text)
    '        End If
    '        If con.GetValue(sql) >= 1 Then
    '            MsgBox("Exam already available", MsgBoxStyle.Critical, "Exam")
    '            ddlBranch.Focus()
    '            isValid = False
    '        End If

    '    Catch ex As Exception
    '        isValid = False
    '    End Try
    'End Function

    'Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
    '    Dim sql As String
    '    Dim Fun As New clsFunctions
    '    sql = "select Id,Name from Exam_Master where Branch_ID=" & ddlBranch.SelectedValue & " "
    '    Fun.FillCombo(sql, ddlExam)

    'End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Dt As New DataTable
            Dim NoOfSeats As Long
            Dim NoOfStud As Long
            Dim NoOfClass As Long
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
            Dim Exam1 As Long
            Dim Exam2 As Long
            Dim dtTmp2 As DataTable
            ''code to find the no. of students & no. of seats
            For i = 0 To gvExamList.Rows.Count - 1
                chk = DirectCast(gvExamList.Rows(i).FindControl("ChkExam"), CheckBox)
                If chk.Checked = True Then
                    lbl = DirectCast(gvExamList.Rows(i).FindControl("lblExamId"), Label)

                    If strExam = "" Then
                        strExam = lbl.Text
                    Else
                        strExam = strExam & "," & lbl.Text
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

                    If strClass = "" Then
                        strClass = lbl.Text
                    Else
                        strClass = strClass & "," & lbl.Text
                    End If

                End If
            Next


            If NoOfSeats < NoOfStud Then
                MsgBox("Seats are less", MsgBoxStyle.Critical, "Student Allocation")
                Exit Sub
            End If
            ''array for the students count course/section wise
            sql = "select * from Similar_Branch "
            sql = sql & " Where Branch_Id1 in (" & strExam & ")"
            dt = Con.GetDataTable(sql)
            For i = 0 To Dt.Rows.Count - 1
                If strTmp1 = "" Then
                    strTmp1 = Dt.Rows(i).Item("Branch_Id1")
                Else
                    strTmp1 &= "," & Dt.Rows(i).Item("Branch_Id1")
                End If
            Next
            sql = "select * from Similar_Branch "
            sql = sql & " Where Branch_Id1 in (" & strExam & " )"
            sql = sql & " and Branch_Id2 not in (" & strExam & ")"
            Dt = Con.GetDataTable(sql)

            DtAllocation.Columns.Add("Branch")
            DtAllocation.Columns.Add("Class")
            DtAllocation.Columns.Add("NoOfStud")
            DtAllocation.Columns.Add("Exam")
            DtAllocation.Columns.Add("Student_Id")
            DtAllocation.Columns.Add("Seat_No")

            ''''''
            DivideInToo(Exam1, Exam2)
            Dim dt1 As New DataTable
            sql = "Select * from intermediate where Exam_Id in ( " & Exam1 & " )"
            dt1 = Con.GetDataTable(sql)
            For j = 0 To dt1.Rows.Count - 1
                sql = "Select * from Class_Master where Id in (" & strClass & ")"
                dtTmp2 = Con.GetDataTable(sql)
                For l = 0 To dtTmp2.Rows.Count - 1
                    For m = 0 To dtTmp2.Rows(l).Item("Number_Of_Benches") - 1
                        If j >= dt1.Rows.Count - 1 Then Exit For
                        DtAllocation.Rows.Add()
                        DtAllocation.Rows(k).Item("Branch") = dt1.Rows(j).Item("Branch_Id")
                        DtAllocation.Rows(k).Item("Class") = dtTmp2.Rows(l).Item("Id")
                        DtAllocation.Rows(k).Item("NoOfStud") = dtTmp2.Rows(l).Item("Number_Of_Benches")
                        DtAllocation.Rows(k).Item("Exam") = dt1.Rows(j).Item("Exam_ID")

                        DtAllocation.Rows(k).Item("Student_Id") = dt1.Rows(j).Item("Student_Id")
                        DtAllocation.Rows(k).Item("Seat_No") = m + 1
                        k = k + 1
                        j = j + 1
                    Next
                Next
            Next

            If Exam2 <> 0 Then
                sql = "Select * from intermediate where Exam_Id in ( " & Exam2 & " )"
                dt1 = Con.GetDataTable(sql)
                For j = 0 To dt1.Rows.Count - 1
                    sql = "Select * from Class_Master where Id in (" & strClass & ")"
                    dtTmp2 = Con.GetDataTable(sql)
                    For l = 0 To dtTmp2.Rows.Count - 1
                        For m = 0 To dtTmp2.Rows(l).Item("Number_Of_Benches") - 1
                            If j >= dt1.Rows.Count - 1 Then Exit For
                            DtAllocation.Rows.Add()
                            DtAllocation.Rows(k).Item("Branch") = dt1.Rows(j).Item("Branch_Id")
                            DtAllocation.Rows(k).Item("Class") = dtTmp2.Rows(l).Item("Id")
                            DtAllocation.Rows(k).Item("NoOfStud") = dtTmp2.Rows(l).Item("Number_Of_Benches")
                            DtAllocation.Rows(k).Item("Exam") = dt1.Rows(j).Item("Exam_ID")
                            DtAllocation.Rows(k).Item("Student_Id") = dt1.Rows(j).Item("Student_Id")
                            DtAllocation.Rows(k).Item("Seat_No") = m + 1
                            k = k + 1
                            j = j + 1
                        Next
                    Next
                Next

            End If

            ''''''



            'If Dt.Rows.Count >= 1 Then
            '    For i = 0 To Dt.Rows.Count - 1
            '        sql = "Select * from Intermediate where branch_Id in (" & Dt.Rows(i).Item("Branch_Id1")
            '        sql = sql & " , " & Dt.Rows(i).Item("Branch_Id2") & ") "
            '        Dim dtTmp1 As New DataTable
            '        dtTmp1 = Con.GetDataTable(sql)
            '        cnt = dtTmp1.Rows.Count
            '        For j = 0 To NoOfClass - 1
            '            sql = "Select * from Class_Master where Id in (" & strClass & ")"
            '            dtTmp2 = Con.GetDataTable(sql)
            '            For l = 0 To dtTmp2.Rows.Count - 1
            '                For m = 0 To dtTmp2.Rows(l).Item("Number_Of_Benches") - 1
            '                    DtAllocation.Rows.Add()
            '                    DtAllocation.Rows(k).Item("Branch") = dtTmp1.Rows(j).Item("Branch_Id")
            '                    DtAllocation.Rows(k).Item("Class") = strClass
            '                    DtAllocation.Rows(k).Item("NoOfStud") = 30
            '                    DtAllocation.Rows(k).Item("Exam") = strExam
            '                    DtAllocation.Rows(k).Item("Student_Id") = dtTmp1.Rows(j).Item("Student_Id")
            '                    DtAllocation.Rows(k).Item("Seat_No") = m
            '                Next
            '            Next
            '        Next
            '    Next
            'Else

            '    sql = "Select * from Intermediate where branch_Id in (" & strExam & ") "
            '    Dim dtTmp1 As New DataTable
            '    dtTmp1 = Con.GetDataTable(sql)

            '    cnt = dtTmp1.Rows.Count
            '    For j = 0 To dtTmp1.Rows.Count - 1
            '        sql = "Select * from Class_Master where Id in (" & strClass & ")"
            '        dtTmp2 = Con.GetDataTable(sql)
            '        For l = 0 To dtTmp2.Rows.Count - 1
            '            For m = 0 To dtTmp2.Rows(l).Item("Number_Of_Benches") - 1
            '                If j >= dtTmp1.Rows.Count - 1 Then Exit For
            '                DtAllocation.Rows.Add()
            '                DtAllocation.Rows(k).Item("Branch") = dtTmp1.Rows(j).Item("Branch_Id")
            '                DtAllocation.Rows(k).Item("Class") = dtTmp2.Rows(l).Item("Id")
            '                DtAllocation.Rows(k).Item("NoOfStud") = dtTmp2.Rows(l).Item("Number_Of_Benches")
            '                DtAllocation.Rows(k).Item("Exam") = strExam
            '                DtAllocation.Rows(k).Item("Student_Id") = dtTmp1.Rows(j).Item("Student_Id")
            '                DtAllocation.Rows(k).Item("Seat_No") = m
            '                k = k + 1
            '                j = j + 1
            '            Next
            '        Next
            '        For l = 0 To dtTmp2.Rows.Count - 1
            '            For m = 0 To dtTmp2.Rows(l).Item("Number_Of_Benches") - 1
            '                If j >= dtTmp1.Rows.Count - 1 Then Exit For
            '                DtAllocation.Rows.Add()
            '                DtAllocation.Rows(k).Item("Branch") = dtTmp1.Rows(j).Item("Branch_Id")
            '                DtAllocation.Rows(k).Item("Class") = dtTmp2.Rows(l).Item("Id")
            '                DtAllocation.Rows(k).Item("NoOfStud") = dtTmp2.Rows(l).Item("Number_Of_Benches")
            '                DtAllocation.Rows(k).Item("Exam") = strExam
            '                DtAllocation.Rows(k).Item("Student_Id") = dtTmp1.Rows(j).Item("Student_Id")
            '                DtAllocation.Rows(k).Item("Seat_No") = m
            '                k = k + 1
            '                j = j + 1
            '            Next
            '        Next
            '    Next
            'End If

            gvTemp.DataSource = DtAllocation
            gvTemp.DataBind()
            '' if it has more then 2 exams
            ''      devide the students count as per odd/even
            ''      if No
            '' divide the students with max strength in all class


            Dim StudentAllocation As New clsStudentAllocation
            For i = 0 To j - 2
                StudentAllocation.init()
                'ClassAllocation.Id = hdnId.Value
                StudentAllocation.Exam_Id = DtAllocation.Rows(i).Item("Exam")
                StudentAllocation.Branch_Id = DtAllocation.Rows(i).Item("Branch")
                StudentAllocation.Class_Id = DtAllocation.Rows(i).Item("Class")
                StudentAllocation.Student_Id = DtAllocation.Rows(i).Item("Student_ID")
                StudentAllocation.Seat_No = DtAllocation.Rows(i).Item("Seat_No")
                If Not IsValid() Then Exit Sub
                If StudentAllocation.Save = True Then
                    '     MsgBox("Class Allocation   successfully", MsgBoxStyle.Information, "Class Allocation")
                    'Dim dt As New DataTable
                    'Dim sql As String
                    'Dim Con As New clsConnection
                    'Dim Fun As New clsFunctions
                    sql = "Select * from Notification_Settings where Generated_Page=" & Fun.SQLString("StudentAllocation")
                    dt = Con.GetDataTable(sql)
                    If dt.Rows.Count = 1 Then
                        sql = "Select * from faculty_master where Designation = 'Exam-Cordinator'"
                        ' Dim dt1 As New DataTable
                        dt1 = Con.GetDataTable(sql)
                        Dim notification As New clsNotification
                        '    Dim j As Integer
                        For j = 0 To dt1.Rows.Count - 1
                            notification.init()
                            notification.Date_OfGeneration = Date.Today
                            notification.IsShown = False
                            notification.Message = "Exam is Generated.Form Timetable"
                            notification.Notification_Settings_ID = Convert.ToString(dt.Rows(0).Item("ID"))
                            notification.Redirection_Feild = Convert.ToString(dt.Rows(0).Item("Redirection_Field"))
                            notification.Redirection_Page = Convert.ToString(dt.Rows(0).Item("Redirected_Page"))
                            notification.Redirection_Value = Convert.ToString(StudentAllocation.Id)
                            notification.Send_By = Convert.ToString(Session.Item("Faculty_ID"))
                            notification.To_Whom = Convert.ToString(dt1.Rows(j).Item("Id"))
                            notification.Save()
                        Next
                    End If

                Else
                    MesgBox("Error while saving record")
                End If
            Next
        Catch ex As Exception
            MesgBox("Error:" & ex.Message)
        End Try

        '    DivideInToo(E1, E2)
    End Sub
    Private Sub HideNoti()
        If Not Request.QueryString("callocation_ID") Is Nothing Then
            Try

                Dim sql As String
                sql = "Update notification"
                sql = sql & " Set IsShown=1 where Redirection_Value=" & Request.QueryString("callocation_ID")
                sql = sql & " And Redirection_Page='StudentAllocation.aspx'"
                Dim Con As New clsConnection
                Con.ExecQuery(sql)
            Catch ex As Exception

            End Try

        End If
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

            sql = "Select e.Id, e.Name as Exam,format(t.Tt_Date,'dd-HH-yyyy') As tt_Date,b.Name as Branch,s.Name as Subject "
            sql = sql & " from Exam_Master e, timetable_master t, Branch_Master b, Subject_Master s "
            sql = sql & " where t.Exam_ID=e.Id "
            sql = sql & " and b.Id=t.Branch_Id "
            sql = sql & "and  s.Id=t.Subject_Id"
            sql = sql & " and tt_date=" & Fun.SQLDate(DtTmp.Rows(0).Item("tt_date"))
            ''sql = sql & " and t.Exam_Id<>" & Fun.SQLNumber(ddlExam.SelectedValue)
            lbExamList.Visible = True
            dtExam = Con.GetDataTable(sql)
            gvExamList.DataSource = dtExam
            gvExamList.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlExam.SelectedIndex = 0

    End Sub

    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim sql As String
        Dim Con As New clsConnection
        Dim Fun As New clsFunctions
        Try
            sql = "Select Id,Name from Exam_Master where Branch_Id=" & Fun.SQLNumber(ddlBranch.SelectedValue)
            sql = sql & " And Is_Active=1 "
            Fun.FillCombo(sql, ddlExam)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DivideInToo(ByRef E1 As String, ByRef E2 As String)

        Dim cnt(20) As Long
        Dim exam(20) As Long
        Dim chk As New CheckBox
        Dim lbl As New Label
        Dim sql As String
        Dim Con As New clsConnection
        Dim k As Integer
        Dim i As Integer
        For i = 0 To gvExamList.Rows.Count - 1
            chk = DirectCast(gvExamList.Rows(i).FindControl("ChkExam"), CheckBox)
            If chk.Checked = True Then
                lbl = DirectCast(gvExamList.Rows(i).FindControl("lblExamId"), Label)
                sql = "Select count(*) from Intermediate where Exam_Id in (" & lbl.Text & ")"
                cnt(k) = Con.GetValue(sql)
                exam(k) = lbl.Text
                k = k + 1
            End If

        Next
        For i = 0 To cnt.Count - 1

        Next
        Dim min As Integer
        'Dim tmp As Integer
        min = cnt(0)
        Dim ind As Integer = 0
        ''Code to sort the arrayof cnt

        For i = 0 To cnt.Count - 1
            min = cnt(i)
            For j = i + 1 To cnt.Count - 1
                If min > cnt(j) Then
                    min = cnt(j)
                    ind = j
                End If
            Next
            If ind <> i Then
                Dim tmp1 As Integer
                tmp1 = cnt(i)
                cnt(i) = cnt(ind)
                cnt(ind) = tmp1
                tmp1 = exam(i)
                exam(i) = exam(ind)
                exam(ind) = tmp1
            End If
        Next

        ''Code to devide in two Exam codes
        If cnt.Count = 1 Then
            E1 = exam(0)
        ElseIf cnt.Count = 2 Then
            E1 = exam(0)
            E2 = exam(1)
        ElseIf cnt.Count = 3 Then
            E1 = exam(0).ToString & "," & exam(1).ToString
            E2 = exam(2).ToString
        Else
            E1 = ""
            E2 = ""
            For i = 0 To cnt.Count - 1
                If i Mod 2 = 0 Then
                    E1 = E1 & exam(i).ToString
                Else
                    E2 = E2 & exam(i).ToString
                End If
            Next
        End If

        'For 
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
