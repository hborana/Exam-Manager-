
Partial Class Course_List
    Inherits System.Web.UI.Page

    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select * from course_master order by name"
            Dt = con.GetDataTable(sql)
            dgvCourse.DataSource = Dt
            dgvCourse.DataBind()
            Dim RP As New clsRole_Allocation
            If RP.ChkAllo("CourseEdit", Session.Item("Role_Id")) Then
                dgvCourse.Columns(2).Visible = True
            Else
                dgvCourse.Columns(2).Visible = False
            End If
            If RP.ChkAllo("CourseDelete", Session.Item("Role_Id")) Then
                dgvCourse.Columns(3).Visible = True
            Else
                dgvCourse.Columns(3).Visible = False
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
                sql = sql & "from Course_Master "
                sql = sql & "where Id=" & lngID
                If con.ExecQuery(sql) >= 1 Then
                    MesgBox("Delete successfully")
                End If
            End If
        Catch ex As Exception
            MesgBox("error:" & ex.Message)
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
