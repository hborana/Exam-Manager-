Imports Microsoft.VisualBasic
Imports System

Public Class clsFaculty_Master
    Dim m_Id As Long
    Dim m_strName As String
    Dim m_strContact_No As String
    Dim m_strEMail As String
    Dim m_lngBranch_Id As Long
    Dim m_strDesignation As String
    Dim m_strEnrolment As String

    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_strName = ""
        m_strContact_No = ""
        m_strEMail = ""
        m_lngBranch_Id = 0
        m_strDesignation = ""
        m_strEnrolment = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Faculty_Master ("
                sql = sql & "Name, "
                sql = sql & "Contact_No, "
                sql = sql & "EMail, "
                sql = sql & "Enrolment, "
                sql = sql & "Branch_ID,"
                sql = sql & "Designation"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLString(m_strName) & ","
                sql = sql & Fun.SQLString(m_strContact_No) & ","
                sql = sql & Fun.SQLString(m_strEMail) & ","
                sql = sql & Fun.SQLString(m_strEnrolment) & ","
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & Fun.SQLString(m_strDesignation) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Faculty_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Faculty_Master Set "
                sql = sql & " Name = " & Fun.SQLString(m_strName) & ", "
                sql = sql & " Contact_No = " & Fun.SQLString(m_strContact_No) & ", "
                sql = sql & " EMail = " & Fun.SQLString(m_strEMail) & ", "
                sql = sql & "Enrolment =" & Fun.SQLString(m_strEnrolment) & ", "
                sql = sql & "Branch_ID = " & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & "Designation = " & Fun.SQLString(m_strDesignation) & " "
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
            sql = "Select * from Faculty_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_strName = Dt.Rows(0).Item("Name")
            m_strContact_No = Dt.Rows(0).Item("Contact_No")
            m_strEMail = Dt.Rows(0).Item("EMail")
            m_lngBranch_Id = Dt.Rows(0).Item("Branch_Id")
            m_strDesignation = Dt.Rows(0).Item("Designation")
            m_strEnrolment = Dt.Rows(0).Item("Enrolment")
         
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
    Public Property Name() As String
        Get
            Return m_strName
        End Get
        Set(ByVal value As String)
            m_strName = value
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
    Public Property Enrolment() As String
        Get
            Return m_strEnrolment
        End Get
        Set(ByVal value As String)
            m_strEnrolment = value
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
    Public Property Designation() As String
        Get
            Return m_strDesignation
        End Get
        Set(ByVal value As String)
            m_strDesignation = value
        End Set
    End Property
End Class
