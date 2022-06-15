Public Class clsRadiologyLaboratory

#Region "Variables"
    Public mtesttypeid,
           mtestid,
           mtestrequestid,
           physician,
           mtestrequestdetailid,
           madmissionid,
           createdbyid,
           updatedbyid,
           mclinicid,
           mserverid As Long

    Public mtesttypedescription,
           mtestcategory,
           mtestcode,
           mtestname,
           mmedication,
           mremarks,
           mitemcode,
           refpatientrequestno,
           destinationoffice As String

    Public misactive, missync, murgency, misfasting, misdaterequired As Boolean

    Public mrequestdate, mdaterequired As Date
    ' Public physician As String
#End Region

    'Property physician As Object

    Public Shared Function getGeneric(ByRef sop As Integer, ByRef search As String, Optional ByVal isactive As Boolean = True) As DataTable
        Dim StrPar As String() = {"operation", "soperation", "search", "isactive"}
        Dim StrVal As String() = {0, sop, search, isactive}
        Return GenericDA.ManageQuery(StrPar, StrVal, "spRadiologyLaboratory", 0)
    End Function

    Public Function Save(ByRef sop As Integer, ByRef isnew As Boolean) As Long
        Dim operation As Integer = 2
        If isnew Then
            operation = 1
        End If
        Dim StrPar As String() = {"operation", "soperation", "testtypeid", "testid", "code",
                                  "description", "testcatcode", "testtypedescription", "isactive",
                                  "createdbyid", "updatedbyid", "issync", "clinicid", "serverid", "NewPK"}
        Dim StrVal As String() = {operation, sop, mtesttypeid, mtestid, mtestcode,
                                  mtestname, mtestcategory, mtesttypedescription, misactive,
                                  createdbyid, updatedbyid, missync, mclinicid, mserverid, operation}
        Return GenericDA.ManageQuery(StrPar, StrVal, "spRadiologyLaboratory", 2)
    End Function

    Public Function SaveRequest(ByRef sop As Integer, ByRef isnew As Boolean) As Long
        Dim operation As Integer = 2
        If isnew Then
            operation = 1
        End If
        Dim StrPar As String() = {"operation", "soperation", "testrequestid", "testid", "admissionid", "requestdate", "urgency", "isfasting",
                                  "medication", "remarks", "testrequestdetailid", "isdaterequired", "daterequired", "physician", "refpatientrequestno",
                                  "itemcode", "destinationoffice", "issync", "clinicid", "serverid", "NewPK"}
        Dim StrVal As String() = {operation, sop, mtestrequestid, mtestid, madmissionid, mrequestdate, murgency, misfasting,
                                  mmedication, mremarks, mtestrequestdetailid, misdaterequired, mdaterequired, modGlobal.userid, refpatientrequestno,
                                  mitemcode, destinationoffice, missync, mclinicid, mserverid, operation}
        'Dim x As New Public_Modules : Return x.RETURN_NEWPK("spRadiologyLaboratory", StrPar, StrVal)
        Return GenericDA.ManageQuery(StrPar, StrVal, "spRadiologyLaboratory", 2)
    End Function

    Public Shared Function RemoveTest(ByRef testrequestdetailid As Long)
        Dim StrPar As String() = {"operation", "soperation", "testrequestdetailid"}
        Dim StrVal As String() = {3, 0, testrequestdetailid}
        Return GenericDA.ManageQuery(StrPar, StrVal, "spRadiologyLaboratory", 1)
    End Function

    Public Shared Function RemoveMainTestRequest(ByRef testrequestid As Long)
        Dim StrPar As String() = {"operation", "soperation", "testrequestid"}
        Dim StrVal As String() = {3, 1, testrequestid}
        Return GenericDA.ManageQuery(StrPar, StrVal, "spRadiologyLaboratory", 1)
    End Function
End Class
