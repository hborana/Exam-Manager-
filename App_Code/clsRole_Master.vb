Imports Microsoft.VisualBasic
Imports System

Public Class clsRole_Master
    Dim m_id As Long
    Dim m_strname As String

    Public Property id As Long
        Get
            Return m_id
        End Get
        Set(value As Long)
            m_id = value
        End Set
    End Property

    Public Property name As String
        Get
            Return m_strname
        End Get
        Set(value As String)
            m_strname = value
        End Set
    End Property

    Public Sub init()
        m_id = 0
        m_strname = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim sql As String
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            If m_id = 0 Then
                sql = "insert into role_master ("
                sql = sql & "name"
                sql = sql & " ) Values ("
                sql = sql & Fun.SQLString(m_strname) & " )"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    'Return True
                Else
                    Save = False
                End If
            Else
                sql = "Update role_master set "
                sql = sql & " name=" & Fun.SQLString(m_strname) & " "
                sql = sql & " Where id=" & Fun.SQLNumber(m_id)
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    'Return True
                Else
                    Save = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Function
End Class


