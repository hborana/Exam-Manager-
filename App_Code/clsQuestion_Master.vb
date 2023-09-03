Imports Microsoft.VisualBasic
Imports System

Public Class clsQuestion_Master
    Dim m_Id As Long
    Dim m_lngBranch_Id As Long
    Dim m_lngSem_Id As Long
    Dim m_lngSubject_Id As Long
    Dim m_lngChapter_Id As Long
    Dim m_lngMarks As Long
    Dim m_lngFormat_Id As Long
    Dim m_strQuestion As String
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngBranch_Id = 0
        m_lngSem_Id = 0
        m_lngSubject_Id = 0
        m_lngChapter_Id = 0
        m_lngMarks = 0
        m_lngFormat_Id = 0
        m_strQuestion = ""
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Question_Master ("
                sql = sql & "Branch_ID,"
                sql = sql & "Sem_ID,"
                sql = sql & "Subject_ID,"
                sql = sql & "Chapter_ID, "
                sql = sql & "Marks, "
                sql = sql & "Format_ID,"
                sql = sql & "Question"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSem_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSubject_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngChapter_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngMarks) & ","
                sql = sql & Fun.SQLNumber(m_lngFormat_Id) & ","
                sql = sql & Fun.SQLNumber(m_strQuestion) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Question_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Question_Master Set "
                sql = sql & "Branch_ID = " & Fun.SQLNumber(m_lngBranch_Id) & ", "
                sql = sql & " Sem_ID = " & Fun.SQLNumber(m_lngSem_Id) & ", "
                sql = sql & " Subject_ID = " & Fun.SQLNumber(m_lngSubject_Id) & ", "
                sql = sql & " chapter_ID = " & Fun.SQLNumber(m_lngChapter_Id) & ", "
                sql = sql & "Marks =" & Fun.SQLNumber(m_lngMarks) & ","
                sql = sql & "Format_ID =" & Fun.SQLNumber(m_lngFormat_Id) & ","
                sql = sql & " Question = " & Fun.SQLString(m_strQuestion) & " "
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
            sql = "Select * from Question_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)

            m_lngBranch_Id = Dt.Rows(0).Item("Branch_Id")
            m_lngSem_Id = Dt.Rows(0).Item("Sem_Id")
            m_lngSubject_Id = Dt.Rows(0).Item("Subject_Id")
            m_lngChapter_Id = Dt.Rows(0).Item("Chapter_Id")
            m_lngMarks = Dt.Rows(0).Item("Marks")
            m_lngFormat_Id = Dt.Rows(0).Item("Format_Id")
            m_strQuestion = Dt.Rows(0).Item("Question")

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
    Public Property Subject_Id() As Long
        Get
            Return m_lngSubject_Id
        End Get
        Set(ByVal value As Long)
            m_lngSubject_Id = value
        End Set
    End Property
    Public Property Chapter_ID() As Long
        Get
            Return m_lngChapter_Id
        End Get
        Set(ByVal value As Long)
            m_lngChapter_Id = value
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
    Public Property Format_Id() As Long
        Get
            Return m_lngFormat_Id
        End Get
        Set(ByVal value As Long)
            m_lngFormat_Id = value
        End Set
    End Property

    Public Property Question() As String
        Get
            Return m_strQuestion
        End Get
        Set(ByVal value As String)
            m_strQuestion = value
        End Set
    End Property
End Class
