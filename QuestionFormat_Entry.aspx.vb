
Partial Class QuestionFormat_Entry
    Inherits System.Web.UI.Page


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '        Dim Sql As String
        Dim Con As New clsConnection
        Try
            'Dim Sql As String
            'Dim Con As New clsConnection
            Dim QuestionFormat As New clsQuestionPaper_Format
            QuestionFormat.init()
            QuestionFormat.Id = hdnId.Value
            QuestionFormat.Format_Id = ddlFormat.SelectedValue
            QuestionFormat.Parent_Question = Val(ddlParentQuestion.SelectedItem.ToString)
            QuestionFormat.Parent_Question_Id = ddlParentQuestion.SelectedValue
            QuestionFormat.Question_No = txtQuestion_No.Text
            QuestionFormat.Required_No = txtRequired_No.Text
            QuestionFormat.Marks = txtMarks.Text
            QuestionFormat.Out_Of = txtOut_Of.Text
            QuestionFormat.Is_Of_Same_Marks = ChkIs_Of_Same_Mark.Checked
            QuestionFormat.Heading = txtHeading.Text
            QuestionFormat.Heading_Que = txtHeading_Que.Text

            If QuestionFormat.Save = True Then
                MesgBox("Question Format saved successfully")
                ClearAll()
            Else
                MesgBox("Error while saving record")
            End If
            LoadPreCombo()
        Catch ex As Exception
            MesgBox("Error:" & ex.Message)
        End Try

        'Sql = "SELECT TOP 15 column FROM Question_Master ORDER BY NEWID()"
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
            ' LoadPreCombo()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadCombo()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions

            sql = "select id,Name from PaperFormat "
            Fun.FillCombo(sql, ddlFormat)
            sql = "Select Id,Question_No from QuestionPaper_Format where Format_Id=" & Fun.SQLNumber(ddlFormat.SelectedValue)
            Fun.FillCombo(sql, ddlParentQuestion)
            Dim itm As New ListItem
            itm.Value = 0
            itm.Text = "No Parent Question"
            ddlParentQuestion.Items.Insert(0, itm)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim QuestionFormat As New clsQuestionPaper_Format

            QuestionFormat.Id = ID
            QuestionFormat.GetById()
            ddlFormat.SelectedValue = QuestionFormat.Format_Id
            hdnId.Value = ID
            txtMarks.Text = QuestionFormat.Marks
            txtOut_Of.Text = QuestionFormat.Out_Of
            txtQuestion_No.Text = QuestionFormat.Question_No
            txtRequired_No.Text = QuestionFormat.Required_No
            ddlParentQuestion.SelectedValue = QuestionFormat.Parent_Question
            ChkIs_Of_Same_Mark.Text = QuestionFormat.Is_Of_Same_Marks
            txtHeading.Text = QuestionFormat.Heading
            txtHeading_Que.Text = QuestionFormat.Heading_Que
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClearAll()


        ddlFormat.SelectedIndex = 0
        txtMarks.Text = " "
        txtOut_Of.Text = " "
        txtQuestion_No.Text = " "
        txtRequired_No.Text = " "
        ddlParentQuestion.SelectedIndex = 0
        ChkIs_Of_Same_Mark.Text = " "
        txtHeading.Text = ""
        txtHeading_Que.Text = ""
    End Sub


    Private Sub LoadPreCombo()
        Try
            Dim FormatID As Integer
            Dim ParentId As Integer
            Dim sql As String
            Dim Fun As New clsFunctions
            FormatID = ddlFormat.SelectedValue
            ParentId = ddlParentQuestion.SelectedValue

            sql = "select id,Name from PaperFormat "
            Fun.FillCombo(sql, ddlFormat)
            ddlFormat.SelectedValue = FormatID
            sql = "Select Id,Question_No from QuestionPaper_Format where Format_Id=" & Fun.SQLNumber(ddlFormat.SelectedValue)
            Fun.FillCombo(sql, ddlParentQuestion)
            Dim itm As New ListItem
            itm.Value = 0
            itm.Text = "No Parent Question"
            ddlParentQuestion.Items.Insert(0, itm)


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
