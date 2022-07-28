Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class clsadmissiondocuments

#Region "Members"

    Public admissiondocumentid As Long
    Public admissionid As Long
    Public documentcode As String
    Public documentlocation As String
    Public documentname As String
    Public documenturl As String
    Public documenttype As String
    Public createdbyid As Long
    Public datecreated As Date
    Public uploadsequence As Integer
    Public isuploaded As Boolean
    Public oadmission As clsAdmission

#End Region
#Region "Region"

    Sub New()

    End Sub

    Sub New(ByVal _admissionid As Long)
        Dim dtAdmissionRecord As DataTable = getAdmissionRecordDetails(_admissionid)
        oadmission = New clsAdmission()
        With dtAdmissionRecord
            oadmission.AdmissionID = _admissionid
            oadmission.ptno = .Rows(0).Item("ptno").ToString
            oadmission.physicianname = .Rows(0).Item("physician").ToString
            oadmission.DateofAdmin = .Rows(0).Item("dateadmitted").ToString
            oadmission.patientname = .Rows(0).Item("patientname").ToString
            oadmission.hospitalno = Utility.NullToEmptyString(.Rows(0).Item("HospitalNo"))
            oadmission.gender = .Rows(0).Item("gender").ToString
            oadmission.birthdate = .Rows(0).Item("BirthDate")
        End With
    End Sub
    Public Shared Function getDocument(sop As Integer, ByVal search As String, ByVal admissionid As Long) As DataTable
        Dim strPar() As String = {"operation", "sOperation", "admissionid", "search"}
        Dim strVal() As String = {0, sop, admissionid, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spAdmissionDocuments", 0)
    End Function

    Public Shared Function getAdmissionRecordDetails(ByVal admissionid As String) As DataTable
        Dim strPar() As String = {"operation", "sOperation", "search"}
        Dim strVal() As String = {0, 35, admissionid}
        Return GenericDA.ManageQuery(strPar, strVal, "spAdmissionDetails", 0)
    End Function

    Public Function getAdmissionDocuments(ByVal admissionid As Long) As DataTable
        Dim strPar() As String = {"operation", "sOperation", "search"}
        Dim strVal() As String = {0, 0, admissionid}
        Return GenericDA.ManageQuery(strPar, strVal, "spAdmissionDocuments", 0)
    End Function

    Public Function getDocumentDetails(ByVal documentid As Long) As DataTable
        Dim strPar() As String = {"operation", "sOperation", "search"}
        Dim strVal() As String = {0, 1, documentid}
        Return GenericDA.ManageQuery(strPar, strVal, "spAdmissionDocuments", 0)
    End Function

    Public Function getTransmittalDocuments(ByVal admissionid As Long) As DataTable
        Dim strPar() As String = {"operation", "sOperation", "search"}
        Dim strVal() As String = {0, 2, admissionid}
        Return GenericDA.ManageQuery(strPar, strVal, "spAdmissionDocuments", 0)
    End Function

    Public Function getDocumentTypes() As DataTable
        Dim strPar() As String = {"operation", "sOperation"}
        Dim strVal() As String = {0, 3}
        Return GenericDA.ManageQuery(strPar, strVal, "spAdmissionDocuments", 0)
    End Function

    Public Sub saveAdmissionDocuments(ByVal dtadmissiondocuments As DataTable)
        Dim strPar() As String = {"operation", "sOperation", "dtadmissiondocuments"}
        Dim strVal() As Object = {1, 0, dtadmissiondocuments}
        GenericDA.ManageQuery(strPar, strVal, "spAdmissionDocuments", 1)
        'Dim strPar() As String = {"operation", "sOperation", "dtadmissiondocuments"}
        'Dim strVal() As Object = {1, 0, dtadmissiondocuments}
        'Dim s As New sqlbridge
        's.Transact("spAdmissionDocuments", strPar, strVal)
    End Sub

    Private Shared Function createDataTable() As DataTable
        Dim dt As New DataTable
        With dt.Columns
            .Add(New DataColumn("admissionid", GetType(Integer)))
            .Add(New DataColumn("documentcode", GetType(String)))
            .Add(New DataColumn("documentlocation", GetType(String)))
            .Add(New DataColumn("documentname", GetType(String)))
            .Add(New DataColumn("documenturl", GetType(String)))
            .Add(New DataColumn("documenttype", GetType(String)))
            .Add(New DataColumn("createdbyid", GetType(Integer)))
            .Add(New DataColumn("datecreated", GetType(Date)))
            .Add(New DataColumn("uploadsequence", GetType(Integer)))
            .Add(New DataColumn("isuploaded", GetType(Boolean)))
        End With
        Return dt
    End Function
    Public Shared Sub SaveLabResultImage(ByVal requestdetailno As Long, ByVal admissionid As Long, ByRef img As Bitmap, ByVal filename As String, ByVal overwrite As Boolean)
        Dim destfolder As String = gDocumentLocationEMR & "\" & admissionid
        Dim destfile As String = destfolder & "\" & filename


        If Not Directory.Exists(destfolder) Then
            Directory.CreateDirectory(destfolder)
        End If
        If File.Exists(destfile) Then
            If overwrite Then
                img.Save(destfile, ImageFormat.Jpeg)
            End If
        Else
            img.Save(destfile, ImageFormat.Jpeg)
            clsadmissiondocuments.SaveAdmissionDocument(requestdetailno, admissionid, destfile)
        End If

    End Sub
    Public Shared Sub SaveAdmissionDocument(ByVal requestdetailno As Long, ByVal admissionid As Long, ByVal destfile As String)
        Dim odocuments As New clsadmissiondocuments
        Dim dtadmissiondocuments As DataTable = createDataTable()

        dtadmissiondocuments.Rows.Add(admissionid,
                                                      requestdetailno,
                                                      "\" & destfile,
                                                      Path.GetFileName(destfile),
                                                      "",
                                                      "RadLab",
                                                      userid,
                                                      Utility.GetServerDate,
                                                      1,
                                                      False
                                                      )

        If dtadmissiondocuments.Rows.Count > 0 Then
            Call odocuments.saveAdmissionDocuments(dtadmissiondocuments)
            dtadmissiondocuments.Rows.Clear()
        End If
    End Sub
#End Region
End Class
