'Imports Microsoft.VisualBasic
'Imports System

'Public Class clsQuestionPaper_Format
'    Dim m_Id As Long
'    Dim m_lngQuestion_No As Long
'    Dim m_lngRequired_No As Long
'    Dim m_lngParent_Question_Id As Long
'    Dim m_lngOut_of As Long
'    Dim m_lngMarks As Long
'    Dim m_lngIs_Of_Same_Marks As Boolean
'    Dim m_lngFormat_Id As Long
'    Dim m_lngParent_Question As Long
'    Dim m_strHeading As String
'    Dim m_strHeading_Que As String
'    Dim m_strErr As String

'    Public Sub init()
'        m_Id = 0
'        m_lngQuestion_No = 0
'        m_lngRequired_No = 0
'        m_lngOut_of = 0
'        m_lngMarks = 0
'        m_lngIs_Of_Same_Marks = 0
'        m_lngFormat_Id = 0
'        m_lngParent_Question = 0
'        m_lngParent_Question_Id = 0
'        m_strErr = ""
'    End Sub

'    Public Function Save() As Boolean
'        Try
'            Dim Fun As New clsFunctions
'            Dim Con As New clsConnection
'            Dim sql As String
'            If m_Id = 0 Then
'                sql = "insert into QuestionPaper_Format ("
'                sql = sql & "Question_No, "
'                sql = sql & "Required_No,"
'                sql = sql & "Out_Of,"
'                sql = sql & "Marks,"
'                sql = sql & "Is_Of_Same_Marks,"
'                sql = sql & "Format_ID,"
'                sql = sql & "Parent_Question,"
'                sql = sql & "Parent_Question_Id"
'                sql = sql & ") Values ("
'                sql = sql & Fun.SQLNumber(m_lngQuestion_No) & ","
'                sql = sql & Fun.SQLNumber(m_lngRequired_No) & ","
'                sql = sql & Fun.SQLNumber(m_lngOut_of) & ","
'                sql = sql & Fun.SQLNumber(m_lngMarks) & ","
'                sql = sql & Fun.SQLBool(m_lngIs_Of_Same_Marks) & ","
'                sql = sql & Fun.SQLNumber(m_lngFormat_Id) & ","
'                sql = sql & Fun.SQLNumber(m_lngParent_Question) & ","
'                sql = sql & Fun.SQLNumber(m_lngParent_Question_Id) & ")"
'                If (Con.ExecQuery(sql) >= 1) Then
'                    Save = True
'                    sql = "select max(id) from QuestionPaper_Format"
'                    m_Id = Con.ExecQuery(sql)
'                Else
'                    m_strErr = sql
'                    Save = False
'                End If
'            Else
'                sql = "Update  Set QuestionPaper_Format"
'                sql = sql & " Question_No = " & Fun.SQLNumber(m_lngQuestion_No) & ", "
'                sql = sql & " Required_No = " & Fun.SQLNumber(m_lngRequired_No) & ", "
'                sql = sql & " Out_Of = " & Fun.SQLNumber(m_lngOut_of) & ", "
'                sql = sql & " Marks = " & Fun.SQLNumber(m_lngMarks) & ", "
'                sql = sql & " Is_Of_Same_Marks = " & Fun.SQLBool(m_lngIs_Of_Same_Marks) & ","
'                sql = sql & " Format_ID = " & Fun.SQLNumber(m_lngFormat_Id) & ","
'                sql = sql & " Parent_Question = " & Fun.SQLNumber(m_lngParent_Question) & ","
'                sql = sql & " Parent_Question_Id = " & Fun.SQLNumber(m_lngParent_Question_Id) & " "
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
'            sql = "Select * from QuestionPaper_Format where id=" & Fun.SQLNumber(m_Id)
'            Dt = Con.GetDataTable(sql)
'            m_lngQuestion_No = Dt.Rows(0).Item("Question_No")
'            m_lngRequired_No = Dt.Rows(0).Item("Required_No")
'            m_lngOut_of = Dt.Rows(0).Item("Out_Of")
'            m_lngMarks = Dt.Rows(0).Item("Marks")
'            m_lngIs_Of_Same_Marks = Dt.Rows(0).Item("Is_Of_Same_Marks")
'            m_lngFormat_Id = Dt.Rows(0).Item("Format_ID")
'            m_lngParent_Question = Dt.Rows(0).Item("Parent_Question")
'            m_lngParent_Question_Id = Dt.Rows(0).Item("Parent_Question_Id")

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
'    Public Property Question_No() As Long
'        Get
'            Return m_lngQuestion_No
'        End Get
'        Set(ByVal value As Long)
'            m_lngQuestion_No = value
'        End Set
'    End Property
'    Public Property Required_No() As Long
'        Get
'            Return m_lngRequired_No
'        End Get
'        Set(ByVal value As Long)
'            m_lngRequired_No = value
'        End Set
'    End Property
'    Public Property Out_Of() As Long
'        Get
'            Return m_lngOut_of
'        End Get
'        Set(ByVal value As Long)
'            m_lngOut_of = value
'        End Set
'    End Property

'    Public Property Marks() As Long
'        Get
'            Return m_lngMarks
'        End Get
'        Set(ByVal value As Long)
'            m_lngMarks = value
'        End Set
'    End Property
'    Public Property Is_Of_Same_Marks() As Boolean
'        Get
'            Return m_lngIs_Of_Same_Marks
'        End Get
'        Set(ByVal value As Boolean)
'            m_lngIs_Of_Same_Marks = value
'        End Set
'    End Property
'    Public Property Format_Id() As Long
'        Get
'            Return m_lngFormat_Id
'        End Get
'        Set(ByVal value As Long)
'            m_lngFormat_Id = value
'        End Set
'    End Property
'    Public Property Parent_Question() As Long
'        Get
'            Return m_lngParent_Question
'        End Get
'        Set(ByVal value As Long)
'            m_lngParent_Question = value
'        End Set
'    End Property
'    Public Property Parent_Question_Id() As Long
'        Get
'            Return m_lngParent_Question_Id
'        End Get
'        Set(ByVal value As Long)
'            m_lngParent_Question_Id = value
'        End Set
'    End Property
'End Class
Imports Microsoft.VisualBasic
Imports System

Public Class clsQuestionPaper_Format
    Dim m_Id As Long
    Dim m_lngQuestion_No As Long
    Dim m_lngRequired_No As Long
    Dim m_lngParent_Question_Id As Long
    Dim m_lngOut_of As Long
    Dim m_lngMarks As Long
    Dim m_lngIs_Of_Same_Marks As Boolean
    Dim m_lngFormat_Id As Long
    Dim m_lngParent_Question As Long
    Dim m_strHeading As String
    Dim m_strHeading_Que As String

    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngQuestion_No = 0
        m_lngRequired_No = 0
        m_lngOut_of = 0
        m_lngMarks = 0
        m_lngIs_Of_Same_Marks = 0
        m_lngFormat_Id = 0
        m_lngParent_Question = 0
        m_lngParent_Question_Id = 0
        m_strHeading = ""
        m_strHeading_Que = ""

        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into QuestionPaper_Format ("
                sql = sql & "Question_No, "
                sql = sql & "Required_No,"
                sql = sql & "Out_Of,"
                sql = sql & "Marks,"
                sql = sql & "Is_Of_Same_Marks,"
                sql = sql & "Format_ID,"
                sql = sql & "Parent_Question,"
                sql = sql & "Heading,"
                sql = sql & "Heading_Que,"
                sql = sql & "Parent_Question_Id"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngQuestion_No) & ","
                sql = sql & Fun.SQLNumber(m_lngRequired_No) & ","
                sql = sql & Fun.SQLNumber(m_lngOut_of) & ","
                sql = sql & Fun.SQLNumber(m_lngMarks) & ","
                sql = sql & Fun.SQLBool(m_lngIs_Of_Same_Marks) & ","
                sql = sql & Fun.SQLNumber(m_lngFormat_Id) & ","
                sql = sql & Fun.SQLNumber(m_lngParent_Question) & ","
                sql = sql & Fun.SQLString(m_strHeading) & ","
                sql = sql & Fun.SQLString(m_strHeading_Que) & ","
                sql = sql & Fun.SQLNumber(m_lngParent_Question_Id) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from QuestionPaper_Format"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update  Set QuestionPaper_Format"
                sql = sql & " Question_No = " & Fun.SQLNumber(m_lngQuestion_No) & ", "
                sql = sql & " Required_No = " & Fun.SQLNumber(m_lngRequired_No) & ", "
                sql = sql & " Out_Of = " & Fun.SQLNumber(m_lngOut_of) & ", "
                sql = sql & " Marks = " & Fun.SQLNumber(m_lngMarks) & ", "
                sql = sql & " Is_Of_Same_Marks = " & Fun.SQLBool(m_lngIs_Of_Same_Marks) & ","
                sql = sql & " Format_ID = " & Fun.SQLNumber(m_lngFormat_Id) & ","
                sql = sql & " Parent_Question = " & Fun.SQLNumber(m_lngParent_Question) & ","
                sql = sql & "Heading=" & Fun.SQLString(m_strHeading) & ","
                sql = sql & "Heading_Que=" & Fun.SQLString(m_strHeading_Que) & ","
                sql = sql & " Parent_Question_Id = " & Fun.SQLNumber(m_lngParent_Question_Id) & " "
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
            sql = "Select * from QuestionPaper_Format where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngQuestion_No = Dt.Rows(0).Item("Question_No")
            m_lngRequired_No = Dt.Rows(0).Item("Required_No")
            m_lngOut_of = Dt.Rows(0).Item("Out_Of")
            m_lngMarks = Dt.Rows(0).Item("Marks")
            m_lngIs_Of_Same_Marks = Dt.Rows(0).Item("Is_Of_Same_Marks")
            m_lngFormat_Id = Dt.Rows(0).Item("Format_ID")
            m_lngParent_Question = Dt.Rows(0).Item("Parent_Question")
            m_lngParent_Question_Id = Dt.Rows(0).Item("Parent_Question_Id")
            m_strHeading = Dt.Rows(0).Item("Heading")
            m_strHeading_Que = Dt.Rows(0).Item("Heading_Que")

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
    Public Property Question_No() As Long
        Get
            Return m_lngQuestion_No
        End Get
        Set(ByVal value As Long)
            m_lngQuestion_No = value
        End Set
    End Property
    Public Property Required_No() As Long
        Get
            Return m_lngRequired_No
        End Get
        Set(ByVal value As Long)
            m_lngRequired_No = value
        End Set
    End Property
    Public Property Out_Of() As Long
        Get
            Return m_lngOut_of
        End Get
        Set(ByVal value As Long)
            m_lngOut_of = value
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
    Public Property Is_Of_Same_Marks() As Boolean
        Get
            Return m_lngIs_Of_Same_Marks
        End Get
        Set(ByVal value As Boolean)
            m_lngIs_Of_Same_Marks = value
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
    Public Property Parent_Question() As Long
        Get
            Return m_lngParent_Question
        End Get
        Set(ByVal value As Long)
            m_lngParent_Question = value
        End Set
    End Property
    Public Property Parent_Question_Id() As Long
        Get
            Return m_lngParent_Question_Id
        End Get
        Set(ByVal value As Long)
            m_lngParent_Question_Id = value
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
