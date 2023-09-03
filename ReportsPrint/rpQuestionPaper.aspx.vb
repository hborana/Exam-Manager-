Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class ReportsPrint_rpQuestionPaper
    Inherits System.Web.UI.Page
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            If Not Request.QueryString("qid1") Is Nothing Then
                CrystalReportSource1.ReportDocument.SetParameterValue("QueId", Request.QueryString("qid1").ToString())
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim crvRpt As New ReportDocument
            If Not Request.QueryString("qid") Is Nothing Then
                Dim sql As String
                Dim Con As New clsConnection
                Dim Dt As New DataTable
                Dim Fun As New clsFunctions
                Dim QueId As Integer
                Dim Dt1 As New DataTable
                sql = "Delete from rptQuestionPaper"
                Con.ExecQuery(sql)
                QueId = Request.QueryString("qid")
                sql = "select qd.* ,q.*"
                sql = sql & " from"
                sql = sql & " QuestionPaper_Detail qd,"
                sql = sql & " Question_Master q"
                sql = sql & " where"
                sql = sql & " qd.Question_ID = q.Id"
                sql = sql & " and  qd.Parent_QuestionNo =0"
                sql = sql & " and qd.QuestionPaper_Id=" & QueId
                sql = sql & " order by qd.Parent_QuestionNo ,"
                sql = sql & " qd.QuestionNo,"
                sql = sql & " qd.Id"

                Dt = Con.GetDataTable(sql)
                Dim i As Integer
                For i = 0 To Dt.Rows.Count - 1
                    sql = "select qd.* ,q.*"
                    sql = sql & " from"
                    sql = sql & " QuestionPaper_Detail qd,"
                    sql = sql & " Question_Master q"
                    sql = sql & " where"
                    sql = sql & " qd.Question_ID = q.Id"
                    sql = sql & " and  qd.Parent_QuestionNo_Id=" & Dt.Rows(i).Item("Question_Id")
                    sql = sql & " and qd.QuestionPaper_Id=" & QueId
                    sql = sql & " order by qd.Parent_QuestionNo ,"
                    sql = sql & " qd.QuestionNo,"
                    sql = sql & " qd.Id"
                    Dt1 = Con.GetDataTable(sql)
                    Dim rpQuePaper As New clsrptQuestionPaper
                    Dim x As Integer = 0
                    If Dt1.Rows.Count >= 1 Then
                        rpQuePaper.init()
                        rpQuePaper.QueNo = Dt.Rows(i).Item("Heading_Que")
                        rpQuePaper.Question = Dt.Rows(i).Item("Heading")
                        rpQuePaper.Marks = 0
                        rpQuePaper.Save()
                        For j = 0 To Dt1.Rows.Count - 1
                            ''Code to save in tmptable
                            rpQuePaper.init()
                            rpQuePaper.QueNo = j + 1
                            rpQuePaper.Question = Dt1.Rows(j).Item("Question")
                            rpQuePaper.Marks = Dt1.Rows(j).Item("Marks")
                            rpQuePaper.Save()
                        Next
                    Else
                        Dim tmp As Integer
                        ''Code to save in tmptable
                        If Convert.ToString(Dt.Rows(i).Item("Heading")) <> "" Then
                            rpQuePaper.init()
                            rpQuePaper.QueNo = Convert.ToString(Dt.Rows(i).Item("Heading"))
                            rpQuePaper.Question = Convert.ToString(Dt.Rows(i).Item("Heading_Que"))
                            rpQuePaper.Marks = 0 'Val(Dt.Rows(i).Item("Marks") & "")
                            rpQuePaper.Save()
                            tmp = 1
                        Else
                            rpQuePaper.init()
                            rpQuePaper.QueNo = tmp ''Convert.ToString(Dt.Rows(i).Item("QuestionNo"))
                            tmp = tmp + 1
                            rpQuePaper.Question = Convert.ToString(Dt.Rows(i).Item("Question"))
                            rpQuePaper.Marks = Val(Dt.Rows(i).Item("Marks") & "")
                            rpQuePaper.Save()
                        End If
                    End If
                Next

                Response.Redirect("rpQuestionPaper.aspx?qid1=" & QueId)

            End If
            'Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
            '    Try
            '        If Not Request.QueryString("qid1") Is Nothing Then
            '            CrystalReportSource1.ReportDocument.SetParameterValue("QueId", Request.QueryString("qid1").ToString())
            '        End If
            '    Catch ex As Exception

            '    End Try
            'End Sub

            'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            '    Try
            '        Dim crvRpt As New ReportDocument
            '        If Not Request.QueryString("qid") Is Nothing Then
            '            Dim sql As String
            '            Dim Con As New clsConnection
            '            Dim Dt As New DataTable
            '            Dim Fun As New clsFunctions
            '            Dim QueId As Integer
            '            Dim Dt1 As New DataTable
            '            sql = "Delete from rptQuestionPaper"
            '            Con.ExecQuery(sql)
            '            QueId = Request.QueryString("qid")
            '            sql = "select qd.* ,q.*"
            '            sql = sql & " from"
            '            sql = sql & " QuestionPaper_Detail qd,"
            '            sql = sql & " Question_Master q"
            '            sql = sql & " where"
            '            sql = sql & " qd.Question_ID = q.Id"
            '            sql = sql & " and  qd.Parent_QuestionNo =0"
            '            sql = sql & " and qd.QuestionPaper_Id=" & QueId
            '            sql = sql & " order by qd.Parent_QuestionNo ,"
            '            sql = sql & " qd.QuestionNo,"
            '            sql = sql & " qd.Id"

            '            Dt = Con.GetDataTable(sql)
            '            Dim i As Integer
            '            For i = 0 To Dt.Rows.Count - 1
            '                sql = "select qd.* ,q.*"
            '                sql = sql & " from"
            '                sql = sql & " QuestionPaper_Detail qd,"
            '                sql = sql & " Question_Master q"
            '                sql = sql & " where"
            '                sql = sql & " qd.Question_ID = q.Id"
            '                sql = sql & " and  qd.Parent_QuestionNo_Id=" & Dt.Rows(i).Item("Question_Id")
            '                sql = sql & " and qd.QuestionPaper_Id=" & QueId
            '                sql = sql & " order by qd.Parent_QuestionNo ,"
            '                sql = sql & " qd.QuestionNo,"
            '                sql = sql & " qd.Id"
            '                Dt1 = Con.GetDataTable(sql)
            '                Dim rpQuePaper As New clsrptQuestionPaper
            '                If Dt1.Rows.Count >= 1 Then
            '                    rpQuePaper.init()
            '                    rpQuePaper.QueNo = Dt.Rows(i).Item("QuestionNo")
            '                    rpQuePaper.Question = Dt.Rows(i).Item("Question")
            '                    rpQuePaper.Marks = 0
            '                    rpQuePaper.Save()
            '                    For j = 0 To Dt1.Rows.Count - 1
            '                        ''Code to save in tmptable
            '                        rpQuePaper.init()
            '                        rpQuePaper.QueNo = Dt1.Rows(j).Item("QuestionNo")
            '                        rpQuePaper.Question = Dt1.Rows(j).Item("Question")
            '                        rpQuePaper.Marks = Dt1.Rows(j).Item("Marks")
            '                        rpQuePaper.Save()
            '                    Next
            '                Else
            '                    ''Code to save in tmptable
            '                    rpQuePaper.init()
            '                    rpQuePaper.QueNo = Dt.Rows(i).Item("QuestionNo")
            '                    rpQuePaper.Question = Dt.Rows(i).Item("Question")
            '                    rpQuePaper.Marks = Dt.Rows(i).Item("Marks")
            '                    rpQuePaper.Save()
            '                End If
            '            Next

            '            ' Response.Redirect("rpQuestionPaper.aspx?qid1=" & QueId)

            '        End If
            'crvRpt.Load("E:\project\ExamManagerNew\Reports\rptQuestionPaper.rpt")
            'CrystalReportViewer1.ReportSource = crvRpt
            'CrystalReportViewer1.RefreshReport()


        Catch ex As Exception

        End Try
    End Sub
End Class
