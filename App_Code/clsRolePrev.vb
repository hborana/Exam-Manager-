Imports Microsoft.VisualBasic

Public Class clsRolePrev
    Dim m_FLG_STUDENT_ENTRY As Boolean
    Dim m_FLG_STUDENT_VIEW As Boolean
    Dim m_FLG_STUDENT_EDIT As Boolean
    Dim m_FLG_STUDENT_DELETE As Boolean
    Dim m_FLG_FACULTY_ENTRY As Boolean
    Dim m_FLG_FACULTY_VIEW As Boolean
    Dim m_FLG_FACULTY_EDIT As Boolean
    Dim m_FLG_FACULTY_DELETE As Boolean
    Dim m_FLG_BRANCH_ENTRY As Boolean
    Dim m_FLG_BRANCH_VIEW As Boolean
    Dim m_FLG_BRANCH_EDIT As Boolean
    Dim m_FLG_BRANCH_DELETE As Boolean
    Dim m_FLG_COURSE_ENTRY As Boolean
    Dim m_FLG_COURSE_VIEW As Boolean
    Dim m_FLG_COURSE_EDIT As Boolean
    Dim m_FLG_COURSE_DELETE As Boolean
    Dim m_FLG_FORMAT_ENTRY As Boolean
    Dim m_FLG_FORMAT_VIEW As Boolean
    Dim m_FLG_FORMAT_EDIT As Boolean
    Dim m_FLG_FORMAT_DELETE As Boolean
    Dim m_FLG_SUBJECT_ENTRY As Boolean
    Dim m_FLG_SUBJECT_VIEW As Boolean
    Dim m_FLG_SUBJECT_EDIT As Boolean
    Dim m_FLG_SUBJECT_DELETE As Boolean
    Dim m_FLG_CHAPTER_ENTRY As Boolean
    Dim m_FLG_CHAPTER_EDIT As Boolean
    Dim m_FLG_CHAPTER_VIEW As Boolean
    Dim m_FLG_CHAPTER_DELETE As Boolean
    Dim m_FLG_EXAM_ENTRY As Boolean
    Dim m_FLG_EXAM_VIEW As Boolean
    Dim m_FLG_EXAM_EDIT As Boolean
    Dim m_FLG_EXAM_DELETE As Boolean
    Dim m_FLG_TIMETABLE_ENTRY As Boolean
    Dim m_FLG_TIMETABLE_VIEW As Boolean
    Dim m_FLG_TIMETABLE_EDIT As Boolean
    Dim m_FLG_TIMETABLE_DELETE As Boolean
    Dim m_FLG_CLASS_ENTRY As Boolean
    Dim m_FLG_CLASS_VIEW As Boolean
    Dim m_FLG_CLASS_EDIT As Boolean
    Dim m_FLG_CLASS_DELETE As Boolean
    Dim m_FLG_CLASSALLOCATION_ENTRY As Boolean
    Dim m_FLG_CLASSALLOCATION_VIEW As Boolean
    Dim m_FLG_CLASSALLOCATION_EDIT As Boolean
    Dim m_FLG_CLASSALLOCATION_DELETE As Boolean
    Dim m_FLG_SECTION_ENTRY As Boolean
    Dim m_FLG_SECTION_VIEW As Boolean
    Dim m_FLG_SECTION_EDIT As Boolean
    Dim m_FLG_SECTION_DELETE As Boolean
    Dim m_FLG_FACULTYALLOCATION_ENTRY As Boolean
    Dim m_FLG_FACULTYALLOCATION_EDIT As Boolean
    Dim m_FLG_FACULTYALLOCATION_DELETE As Boolean
    Dim m_FLG_FACULTYALLOCATION_VIEW As Boolean
    Dim m_FLG_EXAMATTENDANCE_ENTRY As Boolean
    Dim m_FLG_EXAMATTENDANCE_VIEW As Boolean
    Dim m_FLG_EXAMATTENDANCE_EDIT As Boolean
    Dim m_FLG_EXAMATTENDANCE_DELETE As Boolean
    Dim m_FLG_RESULT_ENTRY As Boolean
    Dim m_FLG_RESULT_VIEW As Boolean
    Dim m_FLG_RESULT_EDIT As Boolean
    Dim m_FLG_RESULT_DELETE As Boolean
    Dim m_FLG_QUESTION_ENTRY As Boolean
    Dim m_FLG_QUESTION_VIEW As Boolean
    Dim m_FLG_QUESTION_EDIT As Boolean
    Dim m_FLG_QUESTION_DELETE As Boolean
    Dim m_FLG_QUESTIONPAPER_ENTRY As Boolean
    Dim m_FLG_QUESTIONPAPER_VIEW As Boolean
    Dim m_FLG_QUESTIONPAPER_EDIT As Boolean
    Dim m_FLG_QUESTIONPAPER_DELETE As Boolean
    Dim m_lngRole_Id As Long

    Public Property FLG_STUDENT_ENTRY As Boolean
        Get
            Return m_FLG_STUDENT_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_STUDENT_ENTRY = value
        End Set
    End Property
    Public Property FLG_STUDENT_VIEW As Boolean
        Get
            Return m_FLG_STUDENT_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_STUDENT_VIEW = value
        End Set
    End Property
    Public Property FLG_STUDENT_EDIT As Boolean
        Get
            Return m_FLG_STUDENT_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_STUDENT_EDIT = value
        End Set
    End Property
    Public Property FLG_STUDENT_DELETE As Boolean
        Get
            Return m_FLG_STUDENT_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_STUDENT_DELETE = value
        End Set
    End Property
    Public Property FLG_FACULTY_ENTRY As Boolean
        Get
            Return m_FLG_FACULTY_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_FACULTY_ENTRY = value
        End Set
    End Property
    Public Property FLG_FACULTY_VIEW As Boolean
        Get
            Return m_FLG_FACULTY_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_FACULTY_VIEW = value
        End Set
    End Property
    Public Property FLG_FACULTY_EDIT As Boolean
        Get
            Return m_FLG_FACULTY_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_FACULTY_EDIT = value
        End Set
    End Property
    Public Property FLG_FACULTY_DELETE As Boolean
        Get
            Return m_FLG_FACULTY_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_FACULTY_DELETE = value
        End Set
    End Property
    Public Property FLG_BRANCH_ENTRY As Boolean
        Get
            Return m_FLG_BRANCH_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_BRANCH_ENTRY = value
        End Set
    End Property
    Public Property FLG_BRANCH_VIEW As Boolean
        Get
            Return m_FLG_BRANCH_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_BRANCH_VIEW = value
        End Set
    End Property
    Public Property FLG_BRANCH_EDIT As Boolean
        Get
            Return m_FLG_BRANCH_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_BRANCH_EDIT = value
        End Set
    End Property
    Public Property FLG_BRANCH_DELETE As Boolean
        Get
            Return m_FLG_BRANCH_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_BRANCH_DELETE = value
        End Set
    End Property
    Public Property FLG_COURSE_ENTRY As Boolean
        Get
            Return m_FLG_COURSE_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_COURSE_ENTRY = value
        End Set
    End Property
    Public Property FLG_COURSE_VIEW As Boolean
        Get
            Return m_FLG_COURSE_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_COURSE_VIEW = value
        End Set
    End Property
    Public Property FLG_COURSE_EDIT As Boolean
        Get
            Return m_FLG_COURSE_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_COURSE_EDIT = value
        End Set
    End Property
    Public Property FLG_COURSE_DELETE As Boolean
        Get
            Return m_FLG_COURSE_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_COURSE_DELETE = value
        End Set
    End Property
    Public Property FLG_FORMAT_ENTRY As Boolean
        Get
            Return m_FLG_FORMAT_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_FORMAT_ENTRY = value
        End Set
    End Property
    Public Property FLG_FORMAT_VIEW As Boolean
        Get
            Return m_FLG_FORMAT_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_FORMAT_VIEW = value
        End Set
    End Property
    Public Property FLG_FORMAT_EDIT As Boolean
        Get
            Return m_FLG_FORMAT_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_FORMAT_EDIT = value
        End Set
    End Property
    Public Property FLG_FORMAT_DELETE As Boolean
        Get
            Return m_FLG_FORMAT_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_FORMAT_DELETE = value
        End Set
    End Property
    Public Property FLG_SUBJECT_ENTRY As Boolean
        Get
            Return m_FLG_SUBJECT_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_SUBJECT_ENTRY = value
        End Set
    End Property
    Public Property FLG_SUBJECT_VIEW As Boolean
        Get
            Return m_FLG_SUBJECT_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_SUBJECT_VIEW = value
        End Set
    End Property
    Public Property FLG_SUBJECT_EDIT As Boolean
        Get
            Return m_FLG_SUBJECT_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_SUBJECT_EDIT = value
        End Set
    End Property
    Public Property FLG_SUBJECT_DELETE As Boolean
        Get
            Return m_FLG_SUBJECT_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_SUBJECT_DELETE = value
        End Set
    End Property
    Public Property FLG_CHAPTER_ENTRY As Boolean
        Get
            Return m_FLG_CHAPTER_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_CHAPTER_ENTRY = value
        End Set
    End Property
    Public Property FLG_CHAPTER_VIEW As Boolean
        Get
            Return m_FLG_CHAPTER_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_CHAPTER_VIEW = value
        End Set
    End Property
    Public Property FLG_CHAPTER_EDIT As Boolean
        Get
            Return m_FLG_CHAPTER_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_CHAPTER_EDIT = value
        End Set
    End Property
    Public Property FLG_CHAPTER_DELETE As Boolean
        Get
            Return m_FLG_CHAPTER_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_CHAPTER_DELETE = value
        End Set
    End Property
    Public Property FLG_EXAM_ENTRY As Boolean
        Get
            Return m_FLG_EXAM_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_EXAM_ENTRY = value
        End Set
    End Property
    Public Property FLG_EXAM_VIEW As Boolean
        Get
            Return m_FLG_EXAM_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_EXAM_VIEW = value
        End Set
    End Property
    Public Property FLG_EXAM_EDIT As Boolean
        Get
            Return m_FLG_EXAM_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_EXAM_EDIT = value
        End Set
    End Property
    Public Property FLG_EXAM_DELETE As Boolean
        Get
            Return m_FLG_EXAM_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_EXAM_DELETE = value
        End Set
    End Property
    Public Property FLG_TIMETABLE_ENTRY As Boolean
        Get
            Return m_FLG_TIMETABLE_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_TIMETABLE_ENTRY = value
        End Set
    End Property
    Public Property FLG_TIMETABLE_VIEW As Boolean
        Get
            Return m_FLG_TIMETABLE_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_TIMETABLE_VIEW = value
        End Set
    End Property
    Public Property FLG_TIMETABLE_EDIT As Boolean
        Get
            Return m_FLG_TIMETABLE_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_TIMETABLE_EDIT = value
        End Set
    End Property
    Public Property FLG_TIMETABLE_DELETE As Boolean
        Get
            Return m_FLG_TIMETABLE_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_TIMETABLE_DELETE = value
        End Set
    End Property
    Public Property FLG_CLASS_ENTRY As Boolean
        Get
            Return m_FLG_CLASS_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_CLASS_ENTRY = value
        End Set
    End Property
    Public Property FLG_CLASS_VIEW As Boolean
        Get
            Return m_FLG_CLASS_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_CLASS_VIEW = value
        End Set
    End Property
    Public Property FLG_CLASS_EDIT As Boolean
        Get
            Return m_FLG_CLASS_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_CLASS_EDIT = value
        End Set
    End Property
    Public Property FLG_CLASS_DELETE As Boolean
        Get
            Return m_FLG_CLASS_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_CLASS_DELETE = value
        End Set
    End Property
    Public Property FLG_CLASSALLOCATION_ENTRY As Boolean
        Get
            Return m_FLG_CLASSALLOCATION_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_CLASSALLOCATION_ENTRY = value
        End Set
    End Property
    Public Property FLG_CLASSALLOCATION_VIEW As Boolean
        Get
            Return m_FLG_CLASSALLOCATION_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_CLASSALLOCATION_VIEW = value
        End Set
    End Property
    Public Property FLG_CLASSALOCATION_EDIT As Boolean
        Get
            Return m_FLG_CLASSALLOCATION_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_CLASSALLOCATION_EDIT = value
        End Set
    End Property
    Public Property FLG_CLASSALLOCATION_DELETE As Boolean
        Get
            Return m_FLG_CLASSALLOCATION_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_CLASSALLOCATION_DELETE = value
        End Set
    End Property
    Public Property FLG_SECTION_ENTRY As Boolean
        Get
            Return m_FLG_SECTION_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_SECTION_ENTRY = value
        End Set
    End Property
    Public Property FLG_SECTION_VIEW As Boolean
        Get
            Return m_FLG_SECTION_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_SECTION_VIEW = value
        End Set
    End Property
    Public Property FLG_SECTION_EDIT As Boolean
        Get
            Return m_FLG_SECTION_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_SECTION_EDIT = value
        End Set
    End Property
    Public Property FLG_SECTION_DELETE As Boolean
        Get
            Return m_FLG_SECTION_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_SECTION_DELETE = value
        End Set
    End Property
    Public Property FLG_FACULTYALLOCATION_ENTRY As Boolean
        Get
            Return m_FLG_FACULTYALLOCATION_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_FACULTYALLOCATION_ENTRY = value
        End Set
    End Property
    Public Property FLG_FACULTYALLOCATION_EDIT As Boolean
        Get
            Return m_FLG_FACULTYALLOCATION_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_FACULTYALLOCATION_EDIT = value
        End Set
    End Property
    Public Property FLG_FACULTYALLOCATION_DELETE As Boolean
        Get
            Return m_FLG_FACULTYALLOCATION_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_FACULTYALLOCATION_DELETE = value
        End Set
    End Property
    Public Property FLG_FACULTYALLOCATION_VIEW As Boolean
        Get
            Return m_FLG_FACULTYALLOCATION_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_FACULTYALLOCATION_VIEW = value
        End Set
    End Property
    Public Property FLG_EXAMATTENDANCE_ENTRY As Boolean
        Get
            Return m_FLG_EXAMATTENDANCE_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_EXAMATTENDANCE_ENTRY = value
        End Set
    End Property
    Public Property FLG_EXAMATTENDANCE_VIEW As Boolean
        Get
            Return m_FLG_EXAMATTENDANCE_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_EXAMATTENDANCE_VIEW = value
        End Set
    End Property
    Public Property FLG_EXAMATTENDANCE_EDIT As Boolean
        Get
            Return m_FLG_EXAMATTENDANCE_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_EXAMATTENDANCE_EDIT = value
        End Set
    End Property
    Public Property FLG_EXAMATTENDANCE_DELETE As Boolean
        Get
            Return m_FLG_EXAMATTENDANCE_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_EXAMATTENDANCE_DELETE = value
        End Set
    End Property
    Public Property FLG_RESULT_ENTRY As Boolean
        Get
            Return m_FLG_RESULT_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_RESULT_ENTRY = value
        End Set
    End Property
    Public Property FLG_RESULT_EDIT As Boolean
        Get
            Return m_FLG_RESULT_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_RESULT_EDIT = value
        End Set
    End Property
    Public Property FLG_RESULT_VIEW As Boolean
        Get
            Return m_FLG_RESULT_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_STUDENT_VIEW = value
        End Set
    End Property
    Public Property FLG_RESULT_DELETE As Boolean
        Get
            Return m_FLG_RESULT_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_RESULT_DELETE = value
        End Set
    End Property
    Public Property FLG_QUESTION_ENTRY As Boolean
        Get
            Return m_FLG_QUESTION_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_QUESTION_ENTRY = value
        End Set
    End Property
    Public Property FLG_QUESTION_EDIT As Boolean
        Get
            Return m_FLG_QUESTION_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_QUESTION_EDIT = value
        End Set
    End Property
    Public Property FLG_QUESTION_VIEW As Boolean
        Get
            Return m_FLG_QUESTION_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_QUESTION_VIEW = value
        End Set
    End Property


    Public Property FLG_QUESTION_DELETE As Boolean
        Get
            Return m_FLG_QUESTION_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_QUESTION_DELETE = value
        End Set
    End Property
    Public Property FLG_QUESTIONPAPER_ENTRY As Boolean
        Get
            Return m_FLG_QUESTIONPAPER_ENTRY
        End Get
        Set(value As Boolean)
            m_FLG_QUESTIONPAPER_ENTRY = value
        End Set
    End Property
    Public Property FLG_QUESTIONPAPER_EDIT As Boolean
        Get
            Return m_FLG_QUESTIONPAPER_EDIT
        End Get
        Set(value As Boolean)
            m_FLG_QUESTIONPAPER_EDIT = value
        End Set
    End Property
    Public Property FLG_QUESTIONPAPER_VIEW As Boolean
        Get
            Return m_FLG_QUESTIONPAPER_VIEW
        End Get
        Set(value As Boolean)
            m_FLG_QUESTIONPAPER_VIEW = value
        End Set
    End Property
    Public Property FLG_QUESTIONPAPER_DELETE As Boolean
        Get
            Return m_FLG_QUESTIONPAPER_DELETE
        End Get
        Set(value As Boolean)
            m_FLG_QUESTIONPAPER_DELETE = value
        End Set
    End Property
    Public Property Role_Id As Long
        Get
            Return m_lngRole_Id
        End Get
        Set(value As Long)
            m_lngRole_Id = value
        End Set
    End Property

    Public Sub init()
        Try
            Dim sql As String
            Dim Dt As New DataTable
            Dim Con As New clsConnection
            Dim Fun As New clsFunctions

            sql = "Select r.*,f.Name as Fun from Role_Alloction r,Function_Master f "
            sql = sql & " Where Role_ID=" & Fun.SQLNumber(m_lngRole_Id)
            Dt = Con.GetDataTable(sql)
            Dim i As Integer
            For i = 0 To Dt.Rows.Count - 1
                Select Case (Dt.Rows(i).Item("Fun"))
                    Case "StudentEntry"
                        FLG_STUDENT_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "StudentView"
                        FLG_STUDENT_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "StudentEdit"
                        FLG_STUDENT_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "StudentDelete"
                        FLG_STUDENT_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "FacultyEntry"
                        FLG_FACULTY_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "FacultyView"
                        FLG_FACULTY_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "FacultyEdit"
                        m_FLG_FACULTY_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "FacultyDelete"
                        FLG_FACULTY_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "BranchEntry"
                        FLG_BRANCH_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "BranchView"
                        FLG_BRANCH_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "BranchEdit"
                        FLG_BRANCH_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "BranchDelete"
                        FLG_BRANCH_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "CourseEntry"
                        FLG_COURSE_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "CourseView"
                        FLG_COURSE_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "CourseEdit"
                        FLG_COURSE_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "CourseDelete"
                        FLG_COURSE_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "FormatEntry"
                        FLG_FORMAT_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "FormatView"
                        FLG_FORMAT_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "FormatEdit"
                        FLG_FORMAT_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "FormatDelete"
                        FLG_FORMAT_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "SubjectEntry"
                        FLG_SUBJECT_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "SubjectView"
                        FLG_SUBJECT_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "SubjectEdit"
                        FLG_SUBJECT_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "SubjectDelete"
                        FLG_SUBJECT_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "ChapterEntry"
                        FLG_CHAPTER_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "ChapterView"
                        FLG_CHAPTER_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "ChapterEdit"
                        FLG_CHAPTER_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "ChapterDelete"
                        FLG_CHAPTER_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "ExamEntry"
                        FLG_EXAM_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "ExamView"
                        FLG_EXAM_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "ExamEdit"
                        FLG_EXAM_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "ExamDelete"
                        FLG_EXAM_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "TimetableEntry"
                        FLG_TIMETABLE_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "TimetableView"
                        FLG_TIMETABLE_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "TimetableEdit"
                        FLG_TIMETABLE_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "TimetableDelete"
                        FLG_TIMETABLE_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "ClassEntry"
                        FLG_CLASS_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "ClassView"
                        FLG_CLASS_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "ClassEdit"
                        FLG_CLASS_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "ClassDelete"
                        FLG_CLASS_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "ClassAllocationEntry"
                        FLG_CLASSALLOCATION_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "ClassAllocationView"
                        FLG_CLASSALLOCATION_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "ClassAllocationEdit"
                        FLG_CLASSALOCATION_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "ClassAllocationDelete"
                        FLG_CLASSALLOCATION_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "SectionEntry"
                        FLG_SECTION_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "SectionView"
                        FLG_SECTION_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "SectionEdit"
                        FLG_SECTION_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "SectionDelete"
                        FLG_SECTION_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "FacultyAllocationEntry"
                        FLG_FACULTYALLOCATION_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "FacultyAllocationEdit"
                        FLG_FACULTYALLOCATION_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "FacultyAllocationDelete"
                        FLG_FACULTYALLOCATION_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "FacultyAllocationView"
                        FLG_FACULTYALLOCATION_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "ExamAttendanceEntry"
                        FLG_EXAMATTENDANCE_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "ExamAttendanceView"
                        FLG_EXAMATTENDANCE_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "ExamAttendanceEdit"
                        FLG_EXAMATTENDANCE_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "ExamAttendanceDelete"
                        FLG_EXAMATTENDANCE_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "ResultEntry"
                        FLG_RESULT_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "ResultView"
                        FLG_RESULT_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "ResultEdit"
                        FLG_RESULT_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "ResultDelete"
                        FLG_RESULT_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "QuestionEntry"
                        FLG_QUESTION_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "QuestionView"
                        FLG_QUESTION_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "QuestionEdit"
                        FLG_QUESTION_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "QuestionDelete"
                        FLG_QUESTION_DELETE = Dt.Rows(i).Item("Is_Allow")
                    Case "SubjectEntry"
                        FLG_QUESTIONPAPER_ENTRY = Dt.Rows(i).Item("Is_Allow")
                    Case "QuestionPaperView"
                        FLG_QUESTIONPAPER_VIEW = Dt.Rows(i).Item("Is_Allow")
                    Case "QuestionPaperEdit"
                        FLG_QUESTIONPAPER_EDIT = Dt.Rows(i).Item("Is_Allow")
                    Case "QuestionPaperDelete"
                        FLG_QUESTIONPAPER_DELETE = Dt.Rows(i).Item("Is_Allow")

                End Select
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
