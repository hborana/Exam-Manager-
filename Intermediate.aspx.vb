
Partial Class Intermediate

    Inherits System.Web.UI.Page


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Dim Sql As String
        Dim Con As New clsConnection
        Try
            'Dim Sql As String
            'Dim Con As New clsConnection
            Dim Intermediate As New clsIntermediate
            Intermediate.init()
            Intermediate.Id = hdnId.Value
            Intermediate.Branch_ID = ddlBranch.SelectedValue
            Intermediate.Exam_ID = ddlExam.SelectedValue
            Intermediate.Sem_ID = ddlSem.SelectedValue
            Intermediate.Course_ID = ddlCourse.SelectedValue



            If Intermediate.Save = True Then
                MesgBox("Student saved successfully")
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
        ''ShowGrid()
    End Sub
    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            sql = "select id,Name from Course_Master "
            Fun.FillCombo(sql, ddlCourse)
            ddlCourse.Items.Insert(0, "---Select Course---")
            sql = "select id,Name from Branch_Master "
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch---")
            sql = "select id,Sem from Semester_Master "
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")
            sql = "select id,Name from Exam_Master "
            Fun.FillCombo(sql, ddlExam)
            ddlExam.Items.Insert(0, "---Select Exam---")
            'sql = "select id,Name from Student_Master "
            'Fun.FillCombo(sql, ddl)
            'ddlBranch.Items.Insert(0, "---Select Exam---")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim Intermediate As New clsIntermediate
            Intermediate.Id = ID
            Intermediate.GetById()
            hdnId.Value = ID
            ddlBranch.SelectedValue = Intermediate.Branch_ID
            ddlCourse.SelectedValue = Intermediate.Course_ID
            ddlExam.SelectedValue = Intermediate.Exam_ID
            ddlSem.SelectedValue = Intermediate.Sem_ID
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlCourse.SelectedIndex = 0
        ddlSem.SelectedIndex = 0
        ddlExam.SelectedIndex = 0

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
    Private Sub ShowGrid()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            Dim con As New clsConnection
            sql = "Select * from Student_Master "
            sql = sql & " where Branch_Id=" & ddlBranch.SelectedValue 'class_id
            sql = sql & " and sem_Id=" & ddlSem.SelectedValue    'exam_id
            sql = sql & "order by Name"
            Dt = con.GetDataTable(sql)
            gvIntermediate.DataSource = Dt
            gvIntermediate.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlSem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSem.SelectedIndexChanged
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
