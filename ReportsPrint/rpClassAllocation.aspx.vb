
Partial Class ReportsPrint_rpClassAllocation
    Inherits System.Web.UI.Page
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            If Not Request.QueryString("sid1") Is Nothing Then
                CrystalReportSource1.ReportDocument.SetParameterValue("CId", Request.QueryString("sid1").ToString())
            End If
        Catch ex As Exception

        End Try
    End Sub

   
End Class
