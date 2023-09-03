
Partial Class ClassEntry
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim classE As New clsClass_Master
            classE.init()
            classE.Id = hdnId.Value
            classE.Class_No = txtName.Text
            classE.Number_Of_Benches = txtNumberOfBenches.Text
            classE.Student_Per_Bench = txtstudentPerBenches.Text
            classE.Remark = txtRemark.Text
            If Not is_Valid() Then Exit Sub
            If classE.Save = True Then
                MesgBox("Class saved successfully")
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

        Catch ex As Exception
            MesgBox("Error:" & ex.Message)
        End Try
    End Sub

    Private Sub loadData()
        Try
            Dim ID As Long
            ID = Val(Page.Request.QueryString("Id").ToString())
            Dim classE As New clsClass_Master
            classE.Id = ID
            hdnId.Value = ID
            classE.GetById()
            txtName.Text = classE.Class_No
            txtNumberOfBenches.Text = classE.Number_Of_Benches
            txtstudentPerBenches.Text = classE.Student_Per_Bench
            txtRemark.Text = classE.Remark

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
                sql = "select count(*) from Class_Master where Class_No=" & Fun.SQLString(txtName.Text)
                sql = sql & " and Number_Of_Benches=" & Fun.SQLString(txtNumberOfBenches.Text)
                sql = sql & " and Student_Per_Benches=" & Fun.SQLString(txtstudentPerBenches.Text)
                sql = sql & " and id<>" & Fun.SQLNumber(hdnId.Value)
            Else
                sql = "select count(*) from Class_Master where Class_No=" & Fun.SQLString(txtName.Text)
                sql = sql & " and Number_Of_Benches=" & Fun.SQLString(txtNumberOfBenches.Text)
                sql = sql & " and Student_Per_Benches=" & Fun.SQLString(txtstudentPerBenches.Text)
            End If
            If con.GetValue(sql) >= 1 Then
                MesgBox("Class already available")
                txtName.Focus()
                is_Valid = False
            End If

        Catch ex As Exception
            is_Valid = False
        End Try
    End Function
    Private Sub ClearAll()

        txtName.Text = " "
        txtNumberOfBenches.Text = " "
        txtstudentPerBenches.Text = " "
        txtRemark.Text = " "
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class
