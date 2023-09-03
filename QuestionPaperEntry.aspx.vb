
'Partial Class QuestionPaperEntry
'    Inherits System.Web.UI.Page
'    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
'        Dim Sql As String
'        Dim Con As New clsConnection
'        Dim Fun As New clsFunctions
'        Dim maxQuestion As Integer = 0
'        Dim ParentQuestionNo As Integer = 0
'        Dim ParentQuestionNo_Id As Integer = 0
'        Try
'            'Dim Sql As String
'            'Dim Con As New clsConnection
'            Dim QuestionPaper As New clsQuestionpaper_Master
'            QuestionPaper.init()
'            QuestionPaper.Id = hdnId.Value
'            QuestionPaper.Name = txtName.Text
'            QuestionPaper.Branch_Id = ddlBranch.SelectedValue
'            QuestionPaper.Format_Id = ddlFormat.SelectedValue
'            'QuestionPaper.Course_Id = ddlCourse.SelectedValue
'            'QuestionPaper.Chapter_Id = ddlChpater.SelectedValue
'            QuestionPaper.Sem_Id = ddlSem.SelectedValue
'            QuestionPaper.Subject_Id = ddlSubject.SelectedValue
'            Sql = "Select Total_Marks from PaperFormat where Id=" & Fun.SQLNumber(ddlFormat.SelectedValue)

'            Dim total As Long
'            total = Con.GetValue(Sql)
'            QuestionPaper.Total_Marks = total
'            Dim pass As Long
'            pass = total * 40 / 100
'            QuestionPaper.Passing_Marks = pass
'            '((QuestionPaper.Total_Marks) * 40 / 100)
'            'QuestionPaper.Passing_Marks =

'            If QuestionPaper.Save = True Then
'                Sql = "Select  * from QuestionPaper_format where Format_Id=" & ddlFormat.SelectedValue
'                Sql = Sql & " and Parent_Question=0"
'                Dim Dt As New DataTable
'                Dt = Con.GetDataTable(Sql)
'                For i = 0 To Dt.Rows.Count - 1
'                    If Val(Dt.Rows(i).Item("IS_Of_Same_Marks")) Then
'                        '' code to get random question from database
'                        '' no.of question : dt.rows(i).item("Max_question")
'                        maxQuestion = (Dt.Rows(i).Item("Out_Of"))
'                        Dim j As Integer
'                        Dim dtQue As New DataTable
'                        Sql = "SELECT TOP  " & maxQuestion & " * FROM Question_Master ORDER BY NEWID()"
'                        dtQue = Con.GetDataTable(Sql)
'                        Dim QuestionPaper_Detail As New clsQuestionpaper_Detail

'                        For j = 0 To dtQue.Rows.Count - 1
'                            QuestionPaper_Detail.init()
'                            QuestionPaper_Detail.Question_Id = dtQue.Rows(j).Item("Id")
'                            QuestionPaper_Detail.Question_No = Dt.Rows(i).Item("Question_No")
'                            QuestionPaper_Detail.QuestionNo_Id = Dt.Rows(i).Item("Id")
'                            QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
'                            QuestionPaper_Detail.Parent_QuestionNo = Dt.Rows(i).Item("Parent_Question")
'                            QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt.Rows(i).Item("Parent_Question_Id"))
'                            QuestionPaper_Detail.Remark = "main"
'                            If QuestionPaper_Detail.Save = True Then

'                            End If
'                        Next

'                    Else
'                        Sql = "Select  * from QuestionPaper_format where Format_Id=" & ddlFormat.SelectedValue
'                        Sql = Sql & " and Id=" & Dt.Rows(i).Item("ID")
'                        Dim Dt1 As New DataTable
'                        Dt1 = Con.GetDataTable(Sql)
'                        maxQuestion = (Dt.Rows(i).Item("Out_Of"))
'                        Dim j As Integer
'                        Dim dtQue As New DataTable
'                        Sql = "SELECT TOP  " & maxQuestion & " * FROM Question_Master ORDER BY NEWID()"
'                        dtQue = Con.GetDataTable(Sql)
'                        Dim QuestionPaper_Detail As New clsQuestionpaper_Detail

'                        For j = 0 To dtQue.Rows.Count - 1
'                            QuestionPaper_Detail.init()
'                            QuestionPaper_Detail.Question_Id = dtQue.Rows(j).Item("Id")
'                            QuestionPaper_Detail.Question_No = Dt1.Rows(0).Item("Question_No")
'                            QuestionPaper_Detail.QuestionNo_Id = Dt1.Rows(0).Item("Id")
'                            QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
'                            QuestionPaper_Detail.Parent_QuestionNo = Dt1.Rows(0).Item("Question_No")
'                            QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt1.Rows(0).Item("Id"))

'                            QuestionPaper_Detail.Remark = "Sub"
'                            If QuestionPaper_Detail.Save = True Then

'                            End If
'                        Next

'                    End If
'                Next
'                MsgBox("Question Paper saved successfully", MsgBoxStyle.Information, "Question")
'                '    Response.Redirect("rptQuestionPaper.aspx?qid=" & QuestionPaper.Id)
'                ClearAll()
'            Else
'                MsgBox("Error while saving record", MsgBoxStyle.Critical, "Question")
'            End If
'        Catch ex As Exception
'            MsgBox("Error:" & ex.Message, MsgBoxStyle.Critical, "Question")
'        End Try


'    End Sub
'    'Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
'    '    Dim Sql As String
'    '    Dim Con As New clsConnection
'    '    Dim Fun As New clsFunctions
'    '    Dim maxQuestion As Integer = 0
'    '    Dim ParentQuestionNo As Integer = 0
'    '    Dim ParentQuestionNo_Id As Integer = 0
'    '    Try
'    '        'Dim Sql As String
'    '        'Dim Con As New clsConnection
'    '        Dim QuestionPaper As New clsQuestionpaper_Master
'    '        QuestionPaper.init()
'    '        QuestionPaper.Id = hdnId.Value
'    '        QuestionPaper.Name = txtName.Text
'    '        QuestionPaper.Branch_Id = ddlBranch.SelectedValue
'    '        QuestionPaper.Format_Id = ddlFormat.SelectedValue
'    '        'QuestionPaper.Course_Id = ddlCourse.SelectedValue
'    '        'QuestionPaper.Chapter_Id = ddlChpater.SelectedValue
'    '        QuestionPaper.Sem_Id = ddlSem.SelectedValue
'    '        QuestionPaper.Subject_Id = ddlSubject.SelectedValue
'    '        Sql = "Select Total_Marks from PaperFormat where Id=" & Fun.SQLNumber(ddlFormat.SelectedValue)

'    '        Dim total As Long
'    '        total = Con.GetValue(Sql)
'    '        QuestionPaper.Total_Marks = total
'    '        Dim pass As Long
'    '        pass = total * 40 / 100
'    '        QuestionPaper.Passing_Marks = pass
'    '        '((QuestionPaper.Total_Marks) * 40 / 100)
'    '        'QuestionPaper.Passing_Marks =
'    '        If QuestionPaper.Save = True Then
'    '            Sql = "Select  * from QuestionPaper_format where Format_Id=" & ddlFormat.SelectedValue
'    '            Sql = Sql & " and Parent_Question=0"
'    '            Dim Dt As New DataTable
'    '            Dt = Con.GetDataTable(Sql)
'    '            For i = 0 To Dt.Rows.Count - 1
'    '                If Val(Dt.Rows(i).Item("IS_Of_Same_Marks")) Then
'    '                    '' code to get random question from database
'    '                    '' no.of question : dt.rows(i).item("Max_question")
'    '                    maxQuestion = (Dt.Rows(i).Item("Out_Of"))
'    '                    Dim j As Integer
'    '                    Dim dtQue As New DataTable
'    '                    Sql = "SELECT TOP  " & maxQuestion & " * FROM Question_Master ORDER BY NEWID()"
'    '                    dtQue = Con.GetDataTable(Sql)
'    '                    Dim QuestionPaper_Detail As New clsQuestionpaper_Detail

'    '                    For j = 0 To dtQue.Rows.Count - 1
'    '                        QuestionPaper_Detail.init()
'    '                        QuestionPaper_Detail.Question_Id = dtQue.Rows(j).Item("Id")
'    '                        QuestionPaper_Detail.Question_No = Dt.Rows(i).Item("Question_No")
'    '                        QuestionPaper_Detail.QuestionNo_Id = Dt.Rows(i).Item("Id")
'    '                        QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
'    '                        QuestionPaper_Detail.Parent_QuestionNo = Dt.Rows(i).Item("Parent_Question")
'    '                        QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt.Rows(i).Item("Parent_Question_Id"))
'    '                        QuestionPaper_Detail.Remark = "main"
'    '                        If QuestionPaper_Detail.Save = True Then

'    '                        End If
'    '                    Next

'    '                Else
'    '                    Sql = "Select  * from QuestionPaper_format where Format_Id=" & ddlFormat.SelectedValue
'    '                    Sql = Sql & " and Question_No=" & Dt.Rows(i).Item("ID")
'    '                    Dim Dt1 As New DataTable
'    '                    Dt1 = Con.GetDataTable(Sql)

'    '                    maxQuestion = (Dt.Rows(i).Item("Out_Of"))
'    '                    Dim j As Integer
'    '                    Dim dtQue As New DataTable
'    '                    Sql = "SELECT TOP  " & maxQuestion & " * FROM Question_Master ORDER BY NEWID()"
'    '                    dtQue = Con.GetDataTable(Sql)
'    '                    Dim QuestionPaper_Detail As New clsQuestionpaper_Detail

'    '                    For j = 0 To dtQue.Rows.Count - 1
'    '                        QuestionPaper_Detail.init()
'    '                        QuestionPaper_Detail.Question_Id = dtQue.Rows(j).Item("Id")
'    '                        QuestionPaper_Detail.Question_No = Dt1.Rows(0).Item("Question_No")
'    '                        QuestionPaper_Detail.QuestionNo_Id = Dt1.Rows(0).Item("Id")
'    '                        QuestionPaper_Detail.Parent_QuestionNo = Dt1.Rows(0).Item("Question_No")
'    '                        QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt1.Rows(0).Item("Id"))
'    '                        QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
'    '                        QuestionPaper_Detail.Remark = "Sub"
'    '                        If QuestionPaper_Detail.Save = True Then

'    '                        End If
'    '                    Next

'    '                End If
'    '            Next
'    '            MsgBox("Question Paper saved successfully", MsgBoxStyle.Information, "Question")
'    '            ClearAll()
'    '        Else
'    '            MsgBox("Error while saving record", MsgBoxStyle.Critical, "Question")
'    '        End If
'    '    Catch ex As Exception
'    '        MsgBox("Error:" & ex.Message, MsgBoxStyle.Critical, "Question")
'    '    End Try
'    '    If QuestionPaper.Save = True Then
'    '        Sql = "Select  * from QuestionPaper_format where Format_Id=" & ddlFormat.SelectedValue
'    '        Sql = Sql & " and Parent_Question=0"
'    '        Dim Dt As New DataTable
'    '        Dt = Con.GetDataTable(Sql)
'    '        For i = 0 To Dt.Rows.Count - 1
'    '            If Val(Dt.Rows(i).Item("IS_Of_Same_Marks")) Then
'    '                '' code to get random question from database
'    '                '' no.of question : dt.rows(i).item("Max_question")
'    '                maxQuestion = (Dt.Rows(i).Item("Out_Of"))
'    '                Dim j As Integer
'    '                Dim dtQue As New DataTable
'    '                Sql = "SELECT TOP  " & maxQuestion & " * FROM Question_Master ORDER BY NEWID()"
'    '                dtQue = Con.GetDataTable(Sql)
'    '                Dim QuestionPaper_Detail As New clsQuestionpaper_Detail

'    '                For j = 0 To dtQue.Rows.Count - 1
'    '                    QuestionPaper_Detail.init()
'    '                    QuestionPaper_Detail.Question_Id = dtQue.Rows(j).Item("Id")
'    '                    QuestionPaper_Detail.Question_No = Dt.Rows(i).Item("Question_No")
'    '                    QuestionPaper_Detail.QuestionNo_Id = Dt.Rows(i).Item("Id")
'    '                    QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
'    '                    QuestionPaper_Detail.Parent_QuestionNo = Dt.Rows(i).Item("Parent_Question")
'    '                    QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt.Rows(i).Item("Parent_Question_Id"))
'    '                    QuestionPaper_Detail.Remark = "main"
'    '                    If QuestionPaper_Detail.Save = True Then

'    '                    End If
'    '                Next
'    '            Else
'    '                Sql = "Select  * from QuestionPaper_format where Format_Id=" & ddlFormat.SelectedValue
'    '                Sql = Sql & " and Id=" & Dt.Rows(i).Item("ID")
'    '                Dim Dt1 As New DataTable
'    '                Dt1 = Con.GetDataTable(Sql)
'    '                maxQuestion = (Dt.Rows(i).Item("Out_Of"))
'    '                Dim j As Integer
'    '                Dim dtQue As New DataTable
'    '                Sql = "SELECT TOP  " & maxQuestion & " * FROM Question_Master ORDER BY NEWID()"
'    '                dtQue = Con.GetDataTable(Sql)
'    '                Dim QuestionPaper_Detail As New clsQuestionpaper_Detail

'    '                For j = 0 To dtQue.Rows.Count - 1
'    '                    QuestionPaper_Detail.init()
'    '                    QuestionPaper_Detail.Question_Id = dtQue.Rows(j).Item("Id")
'    '                    QuestionPaper_Detail.Question_No = Dt1.Rows(0).Item("Question_No")
'    '                    QuestionPaper_Detail.QuestionNo_Id = Dt1.Rows(0).Item("Id")
'    '                    QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
'    '                    QuestionPaper_Detail.Parent_QuestionNo = Dt1.Rows(0).Item("Question_No")
'    '                    QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt1.Rows(0).Item("Id"))
'    '                    QuestionPaper_Detail.Remark = "Sub"
'    '                    If QuestionPaper_Detail.Save = True Then

'    '                    End If
'    '                Next
'    '            End If
'    '            MsgBox("Question Paper saved successfully", MsgBoxStyle.Information, "Question")
'    '            '  Response.Redirect("rptQuestionPaper.aspx?qid=" & QuestionPaper.Id)
'    '            ClearAll()
'    '        Next  
'    '    Else
'    '        MsgBox("Error while saving record", MsgBoxStyle.Critical, "Question")
'    '    End If
'    'Catch ex As Exception
'    '    MsgBox("Error:" & ex.Message, MsgBoxStyle.Critical, "Question")
'    'End Try


'    'End Sub
'    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
'        Try
'            If (Session.Item("UserName") Is Nothing) Or (Session.Item("UserName") = "") Then
'                Response.Redirect("Login2.aspx")
'            End If
'            If Not IsPostBack Then
'                hdnId.Value = 0
'                loadData()
'            End If
'            If (Not IsPostBack) Then
'                hdnId.Value = 0
'                LoadCombo()
'                loadData()
'            End If

'        Catch ex As Exception

'        End Try
'    End Sub
'    Private Sub LoadCombo()
'        Try
'            Dim sql As String
'            Dim Fun As New clsFunctions
'            sql = "select id,Name from Course_Master "
'            Fun.FillCombo(sql, ddlCourse)
'            sql = "select id,Name from Branch_Master "
'            Fun.FillCombo(sql, ddlBranch)
'            sql = "select id,sem from Semester_Master "
'            Fun.FillCombo(sql, ddlSem)
'            sql = "select id,Name from Subject_Master "
'            Fun.FillCombo(sql, ddlSubject)
'            '  sql = "select id,Name from Chapter_Master "
'            '  Fun.FillCombo(sql, ddlChpater)
'            sql = "select id,Name from PaperFormat "
'            Fun.FillCombo(sql, ddlFormat)

'        Catch ex As Exception

'        End Try
'    End Sub
'    Private Sub loadData()
'        Try
'            Dim ID As Long
'            ID = Val(Page.Request.QueryString("Id").ToString())
'            Dim QuestionPaper As New clsQuestionpaper_Master
'            QuestionPaper.Id = ID
'            QuestionPaper.GetById()
'            ddlBranch.SelectedValue = QuestionPaper.Branch_Id
'            'ddlCourse.SelectedValue = QuestionPaper.course_Id
'            ddlSem.SelectedValue = QuestionPaper.Sem_Id
'            'ddlChpater.SelectedValue = QuestionPaper.Chapter_Id
'            ddlSubject.SelectedValue = QuestionPaper.Subject_Id
'            ddlFormat.SelectedValue = QuestionPaper.Format_Id
'            hdnId.Value = ID
'            txtName.Text = QuestionPaper.Name
'            ' txtPassingMarks.Text = QuestionPaper.Passing_Marks
'            ' txtTotalMarks.Text = QuestionPaper.Total_Marks

'        Catch ex As Exception

'        End Try
'    End Sub
'    Private Sub ShowGrid()
'        Dim sql As String
'        Dim Con As New clsConnection
'        Dim Fun As New clsFunctions
'        Dim Dt As New DataTable
'        sql = "select * From Chapter_Master where Subject_ID= " & Fun.SQLNumber(ddlSubject.SelectedValue)
'        Dt = Con.GetDataTable(sql)
'        gvChapter.DataSource = Dt
'        gvChapter.DataBind()
'    End Sub
'    Private Sub ClearAll()

'        ddlBranch.SelectedIndex = 0
'        ddlCourse.SelectedIndex = 0
'        '    ddlChpater.SelectedIndex = 0
'        ddlFormat.SelectedIndex = 0
'        ddlSem.SelectedIndex = 0
'        ddlSubject.SelectedIndex = 0
'        '  txtPassingMarks.Text = " "
'        ' txtTotalMarks.Text = " "
'        txtName.Text = ""
'    End Sub

'    Protected Sub ddlSubject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubject.SelectedIndexChanged
'        ShowGrid()
'    End Sub
'End Class

Partial Class QuestionPaperEntry
    Inherits System.Web.UI.Page

    Dim Timetable As Integer

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Sql As String
        Dim Con As New clsConnection
        Dim Fun As New clsFunctions
        Dim maxQuestion As Integer = 0
        Dim ParentQuestionNo As Integer = 0
        Dim ParentQuestionNo_Id As Integer = 0
        Try
            'Dim Sql As String
            'Dim Con As New clsConnection
            Dim QuestionPaper As New clsQuestionpaper_Master
            QuestionPaper.init()
            QuestionPaper.Id = hdnId.Value
            QuestionPaper.Name = txtName.Text
            QuestionPaper.Branch_Id = ddlBranch.SelectedValue
            QuestionPaper.Format_Id = ddlFormat.SelectedValue
            'QuestionPaper.Course_Id = ddlCourse.SelectedValue
            QuestionPaper.Timetable_Id = getTimeTable()
            QuestionPaper.Sem_Id = ddlSem.SelectedValue
            QuestionPaper.Subject_Id = ddlSubject.SelectedValue

            Sql = "Select Total_Marks from PaperFormat where Id=" & Fun.SQLNumber(ddlFormat.SelectedValue)
            Dim total As Long
            total = Con.GetValue(Sql)
            QuestionPaper.Total_Marks = total

            Dim pass As Long
            pass = total * 40 / 100
            QuestionPaper.Passing_Marks = pass
            '((QuestionPaper.Total_Marks) * 40 / 100)
            'QuestionPaper.Passing_Marks =

            '       QuestionPaper.Total_Duration = txtTotalDuretion.Te
            If QuestionPaper.Save = True Then
                Sql = "Select  * from QuestionPaper_format where Format_Id=" & ddlFormat.SelectedValue
                Sql = Sql & " and Parent_Question=0"
                Dim Dt As New DataTable
                Dt = Con.GetDataTable(Sql)
                For i = 0 To Dt.Rows.Count - 1
                    If Val(Dt.Rows(i).Item("IS_Of_Same_Marks")) Then
                        '' code to get random question from database
                        '' no.of question : dt.rows(i).item("Max_question")
                        Dim j As Integer
                        Dim dtQue As New DataTable
                        Sql = "Select  * from QuestionPaper_format where Format_Id=" & ddlFormat.SelectedValue
                        Sql = Sql & " and Id=" & Dt.Rows(i).Item("ID")
                        Dim Dt1 As New DataTable
                        Dt1 = Con.GetDataTable(Sql)
                        maxQuestion = (Dt.Rows(i).Item("Out_Of"))
                        Sql = "SELECT TOP  " & maxQuestion & " * FROM Question_Master"
                        Sql = Sql & " where Marks=" & Fun.SQLNumber(Dt1.Rows(0).Item("Marks"))
                        Sql = Sql & " ORDER BY NEWID()" '' To..Do: Add where condition for marks
                        'Sql = "SELECT TOP  " & maxQuestion & " * FROM Question_Master ORDER BY NEWID()"
                        dtQue = Con.GetDataTable(Sql)
                        Dim QuestionPaper_Detail As New clsQuestionpaper_Detail
                        QuestionPaper_Detail.init()
                        QuestionPaper_Detail.Question_Id = dtQue.Rows(0).Item("Id")
                        QuestionPaper_Detail.Question_No = Dt.Rows(i).Item("Question_No")
                        QuestionPaper_Detail.QuestionNo_Id = Dt.Rows(i).Item("Id")
                        QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
                        QuestionPaper_Detail.Parent_QuestionNo = Dt.Rows(i).Item("Parent_Question")
                        QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt.Rows(i).Item("Parent_Question_Id"))
                        QuestionPaper_Detail.Heading = Dt1.Rows(0).Item("Heading")
                        QuestionPaper_Detail.Heading_Que = Dt.Rows(0).Item("Heading_Que")
                        QuestionPaper_Detail.Remark = "main"
                        If QuestionPaper_Detail.Save = True Then

                        End If
                        For j = 0 To dtQue.Rows.Count - 1
                            QuestionPaper_Detail.init()
                            QuestionPaper_Detail.Question_Id = dtQue.Rows(j).Item("Id")
                            QuestionPaper_Detail.Question_No = Dt.Rows(i).Item("Question_No")
                            QuestionPaper_Detail.QuestionNo_Id = Dt.Rows(i).Item("Id")
                            QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
                            QuestionPaper_Detail.Parent_QuestionNo = Dt.Rows(i).Item("Parent_Question")
                            QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt.Rows(i).Item("Parent_Question_Id"))
                            'QuestionPaper_Detail.Heading = Dt1.Rows(0).Item("Heading")
                            'QuestionPaper_Detail.Heading_Que = Dt.Rows(0).Item("Heading_Que")
                            QuestionPaper_Detail.Remark = "main"
                            If QuestionPaper_Detail.Save = True Then

                            End If
                        Next

                    Else
                        Sql = "Select  * from QuestionPaper_format where Format_Id=" & ddlFormat.SelectedValue
                        Sql = Sql & " and Id=" & Dt.Rows(i).Item("ID")
                        Dim Dt1 As New DataTable
                        Dt1 = Con.GetDataTable(Sql)
                        maxQuestion = (Dt.Rows(i).Item("Out_Of"))
                        Dim j As Integer
                        Dim dtQue As New DataTable
                        Sql = "SELECT TOP  " & maxQuestion & " * FROM Question_Master"
                        Sql = Sql & " where Marks=" & Fun.SQLNumber(Dt1.Rows(0).Item("Marks"))
                        Sql = Sql & " ORDER BY NEWID()" '' To..Do: Add where condition for marks
                        dtQue = Con.GetDataTable(Sql)
                        Dim QuestionPaper_Detail As New clsQuestionpaper_Detail
                        If Dt1.Rows(0).Item("Heading") <> "" Then
                            QuestionPaper.init()
                            QuestionPaper_Detail.Question_Id = dtQue.Rows(0).Item("Id")
                            QuestionPaper_Detail.Question_No = Dt1.Rows(0).Item("Question_No")
                            QuestionPaper_Detail.QuestionNo_Id = Dt1.Rows(0).Item("Id")
                            QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
                            QuestionPaper_Detail.Parent_QuestionNo = Dt1.Rows(0).Item("Question_No")
                            QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt1.Rows(0).Item("Id"))
                            QuestionPaper_Detail.Heading = Dt1.Rows(0).Item("Heading")
                            QuestionPaper_Detail.Heading_Que = Dt.Rows(0).Item("Heading_Que")
                            QuestionPaper_Detail.Remark = "Main"
                            If QuestionPaper_Detail.Save = True Then

                            End If
                        End If
                        For j = 0 To dtQue.Rows.Count - 1
                            QuestionPaper_Detail.init()
                            QuestionPaper_Detail.Question_Id = dtQue.Rows(j).Item("Id")
                            QuestionPaper_Detail.Question_No = j + 1 'Dt1.Rows(0).Item("Question_No")
                            QuestionPaper_Detail.QuestionNo_Id = Dt1.Rows(0).Item("Id")
                            QuestionPaper_Detail.Questionpaper_Id = QuestionPaper.Id
                            QuestionPaper_Detail.Parent_QuestionNo = Dt1.Rows(0).Item("Question_No")
                            QuestionPaper_Detail.Parent_QuestionNo_Id = Val(Dt1.Rows(0).Item("Id"))

                            QuestionPaper_Detail.Remark = "Sub"
                            If QuestionPaper_Detail.Save = True Then

                            End If
                        Next

                    End If
                Next
                MesgBox("Question Paper saved successfully")
                Response.Redirect("~/ReportsPrint/rpQuestionPaper.aspx?qid=" & QuestionPaper.Id)
                ClearAll()
            Else
                MesgBox("Error while saving record")
            End If
        Catch ex As Exception
            ' MsgBox("Error:" & ex.Message, MsgBoxStyle.Critical, "Question")
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
            sql = "select id,Name from Branch_Master "
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch---")
            sql = "select id,sem from Semester_Master "
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")
            sql = "select id,Name from Subject_Master "
            Fun.FillCombo(sql, ddlSubject)
            ddlSubject.Items.Insert(0, "---Select Subject---")
            sql = "select id,Name from Exam_Master "
            Fun.FillCombo(sql, ddlExam)
            ddlExam.Items.Insert(0, "---Select Exam---")
            sql = "select id,Name from PaperFormat "
            Fun.FillCombo(sql, ddlFormat)
            ddlFormat.Items.Insert(0, "---Select Paper Format---")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim QuestionPaper As New clsQuestionpaper_Master
            QuestionPaper.Id = ID
            QuestionPaper.GetById()
            ddlBranch.SelectedValue = QuestionPaper.Branch_Id
            'ddlCourse.SelectedValue = QuestionPaper.course_Id
            ddlSem.SelectedValue = QuestionPaper.Sem_Id
            'ddlTimeTable.SelectedValue = QuestionPaper.Timetable_Id
            ddlSubject.SelectedValue = QuestionPaper.Subject_Id
            ddlFormat.SelectedValue = QuestionPaper.Format_Id
            hdnId.Value = ID
            txtName.Text = QuestionPaper.Name
            ' txtPassingMarks.Text = QuestionPaper.Passing_Marks
            ' txtTotalMarks.Text = QuestionPaper.Total_Marks
            txtTotalDuretion.Text = QuestionPaper.Total_Duration
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ShowGrid()
        Dim sql As String
        Dim Con As New clsConnection
        Dim Fun As New clsFunctions
        Dim Dt As New DataTable
        sql = "select * From Chapter_Master where Subject_ID= " & Fun.SQLNumber(ddlSubject.SelectedValue)
        Dt = Con.GetDataTable(sql)
        gvChapter.DataSource = Dt
        gvChapter.DataBind()
    End Sub
    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlCourse.SelectedIndex = 0
        'ddlTimeTable.SelectedIndex = 0
        ddlExam.SelectedValue = 0
        ddlFormat.SelectedIndex = 0
        ddlSem.SelectedIndex = 0
        ddlSubject.SelectedIndex = 0
        '  txtPassingMarks.Text = " "
        ' txtTotalMarks.Text = " "
        txtName.Text = ""
        txtTotalDuretion.Text = ""
    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubject.SelectedIndexChanged
        ShowGrid()
    End Sub

    Protected Sub ddlExam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExam.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        Dim Con As New clsConnection
        sql = "select Id from Timetable_Master where Branch_ID=" & ddlBranch.SelectedValue
        sql = sql & " and Sem_ID= " & ddlSem.SelectedValue
        sql = sql & " and Exam_ID=" & ddlExam.SelectedValue
        Timetable = Con.GetValue(sql)
    End Sub
    'Protected Sub ddlsem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSem.SelectedIndexChanged()
    '    Dim sql As String
    '    Dim Fun As New clsFunctions
    '    Dim Con As New clsConnection
    '    sql = "select Id from Timetable_Master where Branch_ID=" & ddlBranch.SelectedValue
    '    sql = sql & " and Sem_ID= " & ddlSem.SelectedValue
    '    sql = sql & " and Exam_ID=" & ddlExam.SelectedValue
    '    Timetable = Con.GetValue(sql)
    'End Sub


    Private Function getTimeTable()
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            sql = "select Id from Timetable_Master where Branch_ID=" & ddlBranch.SelectedValue
            sql = sql & " and Sem_ID= " & ddlSem.SelectedValue
            sql = sql & " and Exam_ID=" & ddlExam.SelectedValue
            getTimeTable = Con.GetValue(sql)
        Catch ex As Exception
            getTimeTable = 0
        End Try
    End Function
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
        sql = "select Id,Sem from Semester_Master where Branch_ID =" & ddlBranch.SelectedValue & " "
        Fun.FillCombo(sql, ddlSem)

    End Sub
End Class
