Imports Microsoft.VisualBasic
Imports System

Public Class clsStudent_Master
    Dim m_Id As Long
    Dim m_strEnrolment As String
    Dim m_strName As String
    Dim m_lngBranch_Id As Long
    Dim m_lngSem As Long
    Dim m_strContact_No As String
    Dim m_strEMail As String
    Dim m_bolIsActive As Boolean
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_strEnrolment = ""
        m_strName = ""
        m_lngBranch_Id = 0
        m_lngSem = 0
        m_strContact_No = ""
        m_strEMail = ""
        m_bolIsActive = False
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Student_Master ("
                sql = sql & "Enrolment,"
                sql = sql & "Name, "
                sql = sql & "Branch_ID,"
                sql = sql & "Sem,"
                sql = sql & "Contact_NO,"
                sql = sql & "EMail, "
                sql = sql & "IsActive"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLString(m_strEnrolment) & ","
                sql = sql & Fun.SQLString(m_strName) & ","
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSem) & ","
                sql = sql & Fun.SQLString(m_strContact_No) & ","
                sql = sql & Fun.SQLString(m_strEMail) & ","
                sql = sql & Fun.SQLBool(m_bolIsActive) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Student_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Student_Master Set "
                sql = sql & " Enrolment= " & Fun.SQLString(m_strEnrolment) & ", "
                sql = sql & " Name = " & Fun.SQLString(m_strName) & ", "
                sql = sql & " Branch_ID = " & Fun.SQLNumber(m_lngBranch_Id) & ", "
                sql = sql & "Sem = " & Fun.SQLNumber(m_lngSem) & ", "
                sql = sql & "Contact_No = " & Fun.SQLString(m_strContact_No) & ", "
                sql = sql & " isActive = " & Fun.SQLBool(m_bolIsActive) & ","
                sql = sql & " EMail = " & Fun.SQLString(m_strEMail) & " "
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
            sql = "Select * from Student_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_strEnrolment = Dt.Rows(0).Item("Enrolment")
            m_strName = Dt.Rows(0).Item("Name")
            m_lngBranch_Id = Dt.Rows(0).Item("Branch_Id")
            m_lngSem = Dt.Rows(0).Item("Sem")
            m_strContact_No = Dt.Rows(0).Item("Contact_No")
            m_strEMail = Dt.Rows(0).Item("EMail")
            m_bolIsActive = Dt.Rows(0).Item("IsActive")

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

    Public Property Enrolment() As String
        Get
            Return m_strEnrolment
        End Get
        Set(ByVal value As String)
            m_strEnrolment = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return m_strName
        End Get
        Set(ByVal value As String)
            m_strName = value
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
    Public Property Contact_No() As String
        Get
            Return m_strContact_No
        End Get
        Set(ByVal value As String)
            m_strContact_No = value
        End Set
    End Property
    Public Property EMail() As String
        Get
            Return m_strEMail
        End Get
        Set(ByVal value As String)
            m_strEMail = value
        End Set
    End Property
    Public Property IsActive() As Boolean
        Get
            Return m_bolIsActive
        End Get
        Set(ByVal value As Boolean)
            m_strEMail = value
        End Set
    End Property

End Class
