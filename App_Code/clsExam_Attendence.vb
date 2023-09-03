Imports Microsoft.VisualBasic
Imports System

Public Class clsExam_Attendence
    Dim m_Id As Long
    Dim m_lngStudent_Id As Long
    Dim m_lngTimetable_Id As Long
    Dim m_lngClass_Id As Long
    Dim m_lngExam_Id As Long
    Dim m_lngBranch_Id As Long
    Dim m_lngSem_Id As Long
    Dim m_bolIs_present As Boolean

    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngStudent_Id = 0
        m_lngTimetable_Id = 0
        m_lngClass_Id = 0
        m_lngExam_Id = 0
        m_lngBranch_Id = 0
        m_lngSem_Id = 0
        m_bolIs_present = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Exam_Attendence ("
                sql = sql & "Student_ID, "
                sql = sql & "Timetable_ID, "
                sql = sql & "Class_ID, "
                sql = sql & "Exam_ID, "
                sql = sql & "Branch_ID, "
                sql = sql & "Sem_ID, "
                sql = sql & "IsPresent "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngStudent_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngTimetable_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngClass_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngExam_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSem_Id) & ","
                sql = sql & Fun.SQLBool(m_bolIs_present) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Exam_Attendence"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Exam_Attendence Set "
                sql = sql & " Student_ID = " & Fun.SQLNumber(m_lngStudent_Id) & ", "
                sql = sql & " Timetable_ID = " & Fun.SQLNumber(m_lngTimetable_Id) & ", "
                sql = sql & " Class_ID = " & Fun.SQLNumber(m_lngClass_Id) & ", "
                sql = sql & " Exam_ID = " & Fun.SQLNumber(m_lngExam_Id) & ", "
                sql = sql & " Branch_ID = " & Fun.SQLNumber(m_lngBranch_Id) & ", "
                sql = sql & " Sem_ID = " & Fun.SQLNumber(m_lngSem_Id) & ", "
                sql = sql & " IsPresent = " & Fun.SQLBool(m_bolIs_present) & " "
                sql = sql & " where id=" & Fun.SQLNumber(m_Id)
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                Else
                    m_strErr = sql
                    Save = False
                End If
            End If
        Catch ex As Exception
            Save = False
            'm_strErr = ex.message
        End Try
    End Function

    Public Sub GetById(Optional ByVal lngID As Long = 0)
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim Dt As New DataTable
            If lngID <> 0 Then
                m_Id = lngID
            End If
            sql = "Select * from Exam_Attendence where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngStudent_Id = Dt.Rows(0).Item("Student_Id")
            m_lngTimetable_Id = Dt.Rows(0).Item("Timetable_Id")
            m_lngClass_Id = Dt.Rows(0).Item("Class_Id")
            m_lngExam_Id = Dt.Rows(0).Item("Exam_Id")
            m_lngExam_Id = Dt.Rows(0).Item("Branch_Id")
            m_lngExam_Id = Dt.Rows(0).Item("Sem_Id")
            m_bolIs_present = Dt.Rows(0).Item("IsPresent")

        Catch ex As Exception

        End Try

    End Sub

    Public Property Id() As Long
        Get
            Return m_Id
        End Get
        Set(ByVal value As Long)
            m_Id = value
        End Set
    End Property
    Public Property Student_Id() As Long
        Get
            Return m_lngStudent_Id
        End Get
        Set(ByVal value As Long)
            m_lngStudent_Id = value
        End Set
    End Property
    Public Property Timetable_Id() As Long
        Get
            Return m_lngTimetable_Id
        End Get
        Set(ByVal value As Long)
            m_lngTimetable_Id = value
        End Set
    End Property
    Public Property Class_Id() As Long
        Get
            Return m_lngClass_Id
        End Get
        Set(ByVal value As Long)
            m_lngClass_Id = value
        End Set
    End Property
    Public Property Exam_Id() As Long
        Get
            Return m_lngExam_Id
        End Get
        Set(ByVal value As Long)
            m_lngExam_Id = value
        End Set
    End Property
    Public Property Branch_Id() As Long
        Get
            Return m_lngBranch_Id
        End Get
        Set(ByVal value As Long)
            m_lngBranch_Id = value
        End Set
    End Property
    Public Property Sem_Id() As Long
        Get
            Return m_lngSem_Id
        End Get
        Set(ByVal value As Long)
            m_lngSem_Id = value
        End Set
    End Property
    Public Property Is_Present() As Boolean
        Get
            Return m_bolIs_present
        End Get
        Set(ByVal value As Boolean)
            m_bolIs_present = value
        End Set
    End Property
End Class
