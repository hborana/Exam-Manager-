Imports Microsoft.VisualBasic

Public Class clsStudentAllocation
    Dim m_Id As Long
    Dim m_lngClass_ID As Long
    Dim m_lngExam_ID As Long
    Dim m_lngStudent_ID As Long
    Dim m_lngTimetable_ID As Long
    Dim m_lngBranch_ID As Long
    Dim m_lngSeat_No As Long
    Dim m_strErr As String

    Public Sub init()
        m_lngClass_ID = 0
        m_Id = 0
        m_lngExam_ID = 0
        m_lngStudent_ID = 0
        m_lngTimetable_ID = 0
        m_lngBranch_ID = 0
        m_lngSeat_No = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Student_Allocation ("
                sql = sql & "Class_ID, "
                sql = sql & "Exam_ID, "
                sql = sql & "Student_ID, "
                sql = sql & "Timetable_ID, "
                sql = sql & "Branch_ID, "
                sql = sql & "Seat_No "
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngClass_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngExam_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngStudent_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngTimetable_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngBranch_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngSeat_No) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Student_Allocation"
                    m_Id = Con.GetValue(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Student_Allocation Set "
                sql = sql & " Class_ID = " & Fun.SQLNumber(m_lngClass_ID) & ", "
                sql = sql & " Exam_ID = " & Fun.SQLNumber(m_lngExam_ID) & ", "
                sql = sql & "Student_ID =" & Fun.SQLNumber(m_lngStudent_ID) & ","
                sql = sql & "Timetable_ID =" & Fun.SQLNumber(m_lngTimetable_ID) & ", "
                sql = sql & "Branch_ID" & Fun.SQLNumber(m_lngBranch_ID) & ","
                sql = sql & "Branch_ID" & Fun.SQLNumber(m_lngBranch_ID) & ","
                sql = sql & "Branch_ID" & Fun.SQLNumber(m_lngSeat_No) & " "
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
            sql = "Select * from Student_Allocation where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngClass_ID = Dt.Rows(0).Item("Class_ID")
            m_lngExam_ID = Dt.Rows(0).Item("Exam_ID")
            m_lngStudent_ID = Dt.Rows(0).Item("Student_ID")
            m_lngStudent_ID = Dt.Rows(0).Item("Timetable_ID")
            m_lngBranch_ID = Dt.Rows(0).Item("Branch_ID")
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
    Public Property Class_Id() As Long
        Get
            Return m_lngClass_ID
        End Get
        Set(ByVal value As Long)
            m_lngClass_ID = value
        End Set
    End Property
    Public Property Exam_Id() As Long
        Get
            Return m_lngExam_ID
        End Get
        Set(ByVal value As Long)
            m_lngExam_ID = value
        End Set
    End Property
    Public Property Student_Id() As Long
        Get
            Return m_lngStudent_ID
        End Get
        Set(ByVal value As Long)
            m_lngStudent_ID = value
        End Set
    End Property
    Public Property Timetable_Id() As Long
        Get
            Return m_lngTimetable_ID
        End Get
        Set(ByVal value As Long)
            m_lngTimetable_ID = value
        End Set
    End Property
    Public Property Branch_Id() As Long
        Get
            Return m_lngBranch_ID
        End Get
        Set(ByVal value As Long)
            m_lngBranch_ID = value
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
