
Public Class clsDashboard

#Region "Variables"

    Public soperation As Integer

    Public patientrequestno As Long
    Public registrydetailno As Long
    Public sourceoffice As String
    Public documentno As String
    Public reqtransno As Long
    Public purpose As String
    Public requestedbyid As Long
    Public daterequested As Date
    Public approvedbyid As Long
    Public dateapproved As Date
    Public daterender As Date
    Public stat As Integer

    Public patientrequestdetailno As Long
    Public itemcode As String
    Public quantityrequested As Integer
    Public quantityrendered As Integer
    Public remarks As String
    Public destinationoffice As String


    Dim operation As Integer

    Dim moldprescriptionid As Long
    Dim madmissionid As Long '--- also use in prescription
    Dim mdescription As String
    Dim mdate As Date 
    Dim misprocedure As Boolean
    Dim misprimarydiagnosis As Boolean
    Dim mlaterality As String
    Dim mphysician As Long
    Public createdbyid As Long

    Dim mname As String
    Dim mistemplate As Integer

    Dim mOldadmissiondiagnosisid As Long
    Dim micd10code As String
    Dim mdiagnosis As String

    Dim mhistoryofpresentillness As String
    Dim mphysicalexamination As String
    Dim mchiefcomplaints As String
    Dim massessment As String
    Dim mplan As String


    Dim moldpresecriptiondetailsid As Long
    Dim mprescriptionid As Long
    Dim mdrugcode As String
    Dim mfrequency As Integer
    Dim mquantity As Integer
    Dim mdosage As String
    Dim mperiod As Integer
    Dim mper As String

    Dim moldsoapid As Long
    Dim mtype As String

    Dim mrefpatientrequestno As Long

    Dim msystolic As Integer
    Dim mdiastolic As Integer
    Dim mbreathing As String
    Dim mpulse As String
    Dim mtemperature As String
    Dim mheight As String
    Dim mweight As String
    Dim missync As Boolean
    Dim misdeleted As Boolean
    Dim mserverid As Long

    Dim misfollowup As Boolean
    Dim mfollowup As Date

    Public Property systolic() As Integer
        Get
            Return msystolic
        End Get
        Set(ByVal value As Integer)
            msystolic = value
        End Set
    End Property
    Public Property diastolic() As Integer
        Get
            Return mdiastolic
        End Get
        Set(ByVal value As Integer)
            mdiastolic = value
        End Set
    End Property
    Public Property breathing() As String
        Get
            Return mbreathing
        End Get
        Set(ByVal value As String)
            mbreathing = value
        End Set
    End Property
    Public Property pulse() As String
        Get
            Return mpulse
        End Get
        Set(ByVal value As String)
            mpulse = value
        End Set
    End Property
    Public Property temperature() As String
        Get
            Return mtemperature
        End Get
        Set(ByVal value As String)
            mtemperature = value
        End Set
    End Property
    Public Property height() As String
        Get
            Return mheight
        End Get
        Set(ByVal value As String)
            mheight = value
        End Set
    End Property
    Public Property weight() As String
        Get
            Return mweight
        End Get
        Set(ByVal value As String)
            mweight = value
        End Set
    End Property

    Public Property refpatientrequestno() As Long
        Get
            Return mrefpatientrequestno
        End Get
        Set(ByVal value As Long)
            mrefpatientrequestno = value
        End Set
    End Property
    Public Property oldprescriptionid() As Long
        Get
            Return moldprescriptionid
        End Get
        Set(ByVal value As Long)
            moldprescriptionid = value
        End Set
    End Property
    Public Property admissionid() As Long
        Get
            Return madmissionid
        End Get
        Set(ByVal value As Long)
            madmissionid = value
        End Set
    End Property
    Public Property description() As String
        Get
            Return mdescription
        End Get
        Set(ByVal value As String)
            mdescription = value
        End Set
    End Property
    Public Property xdate() As DateTime
        Get
            Return mdate
        End Get
        Set(ByVal value As DateTime)
            mdate = value
        End Set
    End Property
    Public Property isprocedure() As Boolean
        Get
            Return misprocedure
        End Get
        Set(ByVal value As Boolean)
            misprocedure = value
        End Set
    End Property
    Public Property isprimarydiagnosis() As Boolean
        Get
            Return misprimarydiagnosis
        End Get
        Set(ByVal value As Boolean)
            misprimarydiagnosis = value
        End Set
    End Property
    Public Property laterality() As String
        Get
            Return mlaterality
        End Get
        Set(ByVal value As String)
            mlaterality = value
        End Set
    End Property
    Public Property physician() As Long
        Get
            Return mphysician
        End Get
        Set(ByVal value As Long)
            mphysician = value
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
    Public Property istemplate() As Integer
        Get
            Return mistemplate
        End Get
        Set(ByVal value As Integer)
            mistemplate = value
        End Set
    End Property

    Public Property Oldadmissiondiagnosisid() As Long
        Get
            Return mOldadmissiondiagnosisid
        End Get
        Set(ByVal value As Long)
            mOldadmissiondiagnosisid = value
        End Set
    End Property
    Public Property icd10code() As String
        Get
            Return micd10code
        End Get
        Set(ByVal value As String)
            micd10code = value
        End Set
    End Property
    Public Property diagnosis() As String
        Get
            Return mdiagnosis
        End Get
        Set(ByVal value As String)
            mdiagnosis = value
        End Set
    End Property

    Public Property historyofpresentillness() As String
        Get
            Return mhistoryofpresentillness
        End Get
        Set(ByVal value As String)
            mhistoryofpresentillness = value
        End Set
    End Property
    Public Property plan() As String
        Get
            Return mplan
        End Get
        Set(ByVal value As String)
            mplan = value
        End Set
    End Property
    Public Property assessment() As String
        Get
            Return massessment
        End Get
        Set(ByVal value As String)
            massessment = value
        End Set
    End Property
    Public Property physicalexamination() As String
        Get
            Return mphysicalexamination
        End Get
        Set(ByVal value As String)
            mphysicalexamination = value
        End Set
    End Property
    Public Property chiefcomplaints() As String
        Get
            Return mchiefcomplaints
        End Get
        Set(ByVal value As String)
            mchiefcomplaints = value
        End Set
    End Property



    Public Property oldpresecriptiondetailsid() As Long
        Get
            Return moldpresecriptiondetailsid
        End Get
        Set(ByVal value As Long)
            moldpresecriptiondetailsid = value
        End Set
    End Property
    Public Property prescriptionid() As Long
        Get
            Return mprescriptionid
        End Get
        Set(ByVal value As Long)
            mprescriptionid = value
        End Set
    End Property
    Public Property drugcode() As String
        Get
            Return mdrugcode
        End Get
        Set(ByVal value As String)
            mdrugcode = value
        End Set
    End Property 
    Public Property quantity() As Integer
        Get
            Return mquantity
        End Get
        Set(ByVal value As Integer)
            mquantity = value
        End Set
    End Property
    Public Property frequency() As Integer
        Get
            Return mfrequency
        End Get
        Set(ByVal value As Integer)
            mfrequency = value
        End Set
    End Property
    Public Property dosage() As String
        Get
            Return mdosage
        End Get
        Set(ByVal value As String)
            mdosage = value
        End Set
    End Property
    Public Property period() As Integer
        Get
            Return mperiod
        End Get
        Set(ByVal value As Integer)
            mperiod = value
        End Set
    End Property
    Public Property per() As String
        Get
            Return mper
        End Get
        Set(ByVal value As String)
            mper = value
        End Set
    End Property


    Public Property oldsoapid() As Long
        Get
            Return moldsoapid
        End Get
        Set(ByVal value As Long)
            moldsoapid = value
        End Set
    End Property

    Public Property type() As String
        Get
            Return mtype
        End Get
        Set(ByVal value As String)
            mtype = value
        End Set
    End Property
    Public Property issync() As Boolean
        Get
            Return missync
        End Get
        Set(ByVal value As Boolean)
            missync = value
        End Set
    End Property
    Public Property isdeleted() As Boolean
        Get
            Return misdeleted
        End Get
        Set(ByVal value As Boolean)
            misdeleted = value
        End Set
    End Property
    Public Property serverid() As Long
        Get
            Return mserverid
        End Get
        Set(ByVal value As Long)
            mserverid = value
        End Set
    End Property
    Public Property isfollowup() As Boolean
        Get
            Return misfollowup
        End Get
        Set(ByVal value As Boolean)
            misfollowup = value
        End Set
    End Property
    Public Property followup() As Date
        Get
            Return mfollowup
        End Get
        Set(ByVal value As Date)
            mfollowup = value
        End Set
    End Property
#End Region

     
    Public Shared Function getGeneric(ByRef sop As Integer, ByRef search As String, Optional ByVal sdate As String = "2016-09-09", Optional ByVal edate As String = "2016-09-09") As DataTable
        Dim StrPar As String() = {"operation", "soperation", "search", "startdate", "enddate"}
        Dim StrVal As String() = {0, sop, search, CDate(sdate), CDate(edate)}
        'Dim s As New Public_Modules : Return s.CUSTOM_RETRIEVE("spDashboard", StrPar, StrVal)
        Return GenericDA.ManageQuery(StrPar, StrVal, "spDashboard", 0)
    End Function

    Public Shared Function getClinicPatients(ByVal soperation As Integer, ByVal search As String, Optional ByVal filterby As Long = 0, Optional ByVal doctorid As Long = 0, Optional ByVal type As String = "", Optional ByVal prequestno As String = "") As DataTable
        Dim strPar() As String = {"operation", "soperation", "search", "filterby", "doctorid", "admissiontype"}
        Dim strVal() As String = {0, soperation, search, filterby, doctorid, "opd"}
        'Dim s As New simpleadapter.SimpleAdapter(gconnectionstring)
        Return GenericDA.ManageQuery(strPar, strVal, "spClinicDashboard", 0)
    End Function
    Public Shared Function getPatientInfo(ByVal soperation As Integer, ByVal admissionID As Integer) As DataTable
        Dim strPar() As String = {"@operation", "@soperation", "@AdmissionID"}
        Dim strVal() As String = {0, soperation, admissionID}
        'Return GenericDA.ManageQuery(strPar, strVal, "spDashboard", 0)
        Return GenericDA.ManageQuery(strPar, strVal, "spAdmissionDetails", 0)
    End Function
    Public Shared Function getRadiologyLaboratory(ByRef sop As Integer, ByVal admissionID As Integer, ByRef resultype As String, ByRef testresultid As Long) As DataTable
        Dim strPar() As String = {"operation", "soperation", "AdmissionID", "resulttype", "testresultid"}
        Dim strVal() As String = {0, sop, admissionID, resultype, testresultid}
        'Return GenericDA.ManageQuery(strPar, strVal, "spDashboard", 0)
        Return GenericDA.ManageQuery(strPar, strVal, "spAdmissionDetails", 0)
    End Function
    Public Shared Function getMyPatients(ByVal soperation As Integer, ByVal search As String, Optional ByVal filterby As Long = 0, Optional ByVal doctorid As Long = 0, Optional ByVal type As String = "", Optional ByVal prequestno As String = "") As DataTable
        Dim strPar() As String = {"@operation", "@soperation", "@search", "@filterby", "@doctorid", "@type", "@patientrequestno"}
        Dim strVal() As String = {0, soperation, search, filterby, doctorid, type, prequestno}
        'Return GenericDA.ManageQuery(strPar, strVal, "spDashboard", 0)
        Return GenericDA.ManageQuery(strPar, strVal, "spDashboard", 0)
    End Function
    Public Shared Function getDashboard(ByVal soperation As Integer, ByVal search As String) As DataTable
        Dim strPar() As String = {"@operation", "@soperation", "@search"}
        Dim strVal() As String = {0, soperation, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spReportDashboard", 0)
    End Function

    Public Shared Function getAdmissions(ByVal search As String, ByVal filterby As Integer, ByVal doctorid As Long, ByRef clinicid As Integer, ByRef admissiontype As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search", "filterby", "doctorid", "id", "admissiontype"}
        Dim strVal() As String = {0, 0, search, filterby, doctorid, clinicid, admissiontype}
        'Dim s As New simpleadapter.SimpleAdapter(gconnectionstring)
        Return GenericDA.ManageQuery(strPar, strVal, "spClinicDashboard", 0)
    End Function
    'Public Shared Sub printPrescription(ByVal dtRecord As DataTable)
    '    Dim reportviewer As New frmReportViewerIndividual
    '    Select Case ClinicID
    '        Case 2
    '            Dim cr As New crptprescriptionGeneric
    '            cr.SetDataSource(dtRecord)
    '            reportviewer.CrystalReportViewer1.ReportSource = cr
    '        Case 3
    '            Dim cr As New crptprescriptionGeneric
    '            cr.SetDataSource(dtRecord)
    '            reportviewer.CrystalReportViewer1.ReportSource = cr
    '        Case 4
    '            Dim cr As New crptprescriptionGeneric1_4long
    '            cr.SetDataSource(dtRecord)
    '            reportviewer.CrystalReportViewer1.ReportSource = cr
    '    End Select
    '    reportviewer.Show()
    'End Sub
    'Public Shared Sub printPreprintedPrescription(ByVal dtRecord As DataTable)
    '    Dim reportviewer As New frmReportViewerIndividual
    '    If ClinicID = 3 Or ClinicID = 4 Then
    '        Dim cr As New crptprescriptionDraParcon
    '        cr.SetDataSource(dtRecord)
    '        reportviewer.CrystalReportViewer1.ReportSource = cr
    '    ElseIf ClinicID = 2 Then
    '        Dim cr As New crptpreprinted_rx_DrBenignos
    '        cr.SetDataSource(dtRecord)
    '        reportviewer.CrystalReportViewer1.ReportSource = cr
    '    End If

    '    reportviewer.Show()
    'End Sub

    'Public Shared Sub printTestRequest(ByVal dtRecord As DataTable)
    '    Dim reportviewer As New frmReportViewerIndividual
    '    Select Case ClinicID
    '        Case 2
    '            Dim cr As New crptTestRequestGeneric
    '            cr.SetDataSource(dtRecord)
    '            reportviewer.CrystalReportViewer1.ReportSource = cr
    '        Case 3
    '            Dim cr As New crptTestRequestGeneric
    '            cr.SetDataSource(dtRecord)
    '            reportviewer.CrystalReportViewer1.ReportSource = cr
    '        Case 4
    '            Dim cr As New crptTestRequestLHI
    '            cr.SetDataSource(dtRecord)
    '            reportviewer.CrystalReportViewer1.ReportSource = cr
    '    End Select
    '    reportviewer.Show()
    'End Sub

    'Public Shared Sub printRadiologyRequest(ByVal dtRecord As DataTable)
    '    Dim reportviewer As New frmReportViewerIndividual
    '    Dim cr As New crptRadRequestLHI
    '    cr.SetDataSource(dtRecord)
    '    reportviewer.CrystalReportViewer1.ReportSource = cr
    '    reportviewer.Show()
    'End Sub

    Public Function save(ByVal isNew As Boolean, ByVal soperation As Integer) As Long
        If isNew Then
            operation = 1
            isNew = True
        Else
            operation = 2
        End If
        ' Dim s As New simpleadapter.SimpleAdapter(gconnectionstring)
        Dim strPar() As String = {"operation", "soperation", "oldprescriptionid", "admissionid", "description", "date", "physician", "createdbyid",
                                  "Oldadmissiondiagnosisid", "icd10code", "diagnosis", "isprimarydiagnosis", "isprocedure", "laterality", "assessment", "plan", "physicalexamination",
                                  "chiefcomplaints", "name", "istemplate", "oldpresecriptiondetailsid", "prescriptionid", "drugcode", "quantity",
                                  "dosage", "period", "per", "frequency", "oldsoapid", "type", "refpatientrequestno", "asystolic", "adiastolic",
                                  "abreathing", "apulse", "atemperature", "aheight", "aweight", "isfollowup", "followup",
                                  "issync", "isdeleted", "NewPK"}
        Dim strVal() As String = {operation, soperation, Me.oldprescriptionid, Me.admissionid, Me.description, Me.xdate, Me.physician, createdbyid,
                                  Me.Oldadmissiondiagnosisid, Me.icd10code, Me.diagnosis, Me.isprimarydiagnosis, isprocedure, laterality, Me.assessment, Me.plan, Me.physicalexamination,
                                  Me.chiefcomplaints, Me.name, Me.istemplate, Me.oldpresecriptiondetailsid, Me.prescriptionid, Me.drugcode, Me.quantity,
                                  Me.dosage, Me.period, Me.per, Me.frequency, oldsoapid, Me.type, Me.refpatientrequestno, msystolic, mdiastolic,
                                  mbreathing, mpulse, mtemperature, mheight, mweight, isfollowup, followup,
                                  missync, misdeleted, operation}
        If isNew Then
            Me.oldprescriptionid = GenericDA.ManageQuery(strPar, strVal, "spDashboard", 2)
        Else
            GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
        End If
        Return Me.oldprescriptionid
    End Function
    Public Sub saveMedCert()
        'Dim s As New simpleadapter.SimpleAdapter(gconnectionstring)
        Dim strPar() As String = {"operation", "soperation", "admissionid", "remarks", "issync"}
        Dim strVal() As String = {2, 6, Me.admissionid, Me.remarks, missync}
        GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
    End Sub
    Public Function saveDiagnosis(ByVal isNew As Boolean, ByVal soperation As Integer) As Long
        If isNew Then
            operation = 1
            isNew = True
        Else
            operation = 2
        End If
        'Dim s As New simpleadapter.SimpleAdapter(gconnectionstring)
        Dim strPar() As String = {"operation", "soperation", "Oldadmissiondiagnosisid", "admissionid", "icd10code", "diagnosis",
                                   "issync", "isdeleted", "server_id", "NewPK"}
        Dim strVal() As String = {operation, soperation, Me.Oldadmissiondiagnosisid, Me.admissionid, Me.icd10code, Me.diagnosis,
                                  missync, misdeleted, mserverid, operation}
        Return GenericDA.ManageQuery(strPar, strVal, "spDashboard", 2)
    End Function

    Public Sub DeleteSelectedPrescription(ByVal str As String, Optional ByVal type As String = "")
        Dim strPar() As String = {"@operation", "@soperation", "@search", "@type"}
        Dim strVal() As String = {3, 0, str, type}
        GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
        Call GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
    End Sub
    Public Shared Sub DeleteMainPrescription(ByVal str As String, Optional ByVal type As String = "")
        Dim strPar() As String = {"@operation", "@soperation", "@search"}
        Dim strVal() As String = {3, 3, str}
        GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
        Call GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
    End Sub

    Public Sub Deleterequestdetails(ByVal str As String, Optional ByVal type As String = "", Optional ByVal ptrequestno As String = "")
        Dim strPar() As String = {"@operation", "@soperation", "@search", "@filterby", "@patientrequestno"}
        Dim strVal() As String = {3, 1, str, type, ptrequestno}
        GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
        Call GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
    End Sub
    Public Sub Deleterequest(ByVal str As String, Optional ByVal type As String = "")
        Dim strPar() As String = {"@operation", "@soperation", "@search"}
        Dim strVal() As String = {3, 2, str}
        GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
        Call GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
    End Sub

    Public Function saveDetails(ByVal isNew As Boolean) As DataTable
        If isNew Then

        Else
            operation = 2
            soperation = 3
        End If
        Dim strPar() As String = {"operation", _
                                   "soperation", _
                                  "itemcode", _
                                  "patientrequestdetailno", _
                                  "patientrequestno", _
                                  "quantityrequested", _
                                  "quantityrendered", _
                                  "remarks", _
                                  "destinationoffice", _
                                  "status"}

        Dim strVal() As Object = {operation, _
                                  soperation, _
                                 itemcode, _
                                 patientrequestdetailno, _
                                 patientrequestno, _
                                 quantityrequested, _
                                 quantityrendered, _
                                 remarks, _
                                 destinationoffice, _
                                 stat}
        Return GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
    End Function

    Public Sub DeleteTemplates(ByVal str As String)
        Dim strPar() As String = {"@operation", "@soperation", "@search"}
        Dim strVal() As String = {3, 4, str}
        GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
    End Sub
    Public Sub DeleteAdmissionDiagnosis(ByVal str As String)
        Dim strPar() As String = {"@operation", "@soperation", "@Oldadmissiondiagnosisid"}
        Dim strVal() As String = {3, 5, str}
        GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
    End Sub
    Public Function updateRequest(ByVal isNew As Boolean) As Long
        If isNew Then
            operation = 1
            soperation = 0
        Else
            operation = 2
            soperation = 2
        End If

        Dim strPar() As String = {"operation", _
                                   "soperation", _
                                   "patientrequestno", _
                                   "approvedbyid", _
                                   "dateapproved"}
        Dim strVal() As String = {operation, _
                                  soperation, _
                                  patientrequestno, _
                                  approvedbyid, _
                                  dateapproved}

        If isNew Then
            GenericDA.ManageQuery(strPar, strVal, "spPatientRequisition", 1)
            Call SaveLog("Patient Request", "New Patient Request No  " & Me.patientrequestno, patientrequestno)
        Else
            Call GenericDA.ManageQuery(strPar, strVal, "spPatientRequisition", 1)
            Call SaveLog("Patient Request", "Update Patient Request " & Me.patientrequestno, patientrequestno)
        End If
        Return Me.patientrequestno
    End Function

     

    'Public Function save(ByVal isNew As Boolean, ByVal soperation As Integer) As Long
    '    If isNew Then
    '        operation = 1
    '        isNew = True
    '    Else
    '        operation = 2
    '    End If

    '    Dim strPar() As String = {"operation", "soperation", "oldprescriptionid", "admissionid", "description", "date", "physician",
    '                              "name", "istemplate", "oldpresecriptiondetailsid", "prescriptionid", "drugcode", "quantity",
    '                              "dosage", "period", "per", "frequency", "issync", "isdeleted", "NewPK"}
    '    Dim strVal() As String = {operation, soperation, Me.oldprescriptionid, Me.admissionid, Me.description, Me.xdate, Me.physician,
    '                              Me.name, Me.istemplate, Me.oldpresecriptiondetailsid, Me.prescriptionid, Me.drugcode, Me.quantity,
    '                              Me.dosage, Me.period, Me.per, Me.frequency, missync, misdeleted, operation}
    '    If isNew Then
    '        Me.oldprescriptionid = GenericDA.ManageQuery(strPar, strVal, "spDashboard", 2)
    '    Else
    '        Call GenericDA.ManageQuery(strPar, strVal, "spDashboard", 1)
    '    End If
    '    Return Me.oldprescriptionid
    'End Function

    

    'Public Shared Sub printPrescription(ByVal dtRecord As DataTable)
    '    Dim reportviewer As New frmPrinting

    '    Dim cr As New crptprescriptionGeneric1_4long
    '    cr.SetDataSource(dtRecord)
    '    reportviewer.crvPrinting.ReportSource = cr

    '    reportviewer.Show()
    'End Sub

    Public Shared Function RespondAppointmentRequest(ByVal AppointmentID As Integer, ByVal Response As Integer, ByVal consultime As String, ByVal Comments As String) As Long
        'Dim s As New simpleadapter.SimpleAdapter(gconnectionstring)
        'Dim adap As New Public_Modules
        Dim strPar() As String = {"operation", _
                                   "soperation", _
                                   "id", _
                                   "isApprovedDoctor", _
                                   "commentDoctor", "consultTime", "issync"}
        Dim strVal() As String = {1, 1, AppointmentID, Response, Comments, consultime, False}
        Call GenericDA.ManageQuery(strPar, strVal, "spAppointments", 1)
        'adap.CUSTOM_TRANSACT("spAppointments", strPar, strVal)
        Return AppointmentID
    End Function

    'Public Shared Sub printPreprintedPrescription(ByVal dtRecord As DataTable)
    '    Dim reportviewer As New frmReportViewerIndividual
    '    If ClinicID = 3 Or ClinicID = 4 Then
    '        Dim cr As New crptprescriptionDraParcon
    '        cr.SetDataSource(dtRecord)
    '        reportviewer.CrystalReportViewer1.ReportSource = cr
    '    ElseIf ClinicID = 2 Then
    '        Dim cr As New crptpreprinted_rx_DrBenignos
    '        cr.SetDataSource(dtRecord)
    '        reportviewer.CrystalReportViewer1.ReportSource = cr
    '    End If

    '    reportviewer.Show()
    'End Sub
End Class
