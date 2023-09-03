

Partial Class Role_Allocation
    Inherits System.Web.UI.Page


    Dim m_id As Long


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            Dim Con As New clsConnection
            Dim Dt As New DataTable
            Dim Role_Allocation As New clsRole_Allocation

            If hdnId.Value <> 0 Then
                Role_Allocation.id = hdnId.Value
            Else
                Role_Allocation.init()
            End If

            Role_Allocation.role_id = ddlRole.SelectedValue


            Dim i As Integer

            For i = 0 To dgvRole_Allocation.Rows.Count Step +1

                Dim id As Label
                id = DirectCast(dgvRole_Allocation.Rows(i).FindControl("lbl_functionid"), Label)
                Role_Allocation.function_id = id.Text

                'Dim function_name As Label
                'function_name = DirectCast(dgvroleprivi.Rows(i).FindControl("lbl_functionname"), Label)
                'Role_Allocation.function_id = function_name.Text

                Dim is_allowed As CheckBox
                is_allowed = DirectCast(dgvRole_Allocation.Rows(i).FindControl("chk_isallowed"), CheckBox)
                Role_Allocation.is_allow = is_allowed.Checked.ToString
                'If is_allowed.Checked <> True Then
                '    Role_Allocation.is_allow = "false"
                'Else
                '    Role_Allocation.is_allow = "true"
                'End If



                If Role_Allocation.Save Then
                    'MsgBox("Role Allocation record saved successfully.", MsgBoxStyle.Information, "Role Allocation")
                Else
                    MesgBox("Error while saving record")
                End If
            Next

        Catch ex As Exception
            MesgBox("Error : " & ex.Message)
        End Try
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        ShowGrid()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then
                hdnId.Value = 0
                LoadCombo()
                LoadData()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions

            sql = "Select id,Name from Role_Master"
            Fun.FillCombo(sql, ddlRole)
            ddlRole.Items.Insert(0, "---Select Role---")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadData()
        Try
            Dim sql As String
            Dim Con As New clsConnection
            Dim Dt As New DataTable
            ''Code to check whether query string is passed or not??

            Dim function_name As Label
            function_name = DirectCast(dgvRole_Allocation.FindControl("lbl_functionname"), Label)


            Dim is_allowed As CheckBox
            is_allowed = DirectCast(dgvRole_Allocation.FindControl("chk_isallowed"), CheckBox)

            'm_id = Request.QueryString("sid").ToString
            hdnId.Value = m_id
            sql = "Select * from Role_Privileges_Master where Id=" & m_id
            Dt = Con.GetDataTable(sql)

            For i = 0 To Dt.Rows.Count - 1
                function_name.Text = Dt.Rows(i).Item("Function_id").ToString
                is_allowed.Checked = Dt.Rows(i).Item("is_allow").ToString
            Next
            dgvRole_Allocation.DataSource = Dt
            dgvRole_Allocation.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Con As New clsConnection
            Dim Fun As New clsFunctions
            Dim Dt As New DataTable
            sql = "select f.*,ra.Is_Allow, r.Name as Role from Role_Master r, Function_Master f, Role_Alloction ra"
            sql = sql & " where r.id = ra.role_id"
            sql = sql & " and f.id=ra.function_id"
            sql = sql & " and r.id=2" & Fun.SQLNumber(ddlRole.SelectedValue)
            sql = sql & " union "
            sql = sql & " select f.*,0 as Is_Allow, '' as Role from  Function_Master f"
            sql = sql & " where f.id not in (Select function_Id from Role_Alloction ra "
            sql = sql & " where ra.id=" & Fun.SQLNumber(ddlRole.SelectedValue) & " )"

            'sql = "Select rp.*,f.name,f.id as Function_id from Function_Master f, Role_Allocation ra"
            'sql = sql & " where function_id in (select id from function_Master where role_id=" & Fun.SQLNumber(ddl_role.SelectedValue)
            'sql = sql & " )"
            'sql = sql & " and a.function_id=f.id "
            ''sql query with union

            Dt = Con.GetDataTable(sql)
            If Dt.Rows.Count >= 1 Then
                dgvRole_Allocation.DataSource = Dt
                dgvRole_Allocation.DataBind()
            Else
                sql = "select id,name as Function_id, '' as is_allow from Function_Master where role_id=" & Fun.SQLNumber(ddlRole.SelectedValue)
                'sql = "select is_allow as is_allow from Role_Allocation"
                'sql = sql & " and course_id=" & Fun.SQLNumber(ddl_coursename.SelectedValue)
                'sql = sql & " and branch_id=" & Fun.SQLNumber(ddl_branchname.SelectedValue)
                '           sql = sql & " )"
                Dt = Con.GetDataTable(sql)
                If Dt.Rows.Count >= 1 Then
                    dgvRole_Allocation.DataSource = Dt
                    dgvRole_Allocation.DataBind()
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Function is_Valid() As Boolean
        Try
            Dim sql As String
            Dim con As New clsConnection
            Dim Fun As New clsFunctions
            is_Valid = True
            If hdnId.Value <> 0 Then
                sql = "select count(*) from Role_Allocation where Role_ID=" & Fun.SQLString(ddlRole.Text)
                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Role_Allocation where Role_ID=" & Fun.SQLString(ddlRole.Text)
            End If
            If con.GetValue(sql) >= 1 Then
                MesgBox("Exam already available")
                'txtName.Focus()
                is_Valid = False
            End If

        Catch ex As Exception
            is_Valid = False
        End Try
    End Function
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
