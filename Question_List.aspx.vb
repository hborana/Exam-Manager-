
Partial Class Question_List
    Inherits System.Web.UI.Page

    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            'sql = "Select q.Id, f.name as Format, b.Name as Branch, q.sem_ID, s.name as Subject, c.Name as Chapter, q.Question , Marks "
            'sql = sql & " from Question_master q,Branch_Master b ,format_Master f,Subject_Master s, Chapter_Master c "
            'sql = sql & " where q.Branch_ID=b.id and q.Format_ID=f.Id and q.Subject_ID=s.Id and q.Chapter_ID=c.id"
            'sql = sql & " order by q.subject_ID"
            sql = " select Question,Marks,Id "
            sql = sql & "from Question_Master"
            sql = sql & " where Branch_ID=" & Fun.SQLNumber(ddlBranch.SelectedValue)
            sql = sql & " and Sem_ID=" & Fun.SQLNumber(ddlSem.SelectedValue)
            sql = sql & " and Subject_ID=" & Fun.SQLNumber(ddlSubject.SelectedValue)
            sql = sql & " and Chapter_ID=" & Fun.SQLNumber(ddlChapter.SelectedValue)
            sql = sql & "order by Marks"
            Dt = con.GetDataTable(sql)
            dgvQuestion.DataSource = Dt
            dgvQuestion.DataBind()
            Dim RP As New clsRole_Allocation
            If RP.ChkAllo("QuestionEdit", Session.Item("Role_Id")) Then
                dgvQuestion.Columns(2).Visible = True
            Else
                dgvQuestion.Columns(2).Visible = False
            End If
            If RP.ChkAllo("QuestionDelete", Session.Item("Role_Id")) Then
                dgvQuestion.Columns(3).Visible = True
            Else
                dgvQuestion.Columns(3).Visible = False
            End If


        Catch ex As Exception
            MesgBox("error:" & ex.Message)
        End Try
    End Sub

    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions

            sql = "select id,Name from Branch_Master "
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch---")
            sql = "select id,sem from Semester_Master "
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")
            sql = "select id,Name from Subject_Master "
            Fun.FillCombo(sql, ddlSubject)
            ddlSubject.Items.Insert(0, "---Select Subject---")
            sql = "select id,Name from Chapter_Master "
            Fun.FillCombo(sql, ddlChapter)
            ddlChapter.Items.Insert(0, "---Select Chapter---")

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Code to check whether query string is available?
        ' If available then code to delete that record
        '   Delete from <TableName> where id=<>
        '   Execute above query
        If Not (IsPostBack) Then

            LoadCombo()
        End If
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            Dim lngID As Long
            'lngID = (Page.Request.QueryString("Id").ToString())
            If (Not Page.Request.QueryString("Id") Is Nothing) Then
                lngID = Val(Page.Request.QueryString("Id").ToString())
                'End If

                sql = "delete  "
                sql = sql & "from Question_Master "
                sql = sql & "where Id=" & lngID
                If con.ExecQuery(sql) >= 1 Then
                    MesgBox("Delete successfully")

                    'dgvQuestion.DataSource = Dt
                    'dgvQuestion.DataBind()

                End If
            End If
        Catch ex As Exception
            MsgBox("error:" & ex.Message)
        End Try

    End Sub

    Protected Sub ddlChapter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlChapter.SelectedIndexChanged
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
