
Partial Class ReportsPrint_rpTimeTable
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            If Not Request.QueryString("tid1") Is Nothing Then
                CrystalReportSource1.ReportDocument.SetParameterValue("BId", Request.QueryString("tid1").ToString())
                CrystalReportSource1.ReportDocument.SetParameterValue("SId", Request.QueryString("tid1").ToString())
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
