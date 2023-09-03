Imports Microsoft.VisualBasic
Imports System

Public Class clsFaculty_Allocation
    Dim m_Id As Long
    Dim m_lngClass_Id As Long
    Dim m_lngTimetable_Id As Long
    Dim m_lngFaculty_Id As Long
    Dim m_lngExam_Id As Long
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngClass_Id = 0
        m_lngTimetable_Id = 0
        m_lngFaculty_Id = 0
        m_lngExam_Id = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Faculty_Allocation ("

                sql = sql & "Class_ID,"
                sql = sql & "Timetable_ID, "
                sql = sql & "Faculty_ID,"
                sql = sql & "Exam_ID "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngClass_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngTimetable_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngFaculty_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngExam_Id) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Faculty_Allocation"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Faculty_Allocation Set "
                sql = sql & " Class_ID = " & Fun.SQLNumber(m_lngClass_Id) & ", "
                sql = sql & " Timetable_ID = " & Fun.SQLNumber(m_lngTimetable_Id) & ", "
                sql = sql & " Faculty_ID = " & Fun.SQLNumber(m_lngFaculty_Id) & ", "
                sql = sql & "Exam_ID = " & Fun.SQLNumber(m_lngExam_Id) & " "
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
            sql = "Select * from Faculty_Allocation where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngClass_Id = Dt.Rows(0).Item("Class_Id")
            m_lngTimetable_Id = Dt.Rows(0).Item("Timetable_Id")
            m_lngFaculty_Id = Dt.Rows(0).Item("Faculty_Id")
            m_lngExam_Id = Dt.Rows(0).Item("Exam_Id")

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

    Public Property Class_Id() As Long
        Get
            Return m_lngClass_Id
        End Get
        Set(ByVal value As Long)
            m_lngClass_Id = value
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
    Public Property Faculty_Id() As Long
        Get
            Return m_lngFaculty_Id
        End Get
        Set(ByVal value As Long)
            m_lngFaculty_Id = value
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


End Class
