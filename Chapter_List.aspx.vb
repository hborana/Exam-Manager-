
Partial Class Chapter_List
    Inherits System.Web.UI.Page

    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select c.Id, c.Name,s.Name as Subject "
            sql = sql & " from chapter_master c,Subject_Master s"
            sql = sql & " where c.Subject_ID=s.Id "
            sql = sql & " order by c.name"

            Dt = con.GetDataTable(sql)
            dgvChapter.DataSource = Dt
            dgvChapter.DataBind()
            Dim RP As New clsRole_Allocation
            If RP.ChkAllo("ChapterEdit", Session.Item("Role_Id")) Then
                dgvChapter.Columns(3).Visible = True
            Else
                dgvChapter.Columns(3).Visible = False
            End If
            If RP.ChkAllo("ChapterDelete", Session.Item("Role_Id")) Then
                dgvChapter.Columns(4).Visible = True
            Else
                dgvChapter.Columns(4).Visible = False
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
            'lngID = (Page.Request.QueryString("Id").ToString())
            If (Not Page.Request.QueryString("Id") Is Nothing) Then
                lngID = Val(Page.Request.QueryString("Id").ToString())
                'End If

                sql = "delete  "
                sql = sql & "from Chapter_Master "
                sql = sql & "where Id=" & lngID
                If con.ExecQuery(sql) >= 1 Then
                    MesgBox("Delete successfully")
                End If
            End If
        Catch ex As Exception
            MsgBox("error:" & ex.Message)
        End Try
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

