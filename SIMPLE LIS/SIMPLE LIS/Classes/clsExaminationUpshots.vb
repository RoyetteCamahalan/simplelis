Public Class clsExaminationUpshots
#Region "Variables"
    Private operation As Integer
    Private soperation As Integer

    Dim mstatus As Integer
    Dim mpatientreqdetailno As Long

#End Region

#Region "Properties"

    Public Property status() As Integer
        Get
            Return mstatus
        End Get
        Set(ByVal value As Integer)
            mstatus = value
        End Set
    End Property

    Public Property patientreqdetailno() As Long
        Get
            Return mpatientreqdetailno
        End Get
        Set(ByVal value As Long)
            mpatientreqdetailno = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Shared Function getExaminationUpshots(ByVal search As String, ByVal destinationoffice As String, _
                                                        ByVal requestStatus As Integer) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search", "destinationoffice", "requestStatus"}
        Dim strVal() As String = {0, 0, search, destinationoffice, requestStatus}

        Return GenericDA.ManageQuery(strPar, strVal, "spExaminationUpshots", 0)
    End Function

    Public Shared Function getPatientRequestStatus(ByVal search As Integer) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, 1, search}

        Return GenericDA.ManageQuery(strPar, strVal, "spExaminationUpshots", 0)
    End Function
    Public Function save(ByVal isNew As Boolean) As Long

        If isNew Then
            operation = 1
        Else
            operation = 2
        End If
        'Update Status to 4
        Dim strPar() As String = {"@operation", "@status", "@search"}

        Dim strVal() As String = {operation, Me.mstatus, Me.patientreqdetailno}

        Return GenericDA.ManageQuery(strPar, strVal, "spExaminationUpshots", 1)

    End Function
#End Region
End Class
