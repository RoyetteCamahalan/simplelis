Public Class clsNewBornScreening

#Region "Variables"
    Dim operation As Integer
    Private mlabresultid As String
    Private mlabdetailid As String
    Private mresult As String
    Private madminno As String
    Private mpatientdetailno As String
    Private mlabno As String
    Private mempno As String
    Private mdate As DateTime
#End Region

#Region "Properties"
    Public Property empno() As String
        Get
            Return mempno
        End Get
        Set(ByVal value As String)
            mempno = value
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
    Public Property labdetailid() As String
        Get
            Return mlabdetailid
        End Get
        Set(ByVal value As String)
            mlabdetailid = value
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
    Public Property labno() As String
        Get
            Return mlabno
        End Get
        Set(ByVal value As String)
            mlabno = value
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

#Region "Method"
    Public Shared Function getNBS(ByVal search As String, ByVal vtemp As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, vtemp, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spLaboratoryResult", 0)
    End Function
    Public Shared Function getPediatrician() As DataTable
        Dim strPar() As String = {"operation", "soperation"}
        Dim strVal() As String = {0, 8}
        Return GenericDA.ManageQuery(strPar, strVal, "spLaboratoryResult", 0)
    End Function
    Public Shared Function getNBSresults() As DataTable
        Dim strPar() As String = {"operation", "soperation"}
        Dim strVal() As String = {0, 0}
        Return GenericDA.ManageQuery(strPar, strVal, "spNewBornScreening", 0)
    End Function
    Public Shared Function getNBSDetail(ByVal search As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, 0, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spExamination", 0)
    End Function
    Public Function saveNBS(ByVal isNew As Boolean) As String

        If isNew Then
            operation = 1
        Else
            operation = 2
        End If

        Dim strPar() As String = {"operation", "laboratoryresultid", "laboratorydetailsid", "result"}
        Dim strVal() As String = {Me.operation, Me.labresultid, Me.labdetailid, Me.result}
        Return GenericDA.ManageQuery(strPar, strVal, "spLaboratoryResultdetails", 2)

    End Function
    Public Function saveNBSResult(ByVal isNew As Boolean) As String

        If isNew Then
            operation = 1
        Else
            operation = 2
        End If

        Dim strPar() As String = {"operation", "admissionid", "patientrequestno", "laboratoryid", "dateencoded", "employeeno", "Oldlaboratoryid"}
        Dim strVal() As String = {Me.operation, Me.adminno, Me.patientdetailno, Me.labno, Me.edate, Me.empno, Me.labresultid}
        Return GenericDA.ManageQuery(strPar, strVal, "spLaboratoryResult", 2)

    End Function
#End Region

End Class
