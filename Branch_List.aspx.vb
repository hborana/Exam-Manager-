

Partial Class Branch_List
    Inherits System.Web.UI.Page

    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select b.Id, b.Name,b.Code, c.Name as Course"
            sql = sql & " from branch_master b,Course_Master c"
            sql = sql & " Where b.Course_ID=c.id "
            sql = sql & " order by b.name"
            Dt = con.GetDataTable(sql)
            dgvBranch.DataSource = Dt
            dgvBranch.DataBind()
            Dim RP As New clsRole_Allocation
            If RP.ChkAllo("BranchEdit", Session.Item("Role_Id")) Then
                dgvBranch.Columns(3).Visible = True
            Else
                dgvBranch.Columns(3).Visible = False
            End If
            If RP.ChkAllo("BranchDelete", Session.Item("Role_Id")) Then
                dgvBranch.Columns(4).Visible = True
            Else
                dgvBranch.Columns(4).Visible = False
            End If

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
                sql = sql & "from Branch_Master "
                sql = sql & "where Id=" & lngID
                If con.ExecQuery(sql) >= 1 Then
                    MsgBox("Delete successfully")
                End If
            End If
        Catch ex As Exception
            MsgBox("error:" & ex.Message)
        End Try
        ShowGrid()
    End Sub
End Class
