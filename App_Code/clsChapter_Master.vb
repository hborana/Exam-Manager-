Imports Microsoft.VisualBasic

Public Class clsChapter_Master

    Dim m_Id As Long
    Dim m_strName As String
    Dim m_lngSubject_Id As Long
    Dim m_strErr As String

    Public Sub init()

        m_Id = 0
        m_lngSubject_Id = 0
        m_strName = ""
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try

            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Chapter_Master ("
                sql = sql & "Name, "
                sql = sql & "Subject_Id "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLString(m_strName) & ","
                sql = sql & Fun.SQLNumber(m_lngSubject_Id) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Chapter_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Chapter_Master Set "
                sql = sql & " Name = " & Fun.SQLString(m_strName) & ", "
                sql = sql & " Subject_Id = " & Fun.SQLNumber(m_lngSubject_Id) & " "
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
            sql = "Select * from Chapter_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_strName = Dt.Rows(0).Item("Name")
            m_lngSubject_Id = Dt.Rows(0).Item("Subject_Id")

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

    Public Property Subject_Id() As Long
        Get
            Return m_lngSubject_Id
        End Get
        Set(ByVal value As Long)
            m_lngSubject_Id = value
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

End Class
