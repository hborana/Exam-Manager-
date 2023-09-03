Imports Microsoft.VisualBasic
Imports System

Public Class clsIntermediate
    Dim m_Id As Long
    Dim m_lngBranch_ID As Long
    Dim m_lngExam_ID As Long
    Dim m_lngStudent_ID As Long
    Dim m_lngSem_ID As Long
    Dim m_lngCourse_ID As Long
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngBranch_ID = 0
        m_lngExam_ID = 0
        m_lngStudent_ID = 0
        m_lngSem_ID = 0
        m_lngCourse_ID = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Intermediate ("
                sql = sql & "Branch_ID, "
                sql = sql & "Exam_ID,"
                sql = sql & "Student_ID,"
                sql = sql & "Sem_ID,"
                sql = sql & "Course_ID"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngBranch_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngExam_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngStudent_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngSem_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngCourse_ID) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Intermediate"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Intermediate Set "
                sql = sql & " Branch_Id = " & Fun.SQLNumber(m_lngBranch_ID) & ", "
                sql = sql & " Exam_Id = " & Fun.SQLNumber(m_lngExam_ID) & ","
                sql = sql & " Student_Id = " & Fun.SQLNumber(m_lngStudent_ID) & " "
                sql = sql & " Sem_Id = " & Fun.SQLNumber(m_lngSem_ID) & " "
                sql = sql & " Course_Id = " & Fun.SQLNumber(m_lngCourse_ID) & " "
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
            sql = "Select * from Intermediate where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngBranch_ID = Dt.Rows(0).Item("Branch_ID")
            m_lngExam_ID = Dt.Rows(0).Item("Exam_ID")
            m_lngStudent_ID = Dt.Rows(0).Item("Student_ID")
            m_lngSem_ID = Dt.Rows(0).Item("Sem_ID")
            m_lngCourse_ID = Dt.Rows(0).Item("Course_ID")

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
    Public Property Branch_ID() As Long
        Get
            Return m_lngBranch_ID
        End Get
        Set(ByVal value As Long)
            m_lngBranch_ID = value
        End Set
    End Property
    Public Property Exam_ID() As Long
        Get
            Return m_lngExam_ID
        End Get
        Set(ByVal value As Long)
            m_lngExam_ID = value
        End Set
    End Property
    Public Property Student_ID() As Long
        Get
            Return m_lngStudent_ID
        End Get
        Set(ByVal value As Long)
            m_lngStudent_ID = value
        End Set
    End Property
    Public Property Sem_ID() As Long
        Get
            Return m_lngSem_ID
        End Get
        Set(ByVal value As Long)
            m_lngSem_ID = value
        End Set
    End Property
    Public Property Course_ID() As Long
        Get
            Return m_lngCourse_ID
        End Get
        Set(ByVal value As Long)
            m_lngCourse_ID = value
        End Set
    End Property

End Class

