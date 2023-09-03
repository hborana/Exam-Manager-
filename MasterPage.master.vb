
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sql As String
            Dim Con As New clsConnection
            Dim Fun As New clsFunctions
            sql = "Select Name from Faculty_Master where Id=" & Session("Faculty_Id")
            lblLoginName.Text = Con.GetValue(sql)
            sql = "Select Name from Role_Master where Id=" & Session("Role_Id")
            lblLoginDes.Text = Con.GetValue(sql)

            LoadSideBar()
            LoadNotification()
        End If
    End Sub

    Private Sub LoadSideBar()
        Dim RolePrev As New clsRolePrev
        RolePrev.Role_Id = Val(Session.Item("Role_Id") & "")
        RolePrev.init()
        lblBranchEntry.Visible = RolePrev.FLG_BRANCH_ENTRY
        If RolePrev.FLG_COURSE_ENTRY = True Or RolePrev.FLG_COURSE_VIEW = True Then
            Li4.Visible = True
        Else
            Li4.Visible = False
        End If
        lblBranchList.Visible = RolePrev.FLG_BRANCH_VIEW
        lblCourseEntry.Visible = RolePrev.FLG_COURSE_ENTRY
        lblCourseList.Visible = RolePrev.FLG_COURSE_VIEW
        lblStudentEntry.Visible = RolePrev.FLG_STUDENT_ENTRY
        lblStudentList.Visible = RolePrev.FLG_STUDENT_VIEW
        lblFacultyEntry.Visible = RolePrev.FLG_FACULTY_ENTRY
        lblFacultyList.Visible = RolePrev.FLG_FACULTY_VIEW
        lblSubjectEntry.Visible = RolePrev.FLG_SUBJECT_ENTRY
        lblSubjectList.Visible = RolePrev.FLG_SUBJECT_VIEW
        lblChapterEntry.Visible = RolePrev.FLG_CHAPTER_ENTRY
        lblChapterList.Visible = RolePrev.FLG_CHAPTER_VIEW
        lblQuestionEntry.Visible = RolePrev.FLG_QUESTION_ENTRY
        lblQuestionList.Visible = RolePrev.FLG_QUESTION_VIEW
        lblQuestionPaperEntry.Visible = RolePrev.FLG_QUESTIONPAPER_ENTRY
        lblQuestionPaperList.Visible = RolePrev.FLG_QUESTIONPAPER_VIEW
        lblClassAllocationEntry.Visible = RolePrev.FLG_CLASSALLOCATION_ENTRY
        lblClassAllocationList.Visible = RolePrev.FLG_CLASSALLOCATION_VIEW
        lblFacultyAllocationEntry.Visible = RolePrev.FLG_FACULTYALLOCATION_ENTRY
        lblFacultyAllocationList.Visible = RolePrev.FLG_FACULTYALLOCATION_VIEW
        lblFormatEntry.Visible = RolePrev.FLG_FORMAT_ENTRY
        lblFormatList.Visible = RolePrev.FLG_FORMAT_VIEW
        lblExamEntry.Visible = RolePrev.FLG_EXAM_ENTRY
        lblExamList.Visible = RolePrev.FLG_EXAM_VIEW
        lblTimeTableEntry.Visible = RolePrev.FLG_TIMETABLE_ENTRY
        lblTimeTableList.Visible = RolePrev.FLG_TIMETABLE_VIEW


    End Sub
    Private Sub LoadNotification()
        Try
            Dim sql As String
            Dim Con As New clsConnection
            Dim Fun As New clsFunctions
            sql = "Select * from notification where to_Whom=" & Session.Item("Faculty_Id")
            sql = sql & " and isShown=0"
            Dim dt As New DataTable
            dt = Con.GetDataTable(sql)
            Dim str As String
            For i = 0 To dt.Rows.Count - 1
                Dim lbl As New Label
                'Dim img As New Image
                'sql = "Select * from "

                str = "<img src=""pictures/exam.png"" height=""30"" width=""30""s ><a href="""
                str = str & dt.Rows(i).Item("Redirection_Page") & "?" & dt.Rows(i).Item("Redirection_Field") & "=" & dt.Rows(i).Item("Redirection_Value")
                str = str & """> " & dt.Rows(i).Item("Message") & " </a><br />"
                Dim Spacer1 As LiteralControl = New LiteralControl(str)

                Dim SpacerBr As LiteralControl = New LiteralControl("<br />")

                Dim lb As New LinkButton
                lb.Text = dt.Rows(i).Item("Message")
                lb.PostBackUrl = str
                'lbl.Text = dt.Rows(i).Item("Message")
                'panelNoti.Controls.Add()
                panelNoti.Controls.Add(Spacer1)
                'panelNoti.Controls.Add(SpacerBr)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class


