﻿Public Class frmAddField
    Public field As clsModel.LabControl
    Public issave As Boolean

    Public myformstatus As formstatus
    Enum formstatus
        add = 0
        edit = 1
    End Enum

    Private erp As New ErrorProvider
    Public Sub New(myformstatus As formstatus, ByRef field As clsModel.LabControl)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.myformstatus = myformstatus
        Me.field = field
    End Sub
    Private Sub frmAddField_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadCombo()
        Me.cmbFieldType.SelectedValue = Me.field.ctrtype
        Me.txtfieldname.Text = Me.field.name 
        Me.txtvalue.Text = Me.field.optvalue
        If Me.field.ctrtype = clsModel.ControlTypes.ParagraphField Then
            Me.txtfieldlabelrtf.Rtf = Me.field.labeltext
        Else
            Me.txtLabelText.Text = Me.field.labeltext
        End If
        Me.cmbDefaultValue.Text = Me.field.defaultvalue
        Me.txtX.Text = Me.field.loc.X
        Me.txtY.Text = Me.field.loc.Y
        Me.txtwidth.Text = Me.field.panelwidth
        Me.txtheight.Text = Me.field.panelheight
        Me.txttexthighlight.Text = Me.field.texthighlight
    End Sub

    Private Sub loadCombo()
        With cmbFieldType
            .Items.Add(New DictionaryEntry("Text Field", clsModel.ControlTypes.TextField))
            .Items.Add(New DictionaryEntry("Double Text Field", clsModel.ControlTypes.DoubleTextField))
            .Items.Add(New DictionaryEntry("Resizable Text Field", clsModel.ControlTypes.ResizableTextField))
            .Items.Add(New DictionaryEntry("Paragraph Label", clsModel.ControlTypes.ParagraphField))
            .Items.Add(New DictionaryEntry("Dropdown Field", clsModel.ControlTypes.Dropdown))
            .Items.Add(New DictionaryEntry("Date & Time Picker", clsModel.ControlTypes.DateTimePicker))
            .Items.Add(New DictionaryEntry("Label H1 (Bold)", clsModel.ControlTypes.LabelH1))
            .Items.Add(New DictionaryEntry("Label H2 (Bold)", clsModel.ControlTypes.LabelH2))
            .Items.Add(New DictionaryEntry("Label H3 (Bold)", clsModel.ControlTypes.LabelH3))
            .Items.Add(New DictionaryEntry("Label H4", clsModel.ControlTypes.LabelH4))
            .Items.Add(New DictionaryEntry("Label H5", clsModel.ControlTypes.LabelH5))
            .DisplayMember = "Key"
            .ValueMember = "Value"
            .DataSource = .Items
            .SelectedIndex = 0
        End With
        With cmbDefaultValue
            .DataSource = clsLaboratoryResult.genericcls(15, "")
            .DisplayMember = "defaultval"
            .ValueMember = "defaultval"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click
        Dim isvalid = True
        erp.SetError(Me.cmbFieldType, "")
        If Me.cmbFieldType.SelectedIndex = -1 Then
            erp.SetError(Me.cmbFieldType, "This field is required")
            isvalid = False
        End If
        erp.SetError(Me.txtfieldname, "")
        If Me.txtfieldname.Text = "" Then
            erp.SetError(Me.txtfieldname, "This field is required")
            isvalid = False
        End If
        erp.SetError(Me.txtLabelText, "")
        If Me.cmbFieldType.SelectedIndex >= 0 AndAlso clsModel.ControlTypes.isLabel(Me.cmbFieldType.SelectedValue) AndAlso Me.txtLabelText.Text = "" Then
            erp.SetError(Me.txtLabelText, "This field is required")
            isvalid = False
        End If
        If Not isvalid Then
            Return
        End If
        Me.issave = True
        Me.field.ctrtype = Me.cmbFieldType.SelectedValue
        Me.field.name = Me.txtfieldname.Text
        Me.field.optvalue = Me.txtvalue.Text
        Me.field.defaultvalue = Me.cmbDefaultValue.Text
        If Me.field.ctrtype = clsModel.ControlTypes.ParagraphField Then
            Me.field.labeltext = Me.txtfieldlabelrtf.Rtf
        Else
            Me.field.labeltext = Me.txtLabelText.Text()
        End If
        Me.field.loc.X = Val(Me.txtX.Text)
        Me.field.loc.Y = Val(Me.txtY.Text)
        Me.field.panelwidth = Val(Me.txtwidth.Text)
        Me.field.panelheight = Val(Me.txtheight.Text)
        Me.field.texthighlight = txttexthighlight.Text
        Me.Close()
    End Sub

    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub cmbFieldType_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbFieldType.SelectedValueChanged
        If cmbFieldType.SelectedValue = clsModel.ControlTypes.DoubleTextField Then
            Me.txtheight.Enabled = True
        ElseIf cmbFieldType.SelectedValue = clsModel.ControlTypes.ResizableTextField Then
            Me.txtheight.Enabled = True
        Else
            Me.txtheight.Text = clsModel.ControlTypes.DefaultPanelHeight
            Me.txtheight.Enabled = False
        End If
        If cmbFieldType.SelectedValue = clsModel.ControlTypes.ParagraphField Then
            Me.txtheight.Enabled = True
            Me.paneltextrtf.Visible = True
            Me.paneltextreg.Visible = False
        Else
            Me.paneltextrtf.Visible = False
            Me.paneltextreg.Visible = True
        End If
    End Sub

    Private Sub txtfieldlabelrtf_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtfieldlabelrtf.TextChanged
        If txtfieldlabelrtf.Text = "" Then
            txtfieldlabelrtf.Clear()
        End If
    End Sub

    Private Sub lblseeavailablecolors_Click(sender As System.Object, e As System.EventArgs) Handles lblseeavailablecolors.Click
        Dim f As New frmAvailableColors
        f.ShowDialog()
    End Sub
End Class