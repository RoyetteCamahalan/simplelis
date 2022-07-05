Imports System.Configuration

Module modGlobal
    Public gconnectionstring = ""
    Public defaultdateformat As String = "MM/dd/yyyy"
    Public defaulttimeformat As String = "hh:mmtt"
    Public defaultdatetimeformat As String = "MM/dd/yyyy hh:mmtt"
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

    Public ClinicID As Integer = 4
    Public gFilePrinterName As String = ConfigurationManager.AppSettings("FilePrinterName")
    Public gDocumentLocationEMR As String = ConfigurationManager.AppSettings("DocumentLocationEMR")

    Public themecolor3 As Color = Color.MediumSeaGreen

    Public delete_icon As Image = My.Resources.delete_16x16
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


    Public Enum appSettings
        DatabaseName = 0
        DocumentLocationEMR = 12
    End Enum
    Sub setUserInfo()
        Dim dt As DataTable = clsUsers.GetUser(1, "", "", userid)
        sourceOfficeCode = dt.Rows(0).Item("officecode")
        ulastName = dt.Rows(0).Item("lastname")
        ufirstName = dt.Rows(0).Item("firstname")
        ufullName = ufirstName & " " & ulastName
        Dim dtHospInfo As DataTable = clsHospitalInfo.getInfo(0, "")
        'Select Case IsDBNull(dtHospInfo.Rows(0)("new_icon"))
        '    Case True
        '        new_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("new_icon")
        '        If tempphoto.Length = 0 Then
        '            new_icon = Nothing
        '        Else
        '            new_icon = Utility.convertImage(dtHospInfo.Rows(0)("new_icon")) 'image here
        '        End If
        'End Select
        'hospitalname = dtHospInfo.Rows(0).Item("HospName")
        'hospitalcode = dtHospInfo.Rows(0).Item("eclaimshospitalcode")
        'hospitaladdress = dtHospInfo.Rows(0).Item("Barangay") & ", " & dtHospInfo.Rows(0).Item("MunCity") & ", " & dtHospInfo.Rows(0).Item("Province")

        Select Case IsDBNull(dtHospInfo.Rows(0)("edit_icon"))
            Case True
                edit_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("edit_icon")
                If tempphoto.Length = 0 Then
                    edit_icon = Nothing
                Else
                    edit_icon = Utility.convertImage(dtHospInfo.Rows(0)("edit_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("cancel_icon"))
            Case True
                cancel_icon = Nothing
            Case False
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("cancel_icon")
                If tempphoto.Length = 0 Then
                    cancel_icon = Nothing
                Else
                    cancel_icon = Utility.convertImage(dtHospInfo.Rows(0)("cancel_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("print_icon"))
            Case True
                print_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("print_icon")
                If tempphoto.Length = 0 Then
                    print_icon = Nothing
                Else
                    print_icon = Utility.convertImage(dtHospInfo.Rows(0)("print_icon")) 'image here
                End If
        End Select


        Select Case IsDBNull(dtHospInfo.Rows(0)("save_icon"))
            Case True
                save_icon = Nothing
            Case False
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("save_icon")
                If tempphoto.Length = 0 Then
                    save_icon = Nothing
                Else
                    save_icon = Utility.convertImage(dtHospInfo.Rows(0)("save_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("close_icon"))
            Case True
                close_icon = Nothing
            Case False
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("close_icon")
                If tempphoto.Length = 0 Then
                    close_icon = Nothing
                Else
                    close_icon = Utility.convertImage(dtHospInfo.Rows(0)("close_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("search_icon"))
            Case True
                search_icon = Nothing
            Case False
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("search_icon")
                If tempphoto.Length = 0 Then
                    search_icon = Nothing
                Else
                    search_icon = Utility.convertImage(dtHospInfo.Rows(0)("search_icon")) 'image here
                End If
        End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("select_record_icon"))
        '    Case True
        '        select_record_icon = Nothing
        '    Case False
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("select_record_icon")
        '        If tempphoto.Length = 0 Then
        '            select_record_icon = Nothing
        '        Else
        '            select_record_icon = Utility.convertImage(dtHospInfo.Rows(0)("select_record_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("create_new_record_icon"))
        '    Case True
        '        create_new_record_icon = Nothing
        '    Case False
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("create_new_record_icon")
        '        If tempphoto.Length = 0 Then
        '            create_new_record_icon = Nothing
        '        Else
        '            create_new_record_icon = Utility.convertImage(dtHospInfo.Rows(0)("create_new_record_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("inspect_icon"))
        '    Case True
        '        inspect_icon = Nothing
        '    Case False
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("inspect_icon")
        '        If tempphoto.Length = 0 Then
        '            inspect_icon = Nothing
        '        Else
        '            inspect_icon = Utility.convertImage(dtHospInfo.Rows(0)("inspect_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("checked_icon"))
        '    Case True
        '        checked_icon = Nothing
        '    Case False
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("checked_icon")
        '        If tempphoto.Length = 0 Then
        '            checked_icon = Nothing
        '        Else
        '            checked_icon = Utility.convertImage(dtHospInfo.Rows(0)("checked_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("accept_icon"))
        '    Case True
        '        accept_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("accept_icon")
        '        If tempphoto.Length = 0 Then
        '            accept_icon = Nothing
        '        Else
        '            accept_icon = Utility.convertImage(dtHospInfo.Rows(0)("accept_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("realease_icon"))
        '    Case True
        '        realease_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("realease_icon")
        '        If tempphoto.Length = 0 Then
        '            realease_icon = Nothing
        '        Else
        '            realease_icon = Utility.convertImage(dtHospInfo.Rows(0)("realease_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("receive_icon"))
        '    Case True
        '        receive_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("receive_icon")
        '        If tempphoto.Length = 0 Then
        '            receive_icon = Nothing
        '        Else
        '            receive_icon = Utility.convertImage(dtHospInfo.Rows(0)("receive_icon")) 'image here
        '        End If
        'End Select

        'Select Case IsDBNull(dtHospInfo.Rows(0)("issue_icon"))
        '    Case True
        '        issue_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("issue_icon")
        '        If tempphoto.Length = 0 Then
        '            issue_icon = Nothing
        '        Else
        '            issue_icon = Utility.convertImage(dtHospInfo.Rows(0)("issue_icon")) 'image here
        '        End If
        'End Select


        'Select Case IsDBNull(dtHospInfo.Rows(0)("post_icon"))
        '    Case True
        '        post_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("post_icon")
        '        If tempphoto.Length = 0 Then
        '            post_icon = Nothing
        '        Else
        '            post_icon = Utility.convertImage(dtHospInfo.Rows(0)("post_icon")) 'image here
        '        End If
        'End Select


        ''add

        'Select Case IsDBNull(dtHospInfo.Rows(0)("philhealth_icon"))
        '    Case True
        '        philhealth_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("philhealth_icon")
        '        If tempphoto.Length = 0 Then
        '            philhealth_icon = Nothing
        '        Else
        '            philhealth_icon = Utility.convertImage(dtHospInfo.Rows(0)("philhealth_icon")) 'image here
        '        End If
        'End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("camera_icon"))
            Case True
                camera_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("camera_icon")
                If tempphoto.Length = 0 Then
                    camera_icon = Nothing
                Else
                    camera_icon = Utility.convertImage(dtHospInfo.Rows(0)("camera_icon")) 'image here
                End If
        End Select

        Select Case IsDBNull(dtHospInfo.Rows(0)("pencil_icon"))
            Case True
                pencil_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("pencil_icon")
                If tempphoto.Length = 0 Then
                    pencil_icon = Nothing
                Else
                    pencil_icon = Utility.convertImage(dtHospInfo.Rows(0)("pencil_icon")) 'image here
                End If
        End Select
        Select Case IsDBNull(dtHospInfo.Rows(0)("folder_picture_icon"))
            Case True
                folder_picture_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("folder_picture_icon")
                If tempphoto.Length = 0 Then
                    folder_picture_icon = Nothing
                Else
                    folder_picture_icon = Utility.convertImage(dtHospInfo.Rows(0)("folder_picture_icon")) 'image here
                End If
        End Select
        Select Case IsDBNull(dtHospInfo.Rows(0)("load_item_icon"))
            Case True
                load_item_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("load_item_icon")
                If tempphoto.Length = 0 Then
                    load_item_icon = Nothing
                Else
                    load_item_icon = Utility.convertImage(dtHospInfo.Rows(0)("load_item_icon")) 'image here
                End If
        End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("remove_icon"))
        '    Case True
        '        remove_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("remove_icon")
        '        If tempphoto.Length = 0 Then
        '            remove_icon = Nothing
        '        Else
        '            remove_icon = Utility.convertImage(dtHospInfo.Rows(0)("remove_icon")) 'image here
        '        End If
        'End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("male_icon"))
        '    Case True
        '        male_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("male_icon")
        '        If tempphoto.Length = 0 Then
        '            male_icon = Nothing
        '        Else
        '            male_icon = Utility.convertImage(dtHospInfo.Rows(0)("male_icon")) 'image here
        '        End If
        'End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("female_icon"))
        '    Case True
        '        female_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("female_icon")
        '        If tempphoto.Length = 0 Then
        '            female_icon = Nothing
        '        Else
        '            female_icon = Utility.convertImage(dtHospInfo.Rows(0)("female_icon")) 'image here
        '        End If
        'End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("extract_icon"))
        '    Case True
        '        extract_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("extract_icon")
        '        If tempphoto.Length = 0 Then
        '            extract_icon = Nothing
        '        Else
        '            extract_icon = Utility.convertImage(dtHospInfo.Rows(0)("extract_icon")) 'image here
        '        End If
        'End Select
        'Select Case IsDBNull(dtHospInfo.Rows(0)("continue_icon"))
        '    Case True
        '        continue_icon = Nothing
        '    Case Else
        '        Dim tempphoto As Byte() = dtHospInfo.Rows(0)("continue_icon")
        '        If tempphoto.Length = 0 Then
        '            continue_icon = Nothing
        '        Else
        '            continue_icon = Utility.convertImage(dtHospInfo.Rows(0)("continue_icon")) 'image here
        '        End If
        'End Select
        Select Case IsDBNull(dtHospInfo.Rows(0)("view_icon"))
            Case True
                view_icon = Nothing
            Case Else
                Dim tempphoto As Byte() = dtHospInfo.Rows(0)("view_icon")
                If tempphoto.Length = 0 Then
                    view_icon = Nothing
                Else
                    view_icon = Utility.convertImage(dtHospInfo.Rows(0)("view_icon")) 'image here
                End If
        End Select

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
