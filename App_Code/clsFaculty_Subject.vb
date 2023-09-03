Imports Microsoft.VisualBasic
Imports System

Public Class clsFaculty_Subject
    Dim m_Id As Long
    Dim m_lngFaculty_ID As Long
    Dim m_lngSubject_ID As Long
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngFaculty_ID = 0
        m_lngSubject_ID = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Faculty_Subject ("
                sql = sql & "Faculty_ID, "
                sql = sql & "Subject_ID"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngFaculty_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngSubject_ID) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Faculty_Subject"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Faculty_Subject Set "
                sql = sql & " Faculty_ID = " & Fun.SQLNumber(m_lngFaculty_ID) & ", "
                sql = sql & " Subject_ID = " & Fun.SQLNumber(m_lngSubject_ID) & ","
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
            sql = "Select * from Faculty_Subject where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngFaculty_ID = Dt.Rows(0).Item("Faculty_ID")
            m_lngSubject_ID = Dt.Rows(0).Item("Subject_ID")
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
    Public Property Faculty_ID() As Long
        Get
            Return m_lngFaculty_ID
        End Get
        Set(ByVal value As Long)
            m_lngFaculty_ID = value
        End Set
    End Property
    Public Property Subject_ID() As Long
        Get
            Return m_lngSubject_ID
        End Get
        Set(ByVal value As Long)
            m_lngSubject_ID = value
        End Set
    End Property
End Class

