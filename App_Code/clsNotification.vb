Imports Microsoft.VisualBasic

Public Class clsNotification
    Dim m_Id As Long
    Dim m_lngNotification_Settings_ID As Long
    Dim m_strMessage As String
    Dim m_lngSend_By As Long
    Dim m_lngTo_Whom As Long
    Dim m_dtDate_Of_Generation As Date
    Dim m_strRedirection_Feild As String
    Dim m_strRedirection_Value As String
    Dim m_strRedirection_Page As String
    Dim m_lngIsShown As Boolean
    Dim m_strErr As String

    Public Sub init()
        m_Id = 0
        m_lngNotification_Settings_ID = 0
        m_strMessage = ""
        m_lngSend_By = 0
        m_lngTo_Whom = 0
        m_dtDate_Of_Generation = Nothing
        m_strRedirection_Feild = ""
        m_strRedirection_Value = ""
        m_strRedirection_Page = ""
        m_lngIsShown = False
        m_strErr = ""
    End Sub

    Public Function Save() As Boolean
        Try
            Dim Fun As New clsFunctions
            Dim Con As New clsConnection
            Dim sql As String
            If m_Id = 0 Then
                sql = "insert into Notification ("
                sql = sql & "Notification_Settings_ID, "
                sql = sql & "Message,"
                sql = sql & "Send_By,"
                sql = sql & "To_Whom,"
                sql = sql & "Date_Of_Generation,"
                sql = sql & "Redirection_Field,"
                sql = sql & "Redirection_Value,"
                sql = sql & "Redirection_Page,"
                sql = sql & "IsShown"
                sql = sql & ") Values ("
                sql = sql & Fun.SQLNumber(m_lngNotification_Settings_ID) & ","
                sql = sql & Fun.SQLString(m_strMessage) & ","
                sql = sql & Fun.SQLNumber(m_lngSend_By) & ","
                sql = sql & Fun.SQLNumber(m_lngTo_Whom) & ","
                sql = sql & Fun.SQLDate(m_dtDate_Of_Generation) & ","
                sql = sql & Fun.SQLString(m_strRedirection_Feild) & ","
                sql = sql & Fun.SQLString(m_strRedirection_Value) & ","
                sql = sql & Fun.SQLString(m_strRedirection_Page) & ","
                sql = sql & Fun.SQLBool(m_lngIsShown) & ")"
                If (Con.ExecQuery(sql) >= 1) Then
                    Save = True
                    sql = "select max(id) from Notification"
                    m_Id = Con.ExecQuery(sql)
                Else
                    m_strErr = sql
                    Save = False
                End If
            Else
                sql = "Update  Set Notification"
                sql = sql & " Notification_Settings_ID = " & Fun.SQLNumber(m_lngNotification_Settings_ID) & ", "
                sql = sql & " Message = " & Fun.SQLString(m_strMessage) & ", "
                sql = sql & " Send_By = " & Fun.SQLNumber(m_lngSend_By) & ", "
                sql = sql & " To_Whom = " & Fun.SQLNumber(m_lngTo_Whom) & ", "
                sql = sql & " Date_Of_Generation = " & Fun.SQLDate(m_dtDate_Of_Generation) & ", "
                sql = sql & " Redirection_Feild = " & Fun.SQLString(m_strRedirection_Feild) & ", "
                sql = sql & " Redirection_Value = " & Fun.SQLString(m_strRedirection_Value) & ", "
                sql = sql & " Redirection_Page = " & Fun.SQLString(m_strRedirection_Page) & ", "
                sql = sql & " IsShown = " & Fun.SQLBool(m_lngIsShown) & " "
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
            sql = "Select * from Notification where id=" & Fun.SQLNumber(m_Id)
            Dt = Con.GetDataTable(sql)
            m_lngNotification_Settings_ID = Dt.Rows(0).Item("Notification_Settings_ID")
            m_strMessage = Dt.Rows(0).Item("Message")
            m_lngSend_By = Dt.Rows(0).Item("Send_By")
            m_lngTo_Whom = Dt.Rows(0).Item("To_Whom")
            m_strRedirection_Feild = Dt.Rows(0).Item("Redirection_Feild")
            m_strRedirection_Value = Dt.Rows(0).Item("Redirection_Value")
            m_strRedirection_Page = Dt.Rows(0).Item("Redirection_Page")
            m_lngIsShown = Dt.Rows(0).Item("IsShown")

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
    Public Property Notification_Settings_ID() As Long
        Get
            Return m_lngNotification_Settings_ID
        End Get
        Set(ByVal value As Long)
            m_lngNotification_Settings_ID = value
        End Set
    End Property
    Public Property Message() As String
        Get
            Return m_strMessage
        End Get
        Set(ByVal value As String)
            m_strMessage = value
        End Set
    End Property
    Public Property Send_By() As Long
        Get
            Return m_lngSend_By
        End Get
        Set(ByVal value As Long)
            m_lngSend_By = value
        End Set
    End Property

    Public Property To_Whom() As Long
        Get
            Return m_lngTo_Whom
        End Get
        Set(ByVal value As Long)
            m_lngTo_Whom = value
        End Set
    End Property
    Public Property Date_OfGeneration() As Date
        Get
            Return m_dtDate_Of_Generation
        End Get
        Set(ByVal value As Date)
            m_dtDate_Of_Generation = value
        End Set
    End Property
    Public Property Redirection_Feild() As String
        Get
            Return m_strRedirection_Feild
        End Get
        Set(ByVal value As String)
            m_strRedirection_Feild = value
        End Set
    End Property
    Public Property Redirection_Value() As String
        Get
            Return m_strRedirection_Value
        End Get
        Set(ByVal value As String)
            m_strRedirection_Value = value
        End Set
    End Property
    Public Property Redirection_Page() As String
        Get
            Return m_strRedirection_Page
        End Get
        Set(ByVal value As String)
            m_strRedirection_Page = value
        End Set
    End Property
    Public Property IsShown() As Boolean
        Get
            Return m_lngIsShown
        End Get
        Set(ByVal value As Boolean)
            m_lngIsShown = value
        End Set
    End Property
     
End Class
