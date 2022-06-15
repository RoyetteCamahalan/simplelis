Imports System.Drawing.Drawing2D
'***********
'*    Author: Ronald Jumao-as
'*    Date Created: 06-05-12
'*
'**********

Imports System.Drawing.Imaging
Imports System.IO
Public Class frmResultBaseDesign
#Region "Variables"
    Dim dtHospitalInfo As New DataTable

    '    'Royette 2021-07-29
    Private afterload As Boolean
    Private isformedit As Boolean
    Private laboratoryid As Long
    Private labname As String
    Private requestdetailno As Long
    Private medtech As Long = 0
    Private patho As Long = 0
    Private dtPatientDetails As New DataTable
    Private dtNewBornResults As New DataTable
    Private isLock As Boolean
    Private baseForm As frmResultDesigner

    Public admissionid As Long
    Public itemcode As String
    Public laboratoryresultid As Long
    Public labexaminationno As Long

    'default grid height
    Private rowheight As Integer = 22

#End Region
#Region "Constructor"
    Public Sub New(baseForm As frmResultDesigner, ByVal isformedit As Boolean, ByVal laboratoryid As Long, ByVal labname As String, ByVal isLock As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.isformedit = isformedit
        Me.laboratoryid = laboratoryid
        Me.labname = labname
        Me.isLock = isLock
        Me.baseForm = baseForm
    End Sub

#End Region
#Region "Events"

    Private Sub frmMiscellaneous_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = getLabname()
        Me.lblMisc.Text = Me.getLabname
        dtHospitalInfo = clsLaboratoryResult.getHospitalInfo()
        Me.lblHeader.Text = dtHospitalInfo.Rows(0).Item("Hospital").ToString()
        Me.lblAddress.Text = dtHospitalInfo.Rows(0).Item("Address3").ToString()
        Me.lablTelNo.Text = dtHospitalInfo.Rows(0).Item("Telephone").ToString()
        Try
            Dim tempphoto As Byte() = dtHospitalInfo.Rows(0).Item("hospitallogo")
            If IsDBNull(dtHospitalInfo.Rows(0).Item("hospitallogo")) Or tempphoto.Length = 0 Then
                pctrLogo.Image = Nothing
            Else
                pctrLogo.Image = Utility.convertImage(dtHospitalInfo.Rows(0).Item("hospitallogo")) 'image here
            End If
        Catch ex As Exception
        End Try
        If Me.laboratoryid = clsModel.LabFormats.ECGREPORT Then
            Me.lblpathodesignation.Text = "Cardiologist"
        ElseIf Me.laboratoryid = clsModel.LabFormats.NEWBORNSCREENING Then
            Me.panelnewborn.Visible = True
            Me.lblpathodesignation.Text = "Pediatrician"
            Me.dtNewBornResults = clsNewBornScreening.getNBSresults()
        End If
        Call LoadCombo()
    End Sub
#End Region

#Region "Methods"
    Private Function getLabname() As String
        If Me.labname = "" Then
            Return "Laboratory"
        End If
        Return Me.labname
    End Function

    Public Sub loadRequestDetails(ByVal requestdetailno As Long)
        Me.requestdetailno = requestdetailno
        dtPatientDetails = clsLaboratoryResult.genericcls(14, requestdetailno)
        Me.admissionid = Utility.NullToZero(dtPatientDetails.Rows(0).Item("admissionid"))
        Me.laboratoryresultid = Utility.NullToZero(dtPatientDetails.Rows(0).Item("laboratoryresultid"))
        Me.labexaminationno = Utility.NullToZero(dtPatientDetails.Rows(0).Item("labexaminationno"))
        Me.itemcode = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("itemcode").ToString)
        If Me.labname = "" And Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("itemspecs")) <> "" Then
            Me.labname = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("itemspecs"))
            Me.lblMisc.Text = getLabname()
        End If
        Me.txtRequestedby.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("requestedby").ToString)
        Me.txtPatientName.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("patient").ToString)
        Me.txtAge.Text = dtPatientDetails.Rows(0).Item("age").ToString
        Me.txtGender.Text = dtPatientDetails.Rows(0).Item("gender").ToString

        Me.lblMisc.Text = getLabname()
        Me.lbltransdate.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("daterequested")).ToString(modGlobal.defaultdateformat)
        Me.lbltranstime.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("daterequested")).ToString(modGlobal.defaulttimeformat)
        Me.lbldateencoded.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("resultdatesubmitted")).ToString(modGlobal.defaultdateformat)
        Me.lbltimeencoded.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("resultdatesubmitted")).ToString(modGlobal.defaulttimeformat)
        Me.medtech = dtPatientDetails.Rows(0).Item("medicaltechnologist")
        Me.patho = dtPatientDetails.Rows(0).Item("pathologist")
        Me.txtmother.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("mothername").ToString)
        Me.txtcontactno.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("mobileno").ToString)
        Me.lblptno.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("ptno").ToString)
        Me.lblpatientaddress.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("homeaddress").ToString)
    End Sub
    Private Sub LoadCombo()
        afterload = False
        If Me.laboratoryid = clsModel.LabFormats.ECGREPORT Then
            Me.cmbPathologist.DataSource = clsECGReport.getCardio()
            Me.cmbPathologist.DisplayMember = "cname"
            Me.cmbPathologist.ValueMember = "employeeid"
        ElseIf Me.laboratoryid = clsModel.LabFormats.NEWBORNSCREENING Then
            Me.cmbPathologist.DataSource = clsNewBornScreening.getPediatrician()
            Me.cmbPathologist.DisplayMember = "cname"
            Me.cmbPathologist.ValueMember = "employeeid"
        Else
            Me.cmbPathologist.DataSource = clsLaboratoryResult.getPathologist("777")
            Me.cmbPathologist.DisplayMember = "radiologist"
            Me.cmbPathologist.ValueMember = "employeeid"
        End If
        Me.cmbPathologist.SelectedIndex = -1
        afterload = True
        If patho > 0 Then
            Me.cmbPathologist.SelectedValue = patho
        ElseIf Me.cmbPathologist.Items.Count > 0 Then
            Me.cmbPathologist.SelectedIndex = 0
        End If

        afterload = False
        Me.cmbMedtech.DataSource = clsLaboratoryResult.getPathologist("666")
        Me.cmbMedtech.DisplayMember = "radiologist"
        Me.cmbMedtech.ValueMember = "employeeid"
        Me.cmbMedtech.SelectedIndex = -1
        afterload = True
        If medtech > 0 Then
            Me.cmbMedtech.SelectedValue = medtech
        ElseIf Me.cmbMedtech.Items.Count > 0 Then
            Me.cmbMedtech.SelectedValue = modGlobal.userid
        End If

    End Sub
    Public Sub AddControl(ByVal labeltext As String, ByVal ctrtype As Integer, ByVal loc As Point, ByVal value As String,
                           ByVal optvalue As String, ByVal uuid As String,
                           ByVal panelwidth As Long, panelheight As Long, ByVal defaultvalue As String, Optional ByVal islock As Boolean = False)
        Dim panel As New Panel()
        If Not isformedit AndAlso defaultvalue <> "" AndAlso dtPatientDetails.Columns.Contains(defaultvalue) Then
            value = Me.dtPatientDetails.Rows(0).Item(defaultvalue).ToString
            islock = True
            panel.Tag = "1" 'used to disregard lock fields
        End If
        panel.Size = New Size(IIf(panelwidth = 0, clsModel.ConstrolTypes.DefaultPanelWidth, panelwidth), clsModel.ConstrolTypes.DefaultPanelHeight)
        If Me.isformedit Then
            panel.BorderStyle = BorderStyle.FixedSingle
        End If
        panel.Font = New Font("Cambria", 9)
        panel.Name = "panel_" & uuid
        Me.panelresult.Controls.Add(panel)
        If ctrtype = clsModel.ConstrolTypes.Dropdown Then
            Dim locleft As Integer = 137
            If labeltext = "" Then
                locleft = 19
                'panel.Width = 202
            Else
                Dim lbl As New Label
                lbl.Text = labeltext
                lbl.AutoSize = False
                lbl.Width = 118
                lbl.TextAlign = ContentAlignment.MiddleRight
                panel.Controls.Add(lbl)

                lbl.Left = 19
                lbl.Top = 2
                lbl.Name = "lbl_" & uuid
                If Me.isformedit Then
                    AddHandler lbl.DoubleClick, AddressOf label_MouseDoubleClick
                End If
            End If

            If islock Then
                Dim lbldetail As New Label
                lbldetail.AutoSize = False
                lbldetail.Size = New Size(panel.Width - locleft - 3, 20)
                lbldetail.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                lbldetail.Font = New Font("Cambria", 9, FontStyle.Bold)
                lbldetail.TextAlign = ContentAlignment.MiddleCenter
                If Me.laboratoryid = clsModel.LabFormats.NEWBORNSCREENING AndAlso labeltext.ToLower().Contains("result") Then
                    For Each row As DataRow In Me.dtNewBornResults.Rows
                        If row.Item("newbornscreeningresultid").ToString = value Then
                            value = row.Item("results")
                            Exit For
                        End If
                    Next
                End If
                lbldetail.Text = value
                panel.Controls.Add(lbldetail)

                lbldetail.Left = locleft
                lbldetail.Top = 4
                Dim line1 As New PowerPacks.LineShape
                line1.X1 = lbldetail.Location.X
                line1.X2 = lbldetail.Location.X + lbldetail.Width
                line1.Y1 = lbldetail.Location.Y + lbldetail.Height
                line1.Y2 = lbldetail.Location.Y + lbldetail.Height
                Dim sh As New PowerPacks.ShapeContainer
                sh.Margin = New System.Windows.Forms.Padding(0)
                sh.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {line1})
                sh.Size = New System.Drawing.Size(lbldetail.Width, 24)
                panel.Controls.Add(sh)
            Else
                Dim cmb As New ComboBox
                cmb.Name = "cmb_" & uuid
                cmb.Size = New Size(panel.Width - locleft - 3, 20)
                cmb.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                panel.Controls.Add(cmb)
                If Me.laboratoryid = clsModel.LabFormats.NEWBORNSCREENING AndAlso labeltext.ToLower().Contains("result") Then
                    cmb.DropDownStyle = ComboBoxStyle.DropDownList
                    cmb.DataSource = Me.dtNewBornResults
                    cmb.ValueMember = "newbornscreeningresultid"
                    cmb.DisplayMember = "results"
                    cmb.SelectedValue = Val(value)
                Else
                    Dim opt As String() = optvalue.Split(";")
                    For Each str As String In opt
                        cmb.Items.Add(str)
                    Next
                    cmb.Text = value
                End If
                cmb.Left = locleft
                cmb.Top = 1
            End If
        ElseIf ctrtype = clsModel.ConstrolTypes.DateTimePicker Then
            Dim locleft As Integer = 137
            If labeltext = "" Then
                locleft = 19
                'panel.Width = 202
            Else
                Dim lbl As New Label
                lbl.Text = labeltext
                lbl.AutoSize = False
                lbl.Width = 118
                lbl.TextAlign = ContentAlignment.MiddleRight
                panel.Controls.Add(lbl)

                lbl.Left = 19
                lbl.Top = 2
                lbl.Name = "lbl_" & uuid

                If Me.isformedit Then
                    AddHandler lbl.DoubleClick, AddressOf label_MouseDoubleClick
                End If
            End If

            If islock Then
                Dim lbldetail As New Label
                lbldetail.AutoSize = False
                lbldetail.Size = New Size(panel.Width - locleft - 3, 20)
                lbldetail.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                lbldetail.Font = New Font("Cambria", 9, FontStyle.Bold)
                lbldetail.TextAlign = ContentAlignment.MiddleCenter
                Try
                    lbldetail.Text = CDate(value).ToString(clsModel.ConstrolTypes.yyyyMMddhhmmtt)
                Catch ex As Exception
                    lbldetail.Text = ""
                End Try
                panel.Controls.Add(lbldetail)

                lbldetail.Left = locleft
                lbldetail.Top = 4
                Dim line1 As New PowerPacks.LineShape
                line1.X1 = lbldetail.Location.X
                line1.X2 = lbldetail.Location.X + lbldetail.Width
                line1.Y1 = lbldetail.Location.Y + lbldetail.Height
                line1.Y2 = lbldetail.Location.Y + lbldetail.Height
                Dim sh As New PowerPacks.ShapeContainer
                sh.Margin = New System.Windows.Forms.Padding(0)
                sh.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {line1})
                sh.Size = New System.Drawing.Size(lbldetail.Width, 24)
                panel.Controls.Add(sh)
            Else
                Dim dtp As New DateTimePicker
                dtp.Size = New Size(panel.Width - locleft - 3, 20)
                dtp.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                dtp.Format = DateTimePickerFormat.Custom
                dtp.CustomFormat = clsModel.ConstrolTypes.yyyyMMddhhmmtt
                Try
                    dtp.Value = CDate(value)
                Catch ex As Exception

                End Try
                panel.Controls.Add(dtp)

                dtp.Left = locleft
                dtp.Top = 1
                dtp.Name = "dtp_" & uuid
            End If
        ElseIf ctrtype = clsModel.ConstrolTypes.LabelH1 Or ctrtype = clsModel.ConstrolTypes.LabelH2 Or ctrtype = clsModel.ConstrolTypes.LabelH3 Or
             ctrtype = clsModel.ConstrolTypes.LabelH4 Or ctrtype = clsModel.ConstrolTypes.LabelH5 Then
            Dim lbl As New Label
            lbl.Text = labeltext
            lbl.AutoSize = True
            lbl.TextAlign = ContentAlignment.MiddleCenter

            If ctrtype = clsModel.ConstrolTypes.LabelH1 Then
                panel.Font = New Font("Cambria", 14, FontStyle.Bold)
            ElseIf ctrtype = clsModel.ConstrolTypes.LabelH2 Then
                panel.Font = New Font("Cambria", 12, FontStyle.Bold)
            ElseIf ctrtype = clsModel.ConstrolTypes.LabelH3 Then
                panel.Font = New Font("Cambria", 10, FontStyle.Bold)
            ElseIf ctrtype = clsModel.ConstrolTypes.LabelH4 Then
                panel.Font = New Font("Cambria", 10, FontStyle.Regular)
            ElseIf ctrtype = clsModel.ConstrolTypes.LabelH5 Then
                panel.Font = New Font("Cambria", 8, FontStyle.Regular)
            End If
            panel.Controls.Add(lbl)
            panel.Width = lbl.Width + 2

            lbl.Left = 5
            lbl.Top = 5
            lbl.Name = "lbl_" & uuid
            If Me.isformedit Then
                AddHandler lbl.DoubleClick, AddressOf label_MouseDoubleClick
            End If
        ElseIf ctrtype = clsModel.ConstrolTypes.DoubleTextField Then
            panel.Height = clsModel.ConstrolTypes.DoubleTextFieldHeight
            Dim locleft As Integer = 137
            If labeltext = "" Then
                locleft = 19
                panel.Width = 202
            Else
                Dim lbl As New Label
                lbl.Text = labeltext
                lbl.AutoSize = False
                lbl.Width = 118
                lbl.TextAlign = ContentAlignment.MiddleRight
                panel.Controls.Add(lbl)
                lbl.Left = 19
                lbl.Top = 2
                lbl.Name = "lbl_" & uuid
                If Me.isformedit Then
                    AddHandler lbl.DoubleClick, AddressOf label_MouseDoubleClick
                End If
            End If
            If islock Then
                Dim lbldetail As New Label
                lbldetail.AutoSize = False
                lbldetail.Size = New Size(180, 40)
                lbldetail.TextAlign = ContentAlignment.MiddleCenter
                lbldetail.Text = value
                panel.Controls.Add(lbldetail)

                lbldetail.Left = locleft
                lbldetail.Top = 4
                Dim line1 As New PowerPacks.LineShape
                line1.X1 = lbldetail.Location.X
                line1.X2 = lbldetail.Location.X + lbldetail.Width
                line1.Y1 = lbldetail.Location.Y + lbldetail.Height
                line1.Y2 = lbldetail.Location.Y + lbldetail.Height
                Dim sh As New PowerPacks.ShapeContainer
                sh.Margin = New System.Windows.Forms.Padding(0)
                sh.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {line1})
                sh.Size = New System.Drawing.Size(lbldetail.Width, 24)
                panel.Controls.Add(sh)
            Else
                Dim txt As New TextBox
                txt.Multiline = True
                txt.Size = New Size(180, 40)
                panel.Controls.Add(txt)
                txt.Text = value
                txt.Left = locleft
                txt.Top = 1
                txt.Name = "txt_" & uuid
            End If
        ElseIf ctrtype = clsModel.ConstrolTypes.ResizableTextField Then
            panel.Height = IIf(panelheight = 0, clsModel.ConstrolTypes.ResizableTextFieldHeight, panelheight)
            Dim loctop As Integer = 20
            Dim locl As Integer = 19
            If labeltext = "" Then
                loctop = 1
            Else
                Dim lbl As New Label
                lbl.AutoSize = True
                lbl.Text = labeltext
                lbl.Width = 118
                lbl.TextAlign = ContentAlignment.MiddleLeft
                lbl.Font = New Font("Cambria", 10, FontStyle.Bold)
                panel.Controls.Add(lbl)
                lbl.Left = 18
                lbl.Top = 2
                lbl.Name = "lbl_" & uuid

                If Me.isformedit Then
                    AddHandler lbl.DoubleClick, AddressOf label_MouseDoubleClick
                End If
            End If

            Dim txt As New TextBox
            txt.Multiline = True
            txt.Size = New Size(panel.Width - locl - 4, panel.Height - loctop - 4)
            txt.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            panel.Controls.Add(txt)
            txt.Text = value
            txt.Left = locl
            txt.Top = loctop
            txt.Name = "txt_" & uuid
            txt.BringToFront()
            If islock Then
                txt.BackColor = Color.White
                txt.ReadOnly = True
                txt.BorderStyle = BorderStyle.None
            End If
        ElseIf ctrtype = clsModel.ConstrolTypes.ParagraphField Then
            panel.Height = IIf(panelheight = 0, clsModel.ConstrolTypes.ResizableTextFieldHeight, panelheight)
            Dim loctop As Integer = 20
            Dim locl As Integer = 19

            Dim txt As New RichTextBox
            txt.Size = New Size(panel.Width - locl - 4, panel.Height - loctop - 4)
            txt.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            panel.Controls.Add(txt)

            txt.Rtf = labeltext
            txt.Left = locl
            txt.Top = loctop
            txt.Name = "txt_" & uuid
            txt.BringToFront()
            'If islock Then
            txt.BackColor = Color.White
            txt.ReadOnly = True
            txt.BorderStyle = BorderStyle.None
            'End If
        Else
            Dim locl As Integer = 137
            If labeltext = "" Then
                locl = 19
                'panel.Width = 202
            Else
                Dim lbl As New Label
                lbl.Text = labeltext
                lbl.AutoSize = False
                lbl.Width = 118
                lbl.TextAlign = ContentAlignment.MiddleRight
                panel.Controls.Add(lbl)
                lbl.Left = 19
                lbl.Top = 2
                lbl.Name = "lbl_" & uuid
                If Me.isformedit Then
                    AddHandler lbl.DoubleClick, AddressOf label_MouseDoubleClick
                End If
            End If

            If islock Then
                Dim lbldetail As New Label
                lbldetail.AutoSize = False
                lbldetail.Size = New Size(panel.Width - locl - 3, 20)
                lbldetail.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                lbldetail.TextAlign = ContentAlignment.MiddleCenter
                lbldetail.Text = value
                panel.Controls.Add(lbldetail)

                lbldetail.Left = locl
                lbldetail.Top = 4
                Dim line1 As New PowerPacks.LineShape
                line1.X1 = lbldetail.Location.X
                line1.X2 = lbldetail.Location.X + lbldetail.Width
                line1.Y1 = lbldetail.Location.Y + lbldetail.Height
                line1.Y2 = lbldetail.Location.Y + lbldetail.Height
                Dim sh As New PowerPacks.ShapeContainer
                sh.Margin = New System.Windows.Forms.Padding(0)
                sh.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {line1})
                sh.Size = New System.Drawing.Size(lbldetail.Width, 24)
                panel.Controls.Add(sh)
            Else
                Dim txt As New TextBox
                txt.Size = New Size(panel.Width - locl - 3, 20)
                txt.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                panel.Controls.Add(txt)
                txt.Text = value
                txt.Left = locl
                txt.Top = 1
                txt.Name = "txt_" & uuid
            End If
            'Dim rezi As ResizeableControl = New ResizeableControl(txt)
        End If
        panel.Location = loc
        If Me.isformedit Then
            AddHandler panel.DoubleClick, AddressOf panel_MouseDoubleClick
            Dim rezi2 As ResizeableControl = New ResizeableControl(panel)
        End If
    End Sub
    Private Sub panel_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        Dim panel As Control = CType(sender, Control)
        Me.baseForm.onPanelDoubleClick(panel.Name.Replace("panel_", ""), panel.Location.X, panel.Location.Y, panel.Width, panel.Height)
    End Sub
    Private Sub label_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        Dim panel As Control = CType(sender, Control).Parent
        Me.baseForm.onPanelDoubleClick(panel.Name.Replace("panel_", ""), panel.Location.X, panel.Location.Y, panel.Width, panel.Height)
    End Sub
    Private Sub getEmployeeInfo(ByVal employeeid As String, ByVal ispatho As Boolean)
        Dim dt As DataTable = clsRadiology.genericcls(8, employeeid)
        If dt.Rows.Count = 0 Then
            Exit Sub
        End If
        If ispatho Then 'Patho
            Me.lblpatho.Text = Me.cmbPathologist.Text
            Me.lblpatholicense.Text = "License No. " & dt.Rows(0).Item("prcno")
            If Utility.NullToEmptyString(dt.Rows(0).Item("designation")) = "" Then
                Me.lblpathodesignation.Text = "Clinical Pathologist"
            Else
                Me.lblpathodesignation.Text = dt.Rows(0).Item("designation")
            End If
            If Me.isLock AndAlso Utility.getReference(clsModel.ReferenceKeys.lab_showpatho_sig) > 0 Then
                Try
                    Dim tempphoto As Byte() = dt.Rows(0).Item("usersign")
                    If IsDBNull(dt.Rows(0).Item("usersign")) Or tempphoto.Length = 0 Then
                        panelpatho.BackgroundImage = Nothing
                    Else
                        panelpatho.BackgroundImage = Utility.convertImage(dt.Rows(0).Item("usersign")) 'image here
                    End If
                Catch ex As Exception
                End Try
            Else
                panelpatho.BackgroundImage = Nothing
            End If
        Else 'Medtech
            Me.lblmedtech.Text = Me.cmbMedtech.Text
            Me.lblmedtechlicense.Text = "License No. " & dt.Rows(0).Item("prcno")
            If Utility.NullToEmptyString(dt.Rows(0).Item("designation")) = "" Then
                Me.lblmedtechdesignation.Text = "Medical Technologist"
            Else
                Me.lblmedtechdesignation.Text = dt.Rows(0).Item("designation")
            End If
            If Me.isLock AndAlso Utility.getReference(clsModel.ReferenceKeys.lab_showmedtech_sig) > 0 Then
                Try
                    Dim tempphoto As Byte() = dt.Rows(0).Item("usersign")
                    If IsDBNull(dt.Rows(0).Item("usersign")) Or tempphoto.Length = 0 Then
                        panelmedtech.BackgroundImage = Nothing
                    Else
                        panelmedtech.BackgroundImage = Utility.convertImage(dt.Rows(0).Item("usersign")) 'image here
                    End If
                Catch ex As Exception
                End Try
            Else
                panelmedtech.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Public Sub DisplayPrintPreview()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Text = ""
        Call clsadmissiondocuments.SaveLabResultImage(requestdetailno, Me.admissionid, GetFormImage(True), "RadLab_" & Me.labname & "_")
        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MiscPrintDocu.PrinterSettings = PrintDialog1.PrinterSettings
            MiscPrintDocu.Print()
        End If

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.Text = getLabname()
    End Sub
    Private Function GetFormImage(ByVal include_borders As Boolean) As Bitmap
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.Text = ""
        ' Make the bitmap.
        Dim wid As Integer = Me.Width
        Dim hgt As Integer = Me.Height
        Dim bm As New Bitmap(wid, hgt)
        ' Draw the form onto the bitmap.
        Me.DrawToBitmap(bm, New Rectangle(0, 0, wid, hgt))
        ' Make a smaller bitmap without borders.
        wid = Me.ClientSize.Width
        hgt = Me.ClientSize.Height
        Dim bm2 As New Bitmap(wid, hgt)
        ' Get the offset from the window's corner to its client
        ' area's corner.
        Dim pt As New Point(0, 0)
        pt = PointToScreen(pt)
        Dim dx As Integer = pt.X - Me.Left
        Dim dy As Integer = pt.Y - Me.Top
        ' Copy the part of the original bitmap that we want
        ' into the bitmap.
        Dim gr As Graphics = Graphics.FromImage(bm2)
        gr.DrawImage(bm, 0, 0, New Rectangle(dx, dy, wid, hgt), GraphicsUnit.Pixel)
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        'Me.Text = Labname
        Return bm
    End Function
#End Region

    Private Sub cmbMedtech_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbMedtech.SelectedValueChanged
        If afterload AndAlso cmbMedtech.SelectedIndex >= 0 Then
            Call getEmployeeInfo(cmbMedtech.SelectedValue, False)
        End If
    End Sub

    Private Sub txtPathologist_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbPathologist.SelectedValueChanged
        If afterload AndAlso cmbPathologist.SelectedIndex >= 0 Then
            Call getEmployeeInfo(cmbPathologist.SelectedValue, True)
        End If
    End Sub

    Private Sub MiscPrintDocu_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles MiscPrintDocu.PrintPage
        e.Graphics.DrawImage(GetFormImage(False), New Point(15, 0))
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        Dim f As New frmManageResultParams
        f.labid = Me.laboratoryid
        f.Labname = Me.labname
        f.hasSIvalue = False
        f.ShowDialog()
        If f.issave Then
            Dim dt As DataTable = clsExamination.getLabdetails(Me.laboratoryid)
            dt.Columns.Add("result")
            dt.Columns.Add("laboratoryresultdetailsid")
            For i As Integer = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To Me.dgvResult.Rows.Count - 1
                    If dt.Rows(i).Item("laboratorydetailsid") = Me.dgvResult.Rows(j).Cells(collabdetailid.Index).Value Then
                        dt.Rows(i).Item("result") = Utility.NullToEmptyString(Me.dgvResult.Rows(j).Cells(colresult.Index).Value)
                        dt.Rows(i).Item("laboratoryresultdetailsid") = Utility.NullToZero(Me.dgvResult.Rows(j).Cells(collabresultdetailid.Index).Value)
                        Me.dgvResult.Rows.RemoveAt(j)
                        reduceForm()
                        Exit For
                    End If
                Next
            Next
            For j As Integer = Me.dgvResult.Rows.Count - 1 To 0 Step -1
                Me.dgvResult.Rows.RemoveAt(j)
                reduceForm()
            Next
            For Each row As DataRow In dt.Rows
                If row.Item("visible") Then
                    dgvResult.Rows.Add(1)
                    Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(collabdetailid.Index).Value = row.Item("laboratorydetailsid")
                    Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colparameter.Index).Value = row.Item("description")
                    Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colref.Index).Value = row.Item("normalvalues")
                    Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colresult.Index).Value = Utility.NullToEmptyString(row.Item("result"))
                    Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(collabresultdetailid.Index).Value = Utility.NullToZero(row.Item("laboratoryresultdetailsid"))
                    Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colunits.Index).Value = row.Item("unit")
                    Call adjustForm()
                End If
            Next
        End If
    End Sub

    Public Sub adjustForm()
        If Me.dgvResult.Rows.Count > 15 Then
            Exit Sub
        End If
        Me.dgvResult.Height = Me.dgvResult.Height + rowheight
        Me.panelresultgrid.Height = Me.panelresultgrid.Height + rowheight
        Me.panelmain.Height = Me.panelmain.Height + rowheight
        Me.Height = Me.Height + rowheight
    End Sub
    Public Sub reduceForm()
        If Me.dgvResult.Rows.Count > 15 Or Me.dgvResult.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.dgvResult.Height = Me.dgvResult.Height - rowheight
        Me.panelresultgrid.Height = Me.panelresultgrid.Height - rowheight
        Me.panelmain.Height = Me.panelmain.Height - rowheight
        Me.Height = Me.Height - rowheight
    End Sub

    Public Sub lock()
        Dim dtdatenow As Date = Utility.GetServerDate()
        Me.lblprinttime.Text = dtdatenow.ToString(modGlobal.defaulttimeformat)
        Me.lblprintdate.Text = dtdatenow.ToString(modGlobal.defaultdateformat)
        Me.cmbPathologist.Visible = False
        Me.cmbMedtech.Visible = False
        Me.lblpatho.Visible = True
        Me.lblmedtech.Visible = True
        If panelresultgrid.Visible = True Then
            For i As Integer = Me.dgvResult.Rows.Count - 1 To 0 Step -1
                If Utility.NullToEmptyString(Me.dgvResult.Rows(i).Cells(colresult.Index).Value) = "" Then
                    Me.dgvResult.Rows.RemoveAt(i)
                    Call reduceForm()
                Else
                    Me.dgvResult.Rows(i).Cells(colunits.Index).Value = Me.dgvResult.Rows(i).Cells(colresult.Index).Value & " " & Me.dgvResult.Rows(i).Cells(colunits.Index).Value
                End If
            Next
            Me.panelmanageparams.Visible = False
            Me.dgvResult.Columns(colunits.Index).Width = CInt(Me.dgvResult.Columns(colunits.Index).Width + (Me.dgvResult.Columns(colresult.Index).Width / 2))
            Me.dgvResult.Columns(colresult.Index).Visible = False
            Me.dgvResult.Columns(colunits.Index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvResult.Columns(colunits.Index).DefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)
            Me.dgvResult.Columns(colunits.Index).HeaderText = "Result"
        End If
    End Sub
End Class