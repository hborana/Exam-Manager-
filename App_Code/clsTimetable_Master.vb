Imports Microsoft.VisualBasic
Imports System

Public Class clsTimetable_Master
    Dim m_Id As Long
    Dim m_dTt_Date As Date
    Dim m_dtFormatime As DateTime
    Dim m_dtTotime As DateTime
    Dim m_lngFormat_Id As Long
    Dim m_lngBranch_Id As Long
    Dim m_lngSem_ID As Long
    Dim m_lngSubject_Id As Long
    Dim m_lngExam_Id As Long
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_dTt_Date = Nothing
        m_dtFormatime = Nothing
        m_dtTotime = Nothing
        m_lngFormat_Id = 0
        m_lngBranch_Id = 0
        m_lngSem_ID = 0
        m_lngSubject_Id = 0
        m_lngExam_Id = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Timetable_Master ("
                sql = sql & "Tt_Date, "
                sql = sql & "Fromtime,"
                sql = sql & "Totime,"
                sql = sql & "Format_ID,"
                sql = sql & "Branch_ID,"
                sql = sql & "Sem_ID,"
                sql = sql & "Subject_ID,"
                sql = sql & "Exam_ID"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLDate(m_dTt_Date) & ","
                sql = sql & Fun.SQLTime(m_dtFormatime) & ","
                sql = sql & Fun.SQLTime(m_dtTotime) & ","
                sql = sql & Fun.SQLNumber(m_lngFormat_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSem_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngSubject_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngExam_Id) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Timetable_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Timetable_Master Set "
                sql = sql & " Tt_Date = " & Fun.SQLDate(m_dTt_Date) & ", "
                sql = sql & "Fromtime =" & Fun.SQLTime(m_dtFormatime) & ","
                sql = sql & "Totime=" & Fun.SQLTime(m_dtTotime) & ","
                sql = sql & "Format_ID=" & Fun.SQLNumber(m_lngFormat_Id) & ","
                sql = sql & "Branch_ID=" & Fun.SQLNumber(m_lngBranch_Id) & ","
                sql = sql & "Sem_ID=" & Fun.SQLNumber(m_lngSem_ID) & ","
                sql = sql & "Subject_ID=" & Fun.SQLNumber(m_lngSubject_Id) & ","
                sql = sql & "Exam_ID=" & Fun.SQLNumber(m_lngExam_Id) & " "
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
            sql = "Select * from Timetable_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngFormat_Id = Dt.Rows(0).Item("Format_Id")
            m_lngBranch_Id = Dt.Rows(0).Item("Branch_Id")
            m_lngSem_ID = Dt.Rows(0).Item("Sem_ID")
            m_lngSubject_Id = Dt.Rows(0).Item("Subject_Id")
            m_dTt_Date = Dt.Rows(0).Item("tt_Date")
            m_dtFormatime = Dt.Rows(0).Item("Formatime")
            m_dtTotime = Dt.Rows(0).Item("Totime")
            m_lngExam_Id = Dt.Rows(0).Item("Exam_Id")

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
    Public Property Tt_Date() As Date
        Get
            Return m_dTt_Date
        End Get
        Set(ByVal value As Date)
            m_dTt_Date = value
        End Set
    End Property
    Public Property Formtime() As DateTime
        Get
            Return m_dtFormatime
        End Get
        Set(ByVal value As DateTime)
            m_dtFormatime = value
        End Set
    End Property
    Public Property Totime() As DateTime
        Get
            Return m_dtTotime
        End Get
        Set(ByVal value As DateTime)
            m_dtTotime = value
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
    Public Property Branch_Id() As Long
        Get
            Return m_lngBranch_Id
        End Get
        Set(ByVal value As Long)
            m_lngBranch_Id = value
        End Set
    End Property
    Public Property Sem_ID() As Long
        Get
            Return m_lngSem_ID
        End Get
        Set(ByVal value As Long)
            m_lngSem_ID = value
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
    Public Property Exam_Id() As Long
        Get
            Return m_lngExam_Id
        End Get
        Set(ByVal value As Long)
            m_lngExam_Id = value
        End Set
    End Property
End Class
