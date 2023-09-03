Imports Microsoft.VisualBasic
Imports System

Public Class clsResult_Master
    Dim m_Id As Long
    Dim m_lngStudent_Id As Long
    Dim m_lngSubject_Id As Long
    Dim m_lngAttendence_Id As Long
    Dim m_lngBranch_Id As Long
    Dim m_lngSem_Id As Long
    Dim m_lngMarks As Long
    Dim m_lngExam_Id As Long
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngStudent_Id = 0
        m_lngSubject_Id = 0
        m_lngAttendence_Id = 0
        m_lngSem_Id = 0
        m_lngBranch_Id = 0
        m_lngMarks = 0
        m_lngExam_Id = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Result_Master ("
                sql = sql & "Student_ID, "
                sql = sql & "Subject_ID, "
                sql = sql & "Attendence_ID,"
                sql = sql & "Branch_ID,"
                sql = sql & "Sem_ID,"
                sql = sql & "Marks,"
                sql = sql & "Exam_ID"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngStudent_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSubject_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngAttendence_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSem_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngMarks) & ","
                sql = sql & Fun.SQLNumber(m_lngExam_Id) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Result_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Result_Master Set "
                sql = sql & " Student_ID = " & Fun.SQLNumber(m_lngStudent_Id) & ", "
                sql = sql & " Subject_ID = " & Fun.SQLNumber(m_lngSubject_Id) & ", "
                sql = sql & " Attendence_ID = " & Fun.SQLNumber(m_lngAttendence_Id) & ", "
                sql = sql & " Branch_ID = " & Fun.SQLNumber(m_lngBranch_Id) & ", "
                sql = sql & " Sem_ID = " & Fun.SQLNumber(m_lngSem_Id) & ", "
                sql = sql & " Marks = " & Fun.SQLNumber(m_lngMarks) & ", "
                sql = sql & " Exam_ID = " & Fun.SQLNumber(m_lngExam_Id) & " "
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
            sql = "Select * from Result_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngStudent_Id = Dt.Rows(0).Item("Student_Id")
            m_lngSubject_Id = Dt.Rows(0).Item("Subject_Id")
            m_lngAttendence_Id = Dt.Rows(0).Item("Attendence_Id")
            m_lngBranch_Id = Dt.Rows(0).Item("Branch_ID")
            m_lngSem_Id = Dt.Rows(0).Item("Sem_ID")
            m_lngMarks = Dt.Rows(0).Item("Marks")
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
    Public Property Student_Id() As Long
        Get
            Return m_lngStudent_Id
        End Get
        Set(ByVal value As Long)
            m_lngStudent_Id = value
        End Set
    End Property
    Public Property Subject_Id() As Long
        Get
            Return m_lngSubject_Id
        End Get
        Set(ByVal value As Long)
            m_lngSubject_Id = value
        End Set
    End Property
    Public Property Attendence_Id() As Long
        Get
            Return m_lngAttendence_Id
        End Get
        Set(ByVal value As Long)
            m_lngAttendence_Id = value
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
    Public Property Branch_Id() As Long
        Get
            Return m_lngBranch_Id
        End Get
        Set(ByVal value As Long)
            m_lngBranch_Id = value
        End Set
    End Property

    Public Property Marks() As Long
        Get
            Return m_lngMarks
        End Get
        Set(ByVal value As Long)
            m_lngMarks = value
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
