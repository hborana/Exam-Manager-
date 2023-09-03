Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class ReportsPrint_rpCourseList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Dim crvRpt As New ReportDocument
            crvRpt.Load("E:\project\ExamManagerNew\Reports\rptCourseList.rpt")
            CrystalReportViewer1.ReportSource = crvRpt
            CrystalReportViewer1.RefreshReport()


        Catch ex As Exception

        End Try
    End Sub
End Class
