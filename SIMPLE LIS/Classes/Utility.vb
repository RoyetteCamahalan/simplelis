
#Region " Code History "
'Author:    SSTS Co
'Created:   13 April 2010
'About:
'General utility module for handling general tasks such as determining if a string
'contains only alphabetic characters.
'******************************************************************************
'Modified By:   x
'Modified On:   dd/mm/yyyy
'Changes:
'* Change 1
'* Change 2
'******************************************************************************
'Modified By:   x
'Modified On:   dd/mm/yyyy
'Changes:
'* Change 1
'* Change 2
'******************************************************************************
#End Region

Imports System
Imports System.Management
Imports System.Net.NetworkInformation
Imports System.Security.Cryptography
Imports System.Text
'------------------------------------

'------------------------------------
Imports System.Text.RegularExpressions
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
'---------------------------------------
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.OleDb
Imports System.Windows.Forms

Imports PdfSharp.Pdf

Public Class Utility
    Shared p As SqlParameter
    Public Shared anyRight As ContentAlignment = (ContentAlignment.BottomRight _
                   Or (ContentAlignment.MiddleRight Or ContentAlignment.TopRight))
    Public Shared anyTop As ContentAlignment = (ContentAlignment.TopRight _
                Or (ContentAlignment.TopCenter Or ContentAlignment.TopLeft))
    Public Shared anyBottom As ContentAlignment = (ContentAlignment.BottomRight _
                Or (ContentAlignment.BottomCenter Or ContentAlignment.BottomLeft))
    Public Shared anyCenter As ContentAlignment = (ContentAlignment.BottomCenter _
                Or (ContentAlignment.MiddleCenter Or ContentAlignment.TopCenter))
    Public Shared anyMiddle As ContentAlignment = (ContentAlignment.MiddleRight _
                Or (ContentAlignment.MiddleCenter Or ContentAlignment.MiddleLeft))

    Public Shared Function IsAlpha(ByVal strInput As String) As Boolean
        'Does string contain only alphabetic characters and/or a space?
        'Use for validating a persons name
        Dim bln As Boolean

        bln = Regex.IsMatch(strInput, "^[a-zA-Z ]+$")
        Return bln
    End Function

    Public Shared Function IsAlphaNumeric(ByVal strInput As String) As Boolean
        'Does string contain only alphabetic and number characters and/or a space?
        'Potentially use for validating an address, but be careful if address field
        'might contain a hyphen (-) or double quotes ("  ") or any other punctuation
        Dim bln As Boolean

        bln = Regex.IsMatch(strInput, "^[a-zA-Z0-9 ]+$")
        Return bln
    End Function

    Public Shared Function readSetting(ByVal setting As Integer) As String
        Try
            Dim appSettings = ConfigurationManager.AppSettings
            Dim key As modGlobal.appSettings = setting
            Dim result As String = appSettings(key.ToString)
            If IsNothing(result) Then
                result = "Not found"
            End If
            Return result
        Catch e As ConfigurationErrorsException
            Return ""
        End Try
    End Function
    'Public Shared Function IsNumeric(ByVal strInput As String) As String
    '    Dim word As Char() = strInput.ToCharArray()
    '    Dim pointctr As Integer = 0
    '    Dim newWord1 As String = Nothing
    '    Dim newWord2 As String = Nothing
    '    If word.Length > 0 Then
    '        For i = 0 To word.Length - 1
    '            If word(i).ToString() = "." Then
    '                pointctr = pointctr + 1
    '            End If
    '        Next
    '        For i = 0 To word.Length - 1
    '            If pointctr <= 1 And word(i).ToString() <> "," And word(i).ToString() <> "/" And word(i).ToString() <> ";" And word(i).ToString() <> "'" And word(i).ToString() <> "-" And word(i).ToString() <> "=" Then
    '                If IsAlpha(word(i).ToString()) = False Then
    '                    newWord1 = newWord1 + word(i).ToString()
    '                    newWord2 = newWord1
    '                End If
    '            Else
    '                pointctr -= 1
    '            End If
    '        Next

    '    Else
    '        newWord2 = 0
    '    End If
    '    Return newWord2
    'End Function
    'Public Shared Function IsSpecialCharacter(ByVal str As String) 'by IDRIZ
    '    Dim illegalChars As Char() = "!@#$%^&*(){}[]""_-+<>?|/".ToCharArray()
    '    Dim word As Char() = str.ToCharArray()
    '    Dim ok As Boolean = False
    '    Dim str1 As String = ""
    '    Dim str2 As String = ""
    '    Dim str3 As String = ""
    '    For i = 0 To word.Length - 1
    '        For ctr = 0 To illegalChars.Length - 1
    '            If word(i).ToString() = illegalChars(ctr).ToString() Then
    '                ok = True
    '            End If
    '        Next
    '        If ok Then
    '            str1 = word(i).ToString()
    '            str2 = str2 & str1
    '            str3 = str2.Replace(word(i).ToString(), "")
    '            str2 = str3
    '        Else
    '            str1 = word(i).ToString()
    '            str2 = str2 & str1

    '        End If
    '        ok = False
    '    Next
    '    Return str2
    'End Function

    Public Shared Function NullToEmptyString(ByVal myInput As Object) As String
        'If the input value is NULL then return an empty string
        'Otherwise return the original value as a string
        If IsDBNull(myInput) Then
            Return ""
        ElseIf IsNothing(myInput) Then
            Return ""
        Else
            Return myInput
        End If
    End Function
    Public Shared Function NullToCurrentDate(ByVal myInput As Object) As Date
        'If the input value is NULL then return an empty string
        'Otherwise return the original value as a string
        If IsDBNull(myInput) Then
            Return GetServerDate()
        Else
            Try
                Return myInput
            Catch ex As Exception
                Return GetServerDate()
            End Try
        End If
    End Function
    Public Shared Function NullToBoolean(ByVal myInput As Object) As Boolean
        'If the input value is NULL then return false
        'Otherwise return the original value as a string
        If IsDBNull(myInput) Then
            Return False
        Else
            Return myInput
        End If
    End Function
    Public Shared Function NullToZero(ByVal myInput As Object) As Decimal
        'If the input value is NULL then return an empty string
        'Otherwise return the original value as a string
        If IsDBNull(myInput) Then
            Return 0

        Else
            Return myInput
        End If
    End Function
    Public Shared Function EmptyToZero(ByVal myInput As Object) As Double
        'If the input value is NULL then return an empty string
        'Otherwise return the original value as a string
        Try
            Dim retVal As Double
            If IsDBNull(myInput) Then
                retVal = 0
            ElseIf CStr(myInput) = "" Then
                retVal = 0
            Else
                retVal = myInput
            End If
            Return retVal
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function ZeroToEmpty(ByVal myInput As Object) As String
        'If the input value is NULL then return an empty string
        'Otherwise return the original value as a string
        If (myInput) = 0 Then
            Return ""

        Else
            Return myInput
        End If
    End Function

    'Public Shared Function GetServerDate() As Date 
    '    Dim strPar() As String = {"Operation"}
    '    Dim strVal() As String = {0}
    '    Dim dt As DataTable = GenericDA.ManageQuery(strPar, strVal, "spGetSystemDate", 0)
    '    Dim vServerDate As Date = CDate(dt.Rows(0).Item("serverdatetime").ToString)
    '    dt = Nothing
    '    Return vServerDate
    'End Function

    'Public Shared Sub EnableFields(ByVal FieldStatus As Boolean, ByVal frm As Collection)

    '    Dim obj As Control

    '    For Each obj In frm

    '    Next


    '    frmfield.Enabled = FieldStatus
    'End Sub

    Public Shared Function ConcatFailToEmptyString(ByVal myInput As Object) As String
        If myInput = ", " Then
            Return ""
        ElseIf IsNothing(myInput) Then
            Return ""
        Else
            Return myInput
        End If
    End Function

    Public Shared Function ConcatFailToCustomString(ByVal myInput As Object) As String
        If myInput = ", " Then
            Return "None"
        ElseIf IsNothing(myInput) Then
            Return "" 'returns empty string
        Else
            Return myInput
        End If
    End Function
    Public Shared Function getSPR(ByVal strdesc As String, ByVal strspec As String)
        Dim word As Char() = strdesc.ToCharArray()
        Dim str2 As String = word
        Dim str3 As String = ""
        For i = 0 To word.Length - 1

            If str2 <> strspec Then
                str3 = word(str2.Length - 1).ToString() & str3

                str2 = str2.Remove(str2.Length - 1, 1)
            Else

                Exit For
            End If


        Next


        Return str3.Remove(0, 1).Trim()
    End Function
    Public Shared Function NullToDefaultDateFormat(ByVal myInput As Object) As Date
        'If the input value is NULL then return the default date format 1/1/1900
        'Otherwise return the original value as a string
        If IsDBNull(myInput) Then
            Return FormatDateTime("1/1/1900", DateFormat.ShortDate)
        Else
            Return myInput
        End If
    End Function
    ' Selects all the text in a textbox
    Public Sub SelectAllText(ByRef tb As TextBox)
        Dim s As String

        With tb
            s = .Text
            .SelectionStart = 0
            .SelectionLength = Len(s)
        End With
    End Sub
    Public Shared Sub AutoComplete(ByVal cbo As ComboBox, _
    ByVal e As System.Windows.Forms.KeyEventArgs, ByVal IsInputRestricted As Boolean)
        ' Call this from your form passing in the name 
        ' of your combobox and the event arg:
        ' AutoComplete(cboState, e)

        Dim iIndex As Integer
        Dim sActual As String
        Dim sFound As String
        Dim bMatchFound As Boolean

        'check if the text is blank or not, if not then only proceed
        If Not cbo.Text = "" Then 'if the text is not blank then only proceed

            ' If backspace then remove the last character 
            ' that was typed in and try to find 
            ' a match. note that the selected text from the 
            ' last character typed in to the 
            ' end of the combo text field will also be deleted.

            If e.KeyCode = Keys.Back Then
                cbo.Text = Mid(cbo.Text, 1, Len(cbo.Text) - 1)
            End If

            ' Do nothing for some keys such as navigation keys...

            If ((e.KeyCode = Keys.Left) Or _
             (e.KeyCode = Keys.Right) Or _
             (e.KeyCode = Keys.Up) Or _
             (e.KeyCode = Keys.Down) Or _
             (e.KeyCode = Keys.PageUp) Or _
             (e.KeyCode = Keys.PageDown) Or _
             (e.KeyCode = Keys.Home) Or _
             (e.KeyCode = Keys.End)) Then
                Return
            End If


            Do
                ' Store the actual text that has been typed.
                sActual = cbo.Text
                ' Find the first match for the typed value.
                iIndex = cbo.FindString(sActual)
                ' Get the text of the first match.
                ' if index > -1 then a match was found.
                If (iIndex > -1) Then '** FOUND SECTION **

                    sFound = cbo.Items(iIndex).ToString()
                    ' Select this item from the list.
                    cbo.SelectedIndex = iIndex
                    ' Select the portion of the text that was automatically
                    ' added so that additional typing will replace it.

                    cbo.SelectionStart = sActual.Length
                    cbo.SelectionLength = sFound.Length
                    bMatchFound = True
                Else '** NOT FOUND SECTION ** 
                    'if there isn't a match and the text typed in is only 1 character  
                    'or nothing then just select the first entry in the combo box. 
                    If sActual.Length = 0 Then
                        cbo.SelectedIndex = 0
                        cbo.SelectionStart = 0
                        cbo.SelectionLength = Len(cbo.Text)
                        bMatchFound = True

                    Else
                        'if there isn't a match for the text typed in then  
                        'remove the last character of the text typed in  
                        'and try to find a match. 
                        '************************** NOTE ************************** 
                        'COMMENT THE FOLLOWING THREE LINES AND UNCOMMENT  
                        'THE (bMatchFound = True) LINE  
                        'INCASE YOU WANT TO ALLOW TEXTS TO BE TYPED IN 
                        ' WHICH ARE NOT IN THE LIST. ELSE IF  
                        'YOU WANT TO RESTRICT THE USER TO TYPE TEXTS WHICH ARE  
                        'NOT IN THE LIST THEN LEAVE THE FOLLOWING THREE LINES AS IT IS 
                        'AND COMMENT THE (bMatchFound = True) LINE. 
                        '***********************************************************

                        '/////// THREE LINES SECTION STARTS HERE ///////////

                        'cbo.SelectionStart = sActual.Length - 1
                        'cbo.SelectionLength = sActual.Length - 1
                        'cbo.Text = Mid(cbo.Text, 1, Len(cbo.Text) - 1)
                        '/////// THREE LINES SECTION ENDS HERE /////////////

                        bMatchFound = True
                        If IsInputRestricted Then
                            cbo.SelectionStart = sActual.Length - 1
                            cbo.SelectionLength = sActual.Length - 1
                            cbo.Text = Mid(cbo.Text, 1, Len(cbo.Text) - 1)
                            bMatchFound = False
                        End If

                    End If
                End If
            Loop Until bMatchFound
        End If

    End Sub

    

    Public Shared Function IsNumeric(ByVal strInput As String) As String

        Dim pointctr As Integer = 0
        Dim newWord1 As String = Nothing
        Dim newWord2 As String = Nothing
        Dim indicate As Integer = 0
        If strInput = Nothing Then
            newWord2 = "0.00"
        Else

            Dim word As Char() = strInput.ToCharArray()
            If word.Length > 0 Then
                For i = 0 To word.Length - 1
                    If word(i).ToString() = "." Then
                        pointctr = pointctr + 1
                    End If
                Next
                For i = 0 To word.Length - 1
                    If pointctr <= 1 And word(i).ToString() <> "," And word(i).ToString() <> "/" And word(i).ToString() <> ";" And word(i).ToString() <> "'" And word(i).ToString() <> "-" And word(i).ToString() <> "=" Then
                        If IsAlpha(word(i).ToString()) = False Then
                            newWord1 = newWord1 + word(i).ToString()
                            newWord2 = newWord1
                        Else
                            indicate += 1
                        End If
                    Else
                        pointctr -= 1
                    End If
                Next
                If indicate = word.Length Then
                    newWord2 = "0.00"
                End If
            Else
                newWord2 = "0.00"
            End If
        End If



        Return newWord2
    End Function
    Public Shared Function IsSpecialCharacter(ByVal str As String) 'by IDRIZ
        Dim illegalChars As Char() = "!@#$%^&*(){}[]""_-+<>?|/".ToCharArray()
        Dim word As Char() = str.ToCharArray()
        Dim ok As Boolean = False
        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim str3 As String = ""
        For i = 0 To word.Length - 1
            For ctr = 0 To illegalChars.Length - 1
                If word(i).ToString() = illegalChars(ctr).ToString() Then
                    ok = True
                End If
            Next
            If ok Then
                str1 = word(i).ToString()
                str2 = str2 & str1
                str3 = str2.Replace(word(i).ToString(), "")
                str2 = str3
            Else
                str1 = word(i).ToString()
                str2 = str2 & str1

            End If
            ok = False
        Next
        Return str2
    End Function
    Public Shared Function formatHospitalNumber(ByVal str As String) 'by IDRIZ
        Dim chars As Char() = str.ToCharArray()
        Dim str1 As String = ""
        Dim str2 As String = ""
        If str = "" Then
            str2 = ""
        Else
        For i = 0 To chars.Length
            If i = 2 Then
                str2 = str2 + "-"
                str2 = str2 + chars(i).ToString()
            ElseIf i = 4 Then
                str2 = str2 + "-"
                str2 = str2 + chars(i).ToString()
            ElseIf i = chars.Length - 1 Then
                str1 = chars(i).ToString()
                str2 = str2 + str1
                    Exit For
                ElseIf i = chars.Length Then
                    str2 = str2 + str1
                    Exit For
                Else
                    str1 = chars(i).ToString()
                    str2 = str2 + str1
            End If
            Next


        End If
        Return str2
    End Function

    Public Shared Function formatItemCode(ByVal str As String)
        Dim word As Char() = str.ToCharArray()
        Dim str1 As String = "0000000000000"
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim strReturn As String = ""
        Dim totalLength = CDbl(word.Length + str1.Length)
        If totalLength > 13 Then
            Dim word1 = str1 + word
            str2 = word1.Replace(" ", "")
            For i = 0 To str2.Length
                str2 = str2.Remove(0, 1)
                str3 = str2
                If str3.Length = 13 Then
                    strReturn = str3
                    Exit For
                End If
            Next
        Else
            strReturn = str
        End If
        Return strReturn
    End Function
    Public Shared Function formatPaymentDocumentNumber(ByVal str As String)
        Dim word As Char() = str.ToCharArray()
        Dim str1 As String = "00000"
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim strReturn As String = ""
        Dim totalLength = CDbl(word.Length + str1.Length)
        If totalLength > 5 Then
            str2 = str1 & word
            For i = 0 To str2.Length
                    str2 = str2.Remove(0, 1)
                    str3 = str2
                    If str3.Length = 5 Then
                        strReturn = str3
                        Exit For
                    ElseIf str3(i).ToString() <> "0" Then
                        strReturn = str3
                        Exit For
                    End If
            Next
        Else
            strReturn = str
        End If
        Return strReturn
    End Function
    Public Shared Function formatEmployeeNumber(ByVal str As String) 'IDRIZ
        Dim word As Char() = str.ToCharArray()
        Dim str1 As String = "0000000000"
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim strReturn As String = ""
        Dim totalLength = CDbl(word.Length + str1.Length)
        If totalLength > 10 Then
            str2 = str1 & word
            For i = 0 To str2.Length
                str2 = str2.Remove(0, 1)
                str3 = str2
                If str3.Length = 10 Then
                    strReturn = str3
                    Exit For
                End If
            Next
        Else
            strReturn = str
        End If
        Return strReturn
    End Function
    Public Shared Function formatClaimDocNumberNumber(ByVal str As String) 'IDRIZ
        Dim word As Char() = str.ToCharArray()
        Dim str1 As String = "00000"
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim strReturn As String = ""
        Dim totalLength = CDbl(str1.Length + word.Length)
        Dim arr As Char()
        If totalLength > 5 Then
            str2 = str1 & word
            arr = str2.ToCharArray()
            For i = 0 To str2.Length
                If i = 0 Then
                    If arr(i).ToString() <> "0" Then
                        strReturn = str2
                        Exit For
                    Else
                        str2 = str2.Remove(0, 1)
                        str3 = str2
                        If str3.Length = 5 Then
                            strReturn = str3
                            Exit For
                        End If
                    End If
                Else
                    str2 = str2.Remove(0, 1)
                    str3 = str2
                    If str3.Length = 5 Then
                        strReturn = str3
                        Exit For
                    End If
                End If
            Next
        Else
            strReturn = str
        End If
        Return strReturn
    End Function
    Public Shared Function ScalarToImage(ByRef _SqlConnection As System.Data.SqlClient.SqlConnection, ByVal _SQL As String) As System.Drawing.Image
        Dim _SqlRetVal As Object = Nothing
        Dim _Image As System.Drawing.Image = Nothing
        Try
            Dim _SqlCommand As New System.Data.SqlClient.SqlCommand(_SQL, _SqlConnection)
            _SqlRetVal = _SqlCommand.ExecuteScalar()
            _SqlCommand.Dispose()
            _SqlCommand = Nothing
        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)
            Return Nothing
        End Try
        Try
            Dim _ImageData(-1) As Byte
            _ImageData = CType(_SqlRetVal, Byte())
            Dim _MemoryStream As New System.IO.MemoryStream(_ImageData)
            _Image = System.Drawing.Image.FromStream(_MemoryStream)
        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)
            Return Nothing
        End Try
        Return _Image
    End Function

    Public Shared Function convertImage(ByVal imgdata As Byte()) 'IDRIZ
        Dim ImageData(-1) As Byte
        ImageData = CType(imgdata, Byte())
        Dim MemoryStream As New System.IO.MemoryStream(ImageData)
        Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(MemoryStream)
        Return image
    End Function
    Public Shared Function NormalValues(ByVal str As String, ByVal ctl As Control)
        Dim chars As Char() = str.ToCharArray()
        Dim str1 As String = ""
        Dim str2 As String = ""
        If ctl.Text = "M" Then
            'for male
            For i = 0 To chars.Length - 1
                If chars(i).ToString() = "#" Then
                    Exit For
                Else
                    str1 = chars(i).ToString()
                    str2 = str2 + str1

                End If
            Next
        Else
            'For female
            Dim ok As Boolean = False
            For f = 0 To chars.Length - 1
                If chars(f).ToString() = "#" Then
                    ok = True
                    Exit For
                End If
            Next
            If ok Then
                For i = 0 To chars.Length - 1
                    If chars(i).ToString() = "#" Then
                        For t = i To chars.Length - 1
                            If t <> i Then
                                str1 = chars(t).ToString()
                                str2 = str2 + str1
                            End If
                        Next
                        Exit For
                    End If
                Next
            Else
                For i = 0 To chars.Length - 1
                        str1 = chars(i).ToString()
                        str2 = str2 + str1
                Next
            End If
        End If
        Return str2
    End Function
    Public Shared Function getDosage(ByVal str As String)
        Dim chars As Char() = str.ToCharArray()
        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim ok As Boolean = False
        Dim newVar As String = ""
        Dim indx As Integer = 0
        If str = "" Then
            str2 = ""
        Else
            str2 = str.Replace(" ", "")
            For i = 0 To chars.Length - 1
                If IsAlpha(chars(i).ToString()) = False Then
                    For ctr = i - 1 To chars.Length

                        If ctr = chars.Length Then

                            str1 = chars(ctr - 1).ToString()
                            str3 = str3 & str1
                            ok = True
                            Exit For
                        Else

                            str1 = chars(ctr).ToString()
                            str3 = str3 & str1
                        End If

                    Next


                Else
                    'str2 = str2.Remove(0, 1)
                End If

                If ok Then
                    Exit For
                End If
            Next


        End If
        Return str3 
    End Function



    Public Shared Function getNotificationTransferForReceiving() As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "officecode"}
        Dim arrFieldValue() As Object = {0, 0, sourceOfficeCode}
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spManageMain", 0)
    End Function

    Public Shared Function getNotificationStockRequests() As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "officecode"}
        Dim arrFieldValue() As Object = {0, 1, sourceOfficeCode}
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spManageMain", 0)
    End Function

    Public Shared Function getNotificationRequestsForReceiving() As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "officecode"}
        Dim arrFieldValue() As Object = {0, 2, sourceOfficeCode}
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spManageMain", 0)
    End Function

    Public Shared Function getNotificationPatientRequests() As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "officecode"}
        Dim arrFieldValue() As Object = {0, 3, sourceOfficeCode}
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spManageMain", 0)
    End Function
    
    Public Shared Function getNotificationMGHPatients() As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "officecode"}
        Dim arrFieldValue() As Object = {0, 4, sourceOfficeCode}
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spManageMain", 0)
    End Function
  

    Public Shared Function IsSpecialCharacterWithperiod(ByVal str As String) 'by IDRIZ
        Dim illegalChars As Char() = "!@#$%^&*(){}[]""_-+<>?|/.:;,'\ ".ToCharArray()
        Dim word As Char() = str.ToCharArray()
        Dim ok As Boolean = False
        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim str3 As String = ""
        For i = 0 To word.Length - 1
            For ctr = 0 To illegalChars.Length - 1
                If word(i).ToString() = illegalChars(ctr).ToString() Then
                    ok = True
                End If
            Next
            If ok Then
                str1 = word(i).ToString()
                str2 = str2 & str1
                str3 = str2.Replace(word(i).ToString(), "")
                str2 = str3
            Else
                str1 = word(i).ToString()
                str2 = str2 & str1

            End If
            ok = False
        Next
        Return str2
    End Function
    Public Shared Function isFieldValid(ByVal ctl As Control)
        Dim isValid As Boolean
        If ctl.Text = "" Then
            SetErrorProvider(ctl, "This field is required.", True)
            isValid = False
        Else
            SetErrorProvider(ctl, "This field is required.", False)
            isValid = True
        End If
        Return isValid
    End Function
    Public Shared Function SetErrorProvider(ByVal ctl As Control, Optional ByVal strErrorMessage As String = "", Optional ByVal haserror As Boolean = True)
        Dim erp As New ErrorProvider()
        If haserror Then
            erp.SetError(ctl, strErrorMessage)
        Else
            erp.Clear()
            erp.Dispose()
        End If
        Return erp
    End Function
    Public Shared Function formatCMOfficeNumber(ByVal str As String)
        Dim word As Char() = str.ToCharArray()
        Dim str1 As String = "000"
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim strReturn As String = ""
        Dim totalLength = CDbl(word.Length + str1.Length)
        If word.Length > 3 Then
            strReturn = str
        Else
            If totalLength > 3 Then
                str2 = str1 & word
                For i = 0 To str2.Length
                    str2 = str2.Remove(0, 1)
                    str3 = str2
                    If str3.Length = 3 Then
                        strReturn = str3
                        Exit For
                    ElseIf str3(i).ToString() <> "0" Then
                        strReturn = str3
                        Exit For
                    End If
                Next
            Else
                strReturn = str
            End If
        End If
        Return strReturn
    End Function
    Public Shared Function formatCMDocNumber(ByVal str As String)
        Dim word As Char() = str.ToCharArray()
        Dim str1 As String = "00000"
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim strReturn As String = ""
        Dim totalLength = CDbl(word.Length + str1.Length)
        If word.Length > 5 Then
            strReturn = str
        Else
            If totalLength > 5 Then
                str2 = str1 & word
                For i = 0 To str2.Length
                    str2 = str2.Remove(0, 1)
                    str3 = str2
                    If str3.Length = 5 Then
                        strReturn = str3
                        Exit For
                    ElseIf str3(0).ToString() <> "0" Then
                        strReturn = str3
                        Exit For
                    End If
                Next
            Else
                strReturn = str
            End If
        End If
        Return strReturn
    End Function
    Public Shared Function EmptyStringDefaultDateFormat(ByVal myInput As Object) As Date 'Added by:KIMHOY TAN
        'If the input value is NULL then return the default date format 1/1/1900
        'Otherwise return the original value as a string
        If CStr(myInput) = "" Then
            Return FormatDateTime(Utility.GetServerDate(), DateFormat.ShortDate)
        Else
            Return myInput
        End If
    End Function


    'Public Shared Function encryptAppConfigFile(Optional ByVal isMainCloudDatabase As Boolean = False) As String ' this function was design to encrypt app.config file in your bin not outside the bin folder JHAYROSE
    '    Dim resultConn As String = ""





    '    Dim appConfigPath As String = Application.ExecutablePath & ".config"
    '    Dim appConfigMap = New ExeConfigurationFileMap() With { _
    '      .ExeConfigFilename = appConfigPath _
    '    }
    '    Dim JHAYROSE = ConfigurationManager.OpenMappedExeConfiguration(appConfigMap, ConfigurationUserLevel.None)
    '    If isMainCloudDatabase Then
    '        If clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("IDRISJHAY"), "") = "0" Then
    '            JHAYROSE.AppSettings.Settings("MyWebMainConnectionString").Value = clsJCypher.StringCipher.Encrypt(ConfigurationManager.AppSettings("MyWebMainConnectionString"), "")
    '            JHAYROSE.AppSettings.Settings("IDRISJHAY").Value = clsJCypher.StringCipher.Encrypt("1", "")
    '            JHAYROSE.Save(ConfigurationSaveMode.Modified)
    '            ConfigurationManager.RefreshSection("appSettings")
    '            Try
    '                resultConn = clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("MyWebMainConnectionString"), "")
    '            Catch ex As Exception
    '                resultConn = ConfigurationManager.AppSettings("MyWebMainConnectionString")
    '            End Try
    '        Else
    '            resultConn = clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("MyWebMainConnectionString"), "")
    '        End If
    '    Else
    '        If clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("JHAYROSE"), "") = "0" Then
    '            JHAYROSE.AppSettings.Settings("MyConnectionString").Value = clsJCypher.StringCipher.Encrypt(ConfigurationManager.AppSettings("MyConnectionString"), "")
    '            JHAYROSE.AppSettings.Settings("JHAYROSE").Value = clsJCypher.StringCipher.Encrypt("1", "")
    '            JHAYROSE.Save(ConfigurationSaveMode.Modified)
    '            ConfigurationManager.RefreshSection("appSettings")
    '            Try
    '                resultConn = clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("MyConnectionString"), "")
    '            Catch ex As Exception
    '                resultConn = ConfigurationManager.AppSettings("MyConnectionString")
    '            End Try
    '        Else
    '            'If 
    '            'rebuildAppConfigFile(clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("DATAS"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("INITCAT"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("IDRIS"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("ROSALES"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("AUTH"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("PCBACK"), ""), True)
    '            'End If
    '            resultConn = clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("MyConnectionString"), "")
    '        End If
    '        ' subencryptAppConfigFile(Application.ExecutablePath)
    '    End If



    '    Return resultConn
    'End Function
    'Public Shared Function rebuildAppConfigFile(ByVal server As String, ByVal database As String, ByVal login As String, ByVal password As String, Optional ByVal integratedsecurity As String = "false", Optional ByVal backup As String = "", Optional forTesting As Boolean = False) As Boolean ' this function was design to encrypt app.config file in your bin not outside the bin folder JHAYROSE
    '    Dim canconnect As Boolean = False
    '    Dim resultConn As String = String.Empty
    '    Dim newconn As String = String.Empty

    '    If forTesting Then
    '        If integratedsecurity = "True" Then
    '            newconn = "Data Source=" & server & ";Initial Catalog=" & database & "; Integrated Security=" & integratedsecurity & ";"
    '        Else
    '            newconn = "Data Source=" & server & ";Initial Catalog=" & database & "; User ID=" & login & "; Password=" & password & ";"
    '        End If
    '        Dim sqlconnection As New System.Data.SqlClient.SqlConnection(newconn)
    '        Try
    '            canconnect = True
    '            sqlconnection.Open() : sqlconnection.Close()
    '        Catch
    '            canconnect = False
    '        Finally
    '            sqlconnection.Dispose()
    '        End Try

    '        If canconnect = False Then

    '            newconn = String.Empty
    '            If integratedsecurity = "True" Then
    '                newconn = "Data Source=" & backup & ";Initial Catalog=" & database & "; Integrated Security=" & integratedsecurity & ";"
    '            Else
    '                newconn = "Data Source=" & backup & ";Initial Catalog=" & database & "; User ID=" & login & "; Password=" & password & ";"
    '            End If


    '            'Dim frmdbState As New frmDBProgress()
    '            'frmdbState.INITCAT = clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("INITCAT"), "")
    '            'frmdbState.PCBACK = clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("PCBACK"), "")
    '            'frmdbState.ShowDialog()
    '            'If frmdbState.isServerOnline Then
    '            '    'rebuildAppConfigFile(clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("DATAS"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("INITCAT"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("IDRIS"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("ROSALES"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("AUTH"), ""), clsJCypher.StringCipher.Decrypt(ConfigurationManager.AppSettings("PCBACK"), ""))
    '            '    Dim subsqlconnection As New System.Data.SqlClient.SqlConnection(newconn)
    '            '    Try
    '            '        canconnect = True
    '            '        subsqlconnection.Open() : subsqlconnection.Close()
    '            '    Catch
    '            '        canconnect = False
    '            '    Finally
    '            '        subsqlconnection.Dispose()
    '            '    End Try
    '            '    forTesting = False
    '            'Else
    '            '    canconnect = False
    '            'End If
    '        End If
    '    Else
    '        If integratedsecurity = "True" Then
    '            newconn = "Data Source=" & server & ";Initial Catalog=" & database & "; Integrated Security=" & integratedsecurity & ";"
    '        Else
    '            newconn = "Data Source=" & server & ";Initial Catalog=" & database & "; User ID=" & login & "; Password=" & password & ";"
    '        End If
    '        Dim sqlconnection As New System.Data.SqlClient.SqlConnection(newconn)
    '        Try
    '            canconnect = True
    '            sqlconnection.Open() : sqlconnection.Close()
    '        Catch
    '            canconnect = False
    '        Finally
    '            sqlconnection.Dispose()
    '        End Try
    '    End If










    '    If canconnect And forTesting = False Then
    '        Dim appConfigPath As String = Application.ExecutablePath & ".config"
    '        Dim appConfigMap = New ExeConfigurationFileMap() With { _
    '            .ExeConfigFilename = appConfigPath _
    '        }
    '        Dim JHAYROSE = ConfigurationManager.OpenMappedExeConfiguration(appConfigMap, ConfigurationUserLevel.None)
    '        JHAYROSE.AppSettings.Settings("MyConnectionString").Value = newconn
    '        JHAYROSE.AppSettings.Settings("JHAYROSE").Value = clsJCypher.StringCipher.Encrypt("0", "")
    '        JHAYROSE.AppSettings.Settings("DATAS").Value = clsJCypher.StringCipher.Encrypt(server, "")
    '        JHAYROSE.AppSettings.Settings("INITCAT").Value = clsJCypher.StringCipher.Encrypt(database, "")
    '        JHAYROSE.AppSettings.Settings("AUTH").Value = clsJCypher.StringCipher.Encrypt(integratedsecurity, "")
    '        JHAYROSE.AppSettings.Settings("IDRIS").Value = clsJCypher.StringCipher.Encrypt(login, "")
    '        JHAYROSE.AppSettings.Settings("ROSALES").Value = clsJCypher.StringCipher.Encrypt(password, "")
    '        'JHAYROSE.AppSettings.Settings("PCBACK").Value = clsJCypher.StringCipher.Encrypt(backup, "")
    '        JHAYROSE.Save(ConfigurationSaveMode.Modified)
    '        ConfigurationManager.RefreshSection("appSettings")
    '        resultConn = ConfigurationManager.AppSettings("MyConnectionString")
    '        'subrebuildAppConfigFile(Application.ExecutablePath, newconn)
    '    End If
    '    Return canconnect
    'End Function

 

    Public Shared Function datagridview_RowPrePaint(ByVal sender As DataGridView, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)
        sender.DefaultCellStyle.SelectionBackColor = Color.Transparent
        sender.BorderStyle = BorderStyle.Fixed3D
        sender.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        sender.DefaultCellStyle.SelectionForeColor = Color.Black
        sender.DefaultCellStyle.ForeColor = Color.Black
        sender.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        sender.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        sender.Cursor = Cursors.Hand
        sender.DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)


        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus
        If (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
            Dim rowBounds As New Rectangle( sender.RowHeadersWidth, e.RowBounds.Top,sender.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - sender.HorizontalScrollingOffset + 1, e.RowBounds.Height)
            Dim backbrush As New System.Drawing.Drawing2D.LinearGradientBrush( _
                rowBounds, Color.White, modGlobal.bannerColor, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
            Try
                e.Graphics.FillRectangle(backbrush, rowBounds)
            Finally
                backbrush.Dispose()
            End Try

        End If
        sender.RowHeadersDefaultCellStyle.SelectionBackColor = sender.DefaultCellStyle.SelectionBackColor
        Return sender
    End Function

    Public Shared Function datagridview_RowPostPaint(ByVal sender As DataGridView, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Dim rowBounds As New Rectangle(sender.RowHeadersWidth, e.RowBounds.Top, sender.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - sender.HorizontalScrollingOffset + 1, e.RowBounds.Height)
        Dim forebrush As SolidBrush = Nothing
        Try
            If (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                forebrush = New SolidBrush(Color.DarkOrange)
            Else
                forebrush = New SolidBrush(Color.Black) 'e.InheritedRowStyle.ForeColor)
            End If
            Try
                Dim recipe As Object = sender.Rows.SharedRow(e.RowIndex).Cells(0).Value
                If (recipe IsNot Nothing) Then
                    Dim text As String = recipe.ToString()
                    Dim textArea As Rectangle = rowBounds
                    textArea.X -= sender.HorizontalScrollingOffset
                    textArea.Width += sender.HorizontalScrollingOffset
                    textArea.Y += rowBounds.Height - e.InheritedRowStyle.Padding.Bottom
                    textArea.Height -= rowBounds.Height - e.InheritedRowStyle.Padding.Bottom
                    textArea.Height = (textArea.Height \ e.InheritedRowStyle.Font.Height) * e.InheritedRowStyle.Font.Height
                    Dim clip As RectangleF = textArea
                    clip.Width -= sender.RowHeadersWidth + 1 - clip.X
                    clip.X = sender.RowHeadersWidth + 1
                    Dim oldClip As RectangleF = e.Graphics.ClipBounds
                    e.Graphics.SetClip(clip)
                    e.Graphics.DrawString(text, e.InheritedRowStyle.Font, forebrush,textArea)
                    e.Graphics.SetClip(oldClip)
                End If
            Catch ex As Exception

            End Try
            If sender.CurrentCellAddress.Y = e.RowIndex Then
                e.DrawFocus(rowBounds, True)
            End If
        Finally
            forebrush.Dispose()
        End Try
        Return sender
    End Function

    Public Shared Function datagridview_RowHeightChanged(ByVal sender As DataGridView, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) 'Handles dgGenericList.RowHeightChanged
        Dim preferredNormalContentHeight As Int32 = e.Row.GetPreferredHeight(e.Row.Index, DataGridViewAutoSizeRowMode.AllCellsExceptHeader, True) - e.Row.DefaultCellStyle.Padding.Bottom()
        Dim newPadding As Padding = e.Row.DefaultCellStyle.Padding
        newPadding.Bottom = e.Row.Height - preferredNormalContentHeight
        Return e.Row.DefaultCellStyle.Padding = newPadding

    End Function

    Public Shared Function datagridview_CellPainting(sender As DataGridView, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
        If e.RowIndex = -1 Then
            Dim img As Image = Nothing 'My.Resources.Header_Blue
            TekenAchtergrond(e.Graphics, img, e.CellBounds, 1)
            Dim format1 As StringFormat
            format1 = New StringFormat
            format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
            Dim ef1 As SizeF = e.Graphics.MeasureString(e.Value, sender.Font, New SizeF(CType(e.CellBounds.Width, Single), CType(e.CellBounds.Height, Single)), format1)

            Dim txts As Size = Drawing.Size.Empty

            txts = Drawing.Size.Ceiling(ef1)
            e.CellBounds.Inflate(-4, -4)

            Dim txtr As Rectangle = e.CellBounds
            txtr = HAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
            txtr = VAlignWithin(txts, txtr, ContentAlignment.MiddleCenter)
            Dim brush2 As Brush
            format1 = New StringFormat
            format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show

            brush2 = New SolidBrush(Color.FromArgb(21, 66, 139))

            e.Graphics.DrawString(e.Value, sender.Font, brush2, CType(txtr, RectangleF), format1)
            brush2.Dispose()
            Dim recBorder As New Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1)
            e.Graphics.DrawRectangle(Pens.LightSlateGray, recBorder)

            sender.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            e.Handled = True

        End If
        Return sender
    End Function
    Private Shared Sub TekenAchtergrond(ByVal g As Graphics, _
        ByVal obj As Image, ByVal r As Rectangle, _
        ByVal index As Integer)
        If (obj Is Nothing) Then
            Return
        End If
        Dim oWidth As Integer = obj.Width
        Dim lr As Rectangle = Rectangle.FromLTRB(0, 0, 0, 0)
        Dim r2 As Rectangle
        Dim r1 As Rectangle
        Dim x As Integer = ((index - 1) _
                    * oWidth)
        Dim y As Integer = 0
        Dim x1 As Integer = r.Left
        Dim y1 As Integer = r.Top
        If ((r.Height > obj.Height) _
                    AndAlso (r.Width <= oWidth)) Then
            r1 = New Rectangle(x, y, oWidth, lr.Top)
            r2 = New Rectangle(x1, y1, r.Width, lr.Top)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            r1 = New Rectangle(x, (y + lr.Top), oWidth, (obj.Height _
                            - (lr.Top - lr.Bottom)))
            r2 = New Rectangle(x1, (y1 + lr.Top), r.Width, (r.Height _
                            - (lr.Top - lr.Bottom)))
            If ((lr.Top + lr.Bottom) _
                        = 0) Then
                r1.Height = (r1.Height - 1)
            End If
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            r1 = New Rectangle(x, (y _
                            + (obj.Height - lr.Bottom)), oWidth, lr.Bottom)
            r2 = New Rectangle(x1, (y1 _
                            + (r.Height - lr.Bottom)), r.Width, lr.Bottom)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
        ElseIf ((r.Height <= obj.Height) _
                    AndAlso (r.Width > oWidth)) Then
            r1 = New Rectangle(x, y, lr.Left, obj.Height)
            r2 = New Rectangle(x1, y1, lr.Left, r.Height)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            r1 = New Rectangle((x + lr.Left), y, (oWidth _
                            - (lr.Left - lr.Right)), obj.Height)
            r2 = New Rectangle((x1 + lr.Left), y1, (r.Width _
                            - (lr.Left - lr.Right)), r.Height)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            r1 = New Rectangle((x _
                            + (oWidth - lr.Right)), y, lr.Right, obj.Height)
            r2 = New Rectangle((x1 _
                            + (r.Width - lr.Right)), y1, lr.Right, r.Height)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
        ElseIf ((r.Height <= obj.Height) _
                    AndAlso (r.Width <= oWidth)) Then
            r1 = New Rectangle(((index - 1) _
                            * oWidth), 0, oWidth, (obj.Height - 1))

            g.DrawImage(obj, New Rectangle(x1, y1, r.Width, r.Height), _
                        r1, GraphicsUnit.Pixel)
        ElseIf ((r.Height > obj.Height) _
                    AndAlso (r.Width > oWidth)) Then
            'top-left
            r1 = New Rectangle(x, y, lr.Left, lr.Top)
            r2 = New Rectangle(x1, y1, lr.Left, lr.Top)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'top-bottom
            r1 = New Rectangle(x, (y _
                            + (obj.Height - lr.Bottom)), lr.Left, lr.Bottom)
            r2 = New Rectangle(x1, (y1 _
                            + (r.Height - lr.Bottom)), lr.Left, lr.Bottom)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'left
            r1 = New Rectangle(x, (y + lr.Top), lr.Left, (obj.Height _
                            - (lr.Top - lr.Bottom)))
            r2 = New Rectangle(x1, (y1 + lr.Top), lr.Left, (r.Height _
                            - (lr.Top - lr.Bottom)))
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'top
            r1 = New Rectangle((x + lr.Left), y, (oWidth _
                            - (lr.Left - lr.Right)), lr.Top)
            r2 = New Rectangle((x1 + lr.Left), y1, (r.Width _
                            - (lr.Left - lr.Right)), lr.Top)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'right-top
            r1 = New Rectangle((x _
                            + (oWidth - lr.Right)), y, lr.Right, lr.Top)
            r2 = New Rectangle((x1 _
                            + (r.Width - lr.Right)), y1, lr.Right, lr.Top)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'Right
            r1 = New Rectangle((x _
                            + (oWidth - lr.Right)), (y + lr.Top), lr.Right, (obj.Height _
                            - (lr.Top - lr.Bottom)))
            r2 = New Rectangle((x1 _
                            + (r.Width - lr.Right)), (y1 + lr.Top), lr.Right, (r.Height _
                            - (lr.Top - lr.Bottom)))
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'right-bottom
            r1 = New Rectangle((x _
                            + (oWidth - lr.Right)), (y _
                            + (obj.Height - lr.Bottom)), lr.Right, lr.Bottom)
            r2 = New Rectangle((x1 _
                            + (r.Width - lr.Right)), (y1 _
                            + (r.Height - lr.Bottom)), lr.Right, lr.Bottom)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'bottom
            r1 = New Rectangle((x + lr.Left), (y _
                            + (obj.Height - lr.Bottom)), (oWidth _
                            - (lr.Left - lr.Right)), lr.Bottom)
            r2 = New Rectangle((x1 + lr.Left), (y1 _
                            + (r.Height - lr.Bottom)), (r.Width _
                            - (lr.Left - lr.Right)), lr.Bottom)
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
            'Center
            r1 = New Rectangle((x + lr.Left), (y + lr.Top), (oWidth _
                            - (lr.Left - lr.Right)), (obj.Height _
                            - (lr.Top - lr.Bottom)))
            r2 = New Rectangle((x1 + lr.Left), (y1 + lr.Top), (r.Width _
                            - (lr.Left - lr.Right)), (r.Height _
                            - (lr.Top - lr.Bottom)))
            g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel)
        End If
    End Sub
    Private Shared Function HAlignWithin(ByVal alignThis As Size, ByVal withinThis As Rectangle, ByVal align As ContentAlignment) As Rectangle
        If ((align And anyRight) _
                    <> CType(0, ContentAlignment)) Then
            withinThis.X = (withinThis.X _
                        + (withinThis.Width - alignThis.Width))
        ElseIf ((align And anyCenter) _
                    <> CType(0, ContentAlignment)) Then
            withinThis.X = (withinThis.X _
                        + (((withinThis.Width - alignThis.Width) _
                        + 1) _
                        / 2))
        End If
        withinThis.Width = alignThis.Width
        Return withinThis
    End Function
    Private Shared Function VAlignWithin(ByVal alignThis As Size, ByVal withinThis As Rectangle, ByVal align As ContentAlignment) As Rectangle
        If ((align And anyBottom) _
                    <> CType(0, ContentAlignment)) Then
            withinThis.Y = (withinThis.Y _
                        + (withinThis.Height - alignThis.Height))
        ElseIf ((align And anyMiddle) _
                    <> CType(0, ContentAlignment)) Then
            withinThis.Y = (withinThis.Y _
                        + (((withinThis.Height - alignThis.Height) _
                        + 1) _
                        / 2))
        End If
        withinThis.Height = alignThis.Height
        Return withinThis
    End Function
    Public Shared Function ReadExcelFile(ByVal path As String, ByVal sheet As String) As DataTable
        Dim da As New OleDbDataAdapter : Dim dt As New DataTable() : Dim cmd As New OleDbCommand : Dim xlsConn As OleDbConnection
        Dim sPath As String = String.Empty
        sPath = path

        xlsConn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sPath & ";Extended Properties=Excel 12.0")
        Try
            xlsConn.Open()
            cmd.Connection = xlsConn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = ("select * from [" & sheet & "$]")
            da.SelectCommand = cmd
            da.Fill(dt)
        Catch
            xlsConn.Close()
            xlsConn = Nothing
            MsgBox(ErrorToString)
        Finally
            xlsConn.Close()
            xlsConn = Nothing
        End Try

        Return dt
    End Function
    Public Shared Function isCutOffDate(ByVal prepareddate As Date, ByVal dtCutOffdate As DataTable) As Boolean 'RSJ 2014/10/30
        Dim isCutOff As Boolean = False
        'Dim dtCutOffdate As New DataTable
        'dtCutOffdate = clsEmployeeCharges.getReligiousGroups(15)

        If dtCutOffdate.Rows.Count > 0 Then
            If CDate(dtCutOffdate.Rows(0).Item("cutoffdate")) >= FormatDateTime(prepareddate, DateFormat.ShortDate) Then
                isCutOff = False : Else : isCutOff = True : End If
        Else : isCutOff = True : End If

        Return isCutOff
    End Function
    Public Shared Function GetHash(ByVal theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("x2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function
    Public Shared Function GetRandomPassword() As String
        Dim validchars As String = "0123456789abcdefghjkmnpqrstuvwxyz"
        Dim sb As New System.Text.StringBuilder
        Dim rand As New Random()
        For i As Integer = 1 To 6
            Dim idx As Integer = rand.Next(0, validchars.Length)
            Dim randomChar As Char = validchars(idx)
            sb.Append(randomChar)
        Next i

        Return sb.ToString()
    End Function
    Public Shared Function FormatMultupleIDs(ByRef str As String, ByRef type As String) As String
        Dim strfinal As String = ""
        Dim len As Integer = 0
        Select Case type
            Case "Item"
                len = 7
            Case "Empployee", "Patient", "OR"
                len = 6
        End Select
        For i As Integer = 0 To len - str.Length
            strfinal = strfinal & "0"
        Next
        Return strfinal & str
    End Function
    'Public Shared Sub SetClinicHeader(ByRef crrep As Object, Optional ByRef isdaterange As Boolean = False,
    '                                  Optional ByVal sdate As String = "2016-09-09",
    '                                  Optional ByVal edate As String = "2016-09-09")
    '    Dim companyname As CrystalDecisions.CrystalReports.Engine.TextObject
    '    companyname = crrep.ReportDefinition.Sections("Section1").ReportObjects.Item("txtClinicName")
    '    companyname.Text = ClinicName
    '    Dim comaddress As CrystalDecisions.CrystalReports.Engine.TextObject
    '    comaddress = crrep.ReportDefinition.Sections("Section1").ReportObjects.Item("txtClinicAddress")
    '    comaddress.Text = ClinicAddress
    '    Dim comcontact As CrystalDecisions.CrystalReports.Engine.TextObject
    '    comcontact = crrep.ReportDefinition.Sections("Section1").ReportObjects.Item("txtClinicContact")
    '    comcontact.Text = ClinicContact

    '    If isdaterange Then
    '        Dim txtstartdate As CrystalDecisions.CrystalReports.Engine.TextObject
    '        txtstartdate = crrep.ReportDefinition.Sections("Section1").ReportObjects.Item("txtstartdate")
    '        txtstartdate.Text = CDate(sdate).ToString("MMMM dd, yyyy")
    '        Dim txtenddate As CrystalDecisions.CrystalReports.Engine.TextObject
    '        txtenddate = crrep.ReportDefinition.Sections("Section1").ReportObjects.Item("txtenddate")
    '        txtenddate.Text = CDate(edate).ToString("MMMM dd, yyyy")
    '    End If
    'End Sub

    'Public Shared Sub setSettings(ByVal setting As Integer, ByVal value As String)
    '    Try
    '        Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    '        Dim key As CMSSettings = setting
    '        configFile.AppSettings.Settings(key.ToString).Value = value
    '        configFile.Save(ConfigurationSaveMode.Modified)
    '        ConfigurationManager.RefreshSection("appSettings")
    '    Catch e As ConfigurationErrorsException
    '        Console.WriteLine("Error writing app settings")
    '    End Try
    'End Sub

    'Public Shared Function readSetting(ByVal setting As Integer) As String
    '    Try
    '        Dim appSettings = ConfigurationManager.AppSettings
    '        Dim key As CMSSettings = setting
    '        Dim result As String = appSettings(key.ToString)
    '        If IsNothing(result) Then
    '            result = "Not found"
    '        End If
    '        Return result
    '    Catch e As ConfigurationErrorsException
    '        Return ""
    '    End Try
    'End Function

    'Public Shared Sub backupdatabase(ByRef loc As String)
    '    Dim sqlcmd As New SqlCommand
    '    Dim conn As New SqlConnection
    '    conn.ConnectionString = gconnectionstring
    '    conn.Open()
    '    sqlcmd.Connection = conn
    '    sqlcmd.CommandText = "spUtilities"
    '    sqlcmd.CommandType = CommandType.StoredProcedure
    '    sqlcmd.Parameters.Add(New SqlParameter("operation", 0))
    '    sqlcmd.Parameters.Add(New SqlParameter("soperation", 0))
    '    sqlcmd.Parameters.Add(New SqlParameter("location", loc))
    '    sqlcmd.ExecuteNonQuery()
    'End Sub
    Public Shared Function GetRandomString() As String
        Dim validchars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim sb As New System.Text.StringBuilder
        Dim rand As New Random()
        For i As Integer = 1 To 10
            Dim idx As Integer = rand.Next(0, validchars.Length)
            Dim randomChar As Char = validchars(idx)
            sb.Append(randomChar)
        Next i
        Return sb.ToString()
    End Function
    'Public Shared Sub convertToPDF(ByRef filesToProcess() As String, ByRef destination As String)
    '    Using pdf As New PdfDocument

    '        'Add PDF pages.
    '        For i As Integer = 0 To filesToProcess.Length - 1

    '            'Create new PDF page.
    '            Dim page = pdf.AddPage()

    '            'Create XImage object from file.
    '            Using xImg = PdfSharp.Drawing.XImage.FromFile(filesToProcess(i))
    '                'Resize page Width and Height to fit image size.
    '                page.Width = xImg.PixelWidth * 72 / xImg.HorizontalResolution
    '                page.Height = xImg.PixelHeight * 72 / xImg.HorizontalResolution

    '                'Draw current image file to page.
    '                Dim GR = PdfSharp.Drawing.XGraphics.FromPdfPage(page)
    '                GR.DrawImage(xImg, 0, 0, page.Width, page.Height)
    '            End Using
    '        Next

    '        'Erase all items in array. Memory leaking free...
    '        Erase filesToProcess

    '        'Save to PDF file.
    '        pdf.Save(destination)
    '    End Using
    'End Sub


    Public Shared Function GetServerDate() As Date
        Dim strPar() As String = {"Operation"}
        Dim strVal() As String = {0}
        Dim dt As DataTable = GenericDA.ManageQuery(strPar, strVal, "spGetSystemDate", 0)
        Dim vServerDate As Date = CDate(dt.Rows(0).Item("serverdatetime").ToString)
        dt = Nothing
        Return vServerDate
    End Function
    Public Shared Function Decrypt(ByVal constring As String) As String
        Dim KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
        Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC

        Dim enc As System.Text.UTF8Encoding
        Dim decryptor As ICryptoTransform

        enc = New System.Text.UTF8Encoding
        decryptor = symmetricKey.CreateDecryptor(KEY_128, IV_128)

        Dim cypherTextBytes As Byte() = Convert.FromBase64String(constring)
        Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes(cypherTextBytes.Length) As Byte
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
        memoryStream.Close()
        cryptoStream.Close()
        Return enc.GetString(plainTextBytes, 0, decryptedByteCount)
    End Function
    Public Shared Function getReference(ByRef key As String) As Long
        Try
            Dim strPar() As String = {"operation", "soperation", "search"}
            Dim strVal() As String = {0, 14, key.ToString}
            Dim dt As DataTable = GenericDA.ManageQuery(strPar, strVal, "spEclaims", 0)
            Dim obj As Long = dt.Rows(0).Item("referencevalue")
            Return obj
        Catch ex As Exception
            Return 0
        End Try


    End Function
    Public Shared Function IsColor(ByVal TextName As String) As Boolean
        If [Enum].GetNames(GetType(KnownColor)).Contains(TextName) Then Return True Else Return False
    End Function
    Public Shared Function RemoveIllegalFileNameChars(input As String, Optional replacement As String = "") As String
        Return Regex.Replace(input.Trim(), "[^A-Za-z0-9_. ]+", replacement)
    End Function

End Class
