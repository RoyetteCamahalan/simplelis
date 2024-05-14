Public Class clsModel
    Public Class ControlTypes
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
                Case clsModel.ControlTypes.TextField
                    Return "TextField"
                Case clsModel.ControlTypes.Dropdown
                    Return "Dropdown"
                Case clsModel.ControlTypes.DoubleTextField
                    Return "Double Text Field"
                Case clsModel.ControlTypes.ResizableTextField
                    Return "Resizable Text Field"
                Case clsModel.ControlTypes.ParagraphField
                    Return "Paragraph Field"
                Case clsModel.ControlTypes.DateTimePicker
                    Return "Date & Time Picker"
                Case Else
                    Return "Label"
            End Select
        End Function
        Public Shared Function isInputField(ByVal ctrtype As Integer) As Boolean
            Return ctrtype = TextField Or ctrtype = Dropdown Or ctrtype = DoubleTextField Or ctrtype = ResizableTextField Or ctrtype = DateTimePicker
        End Function
        Public Shared Function isLabel(ByVal ctrtype As Integer) As Boolean
            Return ctrtype = LabelH1 Or ctrtype = LabelH2 Or ctrtype = LabelH3 Or ctrtype = LabelH4 Or ctrtype = LabelH5
        End Function
    End Class
    Public Class LabControl
        Public laboratoryresultdetailid As Long
        Public laboratorydetailsid As Long
        Public mname As String
        Public labeltext As String
        Public ctrtype As Integer
        Public loc As Point
        Public value As String
        Public optvalue As String
        Public muuid As String
        Public panelwidth As Long
        Public panelheight As Long
        Public defaultvalue As String
        Public texthighlight As String = ""
        Public misvisible As Boolean
        Public Property isvisible() As Boolean
            Get
                Return misvisible
            End Get
            Set(ByVal value As Boolean)
                misvisible = value
            End Set
        End Property
        Public Property uuid() As String
            Get
                Return muuid
            End Get
            Set(ByVal value As String)
                muuid = value
            End Set
        End Property
        Public Property name() As String
            Get
                Return mname
            End Get
            Set(ByVal value As String)
                mname = value
            End Set
        End Property
        Public Property controlTypeDescription() As String
            Get
                Return clsModel.ControlTypes.getDescription(Me.ctrtype)
            End Get
            Set(ByVal value As String)

            End Set
        End Property


        Public Sub New()
            Me.uuid = Utility.GetRandomString()
            Me.panelwidth = clsModel.ControlTypes.DefaultPanelWidth
            Me.panelheight = clsModel.ControlTypes.DefaultPanelHeight
        End Sub
        Public Sub New(row As DataRow, Optional laboratoryresultdetailid As Long = 0, Optional value As String = "")
            Me.laboratoryresultdetailid = laboratoryresultdetailid
            Me.laboratorydetailsid = row.Item("laboratorydetailsid")
            Me.name = row.Item("description")
            Me.labeltext = row.Item("labeldescription")
            Me.ctrtype = row.Item("controltype")
            Me.loc = New Point(row.Item("x2"), row.Item("y2"))
            Me.value = value
            Me.optvalue = row.Item("optionvalues")
            Me.uuid = IIf(Me.laboratorydetailsid > 0, Me.laboratorydetailsid, Utility.GetRandomString())
            Me.panelwidth = row.Item("width2")
            Me.panelheight = row.Item("height2")
            Me.defaultvalue = row.Item("defaultvalue")
            Me.texthighlight = row.Item("texthighlight")
            Me.isvisible = row.Item("visible")
        End Sub
        Public Function isLabel() As Boolean
            If ctrtype = clsModel.ControlTypes.LabelH1 Or ctrtype = clsModel.ControlTypes.LabelH2 Or
                ctrtype = clsModel.ControlTypes.LabelH3 Or ctrtype = clsModel.ControlTypes.LabelH4 Or
                ctrtype = clsModel.ControlTypes.LabelH5 Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class

    Public Class EmployeeTypes
        Public Shared radtech As Integer = 901
        Public Shared cardiologist As Integer = 902
        Public Shared radiologist As Integer = 999
        Public Shared medtech As Integer = 666
        Public Shared pathologist As Integer = 777
    End Class
    Public Class RequestStatus
        Public Shared posted As Integer = 3
        Public Shared charged As Integer = 3
        Public Shared resultencoded As Integer = 4
        Public Shared released As Integer = 5
        Public Shared cancelled As Integer = 6
    End Class
    Public Class ReferenceKeys
        Public Shared lab_showmedtech_sig As String = "lab_showmedtech_sig"
        Public Shared lab_showpatho_sig As String = "lab_showpatho_sig"
    End Class
End Class
