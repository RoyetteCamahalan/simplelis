Public Class clsLaboratoryResultDetails
#Region "Variables"
    Private mOldlaboratoryresultid As Long
    Private mlaboratoryresultid As Long
    Private mlaboratorydetailsid As Long
    Private mresult As String
    Private mresultconversion As String
#End Region
#Region "Properties"
    Public Property Oldlaboratoryresultid() As Long
        Get
            Return mOldlaboratoryresultid
        End Get
        Set(ByVal value As Long)
            mOldlaboratoryresultid = value
        End Set
    End Property
    Public Property laboratoryresultid() As Long
        Get
            Return mlaboratoryresultid
        End Get
        Set(ByVal value As Long)
            mlaboratoryresultid = value
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
    Public Property result() As String
        Get
            Return mresult
        End Get
        Set(ByVal value As String)
            mresult = value
        End Set
    End Property
    Public Property resultconversion() As String
        Get
            Return mresultconversion
        End Get
        Set(ByVal value As String)
            mresultconversion = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Shared Function getLaboratoryResultDetails(ByVal requestdetailno As String, ByVal labID As String, ByVal labType As String, ByVal isNew As Integer) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search", "search1", "search2"}
        Dim strVal() As Object = {0, isNew, requestdetailno, labID, labType}
        Return GenericDA.ManageQuery(strPar, strVal, "spLaboratoryResultdetails", 0)
    End Function
    Public Function Save(ByVal isNew As Boolean) As DataTable
        Dim operation As Integer
        If isNew Then
            operation = 1
        Else
            operation = 2
        End If
        Dim strPar() As String = {"@operation", "@soperation", "@Oldlaboratoryresultid", "@laboratoryresultid", "@laboratorydetailsid", "@result", "resultconversion"}
        Dim strVal() As Object = {operation, 0, Me.Oldlaboratoryresultid, Me.laboratoryresultid, Me.laboratorydetailsid, Me.result, Me.resultconversion}
        Return GenericDA.ManageQuery(strPar, strVal, "spLaboratoryResultdetails", 2)
    End Function
#End Region

End Class
