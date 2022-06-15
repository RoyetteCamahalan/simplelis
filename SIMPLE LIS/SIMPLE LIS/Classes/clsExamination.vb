Public Class clsExamination
#Region "Variables"
    Private operation As Integer
    Private soperation As Integer
    Dim mlaboratoryid As Long
    Dim mlabmasterdescription As String
    Dim mlaboratorydetailsid As Long
    Dim mlabdetailsdescription As String
    Dim mnormalvalues As String
    Dim mvisible As Byte
    Dim mx As Long
    Dim myy As Long
    Dim mtxtheight As Long
    Dim mtxtwidth As Long
    Dim mIsDrag As Byte
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
    Public Property normalvalues() As Long
        Get
            Return mnormalvalues
        End Get
        Set(ByVal value As Long)
            mnormalvalues = value
        End Set
    End Property
    Public Property visible() As Byte
        Get
            Return mvisible
        End Get
        Set(ByVal value As Byte)
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


#End Region

End Class
