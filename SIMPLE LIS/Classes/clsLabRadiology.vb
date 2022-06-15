Public Class clsLabRadiology
#Region "Variables"
    Dim Operation As Integer
    Private mLabRadiologyDefaultId As Integer
    Private mItemCode As String
    Private mNormalResultDesc As String
    Private mItemcodeFilm As String
    Private mQtyFilm As Integer 
#End Region

#Region "Property"
    Public Property LabRadiologyDefaultId() As Integer
        Get
            Return mLabRadiologyDefaultId
        End Get
        Set(ByVal value As Integer)
            mLabRadiologyDefaultId = value
        End Set
    End Property
    Public Property ItemCode() As String
        Get
            Return mItemCode
        End Get
        Set(ByVal value As String)
            mItemCode = value
        End Set
    End Property
    Public Property NormalResultDesc() As String
        Get
            Return mNormalResultDesc
        End Get
        Set(ByVal value As String)
            mNormalResultDesc = value
        End Set
    End Property
    Public Property ItemCodeFilm() As String
        Get
            Return mItemcodeFilm
        End Get
        Set(ByVal value As String)
            mItemcodeFilm = value
        End Set
    End Property
    Public Property QtyFilm() As Integer
        Get
            Return mQtyFilm
        End Get
        Set(ByVal value As Integer)
            mQtyFilm = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Shared Function getLabRadiologyResult(ByVal search As String) As DataTable
        Dim strPar() As String = {"operation", "search"}
        Dim strVal() As String = {0, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabRadiologyDefault", 0)
    End Function
    Public Shared Function getItemCode() As DataTable
        Dim strPar() As String = {"operation", "soperation"}
        Dim strVal() As String = {0, 1}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabRadiologyDefault", 0)
    End Function
    Public Shared Function getItemCodeFilm() As DataTable
        Dim strPar() As String = {"operation", "soperation"}
        Dim strVal() As String = {0, 2}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabRadiologyDefault", 0)
    End Function
    Public Shared Function getLabDefID(ByVal vlabdefid As Integer) As DataTable
        Dim strPar() As String = {"operation", "soperation", "Search"}
        Dim strVal() As String = {0, 3, vlabdefid}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabRadiologyDefault", 0)
    End Function
    Public Shared Function getItemCodeEdit() As DataTable
        Dim strPar() As String = {"operation", "soperation", "Search"}
        Dim strVal() As String = {0, 5}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabRadiologyDefault", 0)
    End Function
    Public Function saveRoom(ByVal isNew As Boolean) As String

        If isNew Then
            operation = 1
        Else
            operation = 2
        End If

        Dim strPar() As String = {"operation", "labradiologydefaultid", "itemcode", "normalresultdesc", "itemcodefilm", "qtyfilm"}
        Dim strVal() As String = {Me.Operation, Me.LabRadiologyDefaultId, Me.ItemCode, Me.NormalResultDesc, Me.ItemCodeFilm, Me.QtyFilm}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabRadiologyDefault", 2)

    End Function

#End Region

End Class
