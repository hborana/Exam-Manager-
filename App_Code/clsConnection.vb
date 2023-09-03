Imports System.Data
Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System
Imports Microsoft.VisualBasic

Public Class clsConnection
    Dim Cn As New SqlConnection
    Dim sqlCmd As SqlCommand
    Dim sqlAdp As SqlDataAdapter
    Dim sqlReader As SqlDataReader
    Dim Ds As DataSet
    Dim Dt As DataTable
    Dim strDBFileName As String
    'Dim Fun As New clsFunctions
    Dim ErrorMsg As String

    Public Property ErrorMessage As String
        Get
            Return ErrorMsg
        End Get
        Set(ByVal value As String)
            ErrorMsg = value
        End Set
    End Property

    Public Sub New()
        Try
            'Cn = New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog='SRRakhi_IMS';User ID='sa';Password='admin123'")
            'Cn = New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog='SRRakhi_IMS_1';Trusted_Connection=Yes")
            Cn = New SqlConnection("Data Source=LAPTOP-RCG2FOLR;Initial Catalog='ExamManager';Trusted_Connection=Yes")
            '       Cn.Open()
        Catch ex As Exception
            MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "SR_Rakhi  - Connection")
        End Try
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :		ReadFromFile
    ' Description : Read the data from file and return in string
    ' Parameters :	strFileName - File to be read with complete path
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Function ReadFromFile1(ByVal strFileName As String)
        ReadFromFile1 = ""
        If strFileName <> "" Then
            If File.Exists(strFileName) Then
                ReadFromFile1 = File.ReadAllText(strFileName)
            Else
                'MessageBox("File not found.", MsgBoxStyle.Critical)
            End If
        Else
            'MessageBox("Please specify the file name", MsgBoxStyle.Critical)
        End If
    End Function


    ''' <summary>
    ''' Get DataTable for Query
    ''' </summary>
    ''' <param name="strQuery">String Query</param>
    ''' <returns>DataTable - Result of the query</returns>
    ''' <remarks></remarks>
    Public Function GetDataTable(ByVal strQuery As String) As DataTable
        '''''''''''''''''''''''''''''''''''''''
        'oledbAdp = New OleDbDataAdapter(strQuery, Cn)
        'Dt = New DataTable
        'oledbAdp.Fill(Dt)
        'GetDataTable = Dt
        ''''''''''''''''''''''''''''''''''''''''
        sqlAdp = New SqlDataAdapter(strQuery, Cn)
        Dt = New DataTable
        sqlAdp.Fill(Dt)
        GetDataTable = Dt

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :		ExecQuery
    ' Description : Execute the query
    ' Parameters :	strQuery - sql query to be executed
    ' Returns :     On success - No. of rows affected
    '               On Failur  - 0
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''' <summary>
    ''' Execute Query
    ''' </summary>
    ''' <param name="strQuery">Query</param>
    ''' <returns>No. of rows affected</returns>
    ''' <remarks></remarks>
    Public Function ExecQuery(ByVal strQuery As String) As Integer
        '''''''''''''''''''''''''''''''''''''''''''''''''
        'ExecQuery = "0"
        'Dim x As Integer
        'Try
        '    oledbCmd = New OleDbCommand(strQuery)
        '    oledbCmd.Connection = Cn
        '    Cn.Open()
        '    x = oledbCmd.ExecuteNonQuery()
        '    ExecQuery = x.ToString
        '    oledbCmd.Dispose()
        'Catch ex As Exception
        '    ExecQuery = 0
        '    ErrorMsg = ex.Message
        '    MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "SR_Rakhi  - Connection")
        'Finally
        '    If Cn.State = ConnectionState.Open Then
        '        Cn.Close()
        '    End If
        'End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ExecQuery = "0"
        Dim x As Integer
        Try
            sqlCmd = New SqlCommand(strQuery)
            sqlCmd.Connection = Cn
            Cn.Open()
            x = sqlCmd.ExecuteNonQuery()
            ExecQuery = x.ToString
            sqlCmd.Dispose()
        Catch ex As Exception
            ExecQuery = 0
            ErrorMsg = ex.Message
            MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "SR_Rakhi  - Connection")
        Finally
            If Cn.State = ConnectionState.Open Then
                Cn.Close()
            End If
        End Try

    End Function

    Public Function ExecSP(ByVal strSP As String, ByVal sqlParam() As SqlParameter) As DataSet
        Try
            Dim i As Integer
            Cn.Open()
            sqlCmd = New SqlCommand(strSP, Cn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            For i = 0 To sqlParam.Length - 1
                sqlCmd.Parameters.Add(sqlParam(i))
            Next
            sqlAdp = New SqlDataAdapter(sqlCmd)
            Dim Ds As New DataSet
            sqlAdp.Fill(Ds)
            Return Ds
        Catch ex As Exception
            ErrorMsg = ex.Message
        Finally
            If Cn.State = ConnectionState.Open Then
                Cn.Close()
            End If
            sqlCmd.Dispose()
            Cn.Dispose()
        End Try

    End Function

    Public Function ExecSPDs(ByVal strSP As String, ByVal sqlParam() As SqlParameter) As DataSet
        Try
            Dim i As Integer
            sqlCmd = New SqlCommand(strSP, Cn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            For i = 0 To sqlParam.Length - 1
                sqlCmd.Parameters.Add(sqlParam(i))
            Next
            sqlAdp = New SqlDataAdapter(sqlCmd)
            Dim Ds As New DataSet
            sqlAdp.Fill(Ds)
        Catch ex As Exception
            ErrorMsg = ex.Message
        Finally
            If Cn.State = ConnectionState.Open Then
                Cn.Close()
            End If
            sqlCmd.Dispose()
            Cn.Dispose()
        End Try
    End Function

    Public Function ExecSPInt(ByVal strSP As String, ByVal sqlParam() As SqlParameter) As Integer
        Try
            Dim i As Integer
            sqlCmd = New SqlCommand(strSP, Cn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            For i = 0 To sqlParam.Length - 1
                sqlCmd.Parameters.Add(sqlParam(i))
            Next
            Cn.Open()
            ExecSPInt = sqlCmd.ExecuteNonQuery()
            'sqlAdp = New SqlDataAdapter(sqlCmd)
            'Dim Ds As New DataSet
            'sqlAdp.Fill(Ds)
        Catch ex As Exception
            ErrorMsg = ex.Message
        Finally
            If Cn.State = ConnectionState.Open Then
                Cn.Close()
            End If
            sqlCmd.Dispose()
            Cn.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' Execute command
    ''' </summary>
    ''' <param name="p_oledbCmd">Command</param>
    ''' <returns>No. of records affected</returns>
    ''' <remarks></remarks>
    Public Function ExecCommand(ByVal p_oledbCmd As SqlCommand) As Integer
        '    Public Function ExecCommand(ByVal p_oledbCmd As OleDbCommand) As Integer
        Try
            p_oledbCmd.Connection = Cn
            Cn.Open()
            ExecCommand = p_oledbCmd.ExecuteNonQuery
        Catch ex As Exception
            ExecCommand = 0
            ErrorMsg = ex.Message
            MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "SR_Rakhi  - Connection")
        Finally
            If Cn.State = ConnectionState.Open Then
                Cn.Close()
            End If
        End Try

    End Function

    ''' <summary>
    ''' Get max id from the given table
    ''' </summary>
    ''' <param name="tblName">Table Name</param>
    ''' <returns>Maximum id</returns>
    ''' <remarks></remarks>
    Public Function GetMaxID(ByVal tblName As String) As Long
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Try
        '    GetMaxID = 0
        '    oledbCmd = New OleDbCommand
        '    oledbCmd.CommandText = "Select max(id) from " & tblName
        '    oledbCmd.Connection = Cn
        '    Cn.Open()
        '    GetMaxID = oledbCmd.ExecuteScalar()
        '    'Cn.Close()
        'Catch ex As Exception
        '    ErrorMsg = ex.Message
        'Finally
        '    Cn.Close()
        'End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            GetMaxID = 0
            sqlCmd = New SqlCommand
            sqlCmd.CommandText = "Select max(id) from " & tblName
            sqlCmd.Connection = Cn
            Cn.Open()
            GetMaxID = sqlCmd.ExecuteScalar()
            'Cn.Close()
        Catch ex As Exception
            ErrorMsg = ex.Message
        Finally
            Cn.Close()
        End Try

    End Function

    ''' <summary>
    ''' Get value
    ''' </summary>
    ''' <param name="Sql">String Query</param>
    ''' <returns>Single value got from the query</returns>
    ''' <remarks></remarks>
    Public Function GetValue(ByVal Sql As String)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Try
        '    oledbCmd = New OleDbCommand
        '    oledbCmd.CommandText = Sql
        '    oledbCmd.Connection = Cn
        '    Cn.Open()
        '    GetValue = oledbCmd.ExecuteScalar()
        '    'Cn.Close()
        'Catch ex As Exception
        '    ErrorMsg = ex.Message
        'Finally
        '    Cn.Close()
        'End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            sqlCmd = New SqlCommand
            sqlCmd.CommandText = Sql
            sqlCmd.Connection = Cn
            Cn.Open()
            GetValue = sqlCmd.ExecuteScalar()
            'Cn.Close()
        Catch ex As Exception
            ErrorMsg = ex.Message
        Finally
            Cn.Close()
        End Try

    End Function

    Public Function getMaxAny(ByVal sqlParam As SqlParameter()) As String
        Try
            Dim i As Integer
            sqlCmd = New SqlCommand("getMaxAny", Cn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            For i = 0 To sqlParam.Length - 1
                sqlCmd.Parameters.Add(sqlParam(i))
            Next
            sqlAdp = New SqlDataAdapter(sqlCmd)
            Dim Ds As New DataSet
            sqlAdp.Fill(Ds)

            Dim x As String = String.Empty
            If Ds.Tables(0).Rows.Count <> 0 Then
                x = Ds.Tables(0).Rows(0)(0).ToString()
            Else
                'x = "0001"
            End If
            Return x

        Catch ex As Exception
            ErrorMsg = ex.Message
        Finally
            If Cn.State = ConnectionState.Open Then
                Cn.Close()
            End If
            sqlCmd.Dispose()
            Cn.Dispose()
        End Try
        '###########################################################################################################
        'Try
        '    Dim x As String
        '    Dim objDB As New DBConn()
        '    Dim ds As DataSet = objDB.getDS("getMaxAny", sqlParam)
        '    If ds.Tables(0).Rows.Count <> 0 Then
        '        x = ds.Tables(0).Rows(0).ItemArray.GetValue(0).ToString()
        '    Else
        '        x = "0001"
        '    End If
        '    Return (x)
        'Catch e As Exception

        '    Throw
        'End Try
    End Function

    Function GetDataSet(ByVal strSPName As String) As DataSet

        sqlAdp = New SqlDataAdapter(strSPName, Cn)
        Ds = New DataSet
        sqlAdp.Fill(Ds)
        GetDataSet = Ds
    End Function

    Private Sub MsgBox(p1 As String, p2 As Object, p3 As String)
        Throw New NotImplementedException
    End Sub

End Class
