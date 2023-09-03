

Partial Class BranchEntry
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Branch As New clsBranch_Master
            Branch.init()
            Branch.Id = hdnId.Value
            Branch.Name = txtName.Text
            Branch.Code = txtCode.Text
            Branch.Course_Id = ddlCourse.SelectedValue
            If Not is_Valid() Then Exit Sub
            If Branch.Save = True Then
                ''MsgBox("Branch saved successfully", MsgBoxStyle.Information, "Branch")
                MesgBox("Branch saved successfully")
                Dim sql As String
                Dim i As Integer
                Dim sem As New clsSemester_Master
                Sql = "delete from semester_master where Branch_Id=" & Branch.Id
                For i = 1 To txtSem.Text
                    sem.init()
                    sem.Branch_Id = Branch.Id
                    sem.Sem = i
                    sem.Save()
                    ClearAll()
                Next
            Else
                '' MsgBox("Error while saving record", MsgBoxStyle.Critical, "Branch")
                MesgBox("Error while saving record")
            End If
        Catch ex As Exception
            ''MsgBox("Error:" & ex.Message, MsgBoxStyle.Critical, "Branch")
            MesgBox("Error:")
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
                loadData()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            sql = "select id,Name from Course_Master "
            Fun.FillCombo(sql, ddlCourse)
            ddlCourse.Items.Insert(0, "---Select Course---")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim Branch As New clsBranch_Master
            Branch.Id = ID
            Branch.GetById()
            txtName.Text = Branch.Name
            hdnId.Value = ID
            ddlCourse.SelectedValue = Branch.Course_Id
            txtCode.Text = Branch.Code

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
                sql = "select count(*) from Branch_Master where Name=" & Fun.SQLString(txtName.Text)
                sql = sql & " and Course_ID=" & Fun.SQLString(ddlCourse.Text)
                sql = sql & " and Code=" & Fun.SQLString(txtCode.Text)
                ' sql = sql & " and Sem_ID=" & Fun.SQLString(ddlCourse.Text)

                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Branch_Master where Name=" & Fun.SQLString(txtName.Text)
                sql = sql & " and Course_ID=" & Fun.SQLString(ddlCourse.Text)
                sql = sql & " and Code=" & Fun.SQLString(txtCode.Text)
            End If
            If con.GetValue(sql) >= 1 Then
                ' MsgBox("Branch already available", MsgBoxStyle.Critical, "Branch")
                MesgBox("Branch already available")
                txtName.Focus()
                ClearAll()
                is_Valid = False
            End If

        Catch ex As Exception
            is_Valid = False
        End Try
    End Function
    Private Sub ClearAll()

        txtName.Text = " "
        ddlCourse.SelectedIndex = 0
        txtCode.Text = " "
        txtSem.Text = " "

    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
