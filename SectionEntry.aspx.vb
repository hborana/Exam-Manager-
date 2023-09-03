
Partial Class SectionEntry
    Inherits System.Web.UI.Page
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Section As New clsSection_Master
            Section.init()
            Section.Id = hdnId.Value
            Section.Branch_Id = ddlBranch.SelectedValue
            Section.Academic_Year = txtAcademic_Year.Text
            Section.Sem_Id = ddlSem.SelectedValue
            Section.Section = txtSection.Text
            Section.No_Of_Student = txtNo_Of_Student.Text
            If Not is_Valid() Then Exit Sub
            If Section.Save = True Then
                MesgBox("Section saved successfully")
                ClearAll()
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
            ddlCourse.Items.Insert(0, "---Select Courrse---")
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
            Dim Section As New clsSection_Master
            Section.Id = ID
            Section.GetById()
            txtAcademic_Year.Text = Section.Academic_Year
            hdnId.Value = ID
            ddlBranch.SelectedValue = Section.Branch_Id
            txtSection.Text = Section.Section
            ddlSem.SelectedValue = Section.Sem_Id
            txtNo_Of_Student.Text = Section.No_Of_Student

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
                sql = "select count(*) from Section_Master where Section=" & Fun.SQLString(txtSection.Text)
                sql = sql & " and Branch_ID=" & Fun.SQLString(ddlBranch.Text)
                sql = sql & " and Academic_Year=" & Fun.SQLString(txtAcademic_Year.Text)
                sql = sql & " and Sem_ID=" & Fun.SQLString(ddlSem.Text)
                sql = sql & " and No_Of_Student=" & Fun.SQLString(txtNo_Of_Student.Text)
                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Section_Master where Section=" & Fun.SQLString(txtSection.Text)
                sql = sql & " and Branch_ID=" & Fun.SQLString(ddlBranch.Text)
                sql = sql & " and Academic_Year=" & Fun.SQLString(txtAcademic_Year.Text)
                sql = sql & " and Sem_ID=" & Fun.SQLString(ddlSem.Text)
                sql = sql & " and No_Of_Student=" & Fun.SQLString(txtNo_Of_Student.Text)
            End If
            If con.GetValue(sql) >= 1 Then
                MesgBox("Section already Exist")
                txtSection.Focus()
                is_Valid = False
            End If

        Catch ex As Exception
            is_Valid = False
        End Try
    End Function
    Private Sub ClearAll()

        txtAcademic_Year.Text = " "
        ddlBranch.SelectedIndex = 0
        txtSection.Text = " "
        ddlSem.SelectedIndex = 0
        txtNo_Of_Student.Text = " "
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCourse.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Name from Branch_Master where Course_ID=" & ddlCourse.SelectedValue & " "
        Fun.FillCombo(sql, ddlBranch)

    End Sub

    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Sem from Semester_Master where Branch_ID=" & ddlBranch.SelectedValue & " "
        Fun.FillCombo(sql, ddlSem)
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class

