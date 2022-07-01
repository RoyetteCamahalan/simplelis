Public Class frmAddField
    Public fieldtype As Integer
    Public fieldname As String
    Public fieldoptions As String
    Public fielddefaultval As String
    Public fieldlabel As String
    Public fieldlocationx As Integer
    Public fieldlocationy As Integer
    Public fieldwidth As Integer
    Public fieldheight As Integer
    Public fieldhighlight As String
    Public issave As Boolean

    Public myformstatus As formstatus
    Enum formstatus
        add = 0
        edit = 1
    End Enum

    Private erp As New ErrorProvider
    Public Sub New(ByVal myformstatus As formstatus, ByVal fieldtype As Integer, ByVal fieldname As String, ByVal fieldoptions As String,
                   ByVal fielddefault As String, ByVal labeltext As String, ByVal locx As Integer, ByVal locy As Integer, ByVal width As Integer,
                   ByVal height As Integer, ByVal fieldhighlight As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.myformstatus = myformstatus
        Me.fieldtype = fieldtype
        Me.fieldname = fieldname
        Me.fieldoptions = fieldoptions
        Me.fielddefaultval = fielddefault
        Me.fieldlabel = labeltext
        Me.fieldlocationx = locx
        Me.fieldlocationy = locy
        Me.fieldwidth = width
        Me.fieldheight = height
        Me.fieldhighlight = fieldhighlight
    End Sub
    Private Sub frmAddField_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadCombo()
        Me.cmbFieldType.SelectedValue = Me.fieldtype
        Me.txtfieldname.Text = Me.fieldname
        Me.txtvalue.Text = Me.fieldoptions
        If Me.fieldtype = clsModel.ConstrolTypes.ParagraphField Then
            Me.txtfieldlabelrtf.Rtf = Me.fieldlabel
        Else
            Me.txtLabelText.Text = Me.fieldlabel
        End If
        Me.cmbDefaultValue.Text = Me.fielddefaultval
        Me.txtX.Text = Me.fieldlocationx
        Me.txtY.Text = Me.fieldlocationy
        Me.txtwidth.Text = Me.fieldwidth
        Me.txtheight.Text = Me.fieldheight
        Me.txttexthighlight.Text = Me.fieldhighlight
    End Sub

    Private Sub loadCombo()
        With cmbFieldType
            .Items.Add(New DictionaryEntry("Text Field", clsModel.ConstrolTypes.TextField))
            .Items.Add(New DictionaryEntry("Double Text Field", clsModel.ConstrolTypes.DoubleTextField))
            .Items.Add(New DictionaryEntry("Resizable Text Field", clsModel.ConstrolTypes.ResizableTextField))
            .Items.Add(New DictionaryEntry("Paragraph Label", clsModel.ConstrolTypes.ParagraphField))
            .Items.Add(New DictionaryEntry("Dropdown Field", clsModel.ConstrolTypes.Dropdown))
            .Items.Add(New DictionaryEntry("Date & Time Picker", clsModel.ConstrolTypes.DateTimePicker))
            .Items.Add(New DictionaryEntry("Label H1 (Bold)", clsModel.ConstrolTypes.LabelH1))
            .Items.Add(New DictionaryEntry("Label H2 (Bold)", clsModel.ConstrolTypes.LabelH2))
            .Items.Add(New DictionaryEntry("Label H3 (Bold)", clsModel.ConstrolTypes.LabelH3))
            .Items.Add(New DictionaryEntry("Label H4", clsModel.ConstrolTypes.LabelH4))
            .Items.Add(New DictionaryEntry("Label H5", clsModel.ConstrolTypes.LabelH5))
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
        If Me.txtfieldname.Text = "" Then
            MsgBox("This field is required", MsgBoxStyle.Critical, "")
            Exit Sub
        End If
        Me.issave = True
        Me.fieldtype = Me.cmbFieldType.SelectedValue
        Me.fieldname = Me.txtfieldname.Text
        Me.fieldoptions = Me.txtvalue.Text
        Me.fielddefaultval = Me.cmbDefaultValue.Text
        If fieldtype = clsModel.ConstrolTypes.ParagraphField Then
            Me.fieldlabel = Me.txtfieldlabelrtf.Rtf
        Else
            Me.fieldlabel = Me.txtLabelText.Text()
        End If
        Me.fieldlocationx = Val(Me.txtX.Text)
        Me.fieldlocationy = Val(Me.txtY.Text)
        Me.fieldwidth = Val(Me.txtwidth.Text)
        Me.fieldheight = Val(Me.txtheight.Text)
        Me.fieldhighlight = txttexthighlight.Text
        Me.Close()
    End Sub

    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub cmbFieldType_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbFieldType.SelectedValueChanged
        If cmbFieldType.SelectedValue = clsModel.ConstrolTypes.DoubleTextField Then
            Me.txtheight.Enabled = True
        ElseIf cmbFieldType.SelectedValue = clsModel.ConstrolTypes.ResizableTextField Then
            Me.txtheight.Enabled = True
        Else
            Me.txtheight.Text = clsModel.ConstrolTypes.DefaultPanelHeight
            Me.txtheight.Enabled = False
        End If
        If cmbFieldType.SelectedValue = clsModel.ConstrolTypes.ParagraphField Then
            Me.txtheight.Enabled = True
            Me.paneltextrtf.Visible = True
            Me.paneltextreg.Visible = False
        Else
            Me.paneltextrtf.Visible = False
            Me.paneltextreg.Visible = True
        End If
    End Sub
End Class