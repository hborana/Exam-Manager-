Imports Microsoft.VisualBasic
Imports System

Public Class clsSection_Master

    Dim m_Id As Long
    Dim m_strSection As String
    Dim m_strAcademic_Year As String
    Dim m_lngNo_Of_Student As Long
    Dim m_lngBranch_Id As Long
    Dim m_lngSem_Id As Long

    Dim m_strErr As String

    Public Sub init()
        m_lngBranch_Id = 0
        m_Id = 0
        m_strSection = ""
        m_strAcademic_Year = ""
        m_lngNo_Of_Student = 0
        m_lngSem_Id = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try

            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Section_Master ("
                sql = sql & "Branch_ID, "
                sql = sql & "Section, "
                sql = sql & "No_Of_Student, "
                sql = sql & "Acadamic_Year, "
                sql = sql & "Sem_ID "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & Fun.SQLString(m_strSection) & ","
                sql = sql & Fun.SQLNumber(m_lngNo_Of_Student) & ","
                sql = sql & Fun.SQLString(m_strAcademic_Year) & ","
                sql = sql & Fun.SQLNumber(m_lngSem_Id) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Section_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Section_Master Set "
                sql = sql & " Branch_ID = " & Fun.SQLNumber(m_lngBranch_Id) & ", "
                sql = sql & " Section = " & Fun.SQLString(m_strSection) & ", "
                sql = sql & "No_Of_Student" & Fun.SQLNumber(m_lngNo_Of_Student) & ","
                sql = sql & "Academic_Year" & Fun.SQLString(m_strAcademic_Year) & ","
                sql = sql & " Sem_ID = " & Fun.SQLNumber(m_lngSem_Id) & " "
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
        End Try
        'Catch ex As Exception
        'm_strErr = ex.message
        'End Try
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
            sql = "Select * from Section_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_strAcademic_Year = Dt.Rows(0).Item("Academic_Year")
            m_lngBranch_Id = Dt.Rows(0).Item("Branch_ID")
            m_lngNo_Of_Student = Dt.Rows(0).Item("No_Of_Student")
            m_lngSem_Id = Dt.Rows(0).Item("Sem_ID")
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

    Public Property Section() As String
        Get
            Return m_strSection
        End Get
        Set(ByVal value As String)
            m_strSection = value
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

    Public Property No_Of_Student() As Long
        Get
            Return m_lngNo_Of_Student
        End Get
        Set(ByVal value As Long)
            m_lngNo_Of_Student = value
        End Set
    End Property

    Public Property Academic_Year() As String
        Get
            Return m_strAcademic_Year
        End Get
        Set(ByVal value As String)
            m_strAcademic_Year = value
        End Set
    End Property
End Class
