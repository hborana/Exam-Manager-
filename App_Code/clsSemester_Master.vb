Imports Microsoft.VisualBasic
Imports System

Public Class clsSemester_Master

    Dim m_Id As Long
    Dim m_lngSem As Long
    Dim m_lngBranch_Id As Long

    Dim m_strErr As String

    Public Sub init()

        m_Id = 0
        m_lngBranch_Id = 0
        m_lngSem = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try

            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Semester_Master ("
                sql = sql & "Sem, "
                sql = sql & "Branch_ID "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngSem) & ","
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Semester_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Semester_Master Set "
                sql = sql & " Sem = " & Fun.SQLNumber(m_lngSem) & ", "
                sql = sql & " Branch_ID = " & Fun.SQLNumber(m_lngBranch_Id) & " "
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
            sql = "Select * from Semester_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngBranch_Id = Dt.Rows(0).Item("Branch_ID")
            m_lngSem = Dt.Rows(0).Item("Sem")
          
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

End Class
