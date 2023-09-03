Imports Microsoft.VisualBasic
Imports System

Public Class clsClass_Master
    Dim m_Id As Long
    Dim m_lngClass_No As Long
    Dim m_lngNumber_Of_Brenches As Long
    Dim m_lngStudent_Per_Bench As Long
    Dim m_strRemark As String
    Dim m_strErr As String

    Public Sub init()
        m_lngClass_No = 0
        m_Id = 0
        m_lngNumber_Of_Brenches = 0
        m_lngStudent_Per_Bench = 0
        m_strRemark = ""
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Class_Master ("
                sql = sql & "Class_No, "
                sql = sql & "Number_Of_Benches, "
                sql = sql & "Student_Per_Benches, "
                sql = sql & "Remark"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngClass_No) & ","
                sql = sql & Fun.SQLNumber(m_lngNumber_Of_Brenches) & ","
                sql = sql & Fun.SQLNumber(m_lngStudent_Per_Bench) & ","
                sql = sql & Fun.SQLString(m_strRemark) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Class_Master"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Class_Master Set "
                sql = sql & " Class_No = " & Fun.SQLNumber(m_lngClass_No) & ", "
                sql = sql & " Number_Of_Branchs = " & Fun.SQLNumber(m_lngNumber_Of_Brenches) & ", "
                sql = sql & " Student_Per_Benches = " & Fun.SQLNumber(m_lngStudent_Per_Bench) & ","
                sql = sql & "Remark =" & Fun.SQLString(m_strRemark) & " "
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
            sql = "Select * from Class_Master where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngClass_No = Dt.Rows(0).Item("Class_No")
            m_lngNumber_Of_Brenches = Dt.Rows(0).Item("Number_Of_Benches")
            m_lngStudent_Per_Bench = Dt.Rows(0).Item("Student_Per_Benches")
            m_strRemark = Dt.Rows(0).Item("Remark")
      
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
    Public Property Class_No() As Long
        Get
            Return m_lngClass_No
        End Get
        Set(ByVal value As Long)
            m_lngClass_No = value
        End Set
    End Property
    Public Property Number_Of_Benches() As Long
        Get
            Return m_lngNumber_Of_Brenches
        End Get
        Set(ByVal value As Long)
            m_lngNumber_Of_Brenches = value
        End Set
    End Property
    Public Property Student_Per_Bench() As Long
        Get
            Return m_lngStudent_Per_Bench
        End Get
        Set(ByVal value As Long)
            m_lngStudent_Per_Bench = value
        End Set
    End Property
    Public Property Remark() As String
        Get
            Return m_strRemark
        End Get
        Set(ByVal value As String)
            m_strRemark = value
        End Set
    End Property
End Class
