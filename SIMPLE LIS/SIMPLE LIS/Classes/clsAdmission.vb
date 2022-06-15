Public Class clsAdmission

#Region "Properties"
    Private mPatientID As Long
    Private mAdmissionNo As String
    Private mDateofAdmin As DateTime
    Private mDateDischarge As DateTime
    Private mFinalDiagnosis As String
    Private mAdmittingDiagnosis As String
    Private mReasonForAdmission As String
    Private mPhilHealthNo As String
    Private mPhilHealthMember As String
    Private mAdmissionID As Long
    Private mHC As String
    Private mPC As String
    Private mInformant As String
    Private mInformantRelationship As String
    Private mNotify As String
    Private mNotifyRelationship As String
    Private mNotifyAddress As String
    Private mNotifyTelNo As String
    Private mKindOfOperation As String
    Private mEmployeeID As Integer
    Private mCompanyID As Integer
    Private mAdmissionType As String
    Public casetype As Char
    Public hospitalplan As Integer
    Public hospitalno As String
    Public patientname As String
    Public physicianname As String
    Public gender As String 
    Public birthdate As Date
    Public ptno As String

    Public Property PatientID() As Long
        Get
            Return mPatientID
        End Get
        Set(ByVal value As Long)
            mPatientID = value
        End Set
    End Property

    Public Property AdmissionID() As String
        Get
            Return mAdmissionID
        End Get
        Set(ByVal value As String)
            mAdmissionID = value
        End Set
    End Property

    Public Property DateofAdmin() As DateTime
        Get
            Return mDateofAdmin
        End Get
        Set(ByVal value As DateTime)
            mDateofAdmin = value
        End Set
    End Property
    Public Property DateDischarge() As DateTime
        Get
            Return mDateDischarge
        End Get
        Set(ByVal value As DateTime)
            mDateDischarge = value
        End Set
    End Property

    Public Property FinalDiagnosis() As String
        Get
            Return mFinalDiagnosis
        End Get
        Set(ByVal value As String)
            mFinalDiagnosis = value
        End Set
    End Property
    Public Property AdmittingDiagnosis() As String
        Get
            Return mAdmittingDiagnosis
        End Get
        Set(ByVal value As String)
            mAdmittingDiagnosis = value
        End Set
    End Property
    Public Property ReasonForAdmission() As String
        Get
            Return mReasonForAdmission
        End Get
        Set(ByVal value As String)
            mReasonForAdmission = value
        End Set
    End Property
    Public Property PhilHealthNo() As String
        Get
            Return mPhilHealthNo
        End Get
        Set(ByVal value As String)
            mPhilHealthNo = value
        End Set
    End Property
    Public Property PhilHealthMember() As String
        Get
            Return mPhilHealthMember
        End Get
        Set(ByVal value As String)
            mPhilHealthMember = value
        End Set
    End Property
    Public Property AdmissionNo() As Integer
        Get
            Return mAdmissionNo
        End Get
        Set(ByVal value As Integer)
            mAdmissionNo = value
        End Set
    End Property
    Public Property HC() As String
        Get
            Return mHC
        End Get
        Set(ByVal value As String)
            mHC = value
        End Set
    End Property
    Public Property Pc() As String
        Get
            Return mPC
        End Get
        Set(ByVal value As String)
            mPC = value
        End Set
    End Property
    Public Property Informant() As String
        Get
            Return mInformant
        End Get
        Set(ByVal value As String)
            mInformant = value
        End Set
    End Property
    Public Property InformantRelationship() As String
        Get
            Return mInformantRelationship
        End Get
        Set(ByVal value As String)
            mInformantRelationship = value
        End Set
    End Property
    Public Property Notify() As String
        Get
            Return mNotify
        End Get
        Set(ByVal value As String)
            mNotify = value
        End Set
    End Property
    Public Property NotifyRelationShip() As String
        Get
            Return mNotifyRelationship
        End Get
        Set(ByVal value As String)
            mNotifyRelationship = value
        End Set
    End Property
    Public Property NotifyAddress() As String
        Get
            Return mNotifyAddress
        End Get
        Set(ByVal value As String)
            mNotifyAddress = value
        End Set
    End Property
    Public Property NotifyTelNo() As String
        Get
            Return mNotifyTelNo
        End Get
        Set(ByVal value As String)
            mNotifyTelNo = value
        End Set
    End Property

    Public Property KindOfOperation() As String
        Get
            Return mKindOfOperation
        End Get
        Set(ByVal value As String)
            mKindOfOperation = value
        End Set
    End Property

    Public Property AdmissionType() As String
        Get
            Return mAdmissionType
        End Get
        Set(ByVal value As String)
            mAdmissionType = value
        End Set
    End Property
    Public Property EmployeeID() As String
        Get
            Return mEmployeeID
        End Get
        Set(ByVal value As String)
            mEmployeeID = value
        End Set
    End Property

    Public Property CompanyID() As Integer
        Get
            Return mCompanyID
        End Get
        Set(ByVal value As Integer)
            mCompanyID = value
        End Set
    End Property
#End Region

#Region "Data Access"
    Public Shared Function GetAdmissionRecord(ByVal sValue As String, ByVal sAdmissiontype As String) As DataTable
        Select Case sAdmissiontype
            Case "Inpatients", "NursingServices"
                sAdmissiontype = "IPD"
            Case "Outpatients"
                sAdmissiontype = "OPD"
            Case "Emergency"
                sAdmissiontype = "ER"
        End Select

        'test
        Dim arrFieldName() As String = {"operation", "soperation", "searchvalue", "admissiontype"}
        Dim arrFieldValue() As Object = {0, 0, sValue, sAdmissiontype} 'FETCHDETAILS
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spAdmission", 0)
    End Function
    Public Shared Function GetHospitalCharges(ByVal vadmissionid As Long, _
                                           ByVal vhospplan As Byte, _
                                           ByVal vcasetype As Char, _
                                           ByVal vpackagecaseno As String, _
                                           ByVal vpackagecaseno2 As String, _
                                           ByVal vrecalculate As Boolean) As DataTable

        'hospplan 1(NONPHIC) 2(PHIC)
        Dim soperation As Integer = 15
        If vrecalculate Then
            soperation = 0
        End If

        Dim arrFieldName() As String = {"operation",
                                        "soperation",
                                        "admissionid",
                                        "hospitalplan",
                                        "casetype",
                                        "packagecaseno",
                                       "packagecaseno2"}

        Dim arrFieldValue() As Object = {0,
                                         soperation,
                                         vadmissionid,
                                         vhospplan,
                                         vcasetype,
                                         vpackagecaseno,
                                         vpackagecaseno2}

        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spBilling", 0)
    End Function
    Public Shared Function GetAdmissionRecord(ByVal vadmissionid As String) As DataTable

        Dim arrFieldName() As String = {"operation", "soperation", "admissionid"}
        Dim arrFieldValue() As Object = {0, 4, vadmissionid}
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spBilling", 0)
    End Function

    Public Shared Function GetAdmissionRecordMaster(ByVal sValue As String) As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "@SearchValue", "@FromDate", "@ToDate"}
        Dim arrFieldValue() As Object = {0, 4, sValue, Now, Now} 'FetchAdmission
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spAdmission", "Fetch")
    End Function
    Public Shared Function GetAdmissionDoctorRecord(ByVal sValue As String) As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "@SearchValue", "@FromDate", "@ToDate"}
        Dim arrFieldValue() As Object = {0, 2, sValue, Now, Now} 'FetchDoctors
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spAdmission", "Fetch")
    End Function
    Public Shared Function GetAdmissionCharges(ByVal ChargeCategory As String, ByVal isPHIC As Integer, _
                                      ByVal myAdmissionNo As Long) As DataTable
        Dim arrFieldName() As String = {"@ChargeCategory", "@isPHIC", "@AdmissionNo"}
        Dim arrFieldValue() As Object = {ChargeCategory, isPHIC, myAdmissionNo}
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spAdmissionCharges", "Fetch")
    End Function
    Public Shared Function GetAdmissionRoomRecord(ByVal sValue As String) As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "@SearchValue", "@FromDate", "@ToDate"}
        Dim arrFieldValue() As Object = {0, 3, sValue, Now, Now} 'FetchRooms
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spAdmission", "Fetch")
    End Function
    Public Shared Function GetAllRecords(ByVal sValue As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "@SearchValue", "@FromDate", "@ToDate"}
        Dim arrFieldValue() As Object = {0, 0, sValue, FromDate, ToDate} 'Fetch
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spAdmission", "Fetch")
    End Function
    Public Shared Function GetAdmissionRecord(ByVal sValue As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim arrFieldName() As String = {"operation", "soperation", "@SearchValue", "@FromDate", "@ToDate"}
        Dim arrFieldValue() As Object = {0, 4, sValue, FromDate, ToDate} 'FetchAdmission
        Return GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spAdmission", "Fetch")
    End Function
    Public Sub UpdateAdmission()
        Dim arrFieldName() As String = {"operation", "soperation", "@SearchValue", "@casetype", "@hospitalplan"}
        Dim arrFieldValue() As Object = {2, 0, AdmissionID, casetype, hospitalplan} 'UpdateAdmission
        GenericDA.ManageQuery(arrFieldName, arrFieldValue, "spAdmission", "Update")

    End Sub
    Public Function SaveAdmission(ByVal isNew As Boolean) As String

        Dim arFields As String() = New String() {"@Action", "@AdmissionNo", "@PatientID", "@DateAdmitted", _
                        "@KindOfOperation", "@AdmittingDiagnosis", "@FinalDiagnosis", _
                        "AdmissionType", "EmployeeID", _
                        "Notify", "NotifyRelationship", "NotifyAddress", "NotifyTelNo", _
                        "PhilHealthNo", "PhilHealthMember", _
                        "Informant", "InformantRelationship", "NewPK", "hospitalplan", "companyid"}
        Dim Operation As String = "Update"
        If isNew Then
            Operation = "New"
        End If
        Dim arVal As Object() = New Object() {Operation, Me.AdmissionNo, Me.PatientID, Me.DateofAdmin, _
                                Me.KindOfOperation, Me.AdmittingDiagnosis, Me.FinalDiagnosis, _
                                 Me.AdmissionType, Me.EmployeeID, _
                                 Me.Notify, Me.NotifyRelationShip, Me.NotifyAddress, _
                                 Me.NotifyTelNo, Me.PhilHealthNo, Me.PhilHealthMember, _
                                 Me.Informant, Me.InformantRelationship, 0, hospitalplan, CompanyID}

        Return GenericDA.ManageQuery(arFields, arVal, "sp_Admission_Save", "Save")
    End Function
    Public Sub SaveAdmissionDoctor(ByVal myDoctor As clsDoctor)

        Dim arFields As String() = New String() {"@Operation", "AdmissionID", "DoctorID", _
                                                "Charge", "PHIC", "HMO", "HospitalDiscount"}

        Dim arVal As Object() = New Object() {"Save", Me.AdmissionNo, myDoctor.DoctorID, _
                                                myDoctor.Charge, _
                                                myDoctor.PHIC, _
                                                myDoctor.HMO, myDoctor.HospitalDiscount}

        GenericDA.ManageQuery(arFields, arVal, "sp_AdmissionDoctor_Save", "Save")
    End Sub
    'Public Sub SaveAdmissionRoom(ByVal myRoom As clsRooms)

    '    'Dim arFields As String() = New String() {"@Operation", "AdmissionID", "RoomID", "RoomRate", "NoOfDays", _
    '    '                                        "Charge", "PHIC", "HMO", "Discount"}

    '    'Dim arVal As Object() = New Object() {"Save", Me.AdmissionNo, myRoom.RoomID, myRoom.RoomRate, myRoom.NoOfDays, _
    '    '                                        myRoom.Charge, _
    '    '                                        myRoom.PHIC, _
    '    '                                        myRoom.HMO, myRoom.HospitalDiscount}

    '    'GenericDA.ManageQuery(arFields, arVal, "sp_AdmissionRoom_Save", "Save")
    'End Sub
    Public Sub SaveMghClearance(ByVal strAdmissionNo As String)

        Dim arFields As String() = New String() {"operation", "soperation", "admissionid"}

        Dim arVal As Object() = New Object() {1, 0, strAdmissionNo}

        GenericDA.ManageQuery(arFields, arVal, "spMedicalRecordReport", 1)
    End Sub
   
#End Region

End Class

