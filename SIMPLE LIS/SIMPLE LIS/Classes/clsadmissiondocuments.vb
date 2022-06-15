Imports System.Data.SqlClient

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

    Public Function saveAdmissionDocuments(ByVal dtadmissiondocuments As DataTable) As DataTable

        Dim cConn As New clsDBConnection
        cConn.CreateOpenConnection() 
        'Create a command object that calls the stored proc
        Dim sqlDA As New SqlDataAdapter
        Dim dtResult As New DataTable
        Dim command As New SqlCommand("spadmissiondocuments", cConn.GDBConn)
        command.CommandType = CommandType.StoredProcedure

        'Create a parameter using the new type 
        With command 
            Dim param1 As SqlParameter = .Parameters.AddWithValue("@operation", 1)
            param1.SqlDbType = SqlDbType.Int

            Dim param2 As SqlParameter = .Parameters.AddWithValue("@soperation", 0)
            param2.SqlDbType = SqlDbType.Int

            Dim param3 As SqlParameter = .Parameters.AddWithValue("@dtadmissiondocuments", dtadmissiondocuments)
            param3.SqlDbType = SqlDbType.Structured 

        End With

        sqlDA = New SqlDataAdapter(command)
        sqlDA.Fill(dtResult)
        cConn.CloseDestroyConnection()
        Return dtResult 
    End Function

#End Region
End Class
