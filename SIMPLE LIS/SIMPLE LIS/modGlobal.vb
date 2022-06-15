Imports System.Configuration

Module modGlobal
    Public userid As Integer
    Public isAdmin As Boolean
    Public ufirstName As String
    Public ulastName As String
    Public umiddleName As String
    Public ufullName As String
    Public sourceOfficeCode As String
    Public sourceOfficeDesc As String
    Public divisionCode As String
    Public defaultSOfficeCode As String
    Public userName As String
    Public password As String
    Public designation As String
    Public employeetype As String
    Public msgboxTitle As String

    Public gServername As String
    Public gDatabasename As String
    Public gUsername As String
    Public gPassword As String
    Public gAuthType As Integer

    Public ClinicID As Integer = 4
    Public gFilePrinterName As String = ConfigurationManager.AppSettings("FilePrinterName")
    Public gDocumentLocationEMR As String = ConfigurationManager.AppSettings("DocumentLocationEMR")


    Public new_icon _
    , edit_icon _
    , cancel_icon _
    , print_icon _
    , save_icon _
    , close_icon _
    , search_icon _
    , select_record_icon _
    , create_new_record_icon _
    , inspect_icon _
    , checked_icon _
    , accept_icon _
    , realease_icon _
    , receive_icon _
    , issue_icon _
    , post_icon _
      , philhealth_icon _
      , camera_icon _
      , pencil_icon _
      , folder_picture_icon _
      , load_item_icon _
      , remove_icon _
      , male_icon _
      , female_icon _
      , extract_icon _
      , continue_icon _
      , view_icon As Image
    Public bannerColor As Color


    Sub setUserInfo(ByVal myuser As clsEmployees)

        userid = myuser.EmployeeID
        isAdmin = myuser.isadmin
        ufirstName = myuser.FirstName
        ulastName = myuser.LastName
        umiddleName = myuser.MiddleName
        'umiddleName = myuser.MiddleName
        'ufullName = myuser.OfficeCode
        sourceOfficeCode = myuser.OfficeCode
        sourceOfficeDesc = myuser.OfficeDescription
        defaultSOfficeCode = myuser.SourceOfficeCode
        ufullName = myuser.FullName
        userName = myuser.username
        password = myuser.password
        designation = myuser.Designation

        employeetype = myuser.Employeetype
        msgboxTitle = "SIMPLE Hospital Information System"
    End Sub
    Sub SaveLog(ByVal userModule As String, ByVal userAction As String, Optional ByVal referenceNo As String = "0")
        Dim logs As New clsUserLogs

        logs.username = ufullName & "(" & userName & ")"
        logs.referenceno = referenceNo
        logs.usermodule = userModule
        logs.action = userAction
        logs.logdate = Utility.GetServerDate()
        logs.saveLogs()
    End Sub
End Module
