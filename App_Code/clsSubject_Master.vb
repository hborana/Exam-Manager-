Imports Microsoft.VisualBasic
Imports System

Public Class clsSubject_Master
    Dim m_Id As Long
    Dim m_lngBranch_Id As Long
    Dim m_lngSem As Long
    Dim m_strname As String
    Dim m_strCode As String

    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngBranch_Id = 0
        m_lngSem = 0
        m_strname = ""
        m_strCode = ""
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Subject_Master ("
                sql = sql & "Branch_ID,"
                sql = sql & "Sem,"
                sql = sql & "Name, "
                sql = sql & "Code "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSem) & ","
                sql = sql & Fun.SQLString(m_strname) & ","
                sql = sql & Fun.SQLString(m_strCode) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Subject_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Subject_Master Set "
                sql = sql & " Branch_ID = " & Fun.SQLNumber(m_lngBranch_Id) & ", "
                sql = sql & "Sem = " & Fun.SQLNumber(m_lngSem) & ", "
                sql = sql & " Name = " & Fun.SQLString(m_strname) & ", "
                sql = sql & " Code = " & Fun.SQLString(m_strCode) & " "
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
            sql = "Select * from Subject_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngBranch_Id = Dt.Rows(0).Item("Branch_Id")
            m_lngSem = Dt.Rows(0).Item("Sem")
            m_strname = Dt.Rows(0).Item("Name")
            m_strCode = Dt.Rows(0).Item("Code")

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

    Public Property Sem() As Long
        Get
            Return m_lngSem
        End Get
        Set(ByVal value As Long)
            m_lngSem = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return m_strname
        End Get
        Set(ByVal value As String)
            m_strname = value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return m_strCode
        End Get
        Set(ByVal value As String)
            m_strCode = value
        End Set
    End Property
End Class
