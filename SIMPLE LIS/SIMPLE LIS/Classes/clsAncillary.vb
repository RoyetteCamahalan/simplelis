Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class clsAncillary

#Region "Variables"
    Dim patreqno, postedbyid As Long
    Dim qtyrender, operation, soperation As Integer
    Dim itemcode As String
    Dim datepost As Date
    Private madmissionchargeno As Long
#End Region

#Region "Properties"
    Public Property PatRequestNo() As Long
        Get
            Return patreqno
        End Get
        Set(ByVal value As Long)
            patreqno = value
        End Set
    End Property
    Public Property PostedBy() As Long
        Get
            Return postedbyid
        End Get
        Set(ByVal value As Long)
            postedbyid = value
        End Set
    End Property

    Public Property QuantityRender() As Integer
        Get
            Return qtyrender
        End Get
        Set(ByVal value As Integer)
            qtyrender = value
        End Set
    End Property
    Public Property PostedDate() As Date
        Get
            Return datepost
        End Get
        Set(ByVal value As Date)
            datepost = value
        End Set
    End Property
    Public Property Code() As String
        Get
            Return itemcode
        End Get
        Set(ByVal value As String)
            itemcode = value
        End Set
    End Property
    Public Property admissionchargeno() As Long
        Get
            Return madmissionchargeno
        End Get
        Set(ByVal value As Long)
            madmissionchargeno = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Shared Function getPatientRequest(ByVal strSearch As String, Optional ByVal sourceofficecode As String = "", Optional ByVal o As Integer = 0, Optional ByVal status As String = "") As DataTable
        Dim strPar() As String = {"operation", "search", "officecode", "soperation", "requisitionstatus"}
        Dim strVal() As String = {0, strSearch, sourceofficecode, o, status}

        Return GenericDA.ManageQuery(strPar, strVal, "spAncillary", 0)
    End Function
    Public Shared Function getPatientIssuedItems(ByVal admissionchargeno As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno"}
        Dim strVal() As String = {0, 1, admissionchargeno}

        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Shared Function getPatientRequestDet(ByVal reqno As Integer, ByVal office As String, Optional ByVal o As Integer = 0) As DataTable
        Dim strPar() As String = {"operation", "patientrequestno", "office", "soperation"}
        Dim strVal() As String = {0, reqno, office, o}

        Return GenericDA.ManageQuery(strPar, strVal, "spAncillaryDetails", 0)
    End Function
    Public Shared Function checkCatType(ByVal itemcode As String) As DataTable
        Dim strPar() As String = {"operation", "itemcode", "soperation"}
        Dim strVal() As String = {0, itemcode, 3}

        Return GenericDA.ManageQuery(strPar, strVal, "spAncillaryDetails", 0)
    End Function
    Public Shared Function getPrice(ByVal itemcode As String) As DataTable
        Dim strPar() As String = {"operation", "itemcode", "soperation"}
        Dim strVal() As String = {0, itemcode, 6}

        Return GenericDA.ManageQuery(strPar, strVal, "spItems", 0)
    End Function
    Public Shared Function getUnitCost(ByVal itemcode As String) As DataTable
        Dim strPar() As String = {"operation", "itemcode", "soperation"}
        Dim strVal() As String = {0, itemcode, 7}

        Return GenericDA.ManageQuery(strPar, strVal, "spItems", 0)
    End Function
    'Used to get the list items in patient requisition filter lab/xray/ultrasound items if phic/non-phic--RSJ
    Public Shared Function getItemListing(ByVal officecode As String, ByVal itemcode As String, Optional ByVal isphic As Integer = 0, Optional ByVal vtrackinventory As Byte = 0) As DataTable
        Dim strPar() As String = {"operation", "officecode", "search", "isphic", "trackinventory"}
        Dim strVal() As String = {3, officecode, itemcode, isphic, vtrackinventory}

        Return GenericDA.ManageQuery(strPar, strVal, "spInventory", 0)
    End Function
    'Used to get the list items in patient requisition --RSJ 8/29
    Public Shared Function getItemListingCA(ByVal officecode As String, ByVal itemcode As String, Optional ByVal vtrackinventory As Byte = 0) As DataTable
        Dim strPar() As String = {"operation", "officecode", "search", "trackinventory"}
        Dim strVal() As String = {5, officecode, itemcode, vtrackinventory}

        Return GenericDA.ManageQuery(strPar, strVal, "spInventory", 0)
    End Function
    'Used For Displaying Specific postcharge details in Ancillary--RSJ
    Public Shared Function getPostItems(ByVal chargeid As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, 2, chargeid}

        Return GenericDA.ManageQuery(strPar, strVal, "spAncillary", 0)
    End Function
    'Used For Displaying Specific Document NO "CH007-00001" in Ancillary--RSJ
    Public Shared Function getDocumentCHno(ByVal chargeid As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, 3, chargeid}

        Return GenericDA.ManageQuery(strPar, strVal, "spAncillary", 0)
    End Function

    'For Displaying SPECIFIC POST LABORATORY REQUEST ITEMS in ancillary--RSJ 6/26
    Public Shared Function getLaboratoryItemsPosted(ByVal patreqno As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "patientrequestno"}
        Dim strVal() As String = {0, 4, patreqno}

        Return GenericDA.ManageQuery(strPar, strVal, "spAncillary", 0)
    End Function
    Public Function UpdateRequest() As Long
       

        Dim strPar() As String = {"operation", "soperation", _
                                  "patientrequestno", _
                                  "search" }
        Dim strVal() As String = {2, 4, _
                                  PatRequestNo, _
                                  admissionchargeno}

        'Call SaveLog("Patient Request", "Post patient request.", PatRequestNo)
        Return GenericDA.ManageQuery(strPar, strVal, "spPatientRequisition", 1)
    End Function
    Public Function Save(ByVal isNew As Boolean) As Long
        If isNew Then
            operation = 1
        Else
            operation = 2
            soperation = 5
        End If

        Dim strPar() As String = {"operation", _
                                  "soperation", _
                                  "patientrequestno", _
                                  "dateposted", _
                                  "postedbyid"}
        Dim strVal() As String = {operation, _
                                  soperation, _
                                  PatRequestNo, _
                                  PostedDate, _
                                  PostedBy}

        'Call SaveLog("Patient Request", "Post patient request.", PatRequestNo)
        Return GenericDA.ManageQuery(strPar, strVal, "spPatientRequisition", 1)
    End Function
    Public Function saveDetails(ByVal isNew As Boolean) As DataTable
        If isNew Then
            operation = 1
        Else
            operation = 2
            soperation = 6
        End If
        Dim strPar() As String = {"operation", _
                                  "soperation", _
                                  "itemcode", _
                                  "patientrequestno", _
                                  "quantityrendered"}

        Dim strVal() As Object = {operation, _
                                  soperation, _
                                  Code, _
                                 PatRequestNo, _
                                 QuantityRender}
        Return GenericDA.ManageQuery(strPar, strVal, "spPatientRequisition", 1)
    End Function
#End Region
End Class
