Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data

Public Class clsFunctions

    Dim Con As New clsConnection

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' Name :				FormatDateDisplay(p_vntDate)
    '' Description : 		Format a date to be displayed  
    '' Parameters :			1.	p_vntDate -> date to be formatted
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Public Function FormatDateDisplay(ByVal p_vntDate)
    '    Dim strResult
    '    If IsDate(p_vntDate) And Not IsBlank(p_vntDate) Then
    '        ' Appends leading zero to all the entities, extracts 2 characters from right, and builds the string
    '        '		strResult = DatePart("yyyy", p_vntDate) _
    '        '			        & "/" & Right("0" & DatePart("m", p_vntDate), 2) _ 
    '        '			        & "/" & Right("0" & DatePart("d", p_vntDate), 2)
    '        strResult = Right("0" & DatePart("d", p_vntDate), 2) _
    '                 & "/" & Right("0" & DatePart("m", p_vntDate), 2) _
    '                 & "/" & DatePart("yyyy", p_vntDate)
    '    Else
    '        strResult = ""
    '    End If
    '    FormatDateDisplay = strResult
    'End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				ConvertNumber(p_vntValue)
    ' Description : 		Convert a value into a numeric value  
    ' Parameters :			1.	p_vntValue -> value to convert into a numeric value
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function ConvertNumber(ByVal p_vntValue)

        If IsBlank(p_vntValue) Or Not IsNumeric(p_vntValue) Then
            ConvertNumber = 0
        Else
            ConvertNumber = CDbl(Trim(p_vntValue))
        End If

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				SQLString(p_strString)
    ' Description : 		Format a string variable value to be used in an SQL statement  
    ' Parameters :			1.	p_strString -> string to be formatted
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function SQLString(ByVal p_strString)

        If IsBlank(p_strString) Then
            SQLString = "''"
        Else
            SQLString = "'" & Replace(p_strString, "'", "''") & "'"
        End If

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				SQLMem(p_strString)
    ' Description : 		Format a memo variable value to be used in an SQL statement  
    ' Parameters :			1.	p_memMemo     -> Memo data to be transformed.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function SQLMem(ByVal p_memMemo)

        If IsBlank(p_memMemo) Then
            SQLMem = "NULL"
        Else
            SQLMem = "'" & Replace(Replace(p_memMemo, "'", "''"), "<br>", vbCrLf) & "'"
        End If

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				SQLBool(p_ysnBool)
    ' Description : 		Format a boolean variable value to be used in an SQL statement  
    ' Parameters :			1.	p_ysnBool -> boolean to be formatted
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function SQLBool(ByVal p_ysnBool)

        If p_ysnBool Then
            SQLBool = "1"
        Else
            SQLBool = "0"
        End If

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				SQLNumber(p_dblNumber)
    ' Description : 		Format a numeric variable value to be used in an SQL statement  
    ' Parameters :			1.	p_dblNumber -> numeric value to be formatted
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function SQLNumber(ByVal p_dblNumber)

        If IsBlank(p_dblNumber) Or Not IsNumeric(p_dblNumber) Then
            SQLNumber = 0
        Else
            SQLNumber = p_dblNumber
        End If

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				SQLDate(p_dtmDate)
    ' Description : 		Format a numeric variable value to be used in an SQL statement  
    ' Parameters :			1.	p_dtmDate -> date value to be formatted
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function SQLDate(ByVal p_dtmDate)

        Dim dtmDateRet

        If IsDate(p_dtmDate) Then
            dtmDateRet = DatePart("yyyy", p_dtmDate) & "/"
            If DatePart("m", p_dtmDate) < 10 Then
                dtmDateRet = dtmDateRet & "0" & DatePart("m", p_dtmDate) & "/"
            Else
                dtmDateRet = dtmDateRet & DatePart("m", p_dtmDate) & "/"
            End If

            If DatePart("d", p_dtmDate) < 10 Then
                dtmDateRet = dtmDateRet & "0" & DatePart("d", p_dtmDate)
            Else
                dtmDateRet = dtmDateRet & DatePart("d", p_dtmDate)
            End If

            SQLDate = "'" & dtmDateRet & "'"
        Else
            SQLDate = "NULL"
        End If

    End Function

    Public Function SQLTime(ByVal p_dtTime)
        Dim dtmTimeRet

        If (IsDate(p_dtTime)) Then
            dtmTimeRet = FormatDateTime(p_dtTime, DateFormat.LongTime)
            SQLTime = "'" & dtmTimeRet & "'"
        Else
            SQLTime = Nothing
        End If

    End Function


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' Name :				UrlEncode(p_strValue)
    '' Description : 		Url Encode a string value  
    '' Parameters :			1.	p_strValue -> value to be url encoded
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Public Function UrlEncode(ByVal p_strValue)

    '    If Not isNull(p_strValue) Or p_strValue <> "" Then
    '        UrlEncode = Server.UrlEncode(p_strValue)
    '    Else
    '        UrlEncode = ""
    '    End If

    'End Function


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				IsBlank(p_vntValue)
    ' Description : 		Check if a value is an empty string, null, nothing or empty  
    ' Parameters :			1.	p_Value -> the value to check
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function IsBlank(ByVal p_vntValue As Object)
        Try
            If IsDBNull(p_vntValue) Or p_vntValue.ToString() = "" Or p_vntValue = Nothing Then
                IsBlank = True
            Else
                IsBlank = False
            End If

        Catch ex As Exception
            IsBlank = True
        End Try
        'If Not isObject(p_vntValue) Then

        '    If isNull(p_vntValue) Or p_vntValue = "" Or isEmpty(p_vntValue) Then
        '        IsBlank = True
        '    Else
        '        IsBlank = False
        '    End If

        'Else

        '    If p_vntValue Is Nothing Then
        '        IsBlank = True
        '    ElseIf p_vntValue = "" Or isNull(p_vntValue) Or isEmpty(p_vntValue) Then
        '        IsBlank = True
        '    Else
        '        IsBlank = False
        '    End If

        'End If

    End Function


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' '' Name :				Write(p_strValue)
    ' '' Description : 		Response.Write the p_strValue variable and add a vbcrlf at the end   
    ' '' Parameters :			1.	p_Value -> the value to writes
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''Public Sub Write(ByVal p_strValue)
    ''    Response.Write(p_strValue & vbcrlf)
    ''End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				Append(p_strVariable, p_strValue)
    ' Description : 		Append the p_strValue to the p_strVariable followed by a vbcrlf   
    ' Parameters :			1.	p_strVariable -> variable to append a text to
    ' 						2.	p_strValue -> text to append
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub Append(ByVal p_strVariable, ByVal p_strValue)
        p_strVariable = p_strVariable & p_strValue & vbCrLf
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' Name :				GetTexte(p_vntFrenchValue, p_vntEnglishValue)
    '' Description : 		Return the first or second parameter based on the language session   
    '' Parameters :			1.	p_strFrenchText -> text in french
    '' 						2.	p_strFrenchText -> text in french
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Public Function GetTexte(ByVal p_vntFrenchValue, ByVal p_vntEnglishValue)

    '    ' If language session variable is blank, use the default language constant
    '    If isBlank(Session("strLanguage" & STR_SESSION_SUFFIX)) Then
    '        Session("strLanguage" & STR_SESSION_SUFFIX) = STR_LANGUAGE_DEFAULT
    '    End If

    '    ' Return the first or second parameter based on the language session
    '    Select Case Session("strLanguage" & STR_SESSION_SUFFIX)

    '        Case STR_LANGUAGE_FRENCH
    '            GetTexte = p_vntFrenchValue

    '        Case STR_LANGUAGE_FRENCH
    '            GetTexte = p_vntEnglishValue

    '        Case Else
    '            GetTexte = p_vntEnglishValue

    '    End Select

    'End Function


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' Name :				CSSText(p_intIndexTextClass, p_strText)
    '' Description : 		Display a text and format it with a css style based on the parameter
    '' Parameters :			1.	p_intIndexTextClass -> index of the css class to use. from 1 to 5, from bigger to smaller. 0 is default size 
    ''						2.	p_strText -> text to display
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Public Function CSSText(ByVal p_intIndexTextClass, ByVal p_strText)

    '    CSSText = "<span class=""text" & p_intIndexTextClass & """>" & p_strText & "</span>"

    'End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				CSSTitle(p_intIndexTitleClass, p_strTitle)
    ' Description : 		Display a title and format it with a css style based on the parameter 
    ' Parameters :			1.	p_intIndexTitleClass -> index of the css class to use. from 1 to 4, from bigger to smaller. 0 is default size
    '						2.	p_strTitle -> title to display
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function CSSTitle(ByVal p_intIndexTitleClass, ByVal p_strTitle)

        CSSTitle = "<span class=""title" & p_intIndexTitleClass & """>" & p_strTitle & "</span>"

    End Function



    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				GetHTMLImageTagPath(p_strHTMLTag)
    ' Description : 		Return the image path in an HTML image tag.
    ' Parameters :			1.	p_strHTMLTag -> Html tag of the image.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function GetHTMLImageTagPath(ByVal p_strHTMLTag)

        Dim strTagDelimiter
        Dim strImagePath
        Dim intSRCPositionStart
        Dim intSRCPositionEnd

        intSRCPositionStart = 0
        intSRCPositionEnd = 0
        strImagePath = ""
        strTagDelimiter = "src="""

        ' Find the position of the path.
        intSRCPositionStart = InStr(p_strHTMLTag, strTagDelimiter)
        intSRCPositionEnd = InStr(intSRCPositionStart + Len(strTagDelimiter), p_strHTMLTag, """")

        ' Extracting the path
        If (intSRCPositionStart > 0 And intSRCPositionEnd > 0 And intSRCPositionEnd > intSRCPositionStart) Then
            strImagePath = Mid(p_strHTMLTag, intSRCPositionStart + Len(strTagDelimiter), intSRCPositionEnd)
            intSRCPositionEnd = InStr(intSRCPositionStart + Len(strTagDelimiter), strImagePath, """")
            strImagePath = Left(strImagePath, intSRCPositionEnd - 1)
        End If

        GetHTMLImageTagPath = strImagePath

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' '' Name :				GetImageSize(ByVal strImagePath, intWidth, intHeight)
    ' '' Description : 		Return the image width and height properties.
    ' '' Parameters :			1.	strImagePath -> Html tag of the image.
    ' ''						2.	intWidth -> The returned width value of the image file.
    ' ''						3.	intHeight -> The returned height value of the image file.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''Sub GetImageSize(ByVal p_strImagePath, ByVal p_intWidth, ByVal p_intHeight)

    ''    Dim objFileSystem
    ''    Dim objImage

    ''    objFileSystem = CreateObject("Scripting.FileSystemObject")

    ''    If objFileSystem.fileExists(p_strImagePath) Then

    ''        p_intWidth = 0
    ''        p_intHeight = 0

    ''        If objFileSystem.fileExists(p_strImagePath) Then

    ''            objImage = loadpicture(p_strImagePath)

    ''            p_intWidth = round(objImage.width / 26.4583)
    ''            p_intHeight = round(objImage.height / 26.4583)

    ''        End If

    ''    End If

    ''    objImage = Nothing
    ''    objFileSystem = Nothing

    ''End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				IsExistingFile(p_strFilePath)
    ' Description : 		Indicates if a file exists on the server.
    ' Parameters :			1.	p_strFilePath -> The file path
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function IsExistingFile(ByVal p_strFilePath)

        Dim objFileSystem
        Dim ysnIsPath

        objFileSystem = CreateObject("Scripting.FileSystemObject")

        ysnIsPath = False

        If objFileSystem.fileExists(p_strFilePath) Then
            ysnIsPath = True
        End If

        objFileSystem = Nothing

        IsExistingFile = ysnIsPath

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				RoundUp(p_dblNumber)
    ' Description : 		Rounds a double value always to the higher value.
    ' Parameters :			1.	p_dblNumber -> The double value to round up.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function RoundUp(ByVal p_dblNumber)
        If p_dblNumber > Int(p_dblNumber) Then
            RoundUp = Int(p_dblNumber) + 1
        Else
            RoundUp = p_dblNumber
        End If
    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				GetSecureString(p_strString)
    ' Description : 		Returns a string with a specified part of caracter replaced with *.
    ' Parameters :			1.	p_strString -> The string to transform.
    '						2.  p_intPostionStart -> Position where we start to hide the data. Starts at 0.
    '						3.  p_intLength -> Length of the data to hide.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function GetSecureString(ByVal p_strString, ByVal p_intPostionStart, ByVal p_intLength)

        Dim strSecureString
        Dim strHiddenData
        Dim intCpt

        strSecureString = ""
        strHiddenData = ""

        If Not IsBlank(p_strString) Then

            For intCpt = 1 To p_intLength
                strHiddenData = strHiddenData & "*"
            Next

            strSecureString = Left(p_strString, p_intPostionStart)
            strSecureString = strSecureString & strHiddenData & Right(p_strString, Len(p_strString) - (p_intLength + p_intPostionStart))

        End If

        GetSecureString = strSecureString

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				SQLVariantData(p_strFieldName,p_strFieldValue)
    ' Description : 		Format a variable value to be used in an SQL statement.
    ' Parameters :			1.	p_strFieldName -> The field name
    '						2.  p_strFieldValue -> The field value
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function SQLVariantData(ByVal p_strFieldName, ByVal p_strFieldValue)

        Dim strReturnString

        Select Case Left(p_strFieldName, 3)

            Case "str"

                strReturnString = SQLString(p_strFieldValue)

            Case "ysn"

                strReturnString = SQLBool(p_strFieldValue)

            Case "dbl", "cnt"

                strReturnString = SQLNumber(p_strFieldValue)

            Case "mem"

                strReturnString = SQLMem(p_strFieldValue)

            Case "dtm"

                If p_strFieldValue = "GETDATE()" Then
                    strReturnString = p_strFieldValue
                Else
                    strReturnString = SQLDate(p_strFieldValue)
                End If

            Case Else

                strReturnString = p_strFieldValue

        End Select

        SQLVariantData = strReturnString

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				GetSQLUpdateQuery( p_strTableName, p_arrFieldNames, p_arrFieldValue, p_arrCriteriaFields, p_arrCriteriaValues)
    ' Description : 		Return a UPDATE SQL Statement string.
    ' Parameters :			1.	p_strTableName -> String. Database table name.
    '						2.  p_arrFieldNames -> String array. Field name to update.
    '						2.  p_arrFieldValue -> String array. Field value to update.
    '						2.  p_arrCriteriaFields -> String array. Criteria field name to update.
    '						2.  p_arrCriteriaValues -> String array. Criteria field value to update.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function GetSQLUpdateQuery(ByVal p_strTableName, ByVal p_arrFieldNames, ByVal p_arrFieldValue, ByVal p_arrCriteriaFields, ByVal p_arrCriteriaValues)

        Dim strQ
        Dim intRowCpt


        ' Start the building of the SQL Update query
        strQ = "UPDATE " & p_strTableName & " SET "


        ' Updated fields of the SQL Update query
        For intRowCpt = 0 To UBound(p_arrFieldNames)

            strQ = strQ & p_arrFieldNames(intRowCpt) & "="
            strQ = strQ & SQLVariantData(p_arrFieldNames(intRowCpt), p_arrFieldValue(intRowCpt))
            strQ = strQ & ", "

        Next

        strQ = Left(strQ, Len(strQ) - 2)


        ' Criteria fields of the SQL Update query
        strQ = strQ & " WHERE "

        For intRowCpt = 0 To UBound(p_arrCriteriaFields)

            strQ = strQ & p_arrCriteriaFields(intRowCpt) & "="
            strQ = strQ & SQLVariantData(p_arrCriteriaFields(intRowCpt), p_arrCriteriaValues(intRowCpt))
            strQ = strQ & " AND "

        Next

        strQ = Left(strQ, Len(strQ) - 5)

        strQ = strQ & ";"

        GetSQLUpdateQuery = strQ

    End Function


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				DisplayErrorMessageBox
    ' Description : 		Displays an error message box
    ' Parameters :			1.	p_strErrorMessage -> Error message to display
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function DisplayErrorMessageBox(ByVal p_strErrorMessage)

        Write("<table border=0 cellspacing=0 cellpadding=2>")
        Write("<tr valign=""top"">")
        Write("<td>")
        Write("<img src=""/export/common/graphics/icons/error_icon.gif"">")
        Write("</td>")
        Write("<td id=""tdErrorMessageBox"" style=""padding-top:5px;color:#FF0000;font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 11px;"">")
        Write(p_strErrorMessage)
        Write("</td>")
        Write("</tr>")
        Write("</table>")
        DisplayErrorMessageBox = ""
    End Function


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' '' Name :				SendEmail
    ' '' Description : 		Sends an email.
    ' '' Parameters :			1.	p_strFromName 		-> String. Name for the FROM information for the email.
    ' ''						2.	p_strFromEmail 		-> String. Email for the FROM information for the email.
    ' ''						3.	p_strReplyToEmail 	-> String. REPLY TO email address for the email.
    ' ''						4.	p_strToName 		-> String. Name for the TO information for the email.
    ' ''						5.	p_strToEmail		-> String. Email for the TO information for the email.
    ' ''						6.	p_strText			-> String. Body text of the email
    ' ''						7.	p_strSubject 		-> String. Subject line for the email.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''Function SendEmail(ByVal p_strFromName, ByVal p_strFromEmail, ByVal p_strReplyToEmail, ByVal p_strToName, ByVal p_strToEmail, ByVal p_strText, ByVal p_strSubject)

    ''    Dim objMailer
    ''    Dim strError
    ''    Dim strTypeServeur

    ''    strError = ""

    ''    If Not isBlank(p_strToEmail) And Not isBlank(p_strFromEmail) And Not isBlank(p_strFromEmail) Then

    ''        objMailer = Server.CreateObject("SMTPsvg.Mailer")

    ''        objMailer.RemoteHost = STR_SMTP_MAIL_SERVER
    ''        objMailer.contenttype = "text/html"

    ''        objMailer.FromName = p_strFromName
    ''        objMailer.FromAddress = p_strFromEmail
    ''        objMailer.Replyto = p_strReplyToEmail
    ''        objMailer.AddRecipient(p_strToName, p_strToEmail)
    ''        objMailer.Subject = p_strSubject
    ''        objMailer.BodyText = p_strText

    ''        If Not objMailer.SendMail Then

    ''            If objMailer.Response <> "" Then
    ''                strError = objMailer.Response
    ''            Else
    ''                strError = "Unknown"
    ''            End If

    ''            strError = "The following error occured while sending the email: " & strError

    ''        Else
    ''            strError = "ok"
    ''        End If

    ''        objMailer = Nothing

    ''    Else

    ''        strError = "The following error occured while sending the email: please make sure that the recipient's name, adress and the sender's address are not empty."

    ''    End If

    ''    SendEmail = strError

    ''End Function


    ' '' *******************************************************************************************
    ' '' * Programme     : GetExportPathPHYSICAL                                                                                                    		
    ' '' * Version 	  : 1.4 
    ' '' * Description   : Function that returns the export folder path (PHYSICAL path and not URL)
    ' '' * Modifs        : 
    ' '' * Implant�      : non
    ' '' * Date implant� : [date]
    ' '' *******************************************************************************************
    ''Function GetExportPathPHYSICAL()

    ''    Dim strReturn
    ''    Dim strProtocol

    ''    If instr(1, lcase(Request.serverVariables("SERVER_PROTOCOL")), "https") > 0 Then
    ''        strProtocol = "https://"
    ''    Else
    ''        strProtocol = "http://"
    ''    End If

    ''    strReturn = GetExportPathURL()
    ''    strReturn = replace(strReturn, strProtocol & Request.serverVariables("SERVER_NAME"), "")
    ''    strReturn = Server.MapPath(strReturn) & "\"

    ''    GetExportPathPHYSICAL = strReturn


    ''End Function

    ' '' *******************************************************************************************
    ' '' * Programme     : GetExportPathURL                                                                                                       		
    ' '' * Version 	  : 1.4 
    ' '' * Description   : Function that returns the export folder path (URL path and not PHYSICAL)
    ' '' * Modifs        : 
    ' '' * Implant�      : non
    ' '' * Date implant� : [date]
    ' '' *******************************************************************************************
    ''Function GetExportPathURL()

    ''    Dim strReturn
    ''    Dim strProtocol

    ''    If instr(1, lcase(Request.serverVariables("SERVER_PROTOCOL")), "https") > 0 Then
    ''        strProtocol = "https://"
    ''    Else
    ''        strProtocol = "http://"
    ''    End If

    ''    strReturn = strProtocol & Request.serverVariables("SERVER_NAME") & "/export/" & FOLDER_CUSTOMEREXPORT & "/"

    ''    GetExportPathURL = strReturn


    ''End Function


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :				GenerateRandomPassword
    ' Description : 		Generate a random password
    ' Parameters :			
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function GenerateRandomPassword()

        Dim strPassword
        Dim intType
        Dim intRandomNumber
        Dim intIndex

        strPassword = ""
        Randomize()
        For intIndex = 0 To 5
            intType = Int((1 - 0 + 1) * Rnd() + 0)
            If (intType = 0) Then
                Randomize()
                intRandomNumber = Int((110 - 97 + 1) * Rnd() + 97)
                strPassword = strPassword & Chr(intRandomNumber)
            Else
                Randomize()
                intRandomNumber = Int((9 - 1 + 1) * Rnd() + 1)
                strPassword = strPassword & CStr(intRandomNumber)
            End If
        Next

        GenerateRandomPassword = strPassword

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :		ReadFromFile
    ' Description : Read the data from file and return in string
    ' Parameters :	strFileName - File to be read with complete path
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function ReadFromFile(ByVal strFileName As String)
        ReadFromFile = ""
        If strFileName <> "" Then
            If File.Exists(strFileName) Then
                ReadFromFile = File.ReadAllText(strFileName)
            Else
                'MessageBox("File not found.", MsgBoxStyle.Critical)
            End If
        Else
            'MessageBox("Please specify the file name", MsgBoxStyle.Critical)
        End If
    End Function

    Public Function WriteIntoFile(ByVal strFilePath As String, ByVal strFileName As String, ByVal strContents As String)
        Dim Folder As New DirectoryInfo(strFilePath)
        WriteIntoFile = False
        If Folder.Exists Then
            If strFileName <> String.Empty Then
                Dim FilePathSave As String = Folder.ToString() + strFileName
                File.WriteAllText(FilePathSave, strContents)
                WriteIntoFile = True
            Else
                'MessageBox("Please enter file name", MsgBoxStyle.Critical)
            End If
        Else
            'MessageBox("Folder not found", MsgBoxStyle.Critical)
        End If
    End Function

    Public Function UploadFile(ByVal fpFile As FileUpload, ByVal FilePath As String) As String
        Dim FileNo As Long
        UploadFile = ""
        If fpFile.HasFile = True Then
            FileNo = Val(ReadFromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\images\FNo.kyr")) + 1
            WriteIntoFile(System.AppDomain.CurrentDomain.BaseDirectory & "\images\", "FNo.kyr", FileNo.ToString)
            fpFile.SaveAs(FilePath & "\" & FileNo & ".jpg")
            UploadFile = FilePath & "\" & FileNo & ".jpg"
        End If
    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Name :		FillCombo
    ' Description : Fill the combo with given sql string
    ' Parameters :	strQuery - sql command to be executed
    '               ddlName  - DropDownList in which data has to be filled
    ' Returns :     On success - true
    '               On Failur  - false
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function FillCombo(ByVal strQuery As String, ByRef ddlName As DropDownList) As Boolean
        FillCombo = False
        Dim Dt As New DataTable
        'Dim Con As New clsConnection
        Try
            ddlName.ClearSelection()
            ddlName.Items.Clear()
            Dt = New DataTable
            Dt = Con.GetDataTable(strQuery)
            ddlName.DataValueField = Dt.Columns(0).ColumnName.ToString  ' id
            ddlName.DataTextField = Dt.Columns(1).ColumnName.ToString   ' strName
            ddlName.DataSource = Dt
            ddlName.DataBind()
            ddlName.Dispose()
            Dt.Dispose()
            FillCombo = True
        Catch ex As Exception

        End Try

    End Function

    Public Sub MessageBox(ByVal strMsg As String, ByRef lblMessage As Label, Optional ByVal isError As Boolean = False)
        lblMessage.Text = strMsg
        If isError = False Then
            lblMessage.ForeColor = Drawing.Color.Blue
        Else
            lblMessage.ForeColor = Drawing.Color.Red
        End If
    End Sub

    ''' return XXX XXXX XXXXXXX (Scheme,Agent,AutoNumber)
    ''' new XXXX 
    Public Function GetACNo(ByVal Scheme_Id As Long, ByVal Agent_ID As Long) As String
        Dim strScheme_ID As String
        Dim strAgent_ID As String
        Dim strAutoNum As String
        Dim Dt As New DataTable
        'Dim Con As New clsConnection
        Dim str As String
        Con = New clsConnection
        str = "Select * from tblConfiguration"
        Dt = Con.GetDataTable(str)
        strAutoNum = Dt.Rows(0).Item("lngMaxNo").ToString()
        While strAutoNum.Length < 7
            strAutoNum = "0" & strAutoNum
        End While
        strScheme_ID = Scheme_Id.ToString
        While strScheme_ID.Length < 3
            strScheme_ID = "0" & strScheme_ID
        End While
        strAgent_ID = Agent_ID
        While strAgent_ID.Length < 3
            strAgent_ID = "0" & strAgent_ID
        End While
        GetACNo = strScheme_ID & strAgent_ID & strAutoNum
    End Function

    Public Function CheckLevel(ByVal Scheme_Id As Long)
        Dim Dt As New DataTable
        'Dim Con As New clsConnection
        Dim countParty As Integer
        Dim Sql As String
        CheckLevel = 0
        Sql = "Select count(id) from tblPartyScheme where scheme_id=" & SQLNumber(Scheme_Id)
        countParty = Con.GetValue(Sql)

    End Function

    Public Function CalculateCommission(ByVal Agent_Id As Long, ByVal Scheme_Id As Long)
        Dim Dt As New DataTable
        'Dim Con As New clsConnection
        Dim countParty As Integer
        Dim countMinMember As Integer
        Dim cntGotCommission As Integer
        Dim cntPartyScheme As Integer
        Dim AgentLayer As Integer
        Dim i As Integer
        Dim j As Integer
        Dim level As Long
        Dim Sql As String
        Sql = "Select count(id) from tblParty where lngAgent_Id=" & SQLNumber(Agent_Id)
        countParty = Con.GetValue(Sql)
        Sql = "select lngMinMember from tblScheme where id=" & SQLNumber(Scheme_Id)
        countMinMember = Con.GetValue(Sql)
        If countParty >= countMinMember Then
            Sql = "Select count(Id) from tblTransaction where lngParty_Id=" & SQLNumber(Agent_Id)
            Sql = Sql & " and strType='C' and lngScheme_Id=" & SQLNumber(Scheme_Id)
            cntGotCommission = Con.GetValue(Sql)
            Sql = "Select count(id) from tblParty where id in (select lngParty_Id from tblPartyScheme "
            Sql = Sql & " where lngScheme_Id=" & Scheme_Id
            cntPartyScheme = Con.GetValue(Sql)
            j = cntPartyScheme
            i = 0
            While j >= 1
                j = j / 5
                i = i + 1
            End While
            Sql = "Selct lngLayer from tblDesignation where id= (select lngDesignation_Id from tblAgent "
            Sql = Sql & " where id=" & Agent_Id
            AgentLayer = Con.GetValue(Sql)
            If AgentLayer - i >= 1 Then

            End If
        End If
    End Function

    '' PATCH TO SET THE PARENT_ID OF ALL THE AGENT
    Public Sub setParentID()
        Dim Dt As New DataTable
        'Dim Con As New clsConnection
        Dim sql As String
        Dim count As Long
        Dim Parent_id As Long
        Try
            count = 0
            sql = "Select * from tblCompanyPool order by lngControlNo,id"
            Dt = Con.GetDataTable(sql)
            For Each dr As DataRow In Dt.Rows
                If count = 0 Then
                    sql = "update tblCompanyPool set lngParent_Id=0 where id=" & dr("id")
                Else
                    Parent_id = getParent(count)
                    sql = "update tblCompanyPool set lngParent_Id=" & Dt.Rows(Parent_id).Item("id") & " where id=" & dr("id")
                End If
                Con.ExecQuery(sql)
                count = count + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function getParent(ByVal count As Long) As Long
        If count = 0 Then
            getParent = 0
            Exit Function
        ElseIf count >= 1 And count <= 5 Then
            getParent = 0
            Exit Function
        Else
            getParent = Math.Truncate((count - 1) / 5)
        End If
    End Function


    '''''''''''''' PATCH TO SAVE THE TRANSACTION RECORD OF NEW AGENT & PARTY
    'Public Sub setTransaction()
    '    Try
    '        'Dim Con As New clsConnection
    '        Dim sql As String
    '        Dim dt As New DataTable
    '        Dim Transaction As New clsTransaction
    '        sql = "Delete from tblTransaction where strType='C'"
    '        Con.ExecQuery(sql)
    '        Transaction.Type = "C"
    '        Transaction.Code = "Test_Code"
    '        Transaction.Amount = 0
    '        Transaction.ModifiedBy = 1
    '        dt = Con.GetDataTable("Select * from tblAgent order by id")
    '        For Each dr As DataRow In dt.Rows
    '            Transaction.TransactionDate = dr("dtDateOfRegistration").ToString()
    '            Transaction.Party_Id = dr("id").ToString()
    '            Transaction.save()
    '            Transaction.Id = 0
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    ''' <summary>
    ''' Convert the given code(numeric) in to the string code
    ''' </summary>
    ''' <param name="value">Code in numeric</param>
    ''' <param name="length">Length of the code to be generated</param>
    ''' <returns>String : code with specified length</returns>
    ''' <remarks></remarks>
    Public Function ConvertCode(ByVal value As Long, ByVal length As Long) As String
        Dim code As String
        code = value.ToString
        While code.Length <= length
            code = "0" & code
        End While
        ConvertCode = code
    End Function

    ''' <summary>
    ''' Patch to set the control no.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setControlNo()
        Dim Dt As New DataTable
        'Dim Con As New clsConnection
        Dim sql As String
        Dim count As Long
        '        Dim Parent_id As Long
        Try
            count = 0
            '' KEYUR ALSO ADD 5TH MEMBER'S ID IN THE COMPANY POOL.
            sql = "Select * from tblCompanyPool order by lngLastId,dtDateOfRegistration,id"
            Dt = Con.GetDataTable(sql)
            For Each dr As DataRow In Dt.Rows
                sql = "update tblCompanyPool set lngControlNo=" & count + 1 & " where id=" & dr("id")
                Con.ExecQuery(sql)
                count = count + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    '9099343826

    ''' <summary>
    ''' UNDER CONSTRUCTION Get the control no. 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getControlNo()

    End Function

    ''' <summary>
    ''' Patch : Set the current position in the company pool
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setPosition()
        'Dim Con As New clsConnection
        Dim Dt As New DataTable
        Dim sql As String
        Dim count As Long
        Dim level(10) As Long
        'Dim level2 As Long
        'Dim level3 As Long
        'Dim level4 As Long
        'Dim level5 As Long
        'Dim level6 As Long
        'Dim level7 As Long
        'Dim level8 As Long
        'Dim level9 As Long
        Dim i As Integer
        Dim j As Long
        Dim Designation As Long
        Dim cnt As Long
        Dim MemCount As Long
        '        Dim Parent_id As Long
        Try
            count = 0
            Designation = Con.GetValue("Select id from tblDesignation where lngLayer=2")
            sql = "update tblCompanyPool set lngDesignation_ID=" & Designation
            Con.ExecQuery(sql)
            sql = "Select * from tblCompanyPool order by lngLastId,dtDateOfRegistration,id"
            Dt = Con.GetDataTable(sql)
            j = 0
            level(0) = 1
            For i = 8 To 1 Step -1
                MemCount = Con.GetValue("Select sum(lngMemCount) from tblSchemeCommission where lngDesignation_ID=any(select id from tblDesignation where lngLayer<=" & i & ")")
                level(i) = Math.Truncate((Dt.Rows.Count - MemCount) / (Math.Pow(5, i))) '- level(i + 1)

                For j = level(i + 1) To level(i) - 1
                    Designation = Con.GetValue("Select id from tblDesignation where lngLayer=" & i + 2)
                    sql = "update tblCompanyPool set lngDesignation_id=" & Designation & " where id=" & Dt.Rows(j).Item("id")
                    Con.ExecQuery(sql)
                Next
                'End While
                'MsgBox("level : " & i & " : " & level(i))
            Next
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Patch : Set the company pool data accroding to Agent Data.
    ''' </summary>
    ''' <remarks></remarks>
    'Public Sub SetCompanyPool()
    '    Dim Dt As New DataTable
    '    'Dim Con As New clsConnection
    '    Dim sql As String
    '    Dim CompanyPool As New clsCompanyPool
    '    Dim Agent As New clsAgent
    '    Dim count As Long
    '    '        Dim Parent_id As Long
    '    Try
    '        count = 0
    '        sql = "Select id from tblCompanyPool order by id"
    '        Dt = Con.GetDataTable(sql)
    '        For Each dr As DataRow In Dt.Rows
    '            CompanyPool.init()
    '            CompanyPool.Id = dr("id")
    '            CompanyPool.FindById()
    '            sql = "Select id from tblAgent where strCode=any(Select strCode from tblCompanyPool where id=" & CompanyPool.Id & ") order by id"
    '            Agent.Id = Con.GetValue(sql)
    '            Agent.FindById()
    '            CompanyPool.Code = Agent.Code
    '            CompanyPool.Address = Agent.Address
    '            CompanyPool.Age = Agent.Age
    '            CompanyPool.Agent_Id = Agent.Agent_Id
    '            CompanyPool.BankACNo = Agent.BankACNo
    '            CompanyPool.BranchName = Agent.BranchName
    '            CompanyPool.Business = Agent.Business
    '            CompanyPool.ChequeDate = Agent.ChequeDate
    '            CompanyPool.ChequeNo = Agent.ChequeNo
    '            CompanyPool.Code = Agent.Code
    '            CompanyPool.Created = Agent.Created
    '            CompanyPool.DateOfBirth = Agent.DateOfBirth
    '            CompanyPool.DateOfCommission = Agent.DateOfCommission
    '            'CompanyPool.DateOfRegistration = Agent.DateOfRegistration
    '            'CompanyPool.Deleted=False
    '            'CompanyPool.Designation_Id = Agent.Designation_Id
    '            CompanyPool.DraweeBank = Agent.DraweeBank
    '            CompanyPool.DraweeBranch = Agent.DraweeBranch
    '            CompanyPool.Education = Agent.Education
    '            CompanyPool.FormNo = Agent.FormNo
    '            CompanyPool.Gender = Agent.Gender
    '            CompanyPool.GuardianName = Agent.GuardianName
    '            CompanyPool.IDProof = Agent.IDProof
    '            CompanyPool.MaritalStatus = Agent.MaritalStatus
    '            CompanyPool.Mobile = Agent.Mobile
    '            CompanyPool.Modified = Agent.Modified
    '            CompanyPool.ModifiedBy = Agent.ModifiedBy
    '            CompanyPool.Name = Agent.Name
    '            CompanyPool.NomineeName1 = Agent.NomineeName1
    '            CompanyPool.NomineeName2 = Agent.NomineeName2
    '            CompanyPool.NomineeRelation1 = Agent.NomineeRelation1
    '            CompanyPool.NomineeRelation2 = Agent.NomineeRelation2
    '            CompanyPool.NomineeSign1 = Agent.NomineeSign1
    '            CompanyPool.NomineeSign2 = Agent.NomineeSign2
    '            CompanyPool.OfficeAddress = Agent.OfficeAddress
    '            CompanyPool.OfficeMobile = Agent.OfficeMobile
    '            CompanyPool.OfficePhone = Agent.OfficePhone
    '            CompanyPool.PANNo = Agent.PANNo
    '            CompanyPool.Phone = Agent.Phone
    '            CompanyPool.Photo = Agent.Photo
    '            CompanyPool.Scheme_Id = Agent.Scheme_Id
    '            CompanyPool.Sign = Agent.Sign
    '            CompanyPool.TmpCode = Agent.TmpCode
    '            CompanyPool.VoterId = Agent.VoterId

    '            'sql = "update tblCompanyPool set lngControlNo=" & count + 1 & " where id=" & dr("id")
    '            'Con.ExecQuery(sql)
    '            count = count + 1
    '            CompanyPool.save()
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    ''' <summary>
    ''' Under Construction : Patch : Regenerate the company pool
    ''' </summary>
    ''' <remarks></remarks>
    'Public Sub ReGenerateCompanyPool()
    '    Dim Dt As New DataTable
    '    'Dim Con As New clsConnection
    '    Dim sql As String
    '    Dim CompanyPool As New clsCompanyPool
    '    Dim Agent As New clsAgent
    '    Dim count As Long
    '    '        Dim Parent_id As Long
    '    Try
    '        count = 0
    '        sql = "delete from tblCompanyPool"
    '        Con.ExecQuery(sql)
    '        sql = "Select a.*,(Select count(id) from tblAgent where lngAgent_Id=a.id) as cnt from tblAgent a order by id"
    '        'sql = "Select id from tblCompanyPool order by id"
    '        Dt = Con.GetDataTable(sql)
    '        For Each dr As DataRow In Dt.Rows
    '            If dr("cnt") > 5 Then
    '                MsgBox("Error : " & dr("strCode") & " have more then 5 sub members")
    '                Exit Sub
    '            ElseIf dr("cnt") = 5 Then
    '                Dim DtTmp As DataTable

    '                CompanyPool.init()
    '                CompanyPool.Id = 0
    '                CompanyPool.FindById()
    '                sql = "Select id from tblAgent where strCode=any(Select strCode from tblCompanyPool where id=" & CompanyPool.Id & ") order by id"
    '                Agent.Id = dr("id")
    '                Agent.FindById()
    '                CompanyPool.Code = Agent.Code
    '                CompanyPool.Address = Agent.Address
    '                CompanyPool.Age = Agent.Age
    '                CompanyPool.Agent_Id = Agent.Agent_Id
    '                CompanyPool.BankACNo = Agent.BankACNo
    '                CompanyPool.BranchName = Agent.BranchName
    '                CompanyPool.Business = Agent.Business
    '                CompanyPool.ChequeDate = Agent.ChequeDate
    '                CompanyPool.ChequeNo = Agent.ChequeNo
    '                CompanyPool.Code = Agent.Code
    '                CompanyPool.Created = Agent.Created
    '                CompanyPool.DateOfBirth = Agent.DateOfBirth
    '                CompanyPool.DateOfCommission = Agent.DateOfCommission
    '                sql = "Select id,strCode,dtDateOfRegistration from tblAgent where id= (Select max(id) from tblAgent where lngAgent_Id=" & Agent.Id & ")"
    '                DtTmp = Con.GetDataTable(sql)
    '                CompanyPool.DateOfRegistration = DtTmp.Rows(0).Item("dtDateOfRegistration")
    '                CompanyPool.LastId = DtTmp.Rows(0).Item("id")
    '                CompanyPool.LastCode = DtTmp.Rows(0).Item("strCode")
    '                'CompanyPool.Deleted=False
    '                'CompanyPool.Designation_Id = Agent.Designation_Id
    '                CompanyPool.DraweeBank = Agent.DraweeBank
    '                CompanyPool.DraweeBranch = Agent.DraweeBranch
    '                CompanyPool.Education = Agent.Education
    '                CompanyPool.FormNo = Agent.FormNo
    '                CompanyPool.Gender = Agent.Gender
    '                CompanyPool.GuardianName = Agent.GuardianName
    '                CompanyPool.IDProof = Agent.IDProof
    '                CompanyPool.MaritalStatus = Agent.MaritalStatus
    '                CompanyPool.Mobile = Agent.Mobile
    '                CompanyPool.Modified = Agent.Modified
    '                CompanyPool.ModifiedBy = Agent.ModifiedBy
    '                CompanyPool.Name = Agent.Name
    '                CompanyPool.NomineeName1 = Agent.NomineeName1
    '                CompanyPool.NomineeName2 = Agent.NomineeName2
    '                CompanyPool.NomineeRelation1 = Agent.NomineeRelation1
    '                CompanyPool.NomineeRelation2 = Agent.NomineeRelation2
    '                CompanyPool.NomineeSign1 = Agent.NomineeSign1
    '                CompanyPool.NomineeSign2 = Agent.NomineeSign2
    '                CompanyPool.OfficeAddress = Agent.OfficeAddress
    '                CompanyPool.OfficeMobile = Agent.OfficeMobile
    '                CompanyPool.OfficePhone = Agent.OfficePhone
    '                CompanyPool.PANNo = Agent.PANNo
    '                CompanyPool.Phone = Agent.Phone
    '                CompanyPool.Photo = Agent.Photo
    '                CompanyPool.Scheme_Id = Agent.Scheme_Id
    '                CompanyPool.Sign = Agent.Sign
    '                CompanyPool.TmpCode = Agent.TmpCode
    '                CompanyPool.VoterId = Agent.VoterId
    '                CompanyPool.ControlNo = count + 1
    '                'sql = "update tblCompanyPool set lngControlNo=" & count + 1 & " where id=" & dr("id")
    '                'Con.ExecQuery(sql)
    '                If CompanyPool.save = False Then
    '                    MsgBox("Erro : " & CompanyPool.Code)
    '                Else
    '                    count = count + 1
    '                End If

    '                'MsgBox(CompanyPool.Code & " : " & count)
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MsgBox("Error : " & Agent.Code & " : " & ex.Message)
    '    Finally
    '        MsgBox("Memcount : " & count)
    '    End Try
    'End Sub

    ''' <summary>
    ''' Return the number in words
    ''' </summary>
    ''' <param name="Amount"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AmountInWord(ByVal Amount As Double) As String
        'MsgBox(ConvertCode(Amount, Amount.ToString.Length))
        Dim str As String
        Dim dec As Integer
        Dim intAmt As Long
        Dim decAmt As Integer
        Dim tmp As Long
        Dim x As Long
        str = Amount.ToString
        dec = InStr(str, ".")
        'MsgBox(test(Amount))
        If dec <> 0 Then
            intAmt = Math.Floor(Amount)

            decAmt = Right(str, str.Length - 1 - intAmt.ToString.Length)
            AmountInWord = test(intAmt) & "RUPEES AND " & test(decAmt) & " PAISA ONLY"
            'MsgBox(AmountInWord)
        Else
            AmountInWord = test(Amount) & " ONLY"
        End If
        'amount.
    End Function

    Dim mOnesArray(8) As String
    Dim mOneTensArray(9) As String
    Dim mTensArray(7) As String
    Dim mPlaceValues(4) As String

    Public Function test(ByVal Amount As Double) As String

        mOnesArray(0) = "ONE"
        mOnesArray(1) = "TWO"
        mOnesArray(2) = "THREE"
        mOnesArray(3) = "FOUR"
        mOnesArray(4) = "FIVE"
        mOnesArray(5) = "SIX"
        mOnesArray(6) = "SEVEN"
        mOnesArray(7) = "EIGHT"
        mOnesArray(8) = "NINE"

        mOneTensArray(0) = "TEN"
        mOneTensArray(1) = "ELEVEN"
        mOneTensArray(2) = "TWELVE"
        mOneTensArray(3) = "THIRTEEN"
        mOneTensArray(4) = "FOURTEEN"
        mOneTensArray(5) = "FIFTEEN"
        mOneTensArray(6) = "SIXTEEN"
        mOneTensArray(7) = "SEVENTEEN"
        mOneTensArray(8) = "EIGHTEEN"
        mOneTensArray(9) = "NINETEEN"

        mTensArray(0) = "TWENTY"
        mTensArray(1) = "THIRTY"
        mTensArray(2) = "FORTY"
        mTensArray(3) = "FIFTY"
        mTensArray(4) = "SIXTY"
        mTensArray(5) = "SEVENTY"
        mTensArray(6) = "EIGHTY"
        mTensArray(7) = "NINETY"

        mPlaceValues(0) = "HUNDRED"
        mPlaceValues(1) = "THOUSAND"
        mPlaceValues(2) = "MILLION"
        mPlaceValues(3) = "BILLION"
        mPlaceValues(4) = "TRILLION"

        test = ConvertNumberToWords(Amount)
    End Function

    Protected Function GetOnes(ByVal OneDigit As Integer) As String

        GetOnes = ""

        If OneDigit = 0 Then
            Exit Function
        End If

        GetOnes = mOnesArray(OneDigit - 1)

    End Function


    Protected Function GetTens(ByVal TensDigit As Integer) As String

        GetTens = ""

        If TensDigit = 0 Or TensDigit = 1 Then
            Exit Function
        End If

        GetTens = mTensArray(TensDigit - 2)

    End Function


    Public Function ConvertNumberToWords(ByVal NumberValue As String) As String

        Dim Delimiter As String = " "
        Dim TensDelimiter As String = "-"
        Dim mNumberValue As String = ""
        Dim mNumbers As String = ""
        Dim mNumWord As String = ""
        Dim mFraction As String = ""
        Dim mNumberStack() As String
        Dim j As Integer = 0
        Dim i As Integer = 0
        Dim mOneTens As Boolean = False

        ConvertNumberToWords = ""

        ' validate input
        Try
            j = CDbl(NumberValue)
        Catch ex As Exception
            ConvertNumberToWords = "Invalid input."
            Exit Function
        End Try

        ' get fractional part {if any}
        If InStr(NumberValue, ".") = 0 Then
            ' no fraction
            mNumberValue = NumberValue
        Else
            mNumberValue = Microsoft.VisualBasic.Left(NumberValue, InStr(NumberValue, ".") - 1)
            mFraction = Mid(NumberValue, InStr(NumberValue, ".")) ' + 1)
            mFraction = Math.Round(CSng(mFraction), 2) * 100

            If CInt(mFraction) = 0 Then
                mFraction = ""
            Else
                mFraction = "&& " & mFraction & "/100"
            End If
        End If
        mNumbers = mNumberValue.ToCharArray

        ' move numbers to stack/array backwards
        For j = mNumbers.Length - 1 To 0 Step -1
            ReDim Preserve mNumberStack(i)

            mNumberStack(i) = mNumbers(j)
            i += 1
        Next

        For j = mNumbers.Length - 1 To 0 Step -1
            Select Case j
                Case 0, 3, 6, 9, 12
                    ' ones  value
                    If Not mOneTens Then
                        mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter
                    End If

                    Select Case j
                        Case 3
                            ' thousands
                            mNumWord &= mPlaceValues(1) & Delimiter

                        Case 6
                            ' millions
                            mNumWord &= mPlaceValues(2) & Delimiter

                        Case 9
                            ' billions
                            mNumWord &= mPlaceValues(3) & Delimiter

                        Case 12
                            ' trillions
                            mNumWord &= mPlaceValues(4) & Delimiter
                    End Select


                Case Is = 1, 4, 7, 10, 13
                    ' tens value
                    If Val(mNumberStack(j)) = 0 Then
                        mNumWord &= GetOnes(Val(mNumberStack(j - 1))) & Delimiter
                        mOneTens = True
                        Exit Select
                    End If

                    If Val(mNumberStack(j)) = 1 Then
                        mNumWord &= mOneTensArray(Val(mNumberStack(j - 1))) & Delimiter
                        mOneTens = True
                        Exit Select
                    End If

                    mNumWord &= GetTens(Val(mNumberStack(j)))

                    ' this places the tensdelimiter; check for succeeding 0
                    If Val(mNumberStack(j - 1)) <> 0 Then
                        mNumWord &= TensDelimiter
                    End If
                    mOneTens = False

                Case Else
                    ' hundreds value 
                    mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter

                    If Val(mNumberStack(j)) <> 0 Then
                        mNumWord &= mPlaceValues(0) & Delimiter
                    End If
            End Select
        Next
        Return mNumWord & mFraction
    End Function

    ''' <summary>
    ''' ReGenerate all the user id 
    ''' </summary>
    ''' <remarks>Default password is Mobile no. if not exists then Code</remarks>
    'Public Sub ReGenerateUserID()
    '    Dim Dt As New DataTable
    '    'Dim Con As New clsConnection
    '    Dim User As New clsUser
    '    Dim sql As String
    '    Dim i As Integer
    '    Try
    '        sql = "Delete from tblUser where strRole<>'admin'"
    '        Con.ExecQuery(sql)
    '        sql = "select id,strCode,strName,strMobile from tblAgent order by strCode"
    '        Dt = Con.GetDataTable(sql)
    '        For i = 0 To Dt.Rows.Count - 1
    '            User.Id = 0
    '            User.Name = Dt.Rows(i).Item("strCode")
    '            If Dt.Rows(i).Item("strMobile").ToString <> "" Then
    '                User.Password = Dt.Rows(i).Item("strMobile")
    '            Else
    '                User.Password = Dt.Rows(i).Item("strCode")
    '            End If
    '            User.Role = "USER"
    '            If Not User.save() Then
    '                MsgBox("Error : " & Dt.Rows(i).Item("strCode"), MsgBoxStyle.Critical, "User Creation")
    '            End If

    '        Next
    '        'MsgBox("User generated successfully.", MsgBoxStyle.Information, "Sankalp")
    '        'Response.Redirect("patch.aspx?msg=UserGeneratedSuccessfully")
    '    Catch ex As Exception
    '        'MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "Sankalp Pariwar")
    '        'Response.Redirect("patch.aspx?error:" & ex.Message)
    '    End Try

    'End Sub

    Public Function GetCommissionChart(ByVal strCode As String, ByRef lblMessage As Label) As DataTable
        Dim Dt As New DataTable
        'Dim Con As New clsConnection
        Dim count As Long
        Dim i As Integer
        'Dim dbRow1 As New DataRow
        Try
            Dt.Columns.Add("Cader")
            Dt.Columns.Add("TargetMember")
            Dt.Columns.Add("Member")
            Dt.Columns.Add("Amount")
            Dt.Columns.Add("SFM")
            Dt.Columns.Add("AFM")
            Dt.Columns.Add("RFM")
            Dt.Columns.Add("FieldExecutive")
            Dt.Columns.Add("SrCoordinator")
            Dt.Columns.Add("Coordinator")
            Dt.Columns.Add("SrMotivator")
            Dt.Columns.Add("Motivator")
            Dt.Columns.Add("Promoter")
            Dt.Rows.Add()
            Dt.Rows.Add()
            Dt.Rows.Add()
            Dt.Rows.Add()
            Dt.Rows.Add()
            Dt.Rows.Add()
            Dt.Rows.Add()
            Dt.Rows.Add()
            Dt.Rows.Add()
            Dt.Rows.Add()
            Dt.Rows(0).Item("Cader") = "SFM"
            Dt.Rows(0).Item("TargetMember") = 1
            Dt.Rows(0).Item("Amount") = 0
            Dt.Rows(1).Item("Cader") = "AFM"
            Dt.Rows(1).Item("TargetMember") = 5
            Dt.Rows(1).Item("Amount") = 750
            Dt.Rows(2).Item("Cader") = "RFM"
            Dt.Rows(2).Item("TargetMember") = 25
            Dt.Rows(2).Item("Amount") = 1500
            Dt.Rows(3).Item("Cader") = "FieldExecutive"
            Dt.Rows(3).Item("TargetMember") = 125
            Dt.Rows(3).Item("Amount") = 7500
            Dt.Rows(4).Item("Cader") = "SrCoordinator"
            Dt.Rows(4).Item("TargetMember") = 625
            Dt.Rows(4).Item("Amount") = 37500
            Dt.Rows(5).Item("Cader") = "Coordinator"
            Dt.Rows(5).Item("TargetMember") = 3125
            Dt.Rows(5).Item("Amount") = 93750
            Dt.Rows(6).Item("Cader") = "SrMotivator"
            Dt.Rows(6).Item("TargetMember") = 15625
            Dt.Rows(6).Item("Amount") = 468750
            Dt.Rows(7).Item("Cader") = "Motivator"
            Dt.Rows(7).Item("TargetMember") = 78125
            Dt.Rows(7).Item("Amount") = 2343750
            Dt.Rows(8).Item("Cader") = "Promoter"
            Dt.Rows(8).Item("TargetMember") = 390625
            Dt.Rows(8).Item("Amount") = 11718750
            For i = 0 To 8
                Dt.Rows(i).Item(i + 4) = 0
                Dt.Rows(i).Item(2) = 0
            Next
            count = GetCommissionMemberCount(strCode, 0, Dt)
            lblMessage.Text = count
            For i = 0 To Dt.Rows.Count - 2
                If i < 8 Then
                    If Not (IsDBNull(Dt.Rows(i).Item(i + 4))) And Not (IsDBNull(Dt.Rows(i + 1).Item(i + 5))) Then
                        Dt.Rows(i).Item(i + 4) = Dt.Rows(i).Item(i + 4) - Dt.Rows(i + 1).Item(i + 5)
                        Dt.Rows(i).Item("Member") = Dt.Rows(i).Item(i + 4)
                    End If
                Else
                    Dt.Rows(i).Item("Member") = Dt.Rows(i).Item(i + 4)
                End If
            Next
            GetCommissionChart = Dt
            'Row1.Item("Cader") = "Promoter"
            'Row1.Item("TargetMember") = 1
            'Row1.Item("Member") = 1
            'Row1.Item("Amount") = 0
            'Row1.Item("Promoter") = 0
            'Row1.Item("Motivator") = 0
            'Row1.Item("SrMotivator") = 0
            'Row1.Item("Coordinator") = 0
            'Row1.Item("SrCoordinator") = 0
            'Row1.Item("FieldExecutive") = 0
            'Row1.Item("RFM") = 0
            'Row1.Item("AFM") = 0
            'Row1.Item("SFM") = 0
            'Dt.Rows.Add(Row1)
            'Row1.Item("Cader") = "Motivator"
            'Row1.Item("TargetMember") = 5
            'Dt.Rows.Add(Row1)
            'Row1.Item("Cader") = "SrMotivator"
            'Row1.Item("TargetMember") = 25
            'Dt.Rows.Add(Row1)
            'Row1.Item("Cader") = "Coordinator"
            'Row1.Item("TargetMember") = 125
            'Dt.Rows.Add(Row1)
            'Row1.Item("Cader") = "SrCoordinator"
            'Row1.Item("TargetMember") = 625
            'Dt.Rows.Add(Row1)
            'Row1.Item("Cader") = "FieldExecutive"
            'Row1.Item("TargetMember") = 3125
            'Dt.Rows.Add(Row1)
            'Row1.Item("Cader") = "RFM"
            'Row1.Item("TargetMember") = 15625
            'Dt.Rows.Add(Row1)
            'Row1.Item("Cader") = "AFM"
            'Row1.Item("TargetMember") = 78125
            'Dt.Rows.Add(Row1)
            'Row1.Item("Cader") = "SFM"
            'Row1.Item("TargetMember") = 390625
            'Dt.Rows.Add(Row1)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetCommissionMemberCount(ByVal strCode As String, ByVal lngLevel As Integer, ByRef DtCommChrt As DataTable) As Long
        Dim sql As String
        Dim Dt As New DataTable
        Dim Count As Long
        'Dim Con As New clsConnection
        Dim i As Integer
        Dim Tmp As Integer
        'sql = "Select a.*,(select count(id) from tblAgent where lngAgent_Id=a.id) as cnt from tblAgent where strCode=" & SQLString(strCode)
        'dt = Con.GetDataTable(sql)
        Try
            sql = "Select * from tblAgent where lngAgent_Id=(select id from tblAgent where strCode=" & SQLString(strCode) & ")"
            Dt = Con.GetDataTable(sql)
            Count = 1
            For i = 0 To Dt.Rows.Count - 1
                If (lngLevel <= 8) Then
                    Count = Count + GetCommissionMemberCount(Dt.Rows(i).Item("strCode"), lngLevel + 1, DtCommChrt)
                End If
            Next
            Tmp = lngLevel + 4
            If IsDBNull(DtCommChrt.Rows(lngLevel).Item(Tmp)) Then
                DtCommChrt.Rows(lngLevel).Item(Tmp) = 0 + Count
            Else
                DtCommChrt.Rows(lngLevel).Item(Tmp) = Val(DtCommChrt.Rows(lngLevel).Item(Tmp)) + Count
            End If
            GetCommissionMemberCount = Count
        Catch ex As Exception
            'Fun.MessageBox("Error : " & ex.Message, lblMessage, True)
        End Try

    End Function

    Public Sub ReGenerateLavelStatus()
        Dim Dt As New DataTable
        Dim sql As String
        Dim i As Integer
        Dim DtChart As New DataTable
        Dim lblTmp As New System.Web.UI.WebControls.Label
        Try
            Con.ExecQuery("Delete from tblLvlStatus")
            sql = "Select * from tblAgent order by strCode"
            Dt = Con.GetDataTable(sql)
            For i = 0 To Dt.Rows.Count - 1
                DtChart = GetCommissionChart(Dt.Rows(i).Item("strCode"), lblTmp)
                sql = "Insert into tblLvlStatus (strCode,strName,lngLvl1,lngLvl2,lngLvl3,lngLvl4,lngLvl5,lngLvl6,lngLvl7,lngLvl8,lngLvl9)"
                sql = sql & " values(" & SQLString(Dt.Rows(i).Item("strCode")) & "," & SQLString(Dt.Rows(i).Item("strName")) & ",1,"
                sql = sql & SQLNumber(DtChart.Rows(1).Item("Member")) & "," & SQLNumber(DtChart.Rows(2).Item("Member")) & "," & SQLNumber(DtChart.Rows(3).Item("Member")) & ","
                sql = sql & SQLNumber(DtChart.Rows(4).Item("Member")) & "," & SQLNumber(DtChart.Rows(5).Item("Member")) & "," & SQLNumber(DtChart.Rows(6).Item("Member")) & ","
                sql = sql & SQLNumber(DtChart.Rows(7).Item("Member")) & "," & SQLNumber(DtChart.Rows(8).Item("Member")) & ")"
                'sql = sql & SQLNumber(DtChart.Rows(0).Item("AFM")) & "," & SQLNumber(DtChart.Rows(0).Item("RFM")) & "," & SQLNumber(DtChart.Rows(0).Item("FieldExecutive")) & ","
                'sql = sql & SQLNumber(DtChart.Rows(0).Item("SrCoordinator")) & "," & SQLNumber(DtChart.Rows(0).Item("Coordinator")) & "," & SQLNumber(DtChart.Rows(0).Item("SrMotivator")) & ","
                'sql = sql & SQLNumber(DtChart.Rows(0).Item("Motivator")) & "," & SQLNumber(DtChart.Rows(0).Item("Promoter")) & ")"
                Con.ExecQuery(sql)
            Next
            MsgBox("Levels are set successfully", MsgBoxStyle.Information, "Sankalp - Patch")
        Catch ex As System.Exception
            MsgBox("Error : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Uploads a file to the database server.
    ''' </summary>
    ''' <param name="fileName">The filename of the picture to be uploaded</param>
    ''' <returns>The id of the file on the server.</returns>
    Private Function UploadFile(ByVal FileName As String) As Long
        If (Not File.Exists(FileName)) Then
            Return -1
        End If
        Dim fs As FileStream = Nothing
        Try
            '#Region "Reading file"
            fs = New FileStream(FileName, FileMode.Open)
            '
            ' Finding out the size of the file to be uploaded
            '
            Dim fi As FileInfo = New FileInfo(FileName)
            Dim temp As Long = fi.Length
            Dim lung As Integer = Convert.ToInt32(temp)
            ' ------------------------------------------
            '
            ' Reading the content of the file into an array of bytes.
            '
            Dim picture As Byte() = New Byte(lung - 1) {}
            fs.Read(picture, 0, lung)
            fs.Close()
            ' ------------------------------------------
            '#End Region
            Dim result As Long ' = uploadFileToDatabase(picture, fi.Name)
            Return result
        Catch e As Exception
            Console.WriteLine(e.Message & " - " & e.StackTrace)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Wrapper for downloading a file from a database.
    ''' </summary>
    ''' <param name="kFileName">The Unique ID of the file in database</param>
    ''' <param name="fileName">The file name as it was stored in the database.</param>
    ''' <returns>The byte array required OR null if the ID is not found</returns>
    Private Function DownloadFile(ByVal kFileName As Long, ByRef fileName As String) As Byte()
        Dim result As Byte() '= downloadFileFromDatabase(kFileName, fileName)
        Return result
    End Function

End Class
