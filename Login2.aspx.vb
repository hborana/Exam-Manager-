Imports System.IO
Imports System.Net
Imports System.Net.Mail
Partial Class Login2
    Inherits System.Web.UI.Page

    Dim m_Id As Long
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Try
            Dim sql As String
            Dim Con As New clsConnection
            Dim Dt As New DataTable
            Dim Fun As New clsFunctions
            hdnId.Value = m_Id
            sql = "Select * from Login_Master"
            sql = sql & " where user_name= " & Fun.SQLString(txtName.Text)
            sql = sql & " and password= " & Fun.SQLString(txtPassword.Text)

            'sql = "Select * from Login_Master"

            Dt = Con.GetDataTable(sql)
            If Dt.Rows.Count >= 1 Then

                Session.Add("UserName", txtName.Text)
                Session.Add("Faculty_ID", Dt.Rows(0).Item("Faculty_ID"))
                Session.Add("Student_ID", Dt.Rows(0).Item("Student_ID"))

                Session.Add("Role_Id", Dt.Rows(0).Item("role_id"))
                Response.Redirect("Dashboard.aspx")
                'txt_un.Text = Dt.Rows(0).Item("user_name").ToString
                'txt_pass.Text = Dt.Rows(0).Item("password").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub sendemail()
        Dim mm As New MailMessage()
        'If fuattachment.hasfile Then
        ' Dim filename As String = Path.GetFileName(fuattachment.postedfile.filename)
        ' mm.Attachments.Add(New Attachment(fuattachment.postedfile.inputstream, filename))
        ' End If
        Dim smtp As New SmtpClient("smtp.gmail.com")
        mm.From = New MailAddress("exammanager06@gmail.com")
        mm.To.Add(txtName.Text)
        mm.Subject = "Your password reset link"
        mm.IsBodyHtml = True
        mm.Body = "Click on following link to reset you password : <BR/><a href= ""PMTool.com\ForgetPass_Student.aspx?sid=" & txtName.Text & """> Reset Your Password</a>"
        'smtp.Host = "smtp.gmail.com"
        smtp.EnableSsl = True
        'Dim networkcred As New NetworkCredential("projectmanagmenttoolforcollege@gmail.com", "Amaan@123")
        'smtp.UseDefaultCredentials = True
        smtp.Credentials = New System.Net.NetworkCredential("exammanager06@gmail.com", "ExamManager2017")
        smtp.Port = 465
        smtp.Port = 587
        smtp.Send(mm)

        ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('email sent.');", True)

    End Sub

    Protected Sub lblnkForgot_Click(sender As Object, e As EventArgs) Handles lnkForgot.Click
        If Trim(txtName.Text) = "" Then
            MesgBox("Plesae fill username first")
            Exit Sub
        End If
        sendemail()
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        chkLogout()
        If (Not Session.Item("UserName") Is Nothing) And (Session.Item("UserName") <> "") Then
            Response.Redirect("Dashboard.aspx")
        End If
    End Sub
    Private Sub chkLogout()
        Try
            If Not Request.QueryString("lgout") Is Nothing Then

                Session.Clear()
                Session.Item("UserName") = ""
                Session.Item("Faculty_ID") = ""
                Session.Item("Student_ID") = ""
                Session.Item("Role_Id") = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
