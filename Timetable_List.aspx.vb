
Partial Class Timetable_List
    Inherits System.Web.UI.Page
    Dim x As Integer

    Private Sub ShowGrid()
        Try

            Dim sql As String
            Dim i As Integer
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select t.Id, t.Tt_date,t.Sem_ID,t.Fromtime,t.Totime,s.Name as Subject,e.Name as Exam "
            sql = sql & " from Timetable_master t,Subject_Master s,Exam_Master e "
            sql = sql & " Where t.Subject_ID=s.id and t.Exam_ID=e.id"
            sql = sql & " and t.Branch_Id=" & ddlBranch.SelectedValue & " "
            sql = sql & " and t.Sem_ID=" & ddlSem.SelectedValue & " "
            sql = sql & " order by t.Branch_Id"
            Dt = con.GetDataTable(sql)
            x = Dt.Rows(i).Item("Id")
            dgvTimeTable.DataSource = Dt
            dgvTimeTable.DataBind()
            lbtt.Visible = True
            Dim RP As New clsRole_Allocation
            If RP.ChkAllo("QuestionEdit", Session.Item("Role_Id")) Then
                dgvTimeTable.Columns(4).Visible = True
            Else
                dgvTimeTable.Columns(4).Visible = False
            End If
            If RP.ChkAllo("QuestionDelete", Session.Item("Role_Id")) Then
                dgvTimeTable.Columns(5).Visible = True
            Else
                dgvTimeTable.Columns(5).Visible = False
            End If

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
                sql = sql & "from Timetable_Master "
                sql = sql & "where Id=" & lngID
                If con.ExecQuery(sql) >= 1 Then
                    MesgBox("Delete successfully")

                End If
            End If
        Catch ex As Exception
            MesgBox("error:" & ex.Message)
        End Try

    End Sub
    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions

            sql = "select id,Name from Branch_Master"
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch---")
            sql = "select id,Sem from Semester_Master"
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Sem from Semester_Master where Branch_ID=" & ddlBranch.SelectedValue & " "
        Fun.FillCombo(sql, ddlSem)
        ShowGrid()
    End Sub

    Protected Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        Response.Redirect("~/ReportsPrint/rpTimeTable.aspx?sid=" & x)
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
