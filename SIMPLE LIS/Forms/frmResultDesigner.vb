Imports System.IO
Public Class frmResultDesigner

#Region "Vars"
    Public requestdetailno As Long
    Private admissionid As Long
    Private itemdescription As String
    Private laboratoryresultid As Long
    Private laboratoryid As Integer
    Private laboratoryname As String
    Private laboratoryttitle As String
    Private testofficecode As String


    Private fbaseform As frmResultBaseDesign
    Private fBloodChem As frmtemplatewithconversion
    Private fCrossmatching As frmCrossMatchingNew
    Private frmRadiology As frmtemplateRTF

    Private afterload As Boolean
    Private initpanelresultheight As Integer
    Private initpanelmainheight As Integer
    Private initformheight As Integer

    Private labformatid As Integer
    Private requestStatus As Integer
    Public myFormaction As formaction

    Enum formaction
        NONE = 0
        updateFormat = 1
        manageResult = 2
        Release = 3
        View = 4
    End Enum

    Public Sub New(ByVal myFormaction As formaction, ByVal requestdetailno As Long, ByVal laboratoryid As Long, ByVal status As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.myFormaction = myFormaction
        Me.requestdetailno = requestdetailno
        Me.laboratoryid = laboratoryid
        Me.requestStatus = status
    End Sub
#End Region
    Private Sub frmResultDesigner_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        afterload = False
        Call getLabResultDetails()
        If myFormaction = formaction.updateFormat Then
            Me.Text = "Lab Result Designer"
            Select Case labformatid
                Case clsModel.LabFormats.WITHSIORCONVENTIONALNOCONVERSION
                    Me.tsSave.Visible = False
                    Me.tsClose.Visible = False
                    Dim f As New frmManageResultParams
                    f.labid = Me.laboratoryid
                    f.lblMisc.Text = Me.laboratoryttitle
                    f.hasSIvalue = False
                    f.ShowDialog()
                    Me.Close()
                    Exit Sub
                Case clsModel.LabFormats.WITHSIANDCONVENTIONALWITHCONVERSION
                    Dim f As New frmManageResultParams
                    f.labid = Me.laboratoryid
                    f.lblMisc.Text = Me.laboratoryttitle
                    f.hasSIvalue = True
                    f.ShowDialog()
                    Me.Close()
                    Exit Sub
                Case clsModel.LabFormats.RADIOLOGY, clsModel.LabFormats.ULTRASOUND, clsModel.LabFormats.CROSSMATCHING, clsModel.LabFormats.ECGREPORT
                    MsgBox("Diagnostic Format is not available for editing!", MsgBoxStyle.Information + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                    Me.Close()
                    Exit Sub
                Case Else
                    fbaseform = New frmResultBaseDesign(Me, True, Me.laboratoryid, Me.laboratoryttitle, False)
                    loadForm()
            End Select
        ElseIf myFormaction = formaction.NONE Then
            Me.Close()
            Exit Sub
        Else
            Me.Text = Me.laboratoryname
            Me.panelsidebar.Visible = False
            Select Case Me.labformatid
                Case clsModel.LabFormats.WITHSIANDCONVENTIONALWITHCONVERSION
                    fBloodChem = New frmtemplatewithconversion(requestdetailno, Me.laboratoryid, Me.laboratoryttitle, Me.myFormaction <> formaction.manageResult)
                    fBloodChem.MdiParent = Me
                    fBloodChem.Show()
                    fBloodChem.Top = (Me.Height - fBloodChem.Height) / 2
                Case clsModel.LabFormats.CROSSMATCHING
                    fCrossmatching = New frmCrossMatchingNew(requestdetailno, Me.laboratoryid, Me.laboratoryttitle, Me.myFormaction <> formaction.manageResult)
                    fCrossmatching.MdiParent = Me
                    fCrossmatching.Show()
                    fCrossmatching.Top = (Me.Height - fCrossmatching.Height) / 2
                Case clsModel.LabFormats.RADIOLOGY, clsModel.LabFormats.ULTRASOUND, clsModel.LabFormats.ECGREPORT
                    If Me.myFormaction = formaction.manageResult Then
                        tsradtemplatemain.Visible = True
                        loadTemplateList()
                    End If
                    frmRadiology = New frmtemplateRTF(requestdetailno, Me.laboratoryid, Me.laboratoryname, Me.myFormaction <> formaction.manageResult, Me.requestStatus)
                    frmRadiology.MdiParent = Me
                    frmRadiology.Dock = DockStyle.Fill
                    frmRadiology.Show()
                Case clsModel.LabFormats.WITHSIORCONVENTIONALNOCONVERSION
                    fbaseform = New frmResultBaseDesign(Me, False, Me.laboratoryid, Me.laboratoryttitle, Me.myFormaction <> formaction.manageResult)
                    fbaseform.panelresult.Visible = False
                    fbaseform.panelresultgrid.BorderStyle = BorderStyle.None
                    fbaseform.loadRequestDetails(Me.requestdetailno)
                    loadForm()
                Case Else
                    fbaseform = New frmResultBaseDesign(Me, False, Me.laboratoryid, Me.laboratoryttitle, Me.myFormaction <> formaction.manageResult)
                    fbaseform.panelresult.BorderStyle = BorderStyle.None
                    fbaseform.panelresultgrid.Visible = False
                    fbaseform.loadRequestDetails(Me.requestdetailno)
                    loadForm()
            End Select
            If Me.myFormaction = formaction.View Then
                Me.tsSave.Visible = False
                Me.tsPrint.Visible = testofficecode = modGlobal.sourceOfficeCode
            ElseIf Me.myFormaction = formaction.Release Then
                Me.tsSave.Text = "Release"
            End If
        End If
        afterload = True
    End Sub
    Private Sub getLabResultDetails()
        Dim dt As DataTable
        If Me.myFormaction = formaction.updateFormat Then
            dt = clsExamination.genericcls(8, Me.laboratoryid)
        Else
            dt = clsExamination.genericcls(9, Me.requestdetailno)
            If dt.Rows.Count = 0 Then
                MsgBox("Diagnostic Format not yet assigned!", MsgBoxStyle.Information + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                myFormaction = formaction.NONE
                Exit Sub
            End If
            Me.admissionid = dt.Rows(0).Item("admissionid")
            Me.laboratoryresultid = dt.Rows(0).Item("laboratoryresultid")
            Me.itemdescription = dt.Rows(0).Item("itemdescription")
            Me.testofficecode = Utility.NullToEmptyString(dt.Rows(0).Item("destinationoffice"))
        End If
        Me.laboratoryid = dt.Rows(0).Item("laboratoryid")
        Me.labformatid = dt.Rows(0).Item("labformatid")
        Me.laboratoryname = dt.Rows(0).Item("description")
        Me.laboratoryttitle = IIf(Utility.NullToEmptyString(dt.Rows(0).Item("title")) = "", Me.laboratoryname, dt.Rows(0).Item("title"))
        Me.txtpanelheight.Text = Utility.NullToZero(dt.Rows(0).Item("panelsize"))
    End Sub
    Private Sub loadForm()
        fbaseform.MdiParent = Me
        fbaseform.Show()
        Me.initpanelresultheight = fbaseform.panelresult.Height
        Me.initpanelmainheight = fbaseform.panelmain.Height
        Me.initformheight = fbaseform.Height
        Call adjustPanelSize()
        'Me.txtpanelheight.Text = Me.initpanelresultheight
        'fbaseform.Top = (Me.Height - fbaseform.Height) / 2
        Call loadDesign()
        recenterForm()
    End Sub
    Private Sub adjustPanelSize()
        If CInt(Me.txtpanelheight.Text) >= 100 Then
            Me.fbaseform.panelresult.Height = CInt(Me.txtpanelheight.Text)
            Me.fbaseform.panelmain.Height = Me.initpanelmainheight + (CInt(Me.txtpanelheight.Text) - Me.initpanelresultheight)
            Me.fbaseform.Height = Me.initformheight + (CInt(Me.txtpanelheight.Text) - Me.initpanelresultheight)
            Call recenterForm()
        Else
            Me.txtpanelheight.Text = Me.initpanelresultheight
            adjustPanelSize()
        End If
    End Sub
    Private Sub recenterForm()
        fbaseform.Top = (Me.Height - fbaseform.Height) / 2
    End Sub
    Private Function getPanelCenter() As Point
        Return New Point(fbaseform.panelresult.Width / 2, fbaseform.panelresult.Height / 2)
    End Function
    Private Sub loadDesign()
        If myFormaction = formaction.updateFormat Then
            Dim dt As DataTable = clsExamination.genericcls(10, Me.laboratoryid)
            fbaseform.panelresultgrid.Visible = False
            For Each row As DataRow In dt.Rows
                If row.Item("controltype") > 0 Then
                    If row.Item("visible") Then
                        fbaseform.AddControl(row.Item("labeldescription"), row.Item("controltype"), New Point(row.Item("x2"), row.Item("y2")), row.Item("defaultvalue"),
                                             row.Item("optionvalues"), row.Item("laboratorydetailsid"), row.Item("width2"), row.Item("height2"), row.Item("defaultvalue"))
                    End If
                    Call Me.addRow(row.Item("visible"), row.Item("description"), row.Item("controltype"), row.Item("optionvalues"),
                                   row.Item("laboratorydetailsid"), "", New Point(row.Item("x2"), row.Item("y2")), row.Item("defaultvalue"), 0,
                                   row.Item("labeldescription"), row.Item("width2"), row.Item("height2"))
                End If
            Next
            If Me.labformatid = clsModel.LabFormats.ECGREPORT Then
                Me.fbaseform.cmbMedtech.Visible = False
                Me.fbaseform.lblmedtechlicense.Visible = False
                Me.fbaseform.lblmedtechdesignation.Visible = False
                Me.fbaseform.lblpathodesignation.Text = "Cardiologist"
            End If
        Else
            Dim dt As DataTable = clsLaboratoryResultDetails.getLaboratoryResultDetails(Me.requestdetailno, "", Me.laboratoryid, 2)
            Dim islock As Boolean

            If Not myFormaction = formaction.manageResult Then
                islock = True
            End If
            If Me.labformatid = clsModel.LabFormats.WITHSIORCONVENTIONALNOCONVERSION Then

                For Each row As DataRow In dt.Rows
                    If row.Item("visible") Then
                        fbaseform.dgvResult.Rows.Add(1)
                        fbaseform.dgvResult.Rows(fbaseform.dgvResult.Rows.Count - 1).Cells(fbaseform.collabdetailid.Index).Value = row.Item("laboratorydetailsid")
                        fbaseform.dgvResult.Rows(fbaseform.dgvResult.Rows.Count - 1).Cells(fbaseform.colparameter.Index).Value = row.Item("description")
                        fbaseform.dgvResult.Rows(fbaseform.dgvResult.Rows.Count - 1).Cells(fbaseform.colref.Index).Value = row.Item("normalvalues")
                        fbaseform.dgvResult.Rows(fbaseform.dgvResult.Rows.Count - 1).Cells(fbaseform.colresult.Index).Value = Utility.NullToEmptyString(row.Item("result"))
                        fbaseform.dgvResult.Rows(fbaseform.dgvResult.Rows.Count - 1).Cells(fbaseform.collabresultdetailid.Index).Value = row.Item("laboratoryresultdetailsid")
                        fbaseform.dgvResult.Rows(fbaseform.dgvResult.Rows.Count - 1).Cells(fbaseform.colunits.Index).Value = row.Item("unit")
                        Call fbaseform.adjustForm()
                    End If
                Next
            Else
                If Me.labformatid = clsModel.LabFormats.ECGREPORT Then
                    Me.fbaseform.cmbMedtech.Visible = False
                    Me.fbaseform.lblmedtechlicense.Visible = False
                    Me.fbaseform.lblmedtechdesignation.Visible = False
                    Me.fbaseform.lblmedtech.Visible = False
                End If
                For Each row As DataRow In dt.Rows
                    If row.Item("controltype") > 0 Then
                        If row.Item("visible") Then
                            fbaseform.AddControl(row.Item("labeldescription"), row.Item("controltype"), New Point(row.Item("x2"), row.Item("y2")), row.Item("result"),
                                                 row.Item("optionvalues"), row.Item("laboratorydetailsid"), row.Item("width2"), row.Item("height2"), row.Item("defaultvalue"), islock)
                        End If
                        Call Me.addRow(row.Item("visible"), row.Item("description"), row.Item("controltype"), row.Item("optionvalues"),
                                       row.Item("laboratorydetailsid"), "", New Point(row.Item("x2"), row.Item("y2")), row.Item("defaultvalue"),
                                       row.Item("laboratoryresultdetailsid"), row.Item("labeldescription"), row.Item("width2"), row.Item("height2"))
                    End If
                Next
            End If
            If islock Then
                fbaseform.lock()
            End If
        End If
    End Sub
    Private Sub addRow(ByVal visible As Boolean, ByVal fieldname As String, ByVal ctrtype As Integer, ByVal optvalue As String,
                       ByVal laboratorydetailsid As Long, ByVal uuid As String, ByVal loc As Point, ByVal defaultvalue As String,
                        ByVal laboratoryresultdetailid As String, ByVal labeltext As String,
                        ByVal width As Long, ByVal height As Long)
        afterload = False
        Me.dgvResult.Rows.Add(1)
        With Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1)
            .Cells(colchk.Index).Value = visible
            .Cells(collaboratorydetailsid.Index).Value = laboratorydetailsid
            .Cells(coluuid.Index).Value = uuid
            .Cells(colfieldname.Index).Value = fieldname
            .Cells(colfieldtype.Index).Value = ctrtype
            .Cells(coloptionvalues.Index).Value = optvalue
            .Cells(colfieldtypedesc.Index).Value = clsModel.ConstrolTypes.getDescription(ctrtype)
            .Cells(collocationx.Index).Value = loc.X
            .Cells(collocationy.Index).Value = loc.Y
            .Cells(coldefaultvalue.Index).Value = defaultvalue
            .Cells(collaboratoryresultdetailid.Index).Value = laboratoryresultdetailid
            .Cells(collabeltext.Index).Value = labeltext
            .Cells(colwidth.Index).Value = width
            .Cells(colheight.Index).Value = height
        End With
        afterload = True
    End Sub
    Private Sub Save()
        If myFormaction = formaction.updateFormat Then
            If MsgBox("Do you want to update this format?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                Dim x As New clsExamination
                x.laboratoryid = Me.laboratoryid
                x.panelsize = Me.fbaseform.panelresult.Height
                x.saveLaboratory()
                For Each row As DataGridViewRow In Me.dgvResult.Rows
                    x.laboratorydetailsid = row.Cells(collaboratorydetailsid.Index).Value
                    x.labdetailsdescription = row.Cells(colfieldname.Index).Value
                    x.visible = row.Cells(colchk.Index).Value
                    x.normalvalues = ""
                    x.unit = ""
                    x.orderno = row.Index
                    Dim uuid As String = row.Cells(collaboratorydetailsid.Index).Value
                    If uuid = "0" Then
                        uuid = row.Cells(coluuid.Index).Value
                    End If
                    If x.visible Then
                        x.x2 = CType(Me.fbaseform.panelresult.Controls.Find("panel_" & uuid, True).First, Panel).Location.X
                        x.y2 = CType(Me.fbaseform.panelresult.Controls.Find("panel_" & uuid, True).First, Panel).Location.Y
                        x.width2 = CType(Me.fbaseform.panelresult.Controls.Find("panel_" & uuid, True).First, Panel).Size.Width
                        x.height2 = CType(Me.fbaseform.panelresult.Controls.Find("panel_" & uuid, True).First, Panel).Size.Height
                    Else
                        x.x2 = row.Cells(collocationx.Index).Value
                        x.y2 = row.Cells(collocationy.Index).Value
                        x.width2 = row.Cells(colwidth.Index).Value
                        x.height2 = row.Cells(colheight.Index).Value
                    End If
                    x.optionvalues = row.Cells(coloptionvalues.Index).Value
                    x.controltype = row.Cells(colfieldtype.Index).Value
                    x.defaultvalue = row.Cells(coldefaultvalue.Index).Value
                    x.labeldescription = row.Cells(collabeltext.Index).Value
                    If x.laboratorydetailsid = 0 Then
                        x.saveDetails(True)
                    Else
                        x.saveDetails(False)
                    End If
                Next
                Me.Close()
            End If
        ElseIf myFormaction = formaction.manageResult Then
            If MsgBox("Are you sure you want to save this examination result?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                Select Case labformatid
                    Case clsModel.LabFormats.WITHSIANDCONVENTIONALWITHCONVERSION
                        fBloodChem.save()
                    Case clsModel.LabFormats.CROSSMATCHING
                        fCrossmatching.save()
                        If Not fCrossmatching.issave Then
                            Exit Sub
                        End If
                    Case clsModel.LabFormats.RADIOLOGY, clsModel.LabFormats.ULTRASOUND, clsModel.LabFormats.ECGREPORT
                        frmRadiology.saveNow(Me.tsSave.Text)
                        If Not frmRadiology.isSave Then
                            Exit Sub
                        End If
                    Case Else
                        If fbaseform.cmbMedtech.SelectedIndex = -1 Or fbaseform.cmbPathologist.SelectedIndex = -1 Then
                            MsgBox("Medical Tehnologist and Pathologist are required!", MsgBoxStyle.Critical, msgboxTitle)
                            Exit Sub
                        End If
                        Dim x As New clsLaboratoryResult
                        x.Oldlaboratoryid = fbaseform.laboratoryresultid  'Used as primarykey
                        x.laboratoryid = Me.laboratoryid
                        x.admissionid = fbaseform.admissionid
                        x.patientrequestno = requestdetailno 'dtResult.Rows(0).Item("patientrequestno").ToString
                        x.itemcode = fbaseform.itemcode
                        x.labno = fbaseform.labexaminationno
                        x.dateencoded = Utility.GetServerDate()
                        x.datesubmitted = x.dateencoded
                        x.encodedby = modGlobal.userid
                        x.pathologist = fbaseform.cmbPathologist.SelectedValue
                        x.medtech = fbaseform.cmbMedtech.SelectedValue
                        x.medicaltechnologist = x.medtech
                        x.releasedby = modGlobal.userid
                        x.datereleased = "01/01/1990"
                        x.remarks = fbaseform.txtgridremarks.Text
                        If x.Oldlaboratoryid = 0 Then
                            x.Oldlaboratoryid = x.Save(True)
                            Call SaveLog("Laboratory", "New " & Me.laboratoryname & " result with request no.: " & x.patientrequestno & "", modGlobal.userid)
                        Else
                            x.soperation = 0
                            x.Save(False)
                            Call SaveLog("Laboratory", "Update " & Me.laboratoryname & " result with request no.: " & x.patientrequestno & "", modGlobal.userid)
                        End If
                        If x.Oldlaboratoryid = 0 Then
                            Exit Sub
                        End If
                        Dim xdetails As New clsLaboratoryResultDetails
                        xdetails.laboratoryresultid = x.Oldlaboratoryid
                        If Me.labformatid = clsModel.LabFormats.WITHSIORCONVENTIONALNOCONVERSION Then
                            fbaseform.dgvResult.EndEdit()
                            For Each row As DataGridViewRow In fbaseform.dgvResult.Rows
                                xdetails.laboratorydetailsid = row.Cells(fbaseform.collabdetailid.Index).Value
                                xdetails.Oldlaboratoryresultid = row.Cells(fbaseform.collabresultdetailid.Index).Value
                                xdetails.result = row.Cells(fbaseform.colresult.Index).Value
                                If xdetails.Oldlaboratoryresultid = 0 Then
                                    xdetails.Save(True)
                                Else
                                    xdetails.Save(False)
                                End If
                            Next
                            fbaseform.lock()
                        Else
                            For Each row As DataGridViewRow In Me.dgvResult.Rows
                                Dim uuid As String = row.Cells(collaboratorydetailsid.Index).Value
                                If uuid = "0" Then
                                    uuid = row.Cells(coluuid.Index).Value
                                End If
                                If row.Cells(colchk.Index).Value AndAlso clsModel.ConstrolTypes.isInputField(row.Cells(colfieldtype.Index).Value) AndAlso CType(Me.fbaseform.panelresult.Controls.Find("panel_" & uuid, True).First, Panel).Tag <> "1" Then
                                    xdetails.Oldlaboratoryresultid = row.Cells(collaboratoryresultdetailid.Index).Value
                                    xdetails.laboratorydetailsid = row.Cells(collaboratorydetailsid.Index).Value
                                    If row.Cells(colfieldtype.Index).Value = clsModel.ConstrolTypes.TextField Or row.Cells(colfieldtype.Index).Value = clsModel.ConstrolTypes.DoubleTextField Or
                                     row.Cells(colfieldtype.Index).Value = clsModel.ConstrolTypes.ResizableTextField Then
                                        xdetails.result = CType(Me.fbaseform.panelresult.Controls.Find("txt_" & uuid, True).First, TextBox).Text
                                    ElseIf row.Cells(colfieldtype.Index).Value = clsModel.ConstrolTypes.Dropdown Then
                                        If Me.laboratoryid = clsModel.LabFormats.NEWBORNSCREENING Then
                                            xdetails.result = CType(Me.fbaseform.panelresult.Controls.Find("cmb_" & uuid, True).First, ComboBox).SelectedValue
                                        Else
                                            xdetails.result = CType(Me.fbaseform.panelresult.Controls.Find("cmb_" & uuid, True).First, ComboBox).Text
                                        End If
                                    ElseIf row.Cells(colfieldtype.Index).Value = clsModel.ConstrolTypes.DateTimePicker Then
                                        xdetails.result = CType(Me.fbaseform.panelresult.Controls.Find("dtp_" & uuid, True).First, DateTimePicker).Value
                                    End If
                                    If xdetails.Oldlaboratoryresultid = 0 Then
                                        xdetails.Save(True)
                                    Else
                                        xdetails.Save(False)
                                    End If
                                End If
                            Next
                        End If

                End Select
                updateRequestStatus(4)
                MsgBox("Record successfully saved.", vbInformation, modGlobal.msgboxTitle)
                Me.Close()
            End If
        ElseIf myFormaction = formaction.Release Then
            If MsgBox("Are you sure you want to release this examination?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                updateRequestStatus(5)
                Me.myFormaction = formaction.View
                Me.tsSave.Visible = False
                Me.tsPrint.Visible = True
            End If
        End If

    End Sub
    Public Sub updateRequestStatus(ByVal status As Integer)
        Dim Myrequest As New clsExaminationUpshots
        Myrequest.status = status
        Myrequest.patientreqdetailno = requestdetailno
        Myrequest.save(False)
    End Sub
    Private Sub loadTemplateList()
        If Directory.Exists("templates") = False Then
            MsgBox("Unable to locate template folder", MsgBoxStyle.Critical, msgboxTitle)
            Exit Sub
        End If
        generateTS("templates", LoadFromTemplateToolStripMenuItem)
    End Sub
    Private Sub generateTS(foldername As String, tsitem As ToolStripMenuItem)
        Dim di As New IO.DirectoryInfo(foldername)
        Dim arrFolders As IO.DirectoryInfo() = di.GetDirectories()
        For Each folder In arrFolders
            If folder.Name <> "temp" Then
                Dim tsfolder As New ToolStripMenuItem
                tsfolder.Text = folder.Name
                tsfolder.Image = My.Resources.ic_folder_16
                generateTS(foldername & "/" & folder.Name, tsfolder)
                If tsfolder.DropDownItems.Count > 0 Then
                    tsitem.DropDownItems.Add(tsfolder)
                End If
            End If
        Next
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.rtf")
        For Each fi In aryFi
            Dim tstemplate As New ToolStripMenuItem
            tstemplate.Text = fi.Name.Replace(".rtf", "")
            tstemplate.Tag = fi.FullName
            tstemplate.Image = My.Resources.ic_template
            AddHandler tstemplate.Click, AddressOf tsTemplate_Click
            tsitem.DropDownItems.Add(tstemplate)
        Next
    End Sub
    Private Sub tsTemplate_Click(sender As System.Object, e As System.EventArgs)
        frmRadiology.txtResult.LoadFile(sender.Tag, RichTextBoxStreamType.RichText)
    End Sub
    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim f As New frmAddField(frmAddField.formstatus.add, 0, "", "", "", "", 0, 0, clsModel.ConstrolTypes.DefaultPanelWidth, clsModel.ConstrolTypes.DefaultPanelHeight)
        f.ShowDialog()
        If f.issave Then
            Dim uuid As String = Utility.GetRandomString
            fbaseform.AddControl(f.fieldlabel, f.fieldtype, New Point(0), f.fielddefaultval, f.fieldoptions, uuid, panelwidth:=0, panelheight:=0, defaultvalue:=f.fielddefaultval)
            Call Me.addRow(True, f.fieldname, f.fieldtype, f.fieldoptions, 0, uuid, New Point(0), f.fielddefaultval, 0, f.fieldlabel, 0, 0)
        End If
    End Sub

    Private Sub txtpanelheight_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpanelheight.TextChanged
        If afterload Then
            Try
                Call adjustPanelSize()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click
        Save()
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim style As BorderStyle = BorderStyle.None
        If btnpreview.Text = "Close Preview" Then
            style = BorderStyle.FixedSingle
            btnpreview.Text = "Preview Design"
            btnpreview.BackColor = Color.CornflowerBlue
        Else
            btnpreview.Text = "Close Preview"
            btnpreview.BackColor = Color.MistyRose
        End If
        For Each row As DataGridViewRow In Me.dgvResult.Rows
            If row.Cells(colchk.Index).Value = True Then
                Dim uuid As String = row.Cells(collaboratorydetailsid.Index).Value
                If row.Cells(collaboratorydetailsid.Index).Value = 0 Then
                    uuid = row.Cells(coluuid.Index).Value
                End If
                CType(Me.fbaseform.panelresult.Controls.Find("panel_" & uuid, True).First, Panel).BorderStyle = style
            End If
        Next
        Me.fbaseform.panelresult.BorderStyle = style
    End Sub

    Public Sub removeControl(ByVal ctrname As String, ByVal idx As Integer)
        Try
            Dim p As Panel = CType(Me.fbaseform.panelresult.Controls.Find(ctrname, True).First, Panel)
            Me.dgvResult.Rows(idx).Cells(collocationx.Index).Value = p.Location.X
            Me.dgvResult.Rows(idx).Cells(collocationy.Index).Value = p.Location.Y
            Me.dgvResult.Rows(idx).Cells(colwidth.Index).Value = p.Size.Width
            Me.dgvResult.Rows(idx).Cells(colheight.Index).Value = p.Size.Height
            Me.fbaseform.panelresult.Controls.RemoveByKey(ctrname)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgvResult_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResult.CellContentClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex = colfieldname.Index Then
                Call showFieldForm(Me.dgvResult.Rows(e.RowIndex))
                'With Me.dgvResult.Rows(e.RowIndex)
                '    Dim f As New frmAddField(frmAddField.formstatus.edit, .Cells(colfieldtype.Index).Value,
                '                         .Cells(colfieldname.Index).Value,
                '                         .Cells(coloptionvalues.Index).Value,
                '                         .Cells(coldefaultvalue.Index).Value,
                '                         .Cells(collabeltext.Index).Value)
                '    f.ShowDialog()
                '    If f.issave Then
                '        Dim uuid As String = .Cells(collaboratorydetailsid.Index).Value
                '        If .Cells(collaboratorydetailsid.Index).Value = 0 Then
                '            uuid = .Cells(coluuid.Index).Value
                '        End If
                '        removeControl("panel_" & uuid, e.RowIndex)
                '        fbaseform.AddControl(f.fieldlabel, f.fieldtype, New Point(.Cells(collocationx.Index).Value, .Cells(collocationy.Index).Value),
                '                             f.fielddefaultval, f.fieldoptions, uuid, .Cells(colwidth.Index).Value, .Cells(colheight.Index).Value, .Cells(coldefaultvalue.Index).Value)
                '        .Cells(colfieldname.Index).Value = f.fieldname
                '        .Cells(colfieldtype.Index).Value = f.fieldtype
                '        .Cells(colfieldtypedesc.Index).Value = clsModel.ConstrolTypes.getDescription(f.fieldtype)
                '        .Cells(coloptionvalues.Index).Value = f.fieldoptions
                '        .Cells(coldefaultvalue.Index).Value = f.fielddefaultval
                '        .Cells(collabeltext.Index).Value = f.fieldlabel
                '    End If
                'End With
            ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = colchk.Index Then
                Me.dgvResult.CommitEdit(DataGridViewDataErrorContexts.Commit)
                With Me.dgvResult.Rows(e.RowIndex)
                    Dim uuid As String = .Cells(collaboratorydetailsid.Index).Value
                    If .Cells(collaboratorydetailsid.Index).Value = 0 Then
                        uuid = .Cells(coluuid.Index).Value
                    End If
                    If .Cells(colchk.Index).Value = False Then
                        removeControl("panel_" & uuid, e.RowIndex)
                    Else
                        fbaseform.AddControl(.Cells(collabeltext.Index).Value, .Cells(colfieldtype.Index).Value,
                                              New Point(.Cells(collocationx.Index).Value, .Cells(collocationy.Index).Value), .Cells(coldefaultvalue.Index).Value,
                                              .Cells(collocationy.Index).Value, uuid, .Cells(colwidth.Index).Value, .Cells(colheight.Index).Value, .Cells(coldefaultvalue.Index).Value)
                    End If
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub onPanelDoubleClick(uuid As String, locx As Integer, locy As Integer, width As Integer, length As Integer)
        For Each row As DataGridViewRow In Me.dgvResult.Rows
            If row.Cells(collaboratorydetailsid.Index).Value.ToString = uuid Or row.Cells(coluuid.Index).Value = uuid Then
                row.Cells(collocationx.Index).Value = locx
                row.Cells(collocationy.Index).Value = locy
                row.Cells(colwidth.Index).Value = width
                row.Cells(colheight.Index).Value = length
                showFieldForm(row)
                Exit For
            End If
        Next
    End Sub
    Private Sub showFieldForm(row As DataGridViewRow)
        With row
            Dim f As New frmAddField(frmAddField.formstatus.edit, .Cells(colfieldtype.Index).Value,
                                 .Cells(colfieldname.Index).Value,
                                 .Cells(coloptionvalues.Index).Value,
                                 .Cells(coldefaultvalue.Index).Value,
                                 .Cells(collabeltext.Index).Value,
                                 .Cells(collocationx.Index).Value,
                                 .Cells(collocationy.Index).Value,
                                 .Cells(colwidth.Index).Value,
                                 .Cells(colheight.Index).Value)
            f.ShowDialog()
            If f.issave Then
                Dim uuid As String = .Cells(collaboratorydetailsid.Index).Value
                If .Cells(collaboratorydetailsid.Index).Value = 0 Then
                    uuid = .Cells(coluuid.Index).Value
                End If
                removeControl("panel_" & uuid, row.Index)
                .Cells(collocationx.Index).Value = f.fieldlocationx
                .Cells(collocationy.Index).Value = f.fieldlocationy
                .Cells(colwidth.Index).Value = f.fieldwidth
                .Cells(colheight.Index).Value = f.fieldheight
                fbaseform.AddControl(f.fieldlabel, f.fieldtype, New Point(.Cells(collocationx.Index).Value, .Cells(collocationy.Index).Value),
                                     f.fielddefaultval, f.fieldoptions, uuid, .Cells(colwidth.Index).Value, .Cells(colheight.Index).Value, .Cells(coldefaultvalue.Index).Value)
                .Cells(colfieldname.Index).Value = f.fieldname
                .Cells(colfieldtype.Index).Value = f.fieldtype
                .Cells(colfieldtypedesc.Index).Value = clsModel.ConstrolTypes.getDescription(f.fieldtype)
                .Cells(coloptionvalues.Index).Value = f.fieldoptions
                .Cells(coldefaultvalue.Index).Value = f.fielddefaultval
                .Cells(collabeltext.Index).Value = f.fieldlabel
            End If
        End With
    End Sub

    Private Sub tsPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsPrint.Click
        Select Case Me.labformatid
            Case clsModel.LabFormats.WITHSIANDCONVENTIONALWITHCONVERSION
                fBloodChem.DisplayPrintPreview()
            Case clsModel.LabFormats.CROSSMATCHING
                fCrossmatching.DisplayPrintPreview()
            Case clsModel.LabFormats.RADIOLOGY, clsModel.LabFormats.ULTRASOUND, clsModel.LabFormats.ECGREPORT
                frmRadiology.DisplayPrintPreview()
            Case Else
                Me.fbaseform.DisplayPrintPreview()
        End Select
    End Sub

    Private Sub SaveAsNewTemplateToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveAsNewTemplateToolStripMenuItem.Click
        If frmRadiology.txtResult.Text <> "" Then
            Dim fd As New SaveFileDialog()
            fd.RestoreDirectory = True
            fd.InitialDirectory = Application.StartupPath & "\templates"
            fd.Filter = "Rich Text Files(*.rtf)|*rtf;"
            If fd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim issave As Boolean = True
                Dim filename As String = fd.FileName
                If filename.Contains(".rtf") = False Then
                    filename = filename & ".rtf"
                End If
                Try
                    frmRadiology.txtResult.SaveFile(filename)
                Catch ex As Exception
                    MsgBox("Unable to save template. Existing template might be in use or you do not have access to folder.")
                End Try
            End If
        End If
    End Sub

    Private Sub ExternalTemplateManagementToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExternalTemplateManagementToolStripMenuItem.Click
        Process.Start(Application.StartupPath & "\templates")
    End Sub
End Class