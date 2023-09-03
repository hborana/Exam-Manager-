
Partial Class StudentAllocation_List
    Inherits System.Web.UI.Page

    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select s.Enrolment,sa.Seat_No "
            sql = sql & " from  Student_Allocation sa,Student_Master s"
            sql = sql & " where sa.Class_ID=" & ddlClass.SelectedValue
            sql = sql & " and sa.Exam_Id=" & ddlExam.SelectedValue
            sql = sql & " and s.Id=sa.Student_Id "
            '' sql = sql & " and ca.Class_Id=ca.Class_Id "

            sql = sql & " order by s.Enrolment"
            Dt = con.GetDataTable(sql)
            dgvClass.DataSource = Dt
            dgvClass.DataBind()
            'Dim RP As New clsRole_Allocation
            'If RP.ChkAllo("BranchEdit", Session.Item("Role_Id")) Then
            '    dgvClass.Columns(3).Visible = True
            'Else
            '    dgvClass.Columns(3).Visible = False
            'End If
            'If RP.ChkAllo("BranchDelete", Session.Item("Role_Id")) Then
            '    dgvClass.Columns(4).Visible = True
            'Else
            '    dgvClass(4).Visible = False
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            Dim lngID As Long

            If (Not Page.Request.QueryString("Id") Is Nothing) Then
                lngID = Val(Page.Request.QueryString("Id").ToString())

                sql = "delete  "
                sql = sql & "from Student_Allocation "
                sql = sql & "where Id=" & lngID
                If con.ExecQuery(sql) >= 1 Then
                    MesgBox("Delete successfully")
                End If
            End If
        Catch ex As Exception
            MesgBox("error:" & ex.Message)
        End Try
        If Not IsPostBack Then
            LoadCombo()
            ShowGrid()
        End If
    End Sub

    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            sql = "select id,Class_No from Class_Master "
            Fun.FillCombo(sql, ddlClass)
            sql = "select id,Name from Exam_Master "
            Fun.FillCombo(sql, ddlExam)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlClass.SelectedIndexChanged
        '   Dim sql As String
        Dim con As New clsConnection
        Dim Fun As New clsFunctions
        Dim Dt As New DataTable
        Dim strExam As String = ""
        Try

            'sql = "Select s.Id,s.Branch_Id,s.Sem_ID"
            'sql = sql & "  from Student_Master s ,Class_Allocation ca ,Class_Master c ,Exam_Master e"
            'sql = sql & " where ca.Class_ID=" & ddlClass.SelectedValue
            'Dt = con.GetDataTable(sql)

            ShowGrid()
            ShowLable()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub ShowLable()
        Try
            Dim sql As String
            Dim Con As New clsConnection
            Dim Fun As New clsFunctions
            Dim dt As New DataTable
            Dim strBranch As String = 0
            Dim strSem As String = 0
            Dim i As Integer
            sql = "Select Name from Branch_Master where id in (select Branch_id from Student_Allocation where class_Id=" & ddlClass.SelectedValue & ")"
            dt = Con.GetDataTable(sql)
            For i = 0 To dt.Rows.Count - 1
                If strBranch = "" Then
                    strBranch = dt.Rows(i).Item("Name")
                Else
                    strBranch = strBranch & "," & dt.Rows(i).Item("Name")
                End If
                '                    ExamCount += 1

                ' End If
            Next
            txtName.Text = strBranch
            sql = "Select Sem from Semester_Master where id in (select Branch_id from Student_Allocation where class_Id=" & ddlClass.SelectedValue & ")"
            dt = Con.GetDataTable(sql)
            For i = 0 To dt.Rows.Count - 1
                If strSem = "" Then
                    strSem = dt.Rows(i).Item("Sem")
                Else
                    strSem = strSem & "," & dt.Rows(i).Item("Sem")
                End If
                '                    ExamCount += 1

                ' End If
            Next
            txtSem.Text = strSem
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
