
Partial Class Faculty_List
    Inherits System.Web.UI.Page
    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select f.Id, f.Name,f.Enrolment,b.Name as Branch, Email, Designation,f.contact_No "
            sql = sql & " from Faculty_master f,Branch_Master b "
            sql = sql & " Where f.Branch_ID=b.id"
            sql = sql & " order by f.name"
            Dt = con.GetDataTable(sql)
            dgvFaculty.DataSource = Dt
            dgvFaculty.DataBind()
            Dim RP As New clsRole_Allocation
            If RP.ChkAllo("FacultyEdit", Session.Item("Role_Id")) Then
                dgvFaculty.Columns(6).Visible = True
            Else
                dgvFaculty.Columns(6).Visible = False
            End If
            If RP.ChkAllo("FacultyDelete", Session.Item("Role_Id")) Then
                dgvFaculty.Columns(7).Visible = True
            Else
                dgvFaculty.Columns(7).Visible = False
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
                'End If

                sql = "delete  "
                sql = sql & "from Faculty_Master "
                sql = sql & "where Id=" & lngID
                If con.ExecQuery(sql) >= 1 Then
                    MesgBox("Delete successfully")
                End If
            End If
        Catch ex As Exception
            MesgBox("error:" & ex.Message)
        End Try
        GenerateCre()
        ShowGrid()
    End Sub
    Private Sub GenerateCre()
        Try
            Dim sql As String
            Dim Con As New clsConnection
            Dim _Id As Long
            Dim cnt As Integer
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            If Not Request.QueryString("gid") Is Nothing Then
                _Id = Val(Request.QueryString("gid").ToString() & "")
                sql = "Select count(*) from Faculty_Master where Id=" & _Id
                cnt = Con.GetValue(sql)

                If (cnt <> 0) Then
                    sql = "SElect * from Faculty_Master where Id=" & _Id
                    Dt = Con.GetDataTable(sql)
                    If (Dt.Rows(0).Item("email") = "") Then
                        MesgBox("This Faculty has no email address. Please update it first")
                    End If
                    sql = "Select count(*) from Login_Master where USer_name=" & Fun.SQLString(Dt.Rows(0).Item("EMail"))
                    If Con.GetValue(sql) >= 1 Then
                        MesgBox("Login alreday exists")
                        Exit Sub
                    End If
                    Dim Login As New clslogin_master
                    Login.init()
                    Login.Password = Dt.Rows(0).Item("Contact_No")
                    Login.Role_Id = 4    '' For faculty
                    Login.Faculty_Id = _Id
                    Login.Student_Id = 0
                    Login.Designation = "Faculty"
                    Login.User_Name = Dt.Rows(0).Item("EMail")
                    If Login.Save = True Then
                        MesgBox("Credencial Generated successfully")

                    Else
                        MesgBox("Error while saving record")
                    End If
                End If
            End If
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
