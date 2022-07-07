Public Class clsOffices

#Region "Methods"

    Public Shared Function getOfficeDefaults(ByVal sop As Integer, ByVal search As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As String = {0, sop, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spOfficeDefaults", 0)
    End Function

    Public Shared Sub updateRingtone(ByVal alertaudio As String, ByRef officecode As String)
        Dim strPar() As String = {"operation", "soperation", "alertaudio", "search"}
        Dim strVal() As String = {2, 0, alertaudio, officecode}
        GenericDA.ManageQuery(strPar, strVal, "spOfficeDefaults", 1)
    End Sub
#End Region
End Class
