Imports Microsoft.VisualBasic
Imports System


Public Class clsRole_Allocation
        Dim m_id As Long
        Dim m_stris_allow As String
        Dim m_lngfunction_id As Long
        Dim m_lngrole_id As Long

        Public Property id As Long
            Get
                Return m_id
            End Get
            Set(value As Long)
                m_id = value
            End Set
        End Property

        Public Property is_allow As String
            Get
                Return m_stris_allow
            End Get
            Set(value As String)
                m_stris_allow = value
            End Set
        End Property

        Public Property function_id As Long
            Get
                Return m_lngfunction_id
            End Get
            Set(value As Long)
                m_lngfunction_id = value
            End Set
        End Property

        Public Property role_id As Long
            Get
                Return m_lngrole_id
            End Get
            Set(value As Long)
                m_lngrole_id = value
            End Set
        End Property

        Public Sub init()
            m_id = 0
            m_stris_allow = ""
            m_lngfunction_id = 0
            m_lngrole_id = 0
        End Sub

        Public Function Save() As Boolean
            Try
                Dim sql As String
                Dim Fun As New clsFunctions
                Dim Con As New clsConnection
                If m_id = 0 Then
                    sql = "insert into role_privileges_master ("
                    sql = sql & "is_allow,"
                    sql = sql & "function_id,"
                    sql = sql & "role_id"
                    sql = sql & " ) Values ("
                    sql = sql & Fun.SQLBool(m_stris_allow) & ", "
                    sql = sql & Fun.SQLNumber(m_lngfunction_id) & ", "
                    sql = sql & Fun.SQLNumber(m_lngrole_id) & " )"
                    If (Con.ExecQuery(sql) >= 1) Then
                        Save = True
                        'Return True
                    Else
                        Save = False
                    End If
                Else
                    sql = "Update role_privileges_master set "
                    sql = sql & " is_allow=" & Fun.SQLString(m_stris_allow) & ", "
                    sql = sql & " function_id=" & Fun.SQLNumber(m_lngfunction_id) & ", "
                    sql = sql & " role_id=" & Fun.SQLNumber(m_lngrole_id) & " "
                    sql = sql & " Where id=" & Fun.SQLNumber(m_id)
                    If (Con.ExecQuery(sql) >= 1) Then
                        Save = True
                        'Return True
                    Else
                        Save = False
                    End If
                End If
            Catch ex As Exception
            Save = False
            End Try
    End Function
    Public Function ChkAllo(ByVal strFunction As String, ByVal lngRole_Id As Long) As Boolean
        Try
            Dim sql As String
            Dim Con As New clsConnection
            Dim Fun As New clsFunctions

            sql = "Select Is_Allow from Role_Alloction where Role_Id=" & lngRole_Id
            sql = sql & " and Function_Id = (Select Id from Function_Master where name=" & Fun.SQLString(strFunction) & ")"
            ChkAllo = Con.GetValue(sql)
        Catch ex As Exception

        End Try


    End Function
    End Class


