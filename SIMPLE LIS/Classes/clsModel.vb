Public Class clsModel
    Public Class ConstrolTypes
        Public Shared TextField As Integer = 1
        Public Shared Dropdown As Integer = 2
        Public Shared LabelH1 As Integer = 3
        Public Shared LabelH2 As Integer = 4
        Public Shared LabelH3 As Integer = 5
        Public Shared LabelH4 As Integer = 6
        Public Shared DoubleTextField As Integer = 7
        Public Shared LabelH5 As Integer = 8
        Public Shared ResizableTextField As Integer = 9
        Public Shared DateTimePicker As Integer = 10
        Public Shared ParagraphField As Integer = 11

        Public Shared DoubleTextFieldHeight As Integer = 46
        Public Shared ResizableTextFieldHeight As Integer = 86
        Public Shared DefaultPanelHeight As Integer = 26
        Public Shared DefaultPanelWidth As Integer = 120

        Public Shared yyyyMMddhhmmtt As String = "yyyy/MM/dd hh:mm: tt"
        Public Shared Function getDescription(ByVal ctrtype As Integer) As String
            Select Case ctrtype
                Case clsModel.ConstrolTypes.TextField
                    Return "TextField"
                Case clsModel.ConstrolTypes.Dropdown
                    Return "Dropdown"
                Case clsModel.ConstrolTypes.DoubleTextField
                    Return "Double Text Field"
                Case clsModel.ConstrolTypes.ResizableTextField
                    Return "Resizable Text Field"
                Case clsModel.ConstrolTypes.DateTimePicker
                    Return "Date & Time Picker"
                Case Else
                    Return "Label"
            End Select
        End Function
        Public Shared Function isInputField(ByVal ctrtype As Integer) As Boolean
            If ctrtype = TextField Or ctrtype = Dropdown Or ctrtype = DoubleTextField Or ctrtype = ResizableTextField Or ctrtype = DateTimePicker Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class

    Public Class LabFormats
        Public Shared GENERIC As Integer = 0 'Drag and Drop
        Public Shared WITHSIORCONVENTIONALNOCONVERSION As Integer = 1
        Public Shared WITHSIANDCONVENTIONALWITHCONVERSION As Integer = 2
        Public Shared RADIOLOGY As Integer = 3
        Public Shared ULTRASOUND As Integer = 4
        Public Shared CROSSMATCHING As Integer = 5
        Public Shared NEWBORNSCREENING As Integer = 6
        Public Shared ECGREPORT As Integer = 7
    End Class

    Public Class EmployeeTypes
        Public Shared radtech As Integer = 901
        Public Shared radiologist As Integer = 999
        Public Shared medtech As Integer = 666
        Public Shared pathologist As Integer = 777
    End Class
    Public Class RequestStatus
        Public Shared encoded As Integer = 5
        Public Shared posted As Integer = 5
        Public Shared charged As Integer = 5
        Public Shared resultencoded As Integer = 5
        Public Shared released As Integer = 5
        Public Shared cancelled As Integer = 6
    End Class
    Public Class ReferenceKeys
        Public Shared lab_showmedtech_sig As String = "lab_showmedtech_sig"
        Public Shared lab_showpatho_sig As String = "lab_showpatho_sig"
    End Class
End Class
