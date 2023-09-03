Imports Microsoft.VisualBasic
Imports System

Public Class clsSupervisor_Report
    Dim m_Id As Long
    Dim m_lngStudent_Id As Long
    Dim m_strEnrolment As String
    Dim m_lngClass_Id As Long
    Dim m_lngTimetable_Id As Long
    Dim m_lngSeat_No As Long
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngStudent_Id = 0
        m_strEnrolment = 0
        m_lngClass_Id = 0
        m_lngTimetable_Id = 0
        m_lngSeat_No = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Supervisor_Report ("
                sql = sql & "Student_ID, "
                sql = sql & "Enrollment, "
                sql = sql & "Class_ID,"
                sql = sql & "Timetable_ID,"
                sql = sql & "Seat_No,"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngStudent_Id) & ","
                sql = sql & Fun.SQLString(m_strEnrolment) & ","
                sql = sql & Fun.SQLNumber(m_lngClass_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngTimetable_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngSeat_No) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Supervisor_Report"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Supervisor_Report Set "
                sql = sql & " Student_ID = " & Fun.SQLNumber(m_lngStudent_Id) & ", "
                sql = sql & " Enrollment = " & Fun.SQLString(m_strEnrolment) & ", "
                sql = sql & "Class_ID =" & Fun.SQLNumber(m_lngClass_Id) & ","
                sql = sql & "Timetable =" & Fun.SQLNumber(m_lngTimetable_Id) & ","
                sql = sql & "Seat_No =" & Fun.SQLNumber(m_lngSeat_No) & " "
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
            sql = "Select * from Supervisor_Report where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngStudent_Id = Dt.Rows(0).Item("Student_Id")
            m_strEnrolment = Dt.Rows(0).Item("Enrolment")
            m_lngClass_Id = Dt.Rows(0).Item("Class_Id")
            m_lngTimetable_Id = Dt.Rows(0).Item("Timetable_Id")
            m_lngSeat_No = Dt.Rows(0).Item("Seat_No")

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
    Public Property Student_Id() As Long
        Get
            Return m_lngStudent_Id
        End Get
        Set(ByVal value As Long)
            m_lngStudent_Id = value
        End Set
    End Property
    Public Property Enrolment() As String
        Get
            Return m_strEnrolment
        End Get
        Set(ByVal value As String)
            m_strEnrolment = value
        End Set
    End Property
    Public Property Class_Id() As Long
        Get
            Return m_lngClass_Id
        End Get
        Set(ByVal value As Long)
            m_lngClass_Id = value
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
    Public Property Seat_No() As Long
        Get
            Return m_lngSeat_No
        End Get
        Set(ByVal value As Long)
            m_lngSeat_No = value
        End Set
    End Property

End Class
