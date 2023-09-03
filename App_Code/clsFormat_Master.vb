Imports Microsoft.VisualBasic
Imports System

Public Class clsFormat_Master
    Dim m_Id As Long
    Dim m_strName As String
    Dim m_strRemark As String
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_strName = ""
        m_strRemark = ""
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Format_Master ("
                sql = sql & "Name, "
                sql = sql & "Remark"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLString(m_strName) & ","
                sql = sql & Fun.SQLString(m_strRemark) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Format_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Format_Master Set "
                sql = sql & " Name = " & Fun.SQLString(m_strName) & ", "
                sql = sql & " Remark = " & Fun.SQLString(m_strRemark) & " "
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
            sql = "Select * from Format_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_strName = Dt.Rows(0).Item("Name")
            m_strRemark = Dt.Rows(0).Item("Remark")

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
    Public Property Remark() As String
        Get
            Return m_strRemark
        End Get
        Set(ByVal value As String)
            m_strRemark = value
        End Set
    End Property
End Class
