Public Class clsExamination
#Region "Variables"
    Private operation As Integer
    Private soperation As Integer
    Dim mlaboratoryid As Long
    Dim mlabmasterdescription As String
    Dim mlaboratorydetailsid As Long
    Dim mlabdetailsdescription As String
    Dim mnormalvalues As String
    Dim mvisible As Boolean
    Dim mx As Long
    Dim myy As Long
    Dim mtxtheight As Long
    Dim mtxtwidth As Long
    Dim mIsDrag As Byte
    Public unit As String
    Public orderno As Integer
    Public x2 As Long
    Public y2 As Long
    Public height2 As Long
    Public width2 As Long
    Public optionvalues As String
    Public controltype As String
    Public defaultvalue As String
    Public labeldescription As String
    Public panelsize As Integer
    Public normalvaluessi As String
    Public unitsi As String
    Public siconversion As Double
#End Region

#Region "Properties"
    Public Property laboratoryid() As Long
        Get
            Return mlaboratoryid
        End Get
        Set(ByVal value As Long)
            mlaboratoryid = value
        End Set
    End Property
    Public Property labmasterdescription() As String
        Get
            Return mlabmasterdescription
        End Get
        Set(ByVal value As String)
            mlabmasterdescription = value
        End Set
    End Property
    Public Property laboratorydetailsid() As Long
        Get
            Return mlaboratorydetailsid
        End Get
        Set(ByVal value As Long)
            mlaboratorydetailsid = value
        End Set
    End Property
    Public Property labdetailsdescription() As String
        Get
            Return mlabdetailsdescription
        End Get
        Set(ByVal value As String)
            mlabdetailsdescription = value
        End Set
    End Property
    Public Property normalvalues() As String
        Get
            Return mnormalvalues
        End Get
        Set(ByVal value As String)
            mnormalvalues = value
        End Set
    End Property
    Public Property visible() As Boolean
        Get
            Return mvisible
        End Get
        Set(ByVal value As Boolean)
            mvisible = value
        End Set
    End Property
    Public Property x() As Long
        Get
            Return mx
        End Get
        Set(ByVal value As Long)
            mx = value
        End Set
    End Property
    Public Property y() As Long
        Get
            Return myy
        End Get
        Set(ByVal value As Long)
            myy = value
        End Set
    End Property
    Public Property txtheight() As Long
        Get
            Return mtxtheight
        End Get
        Set(ByVal value As Long)
            mtxtheight = value
        End Set
    End Property
    Public Property txtwidth() As Long
        Get
            Return mtxtwidth
        End Get
        Set(ByVal value As Long)
            mtxtwidth = value
        End Set
    End Property
    Public Property isDrag() As Byte
        Get
            Return mIsDrag
        End Get
        Set(ByVal value As Byte)
            mIsDrag = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Shared Function genericcls(ByVal sop As Integer, ByVal s As String) As DataTable
        Dim strPar() As String = {"@operation", "@soperation", "@search"}
        Dim strVal() As String = {0, sop, s}
        Return GenericDA.ManageQuery(strPar, strVal, "spExamination", 0)
    End Function
    Public Shared Function getLabdetails(ByVal s As String) As DataTable
        Dim strPar() As String = {"@operation", "@soperation", "@search"}
        Dim strVal() As String = {0, 0, s}
        Return GenericDA.ManageQuery(strPar, strVal, "spExamination", 0)
    End Function

    Public Shared Function getLabtypes() As DataTable
        Dim strPar() As String = {"@operation", "@soperation"}
        Dim strVal() As String = {0, 3}
        Return GenericDA.ManageQuery(strPar, strVal, "spExamination", 0)
    End Function
    Public Shared Function getLabItems() As DataTable
        Dim strPar() As String = {"@operation", "@soperation"}
        Dim strVal() As String = {0, 4}
        Return GenericDA.ManageQuery(strPar, strVal, "spExamination", 0)
    End Function
    Public Shared Function getLab() As DataTable
        Dim strPar() As String = {"@operation", "@soperation"}
        Dim strVal() As String = {0, 5}
        Return GenericDA.ManageQuery(strPar, strVal, "spExamination", 0)
    End Function


    Public Function save(ByVal isNew As Boolean) As Long
        If isNew Then
            operation = 1
            soperation = 0
        Else
            operation = 2
        End If

        Dim strPar() As String = {"@operation", _
                                   "@soperation", _
                                   "@laboratorydetailsOLDid", _
                                   "@visible", _
                                   "@isDrag", _
                                   "@x", _
                                   "@y"}

        Dim strVal() As String = {operation, _
                                    soperation, _
                                    Me.laboratorydetailsid, _
                                    Me.visible, _
                                    Me.isDrag, _
                                    Me.x, _
                                    Me.y}
        Return GenericDA.ManageQuery(strPar, strVal, "spExamination", 1)

    End Function
    Public Sub saveDetails(ByVal isNew As Boolean)
        If isNew Then
            operation = 1
        Else
            operation = 2
        End If

        Dim strPar() As String = {"operation", "soperation", "laboratorydetailsid", "laboratoryid", "labdetailsdescription", "normalvalues", "visible",
                                  "unit", "orderno", "x2", "y2", "height2", "width2", "optionvalues", "controltype", "defaultvalue", "labeldescription",
                                  "normalvaluessi", "unitsi", "siconversion"}

        Dim strVal() As String = {operation, 2, Me.laboratorydetailsid, Me.laboratoryid, Me.labdetailsdescription, Me.normalvalues, Me.visible,
                                  Me.unit, Me.orderno, x2, y2, height2, width2, optionvalues, controltype, defaultvalue, labeldescription,
                                  normalvaluessi, unitsi, siconversion}
        GenericDA.ManageQuery(strPar, strVal, "spExamination", 1)

    End Sub
    Public Sub saveLaboratory()
        Dim strPar() As String = {"operation", "soperation", "laboratoryid", "panelsize"}
        Dim strVal() As String = {2, 4, laboratoryid, Me.panelsize}
        GenericDA.ManageQuery(strPar, strVal, "spExamination", 1)
    End Sub
    Public Shared Sub SaveLaboratory(ByVal laboratoryid As Long, ByVal labdescription As String, ByVal resulttitle As String, ByVal isactive As Boolean)
        Dim operation As Integer
        If laboratoryid = 0 Then
            operation = 1
        Else
            operation = 2
        End If
        Dim strPar() As String = {"operation", "soperation", "laboratoryid", "labmasterdescription", "labresulttitle", "isactive"}
        Dim strVal() As Object = {operation, 3, laboratoryid, labdescription, resulttitle, isactive}
        GenericDA.ManageQuery(strPar, strVal, "spExamination", 2)
    End Sub

#End Region

End Class
