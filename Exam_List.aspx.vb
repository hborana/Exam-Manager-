
Partial Class Exam_List
    Inherits System.Web.UI.Page
    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            'sql = "Select e.Id,e.Name,b.Name as Branch,s.Sem as Seme from exam_master e ,Branch_Master b,Semester_Master s"
            'sql = sql & "where e.Branch_ID=b.Id"
            'sql = sql & " and e.Sem_ID=s.Id"
            'sql = sql & " order by e.name"
            sql = "select * from Exam_Master"
            sql = sql & " where Branch_ID=" & Fun.SQLNumber(ddlBranch.SelectedValue)
            sql = sql & " and Sem_ID=" & Fun.SQLNumber(ddlSem.SelectedValue)
            sql = sql & " order by Name"
            Dt = con.GetDataTable(sql)
            dgvExam.DataSource = Dt
            dgvExam.DataBind()
            Dim RP As New clsRole_Allocation
            'If RP.ChkAllo("ExamEdit", Session.Item("Role_Id")) Then
            '    dgvExam.Columns(3).Visible = True
            'Else
            '    dgvExam.Columns(3).Visible = False
            'End If
            'If RP.ChkAllo("ExamDelete", Session.Item("Role_Id")) Then
            '    dgvExam.Columns(4).Visible = True
            'Else
            '    dgvExam.Columns(4).Visible = False
            'End If
            'If RP.ChkAllo("ExamClose", Session.Item("Role_Id")) Then
            '    dgvExam.Columns(2).Visible = True
            'Else
            '    dgvExam.Columns(2).Visible = False
            'End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (IsPostBack) Then

            LoadCombo()
        End If

        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            Dim lngID As Long
            If (Not Page.Request.QueryString("Id") Is Nothing) Then
                lngID = Val(Page.Request.QueryString("Id").ToString())

                sql = "delete  "
                sql = sql & "from Exam_Master "
                sql = sql & "where Id=" & lngID
                If con.ExecQuery(sql) >= 1 Then
                    MesgBox("Delete successfully")

                End If
            End If
            If (Not Page.Request.QueryString("Close") Is Nothing) Then
                lngID = Val(Page.Request.QueryString("Close").ToString())

                sql = "Update  Exam_Master "
                sql = sql & " set Is_Active=0"
                sql = sql & " where Id=" & lngID
                If con.ExecQuery(sql) >= 1 Then
                    MesgBox("Update successfully")

                End If
            End If
        Catch ex As Exception
            MesgBox("error:" & ex.Message)
        End Try
        ShowGrid()
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
    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select id,Sem from Semester_Master where Branch_ID= " & ddlBranch.SelectedValue
        Fun.FillCombo(sql, ddlSem)

    End Sub
End Class
