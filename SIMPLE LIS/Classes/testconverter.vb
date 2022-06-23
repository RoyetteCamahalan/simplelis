Public Class testconverter
    Public Function sRTF_To_HTML(ByVal sRTF As String) As String
        'Declare a Word Application Object and a Word WdSaveOptions object
        Dim MyWord As Microsoft.Office.Interop.Word.Application
        Dim oDoNotSaveChanges As Object = _
             Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges
        'Declare two strings to handle the data
        Dim sReturnString As String = ""
        Dim sConvertedString As String = ""
        Try
            'Instantiate the Word application,
            'set visible to false and create a document
            MyWord = CreateObject("Word.application")
            MyWord.Visible = False
            MyWord.Documents.Add()
            'Create a DataObject to hold the Rich Text
            'and copy it to the clipboard
            Dim doRTF As New System.Windows.Forms.DataObject
            doRTF.SetData("Rich Text Format", sRTF)
            Clipboard.SetDataObject(doRTF)
            'Paste the contents of the clipboard to the empty,
            'hidden Word Document
            MyWord.Windows(1).Selection.Paste()
            'â€¦then, select the entire contents of the document
            'and copy back to the clipboard
            MyWord.Windows(1).Selection.WholeStory()
            MyWord.Windows(1).Selection.Copy()
            'Now retrieve the HTML property of the DataObject
            'stored on the clipboard
            sConvertedString = _
                 Clipboard.GetData(System.Windows.Forms.DataFormats.Html)
            'Remove some leading text that shows up in some instances
            '(like when you insert it into an email in Outlook
            sConvertedString = _
                 sConvertedString.Substring(sConvertedString.IndexOf("<html"))
            'Also remove multiple Ã‚ characters that somehow end up in there
            sConvertedString = sConvertedString.Replace("Ã‚", "")
            'â€¦and you're done.
            sReturnString = sConvertedString
            If Not MyWord Is Nothing Then
                MyWord.Quit(oDoNotSaveChanges)
                MyWord = Nothing
            End If
        Catch ex As Exception
            If Not MyWord Is Nothing Then
                MyWord.Quit(oDoNotSaveChanges)
                MyWord = Nothing
            End If
            MsgBox("Error converting Rich Text to HTML")
        End Try
        Return sReturnString
    End Function
End Class
