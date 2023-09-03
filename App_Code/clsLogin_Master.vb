Imports Microsoft.VisualBasic
Imports System

Public Class clsLogin_Master
    Dim m_Id As Long
    Dim m_strUser_Name As String
    Dim m_strPassword As String
    Dim m_lngFaculty_Id As Long
    Dim m_lngStudent_Id As Long
    Dim m_strDesignation As String
    Dim m_lngRole_Id As Long

    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_strUser_Name = ""
        m_strPassword = ""
        m_lngFaculty_Id = 0
        m_lngStudent_Id = 0
        m_strDesignation = ""
        m_lngRole_Id = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Login_Master ("
                sql = sql & "User_Name,"
                sql = sql & "Password,"
                sql = sql & "Faculty_ID,"
                sql = sql & "Student_ID, "
                sql = sql & "Designation, "
                sql = sql & "Role_ID, "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLString(m_strUser_Name) & ","
                sql = sql & Fun.SQLString(m_strPassword) & ","
                sql = sql & Fun.SQLNumber(m_lngFaculty_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngStudent_Id) & ","
                sql = sql & Fun.SQLString(m_strDesignation) & ","
                sql = sql & Fun.SQLString(m_lngRole_Id) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Login_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Login_Master Set "
                sql = sql & " User_Name = " & Fun.SQLString(m_strUser_Name) & ", "
                sql = sql & " Password = " & Fun.SQLString(m_strPassword) & ", "
                sql = sql & " Faculty_ID = " & Fun.SQLNumber(m_lngFaculty_Id) & ", "
                sql = sql & " Student_ID = " & Fun.SQLNumber(m_lngStudent_Id) & ", "
                sql = sql & " Designation = " & Fun.SQLString(m_strDesignation) & ","
                sql = sql & " Role_ID = " & Fun.SQLString(m_lngRole_Id) & " "
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
            sql = "Select * from Login_MAster where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_strUser_Name = Dt.Rows(0).Item("User_Name")
            m_strPassword = Dt.Rows(0).Item("Password")
            m_lngFaculty_Id = Dt.Rows(0).Item("Faculty_Id")
            m_lngStudent_Id = Dt.Rows(0).Item("Student_Id")
            m_strDesignation = Dt.Rows(0).Item("Designation")
            m_strDesignation = Dt.Rows(0).Item("Role_ID")

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
    Public Property User_Name() As String
        Get
            Return m_strUser_Name
        End Get
        Set(ByVal value As String)
            m_strUser_Name = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return m_strPassword
        End Get
        Set(ByVal value As String)
            m_strPassword = value
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
    Public Property Student_Id() As Long
        Get
            Return m_lngStudent_Id
        End Get
        Set(ByVal value As Long)
            m_lngStudent_Id = value
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
    Public Property Role_Id() As Long
        Get
            Return m_lngRole_Id
        End Get
        Set(ByVal value As Long)
            m_lngRole_Id = value
        End Set
    End Property
End Class
