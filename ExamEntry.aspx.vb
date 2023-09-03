
Partial Class ExamEntry
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Exam As New clsExam_Master
            Exam.init()
            Exam.Id = hdnId.Value
            Exam.Name = txtName.Text
            Exam.Branch_Id = ddlBranch.SelectedValue
            Exam.Sem_Id = ddlSem.SelectedValue
            Exam.Remark = txtRemark.Text
            If Not is_Valid() Then Exit Sub
            If Exam.Save = True Then
                MesgBox("Exam saved successfully")
                ClearAll()
                Dim dt As New DataTable
                Dim sql As String
                Dim Con As New clsConnection
                Dim Fun As New clsFunctions
                sql = "Select * from Notification_Settings where Generated_Page=" & Fun.SQLString("ExamEntry")
                dt = Con.GetDataTable(sql)
                If dt.Rows.Count = 1 Then
                    sql = "Select * from faculty_master where Designation = 'Exam-Cordinator'"
                    Dim dt1 As New DataTable
                    dt1 = Con.GetDataTable(sql)
                    Dim notification As New clsNotification
                    Dim j As Integer
                    For j = 0 To dt1.Rows.Count - 1
                        notification.init()
                        notification.Date_OfGeneration = Date.Today
                        notification.IsShown = False
                        notification.Message = "Exam is Generated.Form Timetable"
                        notification.Notification_Settings_ID = Convert.ToString(dt.Rows(0).Item("ID"))
                        notification.Redirection_Feild = Convert.ToString(dt.Rows(0).Item("Redirection_Field"))
                        notification.Redirection_Page = Convert.ToString(dt.Rows(0).Item("Redirected_Page"))
                        notification.Redirection_Value = Convert.ToString(Exam.Id)
                        notification.Send_By = Convert.ToString(Session.Item("Faculty_ID"))
                        notification.To_Whom = Convert.ToString(dt1.Rows(j).Item("Id"))
                        notification.Save()
                    Next
                End If

            Else
                MesgBox("Error while saving record")
            End If
        Catch ex As Exception
            MesgBox("Error:" & ex.Message)
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
            If Not (IsPostBack) Then
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
            sql = "select id,Name from Branch_Master "
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch---")
            sql = "select id,Sem from Semester_Master "
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim Exam As New clsExam_Master
            Exam.Id = ID
            Exam.GetById()
            txtName.Text = Exam.Name
            hdnId.Value = ID
            txtRemark.Text = Exam.Remark
            ddlSem.SelectedValue = Exam.Branch_ID
            ddlSem.SelectedValue = Exam.Sem_ID
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
                sql = "select count(*) from Exam_Master where Name=" & Fun.SQLString(txtName.Text)
                sql = sql & " and Branch_ID=" & Fun.SQLNumber(ddlBranch.SelectedValue)
                sql = sql & " and Sem_ID=" & Fun.SQLNumber(ddlSem.SelectedValue)
                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Exam_Master where Name=" & Fun.SQLString(txtName.Text)
                sql = sql & " and Branch_ID=" & Fun.SQLNumber(ddlBranch.SelectedValue)
                sql = sql & " and Sem_ID=" & Fun.SQLNumber(ddlSem.SelectedValue)
            End If
            If con.GetValue(sql) >= 1 Then
                MesgBox("Exam already available")
                txtName.Focus()
                is_Valid = False
            End If

        Catch ex As Exception
            is_Valid = False
        End Try
    End Function

    Private Sub ClearAll()

        txtName.Text = " "
        txtRemark.Text = " "
        ddlBranch.SelectedIndex = 0
        ddlSem.SelectedIndex = 0
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
