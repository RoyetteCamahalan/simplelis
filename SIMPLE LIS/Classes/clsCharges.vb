Public Class clsCharges

#Region "Variables"
    Public search As Long
    Public disbursementno As Long
    Public admissionchargeno As Long 'chargeid
    Public refadmissionchargeno As Long
    Public registryno As Long
    Public registrydetailno As Long
    Public patchargetransno As String
    Public pricingscheme As Integer
    Public hospplancode As Integer

    Public totalamount As Double 'totaldue
    Public lessvat As Double
    Public totalsales As Double
    Public subtotaldiscount As Double
    Public grosstotalsales As Double
    Public vatsales As Double
    Public vatexemptsales As Double 
    Public zeroratedsales As Double
    Public vat As Double 

    Public lastname As String
    Public firstname As String
    Public middlename As String
    Public patientname As String
    Public transtype As String
    Public cntranstype As String
    Public officecode As String
    Public transno As Long
    Public preparedbyid As Long
    Public preparedby As String
    Public dateprepared As Date
    Public approvedbyid As Long
    Public approvedby As String
    Public dateapproved As Date
    Public remarks As String


    Public itemcode As String
    Public lotno As String
    Public expirydate As DateTime
    Public unitcost As Double
    Public itemdescription As String
    Public quantity As Long
    Public price As Double
    Public discount As Double
    Public patientno As Long
    Public illnesscase As String
    Public isinpatient As Boolean
    Public void As Integer
    Public toniCharge As Boolean
    Public makeRequest As Boolean
    Public shift As String
    Public markuprate As Long
    Public isadjusted As Byte
    Public discountypeid As Long
    Public istakehomemeds As Boolean

    Public frequencyid As Integer
    Public specialinstructions As String
#End Region

#Region "Properties"
    Private mChargeID As Long
    Private mCharges As String
    Private mAmount As Double
    Private misDefault As Boolean
    Private mCategory As String

    Public AdmissionNo As String
    Public Charge As Double
    Public PHIC As Double
    Public HMO As Double
    Public HospitalDiscount As Double

    Public BillNo As Long
    Public CategoryCode As String

    Public Property ChargeID() As Long
        Get
            Return mChargeID
        End Get
        Set(ByVal value As Long)
            mChargeID = value
        End Set
    End Property
    Public Property Charges() As String
        Get
            Return mCharges
        End Get
        Set(ByVal value As String)
            mCharges = value
        End Set
    End Property
    Public Property Category() As String
        Get
            Return mCategory
        End Get
        Set(ByVal value As String)
            mCategory = value
        End Set
    End Property
    Public Property Amount() As Double
        Get
            Return mAmount
        End Get
        Set(ByVal value As Double)
            mAmount = value
        End Set
    End Property

    
#End Region

#Region "Methods"
    Public Shared Function getChargesForBillingByRegistryNo(ByVal admissionid As Long ) As DataTable
        Dim strPar() As String = {"ChargeCategory", "admissionno"}
        Dim strVal() As String = {"ChargeSummary", admissionid}

        Return GenericDA.ManageQuery(strPar, strVal, "sp_ManageAdmissionCharges", 0)
    End Function
    Public Shared Function getOfficeCode(ByVal strSearch As Integer) As DataTable
        'search = employee id
        Dim strPar() As String = {"@operation", "@soperation", "@search"}
        Dim strVal() As String = {0, 6, strSearch}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Shared Function getInventoryOfficeCode(ByVal soperation As Integer, ByVal strSearch As String) As DataTable
        'search = employee id
        Dim strPar() As String = {"@operation", "@soperation", "@search"}
        Dim strVal() As String = {0, soperation, strSearch}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function

    Public Shared Function getItemCodeFilmName(ByVal search As String) As DataTable
        Dim strPar() As String = {"operation", "sOperation", "@search"}
        Dim strVal() As String = {0, 9, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Shared Function GetCharges() As DataTable
        Dim arrFieldName() As String = {"@ChargeID"}
        Dim arrFieldValue() As Object = {0}
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "sp_ManageCharges", 0)
    End Function
    'New Added 6/19
    Public Shared Function getChargesMain(ByVal transtype As String, ByVal admissionid As Long, ByVal chargeid As String) As DataTable        'search = registryno or admissionchargeno
        Dim strPar() As String = {"operation", "soperation", "transtype", "admissionid", "search"}
        Dim strVal() As String = {0, 3, transtype, admissionid, chargeid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Shared Function getResultCharges(ByVal Soperation As Integer, ByVal strSearch As String, ByVal refChargeID As Long) As DataTable
        'search = registryno or admissionchargeno
        Dim strPar() As String = {"operation", "soperation", "Search", "@refadmissionchargeno"}
        Dim strVal() As String = {0, Soperation, strSearch, refChargeID}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Shared Function getUnpaidCharges(ByVal registryno As Long) As DataTable
        'search = registryno or admissionchargeno
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, 4, registryno}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Shared Function getChargeDetails(ByVal vsoperation As Integer, ByVal vadmissionchargeno As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno", "Search"}
        Dim strVal() As String = {0, vsoperation, vadmissionchargeno, ""}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function

     
    Public Shared Function getTransNo(ByVal officecode As String, _
                                      ByVal transtype As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "officecode", "transtype"}
        Dim strVal() As String = {0, 2, officecode, transtype}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Shared Function voidAdmissionChargeNo(ByVal admissionchargeno As Long)
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno"}
        Dim strVal() As String = {2, 0, admissionchargeno}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Function callInventoryDump(ByVal officecCode As String, ByVal isdate As DateTime)
        Dim strPar() As String = {"@officecode", "@cutoffdate"}
        Dim strVal() As String = {officecCode, isdate}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 2)
    End Function
    'New Added 6/22
    Public Shared Function deleteChargeDetail(ByVal chdetailno As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "chargedetailid"}
        Dim strVal() As String = {3, 1, chdetailno}

        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
        Call SaveLog("Patient Request", "Delete Charge details  " & chdetailno, chdetailno)
    End Function
    'New Added 6/22
    Public Shared Function updateQty(ByVal lotno As String, ByVal qty As Long, ByVal officecode As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "isDeletedLotno", "isDeletedQty", "isDeletedOfficeCode"}
        Dim strVal() As String = {3, 2, lotno, qty, officecode}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 1)
    End Function
    'New Added 6/23
    'For CN List Return MED
    Public Shared Function CreditNotesListReturnMed(ByVal admissionid As Long, ByVal officecode As String, Optional ByVal str As String = "") As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionno", "officecode", "search"}
        Dim strVal() As String = {0, 11, admissionid, officecode, str}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'New Added 6/23
    'For CN List Return CASH
    Public Shared Function CreditNotesListReturnCash(ByVal admissionid As Long, ByVal officecode As String, ByVal discount As Long, Optional ByVal str As String = "") As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionno", "officecode", "discount", "search"}
        Dim strVal() As String = {0, 12, admissionid, officecode, discount, str}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'New Added 6/25
    'update status in patient request details to canceled USE ONLY IN LABORATORY
    Public Shared Function UpdateLaboratoryItemDelete(ByVal chargeid As Long, ByVal itemcode As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno", "itemcode"}
        Dim strVal() As String = {3, 3, chargeid, itemcode}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 1)
    End Function
    'New Added 6/27
    'Select qty use in CN based on the CH,CA transaction
    Public Shared Function CNqty(ByVal chargeid As Long, ByVal lotno As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "refadmissionchargeno", "lotno"}
        Dim strVal() As String = {0, 13, chargeid, lotno}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'New Added 6/28
    'to identify if item is already return
    Public Shared Function ChargeItemCount(ByVal itemcode As String, ByVal lotno As String, ByVal chargeid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "itemcode", "lotno", "refadmissionchargeno"}
        Dim strVal() As String = {0, 14, itemcode, lotno, chargeid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Shared Function QtyPlus(ByVal lotno As String, ByVal qty As Long, ByVal officecode As String, ByVal vitemcode As String, ByVal vexpirydate As Date) As DataTable
        Dim strPar() As String = {"operation", "soperation", "lotno", "quantity", "officecode", "itemcode", "expirydate"}
        Dim strVal() As String = {3, 4, lotno, qty, officecode, vitemcode, vexpirydate}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 1)
    End Function
    Public Shared Function QtyMinus(ByVal lotno As String, ByVal qty As Long, ByVal officecode As String, ByVal vitemcode As String, ByVal vexpirydate As Date) As DataTable
        Dim strPar() As String = {"operation", "soperation", "lotno", "quantity", "officecode", "itemcode", "expirydate"}
        Dim strVal() As String = {3, 5, lotno, qty, officecode, vitemcode, vexpirydate}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 1)
    End Function
    'Added 7/7
    'For philhealth Benefit Displaying MEDS TOTAL
    Public Shared Function PhilhealthBenefitsMEDS(ByVal admissionid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionid"}
        Dim strVal() As String = {0, 16, admissionid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'Added 7/7
    'For philhealth Benefit Displaying LAB TOTAL
    Public Shared Function PhilhealthBenefitsLAB(ByVal admissionid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionid"}
        Dim strVal() As String = {0, 17, admissionid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'Added 7/9
    'Used in frmMainChargelist,Get all the total Medicine consumptions of a patient
    Public Shared Function TotalMeds(ByVal admissionid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionid"}
        Dim strVal() As String = {0, 18, admissionid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'Added 7/9
    'Used in frmMainChargelist,Get all the total Laboratory,XRAY and supplies consumptions of a patient
    Public Shared Function TotalLab(ByVal admissionid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionid"}
        Dim strVal() As String = {0, 19, admissionid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    Public Sub DeleteAllChargeDetailsForXray(ByVal refchargeid As String)
        Dim strPar() As String = {"@operation", "@soperation", "@search"}
        Dim strVal() As String = {2, 5, refchargeid}
        GenericDA.ManageQuery(strPar, strVal, "spCharges", 1)
    End Sub
    'Added 7/10
    'GET PACKAGE
    Public Shared Function GetPackagePHIL(ByVal admissionid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionid"}
        Dim strVal() As String = {0, 20, admissionid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'Added 7/11
    'GET PACKAGE
    Public Shared Function FetchOfficeCharges() As DataTable
        Dim strPar() As String = {"operation", "soperation"}
        Dim strVal() As String = {0, 21}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function

    Public Shared Function isItemOR(ByVal vitemcode As String) As Boolean
        Dim sw As Boolean
        Dim strPar() As String = {"operation", "soperation", "itemcode"}
        Dim strVal() As String = {0, 22, vitemcode}
        Dim dt As DataTable = GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)

        If dt.Rows.Count > 0 Then
            sw = True
        End If

        Return sw
    End Function
    'Added 8/10
    Public Shared Function deleteSpecificItem(ByVal chargeid As Long, ByVal itemcode As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno", "itemcode"}
        Dim strVal() As String = {3, 6, chargeid, itemcode}

        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 1)
        Call SaveLog("Post Charge", "Delete specific item on charge details" & chargeid, itemcode)
    End Function

    Public Shared Function FetchItemsEdit(ByVal chargeid As Long, ByVal itemcode As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno", "itemcode"}
        Dim strVal() As String = {0, 23, chargeid, itemcode}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'Added 8/22
    Public Shared Function FetchItemToVoid(ByVal chargeid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno"}
        Dim strVal() As String = {0, 24, chargeid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'Added 2/19/20114

    Public Shared Function isWard(ByVal vofficecode As String) As Boolean
        Dim sw As Boolean
        Dim strPar() As String = {"operation", "soperation", "officecode"}
        Dim strVal() As String = {0, 25, vofficecode}
        Dim dt As DataTable = GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)

        If dt.Rows(0).Item("officecount") > 0 Then
            sw = True
        End If

        Return sw
    End Function
    'Added 3/18/2014
    '0,26
    Public Shared Function GetSpecificChargeDetails(Optional ByVal vsoperation As Integer = 0, Optional ByVal vchargedetailid As Long = 0) As DataTable
        Dim strPar() As String = {"operation", "soperation", "chargedetailid"}
        Dim strVal() As String = {0, vsoperation, vchargedetailid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function

    'Added 3/26/2014
    Public Shared Function isItemDefaultExistInInventiry(ByVal vofficecode As String, ByVal vitemcode As String, ByVal vlotno As String) As Boolean
        Dim sw As Boolean
        Dim strPar() As String = {"operation", "soperation", "officecode", "itemcode", "lotno"}
        Dim strVal() As String = {0, 27, vofficecode, vitemcode, vlotno}
        Dim dt As DataTable = GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)

        If dt.Rows(0).Item("isitemexist") > 0 Then
            sw = True
        End If

        Return sw
    End Function

    'Added 3/26/2014
    Public Shared Function GetExpiryDate(ByVal vofficecode As String, ByVal vitemcode As String, ByVal vlotno As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "officecode", "itemcode", "lotno"}
        Dim strVal() As String = {0, 28, vofficecode, vitemcode, vlotno}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function

    'Added 4/21/2014
    '0,29
    Public Shared Function ChargesLoadPatient(Optional ByVal vsoperation As Integer = 0, Optional ByVal vadmissionid As String = "", Optional ByVal vtranstype As String = "") As DataTable
        Dim strPar() As String = {"operation", "soperation", "search", "transtype"}
        Dim strVal() As String = {0, vsoperation, vadmissionid, vtranstype}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
    'Added 4/21/2014
    '0,29
    Public Shared Function LoadChargesMain(Optional ByVal vsoperation As Integer = 0, _
                                           Optional ByVal vsearch As String = "", _
                                           Optional ByVal vtranstype As String = "", _
                                           Optional ByVal vstatus As Integer = 0, _
                                           Optional ByVal voffice As String = "") As DataTable
        Dim strPar() As String = {"operation", "soperation", "search", "transtype", "status", "officecode"}
        Dim strVal() As String = {0, vsoperation, vsearch, vtranstype, vstatus, voffice}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
     
    Public Shared Function isAdmin_Billing(Optional ByVal vsoperation As Integer = 0, Optional ByVal vofficecode As String = "") As Boolean
        Dim sw As Boolean
        Dim strPar() As String = {"operation", "soperation", "officecode"}
        Dim strVal() As String = {0, vsoperation, vofficecode}
        Dim dt As DataTable = GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)

        If dt.Rows(0).Item("officecount") > 0 Then
            sw = True
        End If

        Return sw
    End Function
     
    Public Shared Function GetChargeInfo(ByVal chargeid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno"}
        Dim strVal() As String = {0, 35, chargeid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function


    'For CN List Religious Group
    Public Shared Function ReligiousGroup_CN_Listing(ByVal voperation As Integer, ByVal vpatientid As Long, ByVal officecode As String, Optional ByVal str As String = "") As DataTable
        Dim strPar() As String = {"operation", "soperation", "patientno", "officecode", "search"}
        Dim strVal() As String = {0, voperation, vpatientid, officecode, str}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function

    'Added 11/12/2014
    '0,45
    Public Shared Function GetItemInfo(Optional ByVal vsoperation As Integer = 0, Optional ByVal vsearch As String = "") As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, vsoperation, vsearch}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function

    Public Function Save(ByVal isNew As Boolean) As Long

        Dim operation As Integer
        If isNew Then
            operation = 1
        Else
            operation = 2
        End If

        Dim strPar() As String = {"operation", "soperation", "admissionchargeno", _
                                        "patchargetransno", _
                                        "transtype", _
                                        "officecode", _
                                        "transno", _
                                        "preparedbyid", _
                                        "dateprepared", _
                                        "approvedbyid", _
                                        "dateapproved", _
                                        "remarks", _
                                        "isinpatient",
                                        "NewPK" _
                                        , "patientno" _
                                        , "patientname" _
                                        , "admissionid" _
                                        , "discounttypeid" _
                                        , "istakehome" _
                                        , "shift",
                                        "cntranstype",
                                        "grosstotalsales", "lessvat", "totalsales", "discount", "totalamount",
                                        "vatsales", "vatexempt", "vat"}

        Dim strVal() As String = {operation, 1, admissionchargeno, _
                                        patchargetransno, _
                                        transtype, _
                                        officecode, _
                                        transno, _
                                        preparedbyid, _
                                        dateprepared, _
                                        approvedbyid, _
                                        dateapproved, _
                                        remarks, _
                                        isinpatient,
                                        operation, _
                                        patientno, _
                                        patientname, _
                                        registryno, _
                                        discountypeid, _
                                        istakehomemeds, _
                                        shift, cntranstype, _
                                        grosstotalsales, lessvat, totalsales, subtotaldiscount, totalamount,
                                        vatsales, vatexemptsales, vat}

        'returns(admissionchargeno)
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 2)
    End Function
    Public Function SaveUpdate(ByVal isNew As Boolean) As Long

        Dim operation As Integer
        If isNew Then
            operation = 1
        Else
            operation = 2
        End If

        Dim strPar() As String = {"operation", "soperation", "admissionchargeno", _
                                        "patchargetransno", _
                                        "transtype", _
                                        "officecode", _
                                        "transno", _
                                        "preparedbyid", _
                                        "dateprepared", _
                                        "approvedbyid", _
                                        "dateapproved", _
                                        "remarks", _
                                        "isinpatient", _
                                        "discount", _
                                        "NewPK" _
                                        , "patientno" _
                                        , "patientname" _
                                        , "admissionid" _
                                        , "shift"}

        Dim strVal() As String = {operation, 3, admissionchargeno, _
                                        patchargetransno, _
                                        transtype, _
                                        officecode, _
                                        transno, _
                                        preparedbyid, _
                                        dateprepared, _
                                        approvedbyid, _
                                        dateapproved, _
                                        remarks, _
                                        isinpatient, _
                                        discount, _
                                        operation, _
                                        patientno, _
                                        patientname, _
                                        registryno, _
                                        shift}

        'returns(admissionchargeno)
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 2)
    End Function
    Public Function SaveDetails(ByVal isNew As Boolean) As DataTable

        Dim operation As Integer
        If isNew Then
            operation = 1
        Else
            operation = 2
        End If


        Dim strPar() As String = {"operation" _
                                   , "soperation" _
                                   , "admissionchargeno" _
                                   , "refadmissionchargeno" _
                                   , "itemcode" _
                                   , "lotno" _
                                   , "expirydate" _
                                   , "quantity" _
                                   , "unitcost" _
                                   , "price" _
                                   , "phic" _
                                   , "remarks" _
                                   , "hospplancode" _
                                   , "officecode" _
                                   , "preparedbyid" _
                                   , "admissionid" _
                                   , "toniCharge" _
                                   , "makerequest" _
                                   , "TransType" _
                                   , "void" _
                                   , "discount" _
                                   , "markuprate" _
                                   , "istakehome" _
                                   , "isadjusted" _
                                 , "frequencyid" _
                                 , "specialinstructions" _
                                 , "vatexempt"}

        Dim strVal() As String = {operation _
                                    , 2 _
                                    , admissionchargeno _
                                    , refadmissionchargeno _
                                    , itemcode _
                                    , lotno _
                                    , expirydate _
                                    , quantity _
                                    , unitcost _
                                    , price _
                                    , PHIC _
                                    , remarks _
                                    , hospplancode _
                                    , officecode _
                                    , preparedbyid _
                                    , registryno _
                                    , toniCharge _
                                    , makeRequest _
                                    , transtype _
                                    , void _
                                    , discount _
                                    , markuprate _
                                    , istakehomemeds _
                                    , isadjusted _
                                    , frequencyid _
                                    , specialinstructions _
                                    , vat}

        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 2)
    End Function
    Public Function SaveUpdateDetails(ByVal isNew As Boolean) As DataTable

        Dim operation As Integer
        If isNew Then
            operation = 1
        Else
            operation = 2
        End If


        Dim strPar() As String = {"operation" _
                                   , "soperation" _
                                   , "admissionchargeno" _
                                   , "refadmissionchargeno" _
                                   , "itemcode" _
                                   , "lotno" _
                                   , "expirydate" _
                                   , "quantity" _
                                   , "unitcost" _
                                   , "price" _
                                   , "PHIC" _
                                   , "remarks" _
                                   , "hospplancode" _
                                   , "officecode" _
                                   , "preparedbyid" _
                                   , "admissionid" _
                                   , "toniCharge" _
                                   , "makerequest" _
                                   , "chargedetailid" _
                                   , "discount" _
                                   , "markuprate"}

        Dim strVal() As String = {operation _
                                    , 4 _
                                    , admissionchargeno _
                                    , refadmissionchargeno _
                                    , itemcode _
                                    , lotno _
                                    , expirydate _
                                    , quantity _
                                    , unitcost _
                                    , price _
                                    , PHIC _
                                    , remarks _
                                    , hospplancode _
                                    , officecode _
                                    , preparedbyid _
                                    , registryno _
                                    , toniCharge _
                                    , makeRequest _
                                    , search _
                                    , discount _
                                    , markuprate}

        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 1)
    End Function
    Public Shared Sub updateHMODiscount(ByVal myCharges As clsCharges)
        Dim strPar() As String = {"ChargeCategory", _
                                  "disbursementno", _
                                  "itemcode", _
                                  "HMO", _
                                  "Discount"}

        Dim strVal() As String = {"HMODisc", _
                                  myCharges.disbursementno, _
                                  myCharges.itemcode, _
                                  myCharges.HMO, _
                                  myCharges.discount}

        GenericDA.ManageQuery(strPar, strVal, "sp_ManageAdmissionCharges", 1)
    End Sub
    Public Shared Sub UnsetFinalBill(ByVal vregistrydetailno As Long)
        Dim strPar() As String = {"operation", _
                                  "soperation", _
                                  "registrydetailno"}

        Dim strVal() As String = {2, _
                                  2, _
                                  vregistrydetailno}

        GenericDA.ManageQuery(strPar, strVal, "spCharges", 1)

    End Sub

    Public Shared Function UpdateReturnChargeDetails(ByVal vchargeid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno"}
        Dim strVal() As String = {2, 6, vchargeid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 1)
    End Function

    Public Shared Function DeleteCharge(ByVal vchargeid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "admissionchargeno"}
        Dim strVal() As String = {3, 7, vchargeid}
        Return GenericDA.ManageQuery(strPar, strVal, "spCharges", 0)
    End Function
#End Region

End Class
