Imports Microsoft.VisualBasic
Imports System

Public Class clsQuestionpaper_Master
    Dim m_Id As Long
    Dim m_strName As String
    Dim m_lngBranch_Id As Long
    Dim m_lngsem_Id As Long
    Dim m_lngSubject_Id As Long
    Dim m_lngTotal_Marks As Long
    Dim m_lngPassing_Marks As Long
    Dim m_dtTotal_Duretion As DateTime
    Dim m_lngFormat_Id As Long
    Dim m_lngTimetable_Id As Long
    Dim m_strRamark As String
    'Dim m_strTotal As String
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_strName = ""
        m_lngBranch_Id = 0
        m_lngsem_Id = 0
        m_lngSubject_Id = 0
        m_lngTotal_Marks = 0
        m_lngPassing_Marks = 0
        m_dtTotal_Duretion = Nothing
        m_lngFormat_Id = 0
        m_lngTimetable_Id = 0
        m_strRamark = ""
        '   m_strTotal = ""
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Questionpaper_Master ("
                sql = sql & "Name, "
                sql = sql & "Branch_ID,"
                sql = sql & "Sem_ID,"
                sql = sql & "Subject_ID,"
                sql = sql & "Total_Marks,"
                sql = sql & "Passing_Marks,"
                sql = sql & "Total_Duretion,"
                sql = sql & "Format_ID,"
                sql = sql & "Timetable_ID,"
                '          sql = sql & "Total,"
                sql = sql & "Remark "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLString(m_strName) & ","
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngsem_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSubject_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngTotal_Marks) & ","
                sql = sql & Fun.SQLNumber(m_lngPassing_Marks) & ","
                sql = sql & Fun.SQLTime(m_dtTotal_Duretion) & ","
                sql = sql & Fun.SQLNumber(m_lngFormat_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngTimetable_Id) & ","
                '         sql = sql & Fun.SQLString(m_strTotal) & ","
                sql = sql & Fun.SQLString(m_strRamark) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Questionpaper_Master"
                    m_Id = Con.GetValue(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Questionpaper_Master Set "
                sql = sql & " Name = " & Fun.SQLString(m_strName) & ", "
                sql = sql & "Branch_ID=" & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & "Sem=" & Fun.SQLNumber(m_lngsem_Id) & ","
                sql = sql & "Subject_ID=" & Fun.SQLNumber(m_lngSubject_Id) & ","
                sql = sql & "Total_Marks=" & Fun.SQLNumber(m_lngTotal_Marks) & ","
                sql = sql & "Passing_Marks=" & Fun.SQLNumber(m_lngPassing_Marks) & ","
                sql = sql & "Total_Durestion=" & Fun.SQLTime(m_dtTotal_Duretion) & ","
                sql = sql & "Format_ID=" & Fun.SQLNumber(m_lngFormat_Id) & ","
                sql = sql & "Timetable_ID=" & Fun.SQLNumber(m_lngTimetable_Id) & ","
                '        sql = sql & "Total=" & Fun.SQLString(m_strTotal) & ","
                sql = sql & " Remark = " & Fun.SQLString(m_strRamark) & " "
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
            sql = "Select * from Questionpaper_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_strName = Dt.Rows(0).Item("Name")
            m_lngBranch_Id = Dt.Rows(0).Item("Branch_Id")
            m_lngsem_Id = Dt.Rows(0).Item("Sem_ID")
            m_lngSubject_Id = Dt.Rows(0).Item("Subject_Id")
            m_lngTotal_Marks = Dt.Rows(0).Item("Total_Marks")
            m_lngPassing_Marks = Dt.Rows(0).Item("Passing_Marks")
            m_lngFormat_Id = Dt.Rows(0).Item("Format_Id")
            m_dtTotal_Duretion = Dt.Rows(0).Item("Total_Duretion")
            m_lngTimetable_Id = Dt.Rows(0).Item("Timetable_Id")
            '   m_strTotal = Dt.Rows(0).Item("Total")
            m_strRamark = Dt.Rows(0).Item("Remark")

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
    Public Property Branch_Id() As Long
        Get
            Return m_lngBranch_Id
        End Get
        Set(ByVal value As Long)
            m_lngBranch_Id = value
        End Set
    End Property
    Public Property Sem_Id() As Long
        Get
            Return m_lngsem_Id
        End Get
        Set(ByVal value As Long)
            m_lngsem_Id = value
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
    Public Property Total_Marks() As Long
        Get
            Return m_lngTotal_Marks
        End Get
        Set(ByVal value As Long)
            m_lngTotal_Marks = value
        End Set
    End Property
    Public Property Passing_Marks() As Long
        Get
            Return m_lngPassing_Marks
        End Get
        Set(ByVal value As Long)
            m_lngPassing_Marks = value
        End Set
    End Property
    Public Property Total_Duration() As DateTime
        Get
            Return m_dtTotal_Duretion
        End Get
        Set(ByVal value As DateTime)
            m_dtTotal_Duretion = value
        End Set
    End Property
    Public Property Format_Id() As Long
        Get
            Return m_lngFormat_Id
        End Get
        Set(ByVal value As Long)
            m_lngFormat_Id = value
        End Set
    End Property
    Public Property Timetable_Id() As Long
        Get
            Return m_lngTimetable_Id
        End Get
        Set(ByVal value As Long)
            m_lngTimetable_Id = value
        End Set
    End Property
    Public Property Remark() As String
        Get
            Return m_strRamark
        End Get
        Set(ByVal value As String)
            m_strRamark = value
        End Set
    End Property
    'Public Property Total() As String
    'Get
    '    Return m_strTotal
    ' End Get
    '  Set(ByVal value As String)
    '       m_strTotal = value
    '    End Set
    ' End Property
End Class
