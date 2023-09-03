Imports Microsoft.VisualBasic
Imports System

Public Class clsFunction_Master
    Public Class clsFunction_Master
        Dim m_id As Long
        Dim m_strname As String
        Dim m_strremark As String


        Public Property Id As Long
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

        Public Property remark As String
            Get
                Return m_strremark
            End Get
            Set(value As String)
                m_strremark = value
            End Set
        End Property
       

        Public Sub init()
            m_id = 0
            m_strname = ""
            m_strremark = ""

        End Sub

        Public Function Save() As Boolean
            Try
                Dim sql As String
                Dim Fun As New clsFunctions
                Dim Con As New clsConnection
                If m_id = 0 Then
                    sql = "insert into function_master ("
                    sql = sql & "name,"
                    sql = sql & "remark"
                    sql = sql & " ) Values ("
                    sql = sql & Fun.SQLString(m_strname) & ", "
                    sql = sql & Fun.SQLString(m_strremark) & ") "
                    If (Con.ExecQuery(sql) >= 1) Then
                        Save = True
                        'Return True
                    Else
                        Save = False
                    End If
                Else
                    sql = "Update function_master set "
                    sql = sql & " name=" & Fun.SQLString(m_strname) & ", "
                    sql = sql & " remark=" & Fun.SQLString(m_strremark) & " "
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


End Class
