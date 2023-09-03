'Imports Microsoft.VisualBasic
'Imports System

'Public Class clsQuestionpaper_Detail
'    Dim m_Id As Long
'    Dim m_lngQuestion_Id As Long
'    Dim m_lngquestionpaper_Id As Long
'    Dim m_lngQuestion_No As Long
'    Dim m_lngQuestionNo_Id As Long
'    Dim m_lngParentQuestionNo As Long
'    Dim m_lngParentQuestionNo_Id As Long
'    Dim m_strRemark As String
'    Dim m_strErr As String

'    Public Sub init()
'        m_Id = 0
'        m_lngQuestion_Id = 0
'        m_lngquestionpaper_Id = 0
'        m_lngQuestion_No = 0
'        m_lngQuestionNo_Id = 0
'        m_lngParentQuestionNo = 0
'        m_lngParentQuestionNo_Id = 0
'        m_strRemark = ""
'        m_strErr = ""
'    End Sub

'    Public Function Save() As Boolean
'        Try
'            Dim Fun As New clsFunctions
'            Dim Con As New clsConnection
'            Dim sql As String
'            If m_Id = 0 Then
'                sql = "insert into Questionpaper_Detail ("
'                sql = sql & "Question_ID, "
'                sql = sql & "Questionpaper_ID, "
'                sql = sql & "QuestionNo, "
'                sql = sql & "QuestionNO_ID, "
'                sql = sql & "Parent_QuestionNo,"
'                sql = sql & "Parent_QuestionNo_ID,"
'                sql = sql & "Remark"
'                sql = sql & ") Values ("
'                sql = sql & Fun.SQLNumber(m_lngQuestion_Id) & ","
'                sql = sql & Fun.SQLNumber(m_lngquestionpaper_Id) & ","
'                sql = sql & Fun.SQLNumber(m_lngQuestion_No) & ","
'                sql = sql & Fun.SQLNumber(m_lngQuestionNo_Id) & ","
'                sql = sql & Fun.SQLNumber(m_lngParentQuestionNo) & ","
'                sql = sql & Fun.SQLNumber(m_lngParentQuestionNo_Id) & ","
'                sql = sql & Fun.SQLString(m_strRemark) & ")"
'                If (Con.ExecQuery(sql) >= 1) Then
'                    Save = True
'                    sql = "select max(id) from Questionpaper_Detail"
'                    m_Id = Con.GetValue(sql)
'                Else
'                    m_strErr = sql
'                    Save = False
'                End If
'            Else
'                sql = "Update Questionpaper_Detail Set "
'                sql = sql & " Question_ID = " & Fun.SQLNumber(m_lngQuestion_Id) & ", "
'                sql = sql & " Questionpaper_ID = " & Fun.SQLNumber(m_lngquestionpaper_Id) & ", "
'                sql = sql & "Question_No=" & Fun.SQLNumber(m_lngQuestion_No) & ","
'                sql = sql & "QuestionNo_ID=" & Fun.SQLNumber(m_lngQuestionNo_Id) & ","
'                sql = sql & "Parent_QuestionNo=" & Fun.SQLNumber(m_lngParentQuestionNo) & ","
'                sql = sql & "Parent_QuestionNo_Id=" & Fun.SQLNumber(m_lngParentQuestionNo_Id) & ","
'                sql = sql & " Remark=" & Fun.SQLString(m_strRemark) & " "
'                sql = sql & " where id=" & Fun.SQLNumber(m_Id)
'                If (Con.ExecQuery(sql) >= 1) Then
'                    Save = True
'                Else
'                    m_strErr = sql
'                    Save = False
'                End If
'            End If
'        Catch ex As Exception
'            Save = False
'            'm_strErr = ex.message
'        End Try
'    End Function

'    Public Sub GetById(Optional ByVal lngID As Long = 0)
'        Try
'            Dim sql As String
'            Dim Fun As New clsFunctions
'            Dim Con As New clsConnection
'            Dim Dt As New DataTable
'            If lngID <> 0 Then
'                m_Id = lngID
'            End If
'            sql = "Select * from Questionpaper_Detail where id=" & Fun.SQLNumber(m_Id)
'            Dt = Con.GetDataTable(sql)
'            m_lngQuestion_Id = Dt.Rows(0).Item("Question_Id")
'            m_lngquestionpaper_Id = Dt.Rows(0).Item("Questionpaper_Id")
'            m_lngQuestion_No = Dt.Rows(0).Item("Question_No")
'            m_lngParentQuestionNo = Dt.Rows(0).Item("Parent_QuestionNo")
'            m_lngParentQuestionNo_Id = Dt.Rows(0).Item("Parent_QuestionNo_Id")
'            m_lngQuestionNo_Id = Dt.Rows(0).Item("QuestionNo_ID")
'            m_strRemark = Dt.Rows(0).Item("Remark")
'        Catch ex As Exception

'        End Try

'    End Sub
'    Public Property Id() As Long
'        Get
'            Return m_Id
'        End Get
'        Set(ByVal value As Long)
'            m_Id = value
'        End Set
'    End Property
'    Public Property Question_Id() As Long
'        Get
'            Return m_lngQuestion_Id
'        End Get
'        Set(ByVal value As Long)
'            m_lngQuestion_Id = value
'        End Set
'    End Property
'    Public Property Questionpaper_Id() As Long
'        Get
'            Return m_lngquestionpaper_Id
'        End Get
'        Set(ByVal value As Long)
'            m_lngquestionpaper_Id = value
'        End Set
'    End Property
'    Public Property Question_No() As Long
'        Get
'            Return m_lngQuestion_No
'        End Get
'        Set(ByVal value As Long)
'            m_lngQuestion_No = value
'        End Set
'    End Property
'    Public Property QuestionNo_Id() As Long
'        Get
'            Return m_lngQuestionNo_Id
'        End Get
'        Set(ByVal value As Long)
'            m_lngQuestionNo_Id = value
'        End Set
'    End Property
'    Public Property Parent_QuestionNo() As Long
'        Get
'            Return m_lngParentQuestionNo
'        End Get
'        Set(ByVal value As Long)
'            m_lngParentQuestionNo = value
'        End Set
'    End Property
'    Public Property Parent_QuestionNo_Id() As Long
'        Get
'            Return m_lngParentQuestionNo_Id
'        End Get
'        Set(ByVal value As Long)
'            m_lngParentQuestionNo_Id = value
'        End Set
'    End Property
'    Public Property Remark() As String
'        Get
'            Return m_strRemark
'        End Get
'        Set(ByVal value As String)
'            m_strRemark = value
'        End Set
'    End Property

'End Class
Imports Microsoft.VisualBasic
Imports System

Public Class clsQuestionpaper_Detail
    Dim m_Id As Long
    Dim m_lngQuestion_Id As Long
    Dim m_lngquestionpaper_Id As Long
    Dim m_lngQuestion_No As Long
    Dim m_lngQuestionNo_Id As Long
    Dim m_lngParentQuestionNo As Long
    Dim m_lngParentQuestionNo_Id As Long
    Dim m_strHeading As String
    Dim m_strHeading_Que As String
    Dim m_strRemark As String
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngQuestion_Id = 0
        m_lngquestionpaper_Id = 0
        m_lngQuestion_No = 0
        m_lngQuestionNo_Id = 0
        m_lngParentQuestionNo = 0
        m_lngParentQuestionNo_Id = 0
        m_strHeading = ""
        m_strHeading_Que = ""
        m_strRemark = ""
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Questionpaper_Detail ("
                sql = sql & "Question_ID, "
                sql = sql & "Questionpaper_ID, "
                sql = sql & "QuestionNo, "
                sql = sql & "QuestionNO_ID, "
                sql = sql & "Parent_QuestionNo,"
                sql = sql & "Parent_QuestionNo_ID,"
                sql = sql & "Heading,"
                sql = sql & "Heading_Que,"
                sql = sql & "Remark"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngQuestion_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngquestionpaper_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngQuestion_No) & ","
                sql = sql & Fun.SQLNumber(m_lngQuestionNo_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngParentQuestionNo) & ","
                sql = sql & Fun.SQLNumber(m_lngParentQuestionNo_Id) & ","
                sql = sql & Fun.SQLString(m_strHeading) & ","
                sql = sql & Fun.SQLString(m_strHeading_Que) & ","
                sql = sql & Fun.SQLString(m_strRemark) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Questionpaper_Detail"
                    m_Id = Con.GetValue(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update Questionpaper_Detail Set "
                sql = sql & " Question_ID = " & Fun.SQLNumber(m_lngQuestion_Id) & ", "
                sql = sql & " Questionpaper_ID = " & Fun.SQLNumber(m_lngquestionpaper_Id) & ", "
                sql = sql & "Question_No=" & Fun.SQLNumber(m_lngQuestion_No) & ","
                sql = sql & "QuestionNo_ID=" & Fun.SQLNumber(m_lngQuestionNo_Id) & ","
                sql = sql & "Parent_QuestionNo=" & Fun.SQLNumber(m_lngParentQuestionNo) & ","
                sql = sql & "Parent_QuestionNo_Id=" & Fun.SQLNumber(m_lngParentQuestionNo_Id) & ","
                sql = sql & "Heading=" & Fun.SQLString(m_strHeading) & ","
                sql = sql & "Heading_Que=" & Fun.SQLString(m_strHeading_Que) & ","
                sql = sql & " Remark=" & Fun.SQLString(m_strRemark) & " "
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
            sql = "Select * from Questionpaper_Detail where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngQuestion_Id = Dt.Rows(0).Item("Question_Id")
            m_lngquestionpaper_Id = Dt.Rows(0).Item("Questionpaper_Id")
            m_lngQuestion_No = Dt.Rows(0).Item("Question_No")
            m_lngParentQuestionNo = Dt.Rows(0).Item("Parent_QuestionNo")
            m_lngParentQuestionNo_Id = Dt.Rows(0).Item("Parent_QuestionNo_Id")
            m_lngQuestionNo_Id = Dt.Rows(0).Item("QuestionNo_ID")
            m_strHeading = Dt.Rows(0).Item("Heading")
            m_strHeading_Que = Dt.Rows(0).Item("Heading_Que")
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
    Public Property Question_Id() As Long
        Get
            Return m_lngQuestion_Id
        End Get
        Set(ByVal value As Long)
            m_lngQuestion_Id = value
        End Set
    End Property
    Public Property Questionpaper_Id() As Long
        Get
            Return m_lngquestionpaper_Id
        End Get
        Set(ByVal value As Long)
            m_lngquestionpaper_Id = value
        End Set
    End Property
    Public Property Question_No() As Long
        Get
            Return m_lngQuestion_No
        End Get
        Set(ByVal value As Long)
            m_lngQuestion_No = value
        End Set
    End Property
    Public Property QuestionNo_Id() As Long
        Get
            Return m_lngQuestionNo_Id
        End Get
        Set(ByVal value As Long)
            m_lngQuestionNo_Id = value
        End Set
    End Property
    Public Property Parent_QuestionNo() As Long
        Get
            Return m_lngParentQuestionNo
        End Get
        Set(ByVal value As Long)
            m_lngParentQuestionNo = value
        End Set
    End Property
    Public Property Parent_QuestionNo_Id() As Long
        Get
            Return m_lngParentQuestionNo_Id
        End Get
        Set(ByVal value As Long)
            m_lngParentQuestionNo_Id = value
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
    Public Property Heading() As String
        Get
            Return m_strHeading
        End Get
        Set(ByVal value As String)
            m_strHeading = value
        End Set
    End Property
    Public Property Heading_Que() As String
        Get
            Return m_strHeading_Que
        End Get
        Set(ByVal value As String)
            m_strHeading_Que = value
        End Set
    End Property
End Class
