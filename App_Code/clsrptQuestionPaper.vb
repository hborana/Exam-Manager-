Imports Microsoft.VisualBasic
Imports System

Public Class clsrptQuestionPaper

    Dim m_Id As Long
    Dim m_strQueNo As String
    Dim m_strQuestion As String
    Dim m_lngMarks As Long
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngMarks = 0
        m_strQueNo = ""
        m_strQuestion = ""
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try

            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into rptQuestionPaper ("
                sql = sql & "QueNo, "
                sql = sql & "Question, "
                sql = sql & "Marks "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLString(m_strQueNo) & ","
                sql = sql & Fun.SQLString(m_strQuestion) & ","
                sql = sql & Fun.SQLNumber(m_lngMarks) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from rptQuestionPaper"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                'sql = "Update Branch_Master Set "
                'sql = sql & " Name = " & Fun.SQLString(m_strName) & ", "
                'sql = sql & " Code = " & Fun.SQLString(m_strCode) & ", "
                'sql = sql & " Course_Id = " & Fun.SQLNumber(m_lngCourse_Id) & " "
                'sql = sql & " where id=" & Fun.SQLNumber(m_Id)
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                Else
                    m_strErr = sql
                    Save = False
                End If
            End If
        Catch ex As Exception
            Save = False
        End Try
        'Catch ex As Exception
        'm_strErr = ex.message
        'End Try
    End Function


    'Public Sub GetById(Optional ByVal lngID As Long = 0)
    '    Try
    '        Dim sql As String
    '        Dim Fun As New clsFunctions
    '        Dim Con As New clsConnection
    '        Dim Dt As New DataTable
    '        If lngID <> 0 Then
    '            m_Id = lngID
    '        End If
    '        sql = "Select * from Branch_Master where id=" & Fun.SQLNumber(m_Id)
    '        Dt = Con.GetDataTable(sql)
    '        m_lngCourse_Id = Dt.Rows(0).Item("Course_Id")
    '        m_strCode = Dt.Rows(0).Item("Code")
    '        m_strName = Dt.Rows(0).Item("Name")

    '    Catch ex As Exception

    '    End Try

    'End Sub

    Public Property Id() As Long
        Get
            Return m_Id
        End Get
        Set(ByVal value As Long)
            m_Id = value
        End Set
    End Property

    Public Property QueNo() As String
        Get
            Return m_strQueNo
        End Get
        Set(ByVal value As String)
            m_strQueNo = value
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

    Public Property Marks() As Long
        Get
            Return m_lngMarks
        End Get
        Set(ByVal value As Long)
            m_lngMarks = value
        End Set
    End Property

End Class


