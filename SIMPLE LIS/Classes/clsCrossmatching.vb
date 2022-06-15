Public Class clsCrossmatching
#Region "Variables"
    Dim operation As Integer
    Private mlabresultid As String
    Private mpatientrh As String
    Private mdonorrh As String
    Private mbloodsource As String
    Private mserialno As String
    Private mbloodcomponent As String
    Private mvolume As String
    Private mdateextracted As String
    Private mdateexpired As String
    Private mremarks As String
    Private mpathologist As String
    Private mmedtech As String
    Private mlabno As String
    Private mdate As DateTime
    Private mlaboratoryresultcrossmatchingid As String
    Private madminno As String
    Private mpatientdetailno As String
    Private mempno As String
    Private mlabresultdetailid As String

#End Region

#Region "Properties"
    Public Property labresultdetailid() As String
        Get
            Return mlabresultdetailid
        End Get
        Set(ByVal value As String)
            mlabresultdetailid = value
        End Set
    End Property
    Public Property empno() As String
        Get
            Return mempno
        End Get
        Set(ByVal value As String)
            mempno = value
        End Set
    End Property
    Public Property adminno() As String
        Get
            Return madminno
        End Get
        Set(ByVal value As String)
            madminno = value
        End Set
    End Property
    Public Property patientdetailno() As String
        Get
            Return mpatientdetailno
        End Get
        Set(ByVal value As String)
            mpatientdetailno = value
        End Set
    End Property
    Public Property labresultid() As String
        Get
            Return mlabresultid
        End Get
        Set(ByVal value As String)
            mlabresultid = value
        End Set
    End Property
    Public Property labno() As String
        Get
            Return mlabno
        End Get
        Set(ByVal value As String)
            mlabno = value
        End Set
    End Property
    Public Property patientrh() As String
        Get
            Return mpatientrh
        End Get
        Set(ByVal value As String)
            mpatientrh = value
        End Set
    End Property
    Public Property donorrh() As String
        Get
            Return mdonorrh
        End Get
        Set(ByVal value As String)
            mdonorrh = value
        End Set
    End Property
    Public Property bloodsource() As String
        Get
            Return mbloodsource
        End Get
        Set(ByVal value As String)
            mbloodsource = value
        End Set
    End Property
    Public Property serialno() As String
        Get
            Return mserialno
        End Get
        Set(ByVal value As String)
            mserialno = value
        End Set
    End Property
    Public Property bloodcomponent() As String
        Get
            Return mbloodcomponent
        End Get
        Set(ByVal value As String)
            mbloodcomponent = value
        End Set
    End Property
    Public Property volume() As String
        Get
            Return mvolume
        End Get
        Set(ByVal value As String)
            mvolume = value
        End Set
    End Property
    Public Property dateextracted() As String
        Get
            Return mdateextracted
        End Get
        Set(ByVal value As String)
            mdateextracted = value
        End Set
    End Property
    Public Property dateexpired() As String
        Get
            Return mdateexpired
        End Get
        Set(ByVal value As String)
            mdateexpired = value
        End Set
    End Property
    Public Property remarks() As String
        Get
            Return mremarks
        End Get
        Set(ByVal value As String)
            mremarks = value
        End Set
    End Property
    Public Property pathologist() As String
        Get
            Return mpathologist
        End Get
        Set(ByVal value As String)
            mpathologist = value
        End Set
    End Property
    Public Property medtech() As String
        Get
            Return mmedtech
        End Get
        Set(ByVal value As String)
            mmedtech = value
        End Set
    End Property
    Public Property edate() As DateTime
        Get
            Return mdate
        End Get
        Set(ByVal value As DateTime)
            mdate = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Shared Function getPathologist() As DataTable
        Dim strPar() As String = {"operation", "soperation"}
        Dim strVal() As String = {0, 1}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabResultCrossmatching", 0)
    End Function
    Public Shared Function getMedtech() As DataTable
        Dim strPar() As String = {"operation", "soperation"}
        Dim strVal() As String = {0, 2}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabResultCrossmatching", 0)
    End Function
    Public Shared Function getPhysician() As DataTable
        Dim strPar() As String = {"operation", "soperation"}
        Dim strVal() As String = {0, 3}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabResultCrossmatching", 0)
    End Function
    Public Shared Function getXmatch(ByVal search As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, 11, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spLaboratoryResult", 0)
    End Function
    Public Shared Function getECGReportresult(ByVal search As String, ByVal vtemp As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, vtemp, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spLaboratoryResult", 0)
    End Function
    Public Shared Function getlabresultid(ByVal vtemp As String, ByVal search As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "laboratoryid", "search"}
        Dim strVal() As String = {0, 4, vtemp, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabResultCrossmatching", 0)
    End Function
    Public Shared Function getlabresultxmtching(ByVal search As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, 5, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabResultCrossmatching", 0)
    End Function
    Public Shared Function getlabresultxmtchingdetail(ByVal search As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, 0, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabResultDetailCrossmatching", 0)
    End Function
    Public Function deleteXmatchingdetails(ByVal strSearch As String) As String
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {3, 0, strSearch}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabResultDetailCrossmatching", 1)
    End Function
    Public Function saveLRXmatching(ByVal isNew As Boolean) As String

        If isNew Then
            operation = 1
        Else
            operation = 2
        End If

        Dim strPar() As String = {"operation", "laboratoryresultid", "patientrh", "donorrh", "labno"}
        Dim strVal() As String = {Me.operation, Me.labresultid, Me.patientrh, Me.donorrh, Me.labno}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabResultCrossmatching", 2)

    End Function
    Public Function saveLRXmatchingResult(ByVal isNew As Boolean) As String

        If isNew Then
            operation = 1
        Else
            operation = 2
        End If

        Dim strPar() As String = {"operation", "admissionid", "patientrequestno", "laboratoryid", "dateencoded", "employeeno", "pathologist", "medtech", "Oldlaboratoryid"}
        Dim strVal() As String = {Me.operation, Me.adminno, Me.patientdetailno, Me.labno, Me.edate, Me.empno, Me.pathologist, Me.medtech, Me.labresultid}
        Return GenericDA.ManageQuery(strPar, strVal, "spLaboratoryResult", 2)

    End Function
    Public Function saveLRXmatchingResultDetail(ByVal isNew As Boolean) As String

        If isNew Then
            operation = 1
        Else
            operation = 2
        End If

        Dim strPar() As String = {"operation", "laboratoryresultcrossmatchingid", "bloodsource", "serialno", "bloodcomponent", "volume", "dateextracted", "dateexpired", "remarks", "search"}
        Dim strVal() As String = {Me.operation, "1", Me.bloodsource, Me.serialno, Me.bloodcomponent, Me.volume, Me.dateextracted, Me.dateexpired, Me.remarks, Me.labresultdetailid}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabResultDetailCrossmatching", 2)

    End Function
#End Region

End Class
