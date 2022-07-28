Imports System.Configuration

Module modGlobal
    Public gconnectionstring = ""
    Public cypherpassphrase As String = ""
    Public defaultdateformat As String = "MM/dd/yyyy"
    Public defaulttimeformat As String = "hh:mmtt"
    Public defaultdatetimeformat As String = "MM/dd/yyyy hh:mmtt"
    Public userid As Integer
    Public isAdmin As Boolean
    Public ufirstName As String
    Public ulastName As String
    Public umiddleName As String
    Public ufullName As String
    Public sourceOfficeCode As String
    Public sourceOfficeDesc As String
    Public divisionCode As String
    Public defaultSOfficeCode As String
    Public userName As String
    Public password As String
    Public designation As String
    Public employeetypeid As Integer
    Public msgboxTitle As String
    Public alertaudio As String
    Public alerttimeout As Integer
    'Private _conn As New SqlClient.SqlConnection
    'Public ReadOnly Property conn() As SqlClient.SqlConnection
    '    Get
    '        If _conn.ConnectionString = "" Then
    '            _conn.ConnectionString = gconnectionstring
    '        End If
    '        If _conn.State <> ConnectionState.Open Then
    '            _conn.Open()
    '        End If
    '        Return _conn
    '    End Get
    'End Property

    Public ClinicID As Integer = 4
    Public gFilePrinterName As String = ConfigurationManager.AppSettings("FilePrinterName")
    Public gDocumentLocationEMR As String = ConfigurationManager.AppSettings("DocumentLocationEMR")

    Public themecolor3 As Color = Color.MediumSeaGreen

    Public delete_icon As Image = My.Resources.delete_16x16
    Public new_icon _
    , edit_icon _
    , cancel_icon _
    , print_icon _
    , save_icon _
    , close_icon _
    , search_icon _
    , select_record_icon _
    , create_new_record_icon _
    , inspect_icon _
    , checked_icon _
    , accept_icon _
    , realease_icon _
    , receive_icon _
    , issue_icon _
    , post_icon _
      , philhealth_icon _
      , camera_icon _
      , pencil_icon _
      , folder_picture_icon _
      , load_item_icon _
      , remove_icon _
      , male_icon _
      , female_icon _
      , extract_icon _
      , continue_icon _
      , view_icon As Image
    Public bannerColor As Color


    Public Enum appSettings
        DatabaseName = 0
        DocumentLocationEMR = 12
    End Enum
    Public canAdd As Boolean
    Public canEdit As Boolean
    Public canView As Boolean
    Public canDelete As Boolean
    Public canApprove As Boolean
    Public canInspect As Boolean
    Public canCheck As Boolean
    Public canReceive As Boolean
    Public canIssue As Boolean
    Public canVerify As Boolean
    Enum AccountModule
        modNone = 0
        modPatients = 9
        modDoctors = 10
        modEmployees = 12
        modItemCategory = 13
        modOffices = 14
        modOutpatient = 18
        modEmergency = 17
        modInpatients = 19
        modItems = 22
        modExaminationUpshots = 24
        modSuppliers = 25
        modPHICProcedures = 28
        modICD10 = 29
        modRegions = 48
        modProvinces = 49
        modMunicipality = 50
        modNationality = 51
        modReligion = 52
        modOccupation = 53
        modUsers = 54
        modHCI = 60
        modDiscountTypes = 61
        modReasonForReferral = 66
        modUnitOfMeasurement = 70
        modItemTaxType = 71
        modPackageCharge = 79
        modAppointments = 93
        'modAppointment = 2
        'modCashiering = 8
        'modClinics = 10
        'modTransfer
        'modRequestIssuance
        'modAdjustment
        'modSupplierReturns = 5
        'modCashReceipts = 6
        'modPurchaseRequest = 7
        'modPurchaseOrder = 8
        'modDivisions = 11
        'modRooms = 15
        'modRoomTypes = 16
        'modAncillary = 20
        'modNursingServices = 21
        'modPatientRefunds = 23
        'modOfficeItems = 26
        'modPHICMembers = 30
        'modTransmittals = 31
        'modExtraction = 32
        'modBanks = 33
        'modRadiologyTemplates = 34
        'modPHICPackage = 35
        'modEmployeeAccountReceivable = 39
        'modPatientAccountReceivable = 40
        'modHMO = 41
        'modReligiousGroups = 42
        'modHMOAccountReceivable = 43
        'modReligiousAcctReceivable = 44
        'modSupplierPayments = 45
        'modCF2 = 46
        'modPHICCashReceipts = 47
        'modManageUsers = 54
        'modEmployeeCreditPayrollDeduction = 55
        'modEmployeeSalaryDeductionBracket = 56
        'modHospitalInformation = 57
        'modReloadInventory = 58
        'modOutGoingPayment = 59
        'modDiscountTypes = 61
        'modIndicationForCS = 62
        'modItemTransferForReasons = 63
        'modUserLogs = 64
        'modUnsetBill = 65
        'modHMOClaims = 67
        'modBirthCertificate = 68
        'modDeathCertificate = 69
        'modPatientAROptions = 72
        'modReligiousGroupsBilling = 73
        'modEmployeeARCutOffDate = 74
        'modPatientARCutOffDate = 75
        'modHMOARCutOffDate = 76
        'modReligiousARCutOffDate = 77
        'modSupplierAPCutOffDate = 78
        'modImportDataPatientAccountRecivables = 80
        'modORControlNo = 81
        'modOutGoingPaymentPayee = 82
        'modCheckEncashment = 83
        'modPettyCashVoucher = 84
        'modCashierCollection = 85
        'modDietaryService = 86
        'modCheckVoucherEntry = 87
        'modOtherCashierCollection = 88
        'modCheckDeposit = 89
    End Enum
    Enum AccountSubModule
        smodNone = 0
        smodInpatientDetails = 1
        smodPatientProfile = 2
        smodCashReceipts = 3
        smodCreditNotes = 4
        smodDischarge = 5
        smodPostCharges = 6
        smodRequisition = 7
        smodRenderingRequisition = 8
        smodBilling = 9
        smodDirectRender = 10
        smodRelocation = 11
        smodViewMedicines = 12
        'smodCashRefunds = 12

        smodPrintCharges = 13

        smodCashTransaction = 14
        smodMGH = 15
        smodManageExamination = 16
        smodReleaseExamination = 17
        smodReturnMedicine = 18
        smodCashReceiptList = 19
        smodDiagnosis = 20
        smodPhilHealthRequirements = 21
        smodAdmissionHistory = 22
        smodReturnCashTransaction = 23
        smodSchemaExamination = 24
        smodEmployeeCharges = 25
        smodUntagasMGH = 26
        smodAdmitPatient = 27
        smodEmployeeCashReceipts = 47

        '--items
        smodItemStockCard = 28
        smodReceivingHistory = 29
        smodTransferHistory = 30  'transfer
        smodIssuanceHistory = 52  'issuance
        smodExtractionHistory = 53 'extraction
        smodChargesHistory = 41
        smodEmpChargesHistory = 42
        smodAdjustmentHistory = 43
        smodReturnToSupplierHistory = 44
        smodExpenseIssuanceHistory = 45

        '--items
        '--REPORTS
        'smodItemStockCard = 28
        'smodReceivingHistory = 29
        'smodTransferHistory = 30

        smodCashierReports = 31
        smodDOHReports = 32
        smodFinanceReports = 33
        smodInventoryReports = 34
        smodLaboratoryReports = 35
        smodMedicalRecordReports = 36
        smodPharmacyRecordReports = 37
        smodPhilHealthRecordReports = 38
        smodRadUltraReports = 39
        smodFormReports = 40
        smodBillingReports = 46
        smodPaymentSuppliers = 48
        smodPaymentHistorySuppliers = 49

        smodBirthCertificateEntryForm = 51
        smodDeathCertificateEntryForm = 50

        smodReligiousGroupsCharges = 52
        smodReligiousGroupsReturn = 53
        smodEmployeeChargeInvoice = 54
        smodDiagnosticTestMapping = 62
    End Enum
    Dim dtModule As New DataTable
    Dim dtsModule As New DataTable
    Sub LoadUserModules()
        Dim dpk(1) As DataColumn
        dtModule = clsUsers.GetUser(2, "", "", modGlobal.userid)
        dpk(0) = dtModule.Columns("modcode")
        dtModule.PrimaryKey = dpk
    End Sub
    Sub LoadUserSubModules()
        Dim dpk(1) As DataColumn
        dtsModule = clsUsers.GetUser(3, "", "", modGlobal.userid)
        dpk(0) = dtsModule.Columns("submodcode")
        dtsModule.PrimaryKey = dpk
    End Sub
    Sub GetUserModules(ByVal accMod As Integer)
        'Dim idx As Integer
        'Dim dtModule As New DataTable

        'dtModule = clsAuthentication.getUsersModules(authId)

        If dtModule.Rows.Count > 0 Then
            Dim row As DataRow = dtModule.Rows.Find(accMod)
            If Not (row Is Nothing) Then
                canAdd = row("canadd")
                canEdit = row("canedit")
                canDelete = row("candelete")
                canView = row("canview")
                canApprove = row("canapprove")
                canInspect = row("caninspect")
                canCheck = row("cancheck")
                canReceive = row("canreceive")
                canIssue = row("canissue")
                canVerify = row("canverify")
            Else
                canAdd = False
                canEdit = False
                canDelete = False
                canView = False
                canApprove = False
                canInspect = False
                canCheck = False
                canReceive = False
                canIssue = False
                canVerify = False
            End If
        End If
    End Sub
    Function GetUserSubModulesVisibility(ByVal accSubMod As Integer) As Boolean
        Dim sw As Boolean
        Try
            If dtsModule.Rows.Count > 0 Then
                Dim Row As DataRow = dtsModule.Rows.Find(accSubMod)
                If Row Is Nothing Then
                    sw = False
                End If
                If Row("canaccess") = False Then
                    sw = False
                Else
                    sw = True
                End If
            End If
        Catch ex As Exception

        End Try

        Return sw
    End Function
    Sub setUserInfo()
        Dim dt As DataTable = clsUsers.GetUser(1, "", "", userid)
        sourceOfficeCode = dt.Rows(0).Item("officecode")
        ulastName = dt.Rows(0).Item("lastname")
        ufirstName = dt.Rows(0).Item("firstname")
        ufullName = ufirstName & " " & ulastName
        employeetypeid = dt.Rows(0).Item("employeetypeid")
        dt = clsOffices.getOfficeDefaults(0, sourceOfficeCode)
        If dt.Rows.Count > 0 Then
            alertaudio = dt.Rows(0).Item("alertaudio")
            alerttimeout = dt.Rows(0).Item("alerttimeout")
        End If
        Dim dtHospInfo As DataTable = clsHospitalInfo.getInfo(0, "")
        'Select Case IsDBNull(dtHospInfo.Rows(0)("new_icon"))
        '    Case True
        '        new_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("new_icon")
        '        If tempphoto.Length = 0 Then
        '            new_icon = Nothing
        '        Else
        '            new_icon = Utility.convertImage(dtHospInfo.Rows(0)("new_icon")) 'image here
        '        End If
        'End Select
        'hospitalname = dtHospInfo.Rows(0).Item("HospName")
        'hospitalcode = dtHospInfo.Rows(0).Item("eclaimshospitalcode")
        'hospitaladdress = dtHospInfo.Rows(0).Item("Barangay") & ", " & dtHospInfo.Rows(0).Item("MunCity") & ", " & dtHospInfo.Rows(0).Item("Province")

        Select Case IsDBNull(dtHospInfo.Rows(0)("edit_icon"))
            Case True
                edit_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("edit_icon")
                If tempphoto.Length = 0 Then
                    edit_icon = Nothing
                Else
                    edit_icon = Utility.convertImage(dtHospInfo.Rows(0)("edit_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("cancel_icon"))
            Case True
                cancel_icon = Nothing
            Case False
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("cancel_icon")
                If tempphoto.Length = 0 Then
                    cancel_icon = Nothing
                Else
                    cancel_icon = Utility.convertImage(dtHospInfo.Rows(0)("cancel_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("print_icon"))
            Case True
                print_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("print_icon")
                If tempphoto.Length = 0 Then
                    print_icon = Nothing
                Else
                    print_icon = Utility.convertImage(dtHospInfo.Rows(0)("print_icon")) 'image here
                End If
        End Select


        Select Case IsDBNull(dtHospInfo.Rows(0)("save_icon"))
            Case True
                save_icon = Nothing
            Case False
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("save_icon")
                If tempphoto.Length = 0 Then
                    save_icon = Nothing
                Else
                    save_icon = Utility.convertImage(dtHospInfo.Rows(0)("save_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("close_icon"))
            Case True
                close_icon = Nothing
            Case False
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("close_icon")
                If tempphoto.Length = 0 Then
                    close_icon = Nothing
                Else
                    close_icon = Utility.convertImage(dtHospInfo.Rows(0)("close_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("search_icon"))
            Case True
                search_icon = Nothing
            Case False
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("search_icon")
                If tempphoto.Length = 0 Then
                    search_icon = Nothing
                Else
                    search_icon = Utility.convertImage(dtHospInfo.Rows(0)("search_icon")) 'image here
                End If
        End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("select_record_icon"))
        '    Case True
        '        select_record_icon = Nothing
        '    Case False
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("select_record_icon")
        '        If tempphoto.Length = 0 Then
        '            select_record_icon = Nothing
        '        Else
        '            select_record_icon = Utility.convertImage(dtHospInfo.Rows(0)("select_record_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("create_new_record_icon"))
        '    Case True
        '        create_new_record_icon = Nothing
        '    Case False
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("create_new_record_icon")
        '        If tempphoto.Length = 0 Then
        '            create_new_record_icon = Nothing
        '        Else
        '            create_new_record_icon = Utility.convertImage(dtHospInfo.Rows(0)("create_new_record_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("inspect_icon"))
        '    Case True
        '        inspect_icon = Nothing
        '    Case False
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("inspect_icon")
        '        If tempphoto.Length = 0 Then
        '            inspect_icon = Nothing
        '        Else
        '            inspect_icon = Utility.convertImage(dtHospInfo.Rows(0)("inspect_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("checked_icon"))
        '    Case True
        '        checked_icon = Nothing
        '    Case False
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("checked_icon")
        '        If tempphoto.Length = 0 Then
        '            checked_icon = Nothing
        '        Else
        '            checked_icon = Utility.convertImage(dtHospInfo.Rows(0)("checked_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("accept_icon"))
        '    Case True
        '        accept_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("accept_icon")
        '        If tempphoto.Length = 0 Then
        '            accept_icon = Nothing
        '        Else
        '            accept_icon = Utility.convertImage(dtHospInfo.Rows(0)("accept_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("realease_icon"))
        '    Case True
        '        realease_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("realease_icon")
        '        If tempphoto.Length = 0 Then
        '            realease_icon = Nothing
        '        Else
        '            realease_icon = Utility.convertImage(dtHospInfo.Rows(0)("realease_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("receive_icon"))
        '    Case True
        '        receive_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("receive_icon")
        '        If tempphoto.Length = 0 Then
        '            receive_icon = Nothing
        '        Else
        '            receive_icon = Utility.convertImage(dtHospInfo.Rows(0)("receive_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("issue_icon"))
        '    Case True
        '        issue_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("issue_icon")
        '        If tempphoto.Length = 0 Then
        '            issue_icon = Nothing
        '        Else
        '            issue_icon = Utility.convertImage(dtHospInfo.Rows(0)("issue_icon")) 'image here
        '        End If
        'End Select


        'Select Case IsDBNull(dtHospInfo.Rows(0)("post_icon"))
        '    Case True
        '        post_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("post_icon")
        '        If tempphoto.Length = 0 Then
        '            post_icon = Nothing
        '        Else
        '            post_icon = Utility.convertImage(dtHospInfo.Rows(0)("post_icon")) 'image here
        '        End If
        'End Select


        ''add

        'Select Case IsDBNull(dtHospInfo.Rows(0)("philhealth_icon"))
        '    Case True
        '        philhealth_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("philhealth_icon")
        '        If tempphoto.Length = 0 Then
        '            philhealth_icon = Nothing
        '        Else
        '            philhealth_icon = Utility.convertImage(dtHospInfo.Rows(0)("philhealth_icon")) 'image here
        '        End If
        'End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("camera_icon"))
            Case True
                camera_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("camera_icon")
                If tempphoto.Length = 0 Then
                    camera_icon = Nothing
                Else
                    camera_icon = Utility.convertImage(dtHospInfo.Rows(0)("camera_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("pencil_icon"))
            Case True
                pencil_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("pencil_icon")
                If tempphoto.Length = 0 Then
                    pencil_icon = Nothing
                Else
                    pencil_icon = Utility.convertImage(dtHospInfo.Rows(0)("pencil_icon")) 'image here
                End If
        End Select
        Select Case IsDBNull(dtHospInfo.Rows(0)("folder_picture_icon"))
            Case True
                folder_picture_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("folder_picture_icon")
                If tempphoto.Length = 0 Then
                    folder_picture_icon = Nothing
                Else
                    folder_picture_icon = Utility.convertImage(dtHospInfo.Rows(0)("folder_picture_icon")) 'image here
                End If
        End Select
        Select Case IsDBNull(dtHospInfo.Rows(0)("load_item_icon"))
            Case True
                load_item_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("load_item_icon")
                If tempphoto.Length = 0 Then
                    load_item_icon = Nothing
                Else
                    load_item_icon = Utility.convertImage(dtHospInfo.Rows(0)("load_item_icon")) 'image here
                End If
        End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("remove_icon"))
        '    Case True
        '        remove_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("remove_icon")
        '        If tempphoto.Length = 0 Then
        '            remove_icon = Nothing
        '        Else
        '            remove_icon = Utility.convertImage(dtHospInfo.Rows(0)("remove_icon")) 'image here
        '        End If
        'End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("male_icon"))
        '    Case True
        '        male_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("male_icon")
        '        If tempphoto.Length = 0 Then
        '            male_icon = Nothing
        '        Else
        '            male_icon = Utility.convertImage(dtHospInfo.Rows(0)("male_icon")) 'image here
        '        End If
        'End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("female_icon"))
        '    Case True
        '        female_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("female_icon")
        '        If tempphoto.Length = 0 Then
        '            female_icon = Nothing
        '        Else
        '            female_icon = Utility.convertImage(dtHospInfo.Rows(0)("female_icon")) 'image here
        '        End If
        'End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("extract_icon"))
        '    Case True
        '        extract_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("extract_icon")
        '        If tempphoto.Length = 0 Then
        '            extract_icon = Nothing
        '        Else
        '            extract_icon = Utility.convertImage(dtHospInfo.Rows(0)("extract_icon")) 'image here
        '        End If
        'End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("continue_icon"))
        '    Case True
        '        continue_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("continue_icon")
        '        If tempphoto.Length = 0 Then
        '            continue_icon = Nothing
        '        Else
        '            continue_icon = Utility.convertImage(dtHospInfo.Rows(0)("continue_icon")) 'image here
        '        End If
        'End Select
        Select Case IsDBNull(dtHospInfo.Rows(0)("view_icon"))
            Case True
                view_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("view_icon")
                If tempphoto.Length = 0 Then
                    view_icon = Nothing
                Else
                    view_icon = Utility.convertImage(dtHospInfo.Rows(0)("view_icon")) 'image here
                End If
        End Select

    End Sub
    Sub SaveLog(ByVal userModule As String, ByVal userAction As String, Optional ByVal referenceNo As String = "0")
        Dim logs As New clsUserLogs
        If referenceNo = "0" Then
            referenceNo = modGlobal.userid
        End If

        logs.username = ufullName & "(" & userName & ")"
        logs.referenceno = referenceNo
        logs.usermodule = userModule
        logs.action = userAction
        logs.logdate = Utility.GetServerDate()
        logs.saveLogs()
    End Sub
End Module
