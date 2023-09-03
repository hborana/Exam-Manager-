
Partial Class TimetableEntry
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Timetable As New clsTimetable_Master
            Timetable.init()
            Timetable.Id = hdnId.Value
            Timetable.Exam_Id = ddlExam.SelectedValue
            Timetable.Tt_Date = txtDate.Text
            Timetable.Totime = txtStartTime.Text
            Timetable.Formtime = txtEndTime.Text
            Timetable.Format_Id = ddlFormat.SelectedValue
            Timetable.Branch_Id = ddlBranch.SelectedValue
            Timetable.Sem_ID = ddlsem.SelectedValue
            Timetable.Subject_Id = ddlSubject.SelectedValue
            If Not isValid() Then Exit Sub
            If Timetable.Save = True Then
                MesgBox("TimeTable    saved    successfully")
                Dim dt As New DataTable
                Dim sql As String
                Dim Con As New clsConnection
                Dim Fun As New clsFunctions
                sql = "Select * from Notification_Settings where Generated_Page=" & Fun.SQLString("TimeTableEntry")
                dt = Con.GetDataTable(sql)
                If dt.Rows.Count = 1 Then
                    sql = "Select * from faculty_subject where subject_ID=" & Timetable.Subject_Id
                    Dim dt1 As New DataTable
                    dt1 = Con.GetDataTable(sql)
                    Dim notification As New clsNotification
                    Dim j As Integer
                    For j = 0 To dt1.Rows.Count - 1
                        notification.init()
                        notification.Date_OfGeneration = Date.Today
                        notification.IsShown = False
                        notification.Message = "Time table is formed.Generate  Question Paper"
                        notification.Notification_Settings_ID = Convert.ToString(dt.Rows(0).Item("ID"))
                        notification.Redirection_Feild = Convert.ToString(dt.Rows(0).Item("Redirection_Field"))
                        notification.Redirection_Page = Convert.ToString(dt.Rows(0).Item("Redirected_Page"))
                        notification.Redirection_Value = Convert.ToString(Timetable.Subject_Id)
                        notification.Send_By = Convert.ToString(Session.Item("Faculty_ID"))
                        notification.To_Whom = Convert.ToString(dt1.Rows(j).Item("Faculty_Id"))
                        notification.Save()
                    Next
                End If

                'If Not isValid() Then Exit Sub
                'If Timetable.Save = True Then
                'MsgBox("TimeTable    saved    successfully", MsgBoxStyle.Information, "TimeTable")

                sql = "Select * from Notification_Settings where Generated_Page=" & Fun.SQLString("TimeTableEntry1")
                dt = Con.GetDataTable(sql)
                If dt.Rows.Count = 1 Then
                    sql = "Select * from Faculty_Master where id in (Select Faculty_ID from Login_Master where role_ID=2)"
                    Dim dt1 As New DataTable
                    dt1 = Con.GetDataTable(sql)
                    Dim notification As New clsNotification
                    Dim j As Integer
                    For j = 0 To dt1.Rows.Count - 1
                        notification.init()
                        notification.Date_OfGeneration = Date.Today
                        notification.IsShown = False
                        notification.Message = "Time table is formed.Do Student Allocation."
                        notification.Notification_Settings_ID = dt.Rows(0).Item("ID")
                        notification.Redirection_Feild = Convert.ToString(dt.Rows(0).Item("Redirection_Field"))
                        notification.Redirection_Page = Convert.ToString(dt.Rows(0).Item("Redirected_Page"))
                        notification.Redirection_Value = Convert.ToString(Timetable.Subject_Id)
                        notification.Send_By = Convert.ToString(Session.Item("Faculty_ID"))
                        notification.To_Whom = Convert.ToString(dt1.Rows(j).Item("Id"))
                        notification.Save()
                        'notification.init()
                        'notification.Date_OfGeneration = Date.Today
                        'notification.IsShown = False
                        'notification.Message = "Time table generated."
                        'notification.Notification_Settings_ID = dt.Rows(0).Item("ID")
                        'notification.Redirection_Feild = dt.Rows(0).Item("Redirection_Field")
                        'notification.Redirection_Page = dt.Rows(0).Item("Redirection_Page")
                        'notification.Redirection_Value = Timetable.Subject_Id
                        'notification.Send_By = Session.Item("Faculty_ID")
                        'notification.To_Whom = dt1.Rows(j).Item("Id")
                        'notification.Save()
                    Next
                End If
            Else
                MesgBox("Error while saving record")
            End If
            'End If

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
            sql = "select id,Name from paperformat "
            Fun.FillCombo(sql, ddlFormat)
            ddlFormat.Items.Insert(0, "---Select Format---")
            sql = "select id,Name from Exam_Master "
            Fun.FillCombo(sql, ddlExam)
            ddlExam.Items.Insert(0, "---Select Exam---")
            sql = "select id,Name from Subject_Master "
            Fun.FillCombo(sql, ddlSubject)
            ddlSubject.Items.Insert(0, "---Select Subject---")
            sql = "select id,Sem from Semester_Master "
            Fun.FillCombo(sql, ddlsem)
            ddlsem.Items.Insert(0, "---Select Semester---")

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
                HideNoti()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub HideNoti()
        If Not Request.QueryString("exam_Id") Is Nothing Then
            Try

            Dim sql As String
            sql = "Update notification"
                sql = sql & " Set IsShown=1 where Redirection_Value=" & Request.QueryString("exam_Id")
                sql = sql & " And Redirection_Page='TimetableEntry.aspx'"
            Dim Con As New clsConnection
                Con.ExecQuery(sql)
            Catch ex As Exception

            End Try

        End If
    End Sub
    Private Function is_Valid() As Boolean
        Try
            Dim sql As String
            Dim con As New clsConnection
            Dim Fun As New clsFunctions
            is_Valid = True
            If hdnId.Value <> 0 Then
                sql = "select count(*) from Timetable_Master where Exam_ID=" & Fun.SQLString(ddlExam.Text)
                sql = sql & " and Tt_date=" & Fun.SQLString(txtDate.Text)
                sql = sql & "and Branch_ID=" & Fun.SQLNumber(ddlBranch.SelectedValue)
                sql = sql & "and Sem_ID=" & Fun.SQLNumber(ddlsem.SelectedValue)
                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Timetable_Master where Exam_ID=" & Fun.SQLString(ddlExam.Text)
                sql = sql & " and Tt_date=" & Fun.SQLString(txtDate.Text)
                sql = sql & "and Branch_ID=" & Fun.SQLNumber(ddlBranch.SelectedValue)
                sql = sql & "and Sem_ID=" & Fun.SQLNumber(ddlsem.SelectedValue)
            End If
            If con.GetValue(sql) >= 1 Then
                MesgBox("Exam Date already Exist")
                ddlExam.Focus()
                is_Valid = False
            End If

            If txtStartTime.Text >= txtEndTime.Text Then
                MesgBox("Start Time should be less then End Time")
                is_Valid = False
            End If
        Catch ex As Exception
            is_Valid = False
        End Try
    End Function
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim TimeTable As New clsTimetable_Master
            TimeTable.Id = ID
            TimeTable.GetById()
            ddlBranch.SelectedValue = TimeTable.Branch_Id
            hdnId.Value = ID
            ddlsem.SelectedValue = TimeTable.Sem_ID
            txtDate.Text = TimeTable.Tt_Date
            txtStartTime.Text = TimeTable.Totime
            txtEndTime.Text = TimeTable.Formtime
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Sem from Semester_Master where Branch_ID=" & ddlBranch.SelectedValue & " "
        Fun.FillCombo(sql, ddlsem)
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
