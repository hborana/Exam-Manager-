Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
'Imports System.IO
'Imports System.Data
'Imports ClosedXML.Excel
'Imports System.Configuration
'Imports System.Data.SqlClient
'Imports System.Web.UI.WebControls

Partial Class QuestionEntry
    Inherits System.Web.UI.Page

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Try
            If FileUpload1.HasFile Then

                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)

                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)

                Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")



                Dim FilePath As String = Server.MapPath(FolderPath + FileName)

                FileUpload1.SaveAs(FilePath)

                Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)

                Dim Question As New clsQuestion_Master
                For i = 0 To gvUpload.Rows.Count - 1
                    Question.init()
                    ' Question.Format_Id = ddlFormat.SelectedValue
                    Question.Branch_Id = ddlBranch.SelectedValue
                    Question.Chapter_ID = ddlChapter.SelectedValue
                    Question.Sem_Id = ddlSem.SelectedValue
                    Question.Subject_Id = ddlSubject.SelectedValue

                    '    Question.Question = gvUpload.Rows(i).DataItem("Question")
                    Dim que As Label
                    que = DirectCast(gvUpload.Rows(i).FindControl("lblQuestion"), Label)
                    Question.Question = que.Text

                    '  Question.Marks = gvUpload.Rows(i).Cells("Marks").Text
                    Dim mar As Label
                    mar = DirectCast(gvUpload.Rows(i).FindControl("lblMarks"), Label)
                    Question.Marks = mar.Text

                    If Question.Save Then
                        MesgBox("Question saved successfully")
                    Else
                        MesgBox("Error while saving record")
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("Please Upload Proper Format Excel File", MsgBoxStyle.Critical, "Question")
        End Try


    End Sub
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)

        Dim conStr As String = ""

        Select Case Extension

            Case ".xls"

                'Excel 97-03

                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString()

                Exit Select

            Case ".xlsx"

                'Excel 07

                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString()

                Exit Select

        End Select

        conStr = String.Format(conStr, FilePath, isHDR)



        Dim connExcel As New OleDbConnection(conStr)

        Dim cmdExcel As New OleDbCommand()

        Dim oda As New OleDbDataAdapter()

        Dim dt As New DataTable()



        cmdExcel.Connection = connExcel



        'Get the name of First Sheet

        connExcel.Open()

        Dim dtExcelSchema As DataTable

        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()

        connExcel.Close()



        'Read Data from First Sheet

        connExcel.Open()

        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"

        oda.SelectCommand = cmdExcel

        oda.Fill(dt)

        connExcel.Close()


        gvUpload.Caption = Path.GetFileName(FilePath)

        gvUpload.DataSource = dt

        gvUpload.DataBind()

    End Sub

    'Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

    '    Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")

    '    Dim FileName As String = gvUpload.Caption

    '    Dim Extension As String = Path.GetExtension(FileName)

    '    Dim FilePath As String = Server.MapPath(FolderPath + FileName)



    '    Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)

    '    gvUpload.PageIndex = e.NewPageIndex

    '    gvUpload.DataBind()

    'End Sub
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
            sql = "select id,Name from PaperFormat "
            'Fun.FillCombo(sql, ddlFormat)
            'ddlFormat.Items.Insert(0, "---Select Format---")
            sql = "select id,Name from Subject_Master "
            Fun.FillCombo(sql, ddlSubject)
            ddlSubject.Items.Insert(0, "---Select Subject---")
            sql = "select id,Name from Branch_Master "
            Fun.FillCombo(sql, ddlBranch)
            ddlBranch.Items.Insert(0, "---Select Branch---")
            sql = "select id,Name from Chapter_Master "
            Fun.FillCombo(sql, ddlChapter)
            ddlChapter.Items.Insert(0, "---Select Chapter---")
            sql = "select id,Name from Semester_Master "
            Fun.FillCombo(sql, ddlSem)
            ddlSem.Items.Insert(0, "---Select Semester---")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim Question As New clsQuestion_Master
            Question.Id = ID
            Question.GetById()
            hdnId.Value = ID
            '    ddlFormat.SelectedValue = Question.Format_Id
            ddlBranch.SelectedValue = Question.Branch_Id
            ddlSem.SelectedValue = Question.Sem_Id
            ddlSubject.SelectedValue = Question.Subject_Id
            ddlChapter.SelectedValue = Question.Chapter_ID
            '   txtMarks.Text = Question.Marks
            '  txtQuestion.Text = Question.Question
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
                sql = "select count(*) from Question_Master where Subject_ID=" & Fun.SQLString(ddlSubject.Text)
                ' sql = sql & " and Marks=" & Fun.SQLString(txtMarks.Text)
                sql = sql & " and Chapter_ID=" & Fun.SQLString(ddlChapter.Text)
                '  sql = sql & " and Question=" & Fun.SQLString(txtQuestion.Text)
                sql = sql & " and Sem_ID=" & Fun.SQLString(ddlSem.Text)
                sql = sql & " and Branch_ID=" & Fun.SQLString(ddlBranch.Text)
                '       sql = sql & " and Format_ID=" & Fun.SQLString(ddlFormat.Text)
                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Question_Master where Subject_ID=" & Fun.SQLString(ddlSubject.Text)
                ' sql = sql & " and Marks=" & Fun.SQLString(txtMarks.Text)
                sql = sql & " and Chapter_ID=" & Fun.SQLString(ddlChapter.Text)
                '  sql = sql & " and Question=" & Fun.SQLString(txtQuestion.Text)
                sql = sql & " and Sem_ID=" & Fun.SQLString(ddlSem.Text)
                sql = sql & " and Branch_ID=" & Fun.SQLString(ddlBranch.Text)
                '      sql = sql & " and Format_ID=" & Fun.SQLString(ddlFormat.Text)

            End If
            If con.GetValue(sql) >= 1 Then
                MesgBox("Question already Exist")
                ' txtQuestion.Focus()
                is_Valid = False
            End If

        Catch ex As Exception
            is_Valid = False
        End Try
    End Function
    Private Sub ClearAll()

        ddlBranch.SelectedIndex = 0
        ddlChapter.SelectedIndex = 0
        'ddlFormat.SelectedIndex = 0
        ddlSubject.SelectedIndex = 0
        ddlSem.SelectedIndex = 0
        ' txtMarks.Text = " "
        ' txtQuestion.Text = " "
    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubject.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Name from Chapter_Master where Subject_ID=" & ddlSubject.SelectedValue & " "
        Fun.FillCombo(sql, ddlChapter)
    End Sub

    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Sem from Semester_Master where Branch_ID=" & ddlBranch.SelectedValue & " "
        Fun.FillCombo(sql, ddlSem)
    End Sub
    Protected Sub ddlSem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSem.SelectedIndexChanged
        Dim sql As String
        Dim Fun As New clsFunctions
        sql = "select Id,Name from Subject_Master where Branch_ID=" & ddlBranch.SelectedValue
        sql = sql & "and Sem_ID= " & ddlSem.SelectedValue
        Fun.FillCombo(sql, ddlSubject)
    End Sub
    'Dim sql As String
    'Dim Con As clsConnection
    ' Dim Fun As clsFunctions
    'Dim dt As New DataTable()
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click


        Response.ClearContent()
        Response.Buffer = True
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "QuestionFormat.xls"))
        Response.ContentType = "application/ms-excel"

        'sql = "select * from ExcelQuestion "
        'dt = Con.GetDataTable(sql)
        Dim dt As DataTable = BindDatatable()
        Dim str As String = String.Empty
        For Each dtcol As DataColumn In dt.Columns
            Response.Write(str + dtcol.ColumnName)
            str = vbTab
        Next
        Response.Write(vbLf)
        For Each dr As DataRow In dt.Rows
            str = ""
            For j As Integer = 0 To dt.Columns.Count - 1
                Response.Write(str & Convert.ToString(dr(j)))
                str = vbTab
            Next
            Response.Write(vbLf)
        Next
        Response.[End]()


        'Dim strFilePath As String
        'strFilePath = "E:\project2\ExamManagerold\Download\QuestioFormat.xlsx"
        'Download_File(strFilePath)

    End Sub
    Protected Function BindDatatable() As DataTable
        Dim dt As New DataTable()

        dt.Columns.Add("Question", GetType(String))
        dt.Columns.Add("Marks", GetType(Integer))

        dt.Rows.Add("hi", "5")
        dt.Rows.Add("hight", "58")

        Return dt
    End Function
    'Private Sub Download_File(FilePath As String)

    '    Response.ContentType = ContentType
    '    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(FilePath))
    '    'Response.WriteFile(FilePath)
    '    Response.End()
    'End Sub
    '    Protected Sub ExportExcel(sender As Object, e As EventArgs)
    '        Dim sql As String
    '        Dim Con As clsConnection
    '        Dim Fun As clsFunctions
    '        Dim dt As New DataTable()
    '        sql = "select * from ExcelQuestion"
    '        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    '        'Using con As New SqlConnection(constr)
    '        '    Using cmd As New SqlCommand("SELECT * FROM Customers")
    '        '        Using sda As New SqlDataAdapter()
    '        '            cmd.Connection = con
    '        '            sda.SelectCommand = cmd
    '        '            Using dt As New DataTable()
    '        '  sda.Fill(dt)
    '        dt = Con.GetDataTable(sql)

    '        Using wb As New XLWorkbook()
    '            wb.Worksheets.Add(dt, "Question")
    'End Using
    '            '    Response.Clear()
    '            '    Response.Buffer = True
    '            '    Response.Charset = ""
    '            '    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    '            '    Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx")
    '            '    Using MyMemoryStream As New MemoryStream()
    '            '        wb.SaveAs(MyMemoryStream)
    '            '        MyMemoryStream.WriteTo(Response.OutputStream)
    '            '        Response.Flush()
    '            '        Response.End()
    '            '    End Using
    '            'End Using
    '            '            End Using
    '            '        End Using
    '            '    End Using
    '            'End Using
    '  End Sub

    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
