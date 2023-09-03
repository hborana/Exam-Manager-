Imports Microsoft.VisualBasic

Public Class clsQuestionFormat_Detail
    Dim m_Id As Long
    Dim m_lngQuestionPaper_Format_ID As Long
    Dim m_lngMarks As Long
    Dim m_lngQuestion_Sub_No As Long
    Dim m_lngIs_Required As Boolean
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngQuestionPaper_Format_ID = 0
        m_lngMarks = 0
        m_lngQuestion_Sub_No = 0
        m_lngIs_Required = 0
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into QuestionFormat_Detail ("
                sql = sql & "QuestionPaper_Format_Id, "
                sql = sql & "Marks,"
                sql = sql & "Question_Sub_No,"
                sql = sql & "Is_Required"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngQuestionPaper_Format_ID) & ","
                sql = sql & Fun.SQLNumber(m_lngMarks) & ","
                sql = sql & Fun.SQLNumber(m_lngQuestion_Sub_No) & ","
                sql = sql & Fun.SQLBool(m_lngIs_Required) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from QuestionFormat_Detail"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update  Set QuestionFormat_Detail"
                sql = sql & " QuestionPaper_Format_ID = " & Fun.SQLNumber(m_lngQuestionPaper_Format_ID) & ", "
                sql = sql & " Required_No = " & Fun.SQLNumber(m_lngMarks) & ", "
                sql = sql & " Out_Of = " & Fun.SQLNumber(m_lngQuestion_Sub_No) & ", "
                sql = sql & " Is_Of_Same_Marks = " & Fun.SQLBool(m_lngIs_Required) & " "
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
            sql = "Select * from QuestionFormat_Detail where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngQuestionPaper_Format_ID = Dt.Rows(0).Item("QuestionPaper_Format_ID")
            m_lngMarks = Dt.Rows(0).Item("Marks")
            m_lngQuestion_Sub_No = Dt.Rows(0).Item("Question_Sub_No")
            m_lngIs_Required = Dt.Rows(0).Item("Is_Required")

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
    Public Property QuestionPaper_Format_Id() As Long
        Get
            Return m_lngQuestionPaper_Format_ID
        End Get
        Set(ByVal value As Long)
            m_lngQuestionPaper_Format_ID = value
        End Set
    End Property
    Public Property Marks() As Long
        Get
            Return m_lngMarks
        End Get
        Set(ByVal value As Long)
            m_lngMarks = value
        End Set
    End Property
    Public Property Question_Sub_No() As Long
        Get
            Return m_lngQuestion_Sub_No
        End Get
        Set(ByVal value As Long)
            m_lngQuestion_Sub_No = value
        End Set
    End Property

    Public Property Is_Required() As Boolean
        Get
            Return m_lngIs_Required
        End Get
        Set(ByVal value As Boolean)
            m_lngIs_Required = value
        End Set
    End Property
End Class
