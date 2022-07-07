Public Class clsNotification
    Public Shared Function getNotifs() As DataTable
        Dim strPar() As String = {"operation", "soperation", "officecode", "employeetypeid"}
        Dim strVal() As Object = {0, 0, modGlobal.sourceOfficeCode, modGlobal.employeetypeid}
        Return GenericDA.ManageQuery(strPar, strVal, "spSystemNotification", 0)
    End Function
    Public Shared Sub markAsRead(notificationid As Long)
        Dim strPar() As String = {"operation", "soperation", "notificationid", "readby"}
        Dim strVal() As Object = {2, 0, notificationid, modGlobal.userid}
        GenericDA.ManageQuery(strPar, strVal, "spSystemNotification", 1)
    End Sub

    Public Shared Sub generateRequestNotif(patientrequestno As Long)
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As Object = {1, 1, patientrequestno}
        GenericDA.ManageQuery(strPar, strVal, "spSystemNotification", 1)
    End Sub

End Class
