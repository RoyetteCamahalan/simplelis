﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageResultParams
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageResultParams))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dlgPrint = New System.Windows.Forms.PrintDialog()
        Me.dlgPrintPreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.MiscPrintDocu = New System.Drawing.Printing.PrintDocument()
        Me.panelmain = New System.Windows.Forms.Panel()
        Me.panelresult = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblconversion = New System.Windows.Forms.Label()
        Me.lblconventional = New System.Windows.Forms.Label()
        Me.lblSI = New System.Windows.Forms.Label()
        Me.lblunit2 = New System.Windows.Forms.Label()
        Me.lblrefval2 = New System.Windows.Forms.Label()
        Me.lblunit1 = New System.Windows.Forms.Label()
        Me.lblrefval1 = New System.Windows.Forms.Label()
        Me.lbltest = New System.Windows.Forms.Label()
        Me.btndown = New System.Windows.Forms.Button()
        Me.btnup = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.lblMisc = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colchk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colparameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colsiref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colsiunit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colconversion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colunits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collabdetailid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelmain.SuspendLayout()
        Me.panelresult.SuspendLayout()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dlgPrint
        '
        Me.dlgPrint.UseEXDialog = True
        '
        'dlgPrintPreview
        '
        Me.dlgPrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.dlgPrintPreview.Document = Me.MiscPrintDocu
        Me.dlgPrintPreview.Enabled = True
        Me.dlgPrintPreview.Icon = CType(resources.GetObject("dlgPrintPreview.Icon"), System.Drawing.Icon)
        Me.dlgPrintPreview.Name = "dlgPrintPreview"
        Me.dlgPrintPreview.Visible = False
        '
        'panelmain
        '
        Me.panelmain.Controls.Add(Me.panelresult)
        Me.panelmain.Location = New System.Drawing.Point(20, 71)
        Me.panelmain.Name = "panelmain"
        Me.panelmain.Size = New System.Drawing.Size(714, 356)
        Me.panelmain.TabIndex = 250
        '
        'panelresult
        '
        Me.panelresult.Controls.Add(Me.Label9)
        Me.panelresult.Controls.Add(Me.lblconversion)
        Me.panelresult.Controls.Add(Me.lblconventional)
        Me.panelresult.Controls.Add(Me.lblSI)
        Me.panelresult.Controls.Add(Me.lblunit2)
        Me.panelresult.Controls.Add(Me.lblrefval2)
        Me.panelresult.Controls.Add(Me.lblunit1)
        Me.panelresult.Controls.Add(Me.lblrefval1)
        Me.panelresult.Controls.Add(Me.lbltest)
        Me.panelresult.Controls.Add(Me.btndown)
        Me.panelresult.Controls.Add(Me.btnup)
        Me.panelresult.Controls.Add(Me.btnAdd)
        Me.panelresult.Controls.Add(Me.dgvResult)
        Me.panelresult.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelresult.Location = New System.Drawing.Point(0, 0)
        Me.panelresult.Name = "panelresult"
        Me.panelresult.Size = New System.Drawing.Size(714, 353)
        Me.panelresult.TabIndex = 252
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(7, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 43)
        Me.Label9.TabIndex = 245
        Me.Label9.Text = "Visible?"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblconversion
        '
        Me.lblconversion.BackColor = System.Drawing.Color.Transparent
        Me.lblconversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblconversion.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconversion.ForeColor = System.Drawing.Color.Black
        Me.lblconversion.Location = New System.Drawing.Point(433, 28)
        Me.lblconversion.Name = "lblconversion"
        Me.lblconversion.Size = New System.Drawing.Size(75, 43)
        Me.lblconversion.TabIndex = 244
        Me.lblconversion.Text = "Convertion (Con.->SI)"
        Me.lblconversion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblconventional
        '
        Me.lblconventional.BackColor = System.Drawing.Color.Transparent
        Me.lblconventional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblconventional.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconventional.ForeColor = System.Drawing.Color.Black
        Me.lblconventional.Location = New System.Drawing.Point(507, 49)
        Me.lblconventional.Name = "lblconventional"
        Me.lblconventional.Size = New System.Drawing.Size(199, 22)
        Me.lblconventional.TabIndex = 243
        Me.lblconventional.Text = "(Conventional)"
        Me.lblconventional.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSI
        '
        Me.lblSI.BackColor = System.Drawing.Color.Transparent
        Me.lblSI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSI.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSI.ForeColor = System.Drawing.Color.Black
        Me.lblSI.Location = New System.Drawing.Point(255, 49)
        Me.lblSI.Name = "lblSI"
        Me.lblSI.Size = New System.Drawing.Size(179, 22)
        Me.lblSI.TabIndex = 242
        Me.lblSI.Text = "(S.I.)"
        Me.lblSI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblunit2
        '
        Me.lblunit2.BackColor = System.Drawing.Color.Transparent
        Me.lblunit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblunit2.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblunit2.ForeColor = System.Drawing.Color.Black
        Me.lblunit2.Location = New System.Drawing.Point(626, 28)
        Me.lblunit2.Name = "lblunit2"
        Me.lblunit2.Size = New System.Drawing.Size(80, 22)
        Me.lblunit2.TabIndex = 241
        Me.lblunit2.Text = "UNIT"
        Me.lblunit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblrefval2
        '
        Me.lblrefval2.BackColor = System.Drawing.Color.Transparent
        Me.lblrefval2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblrefval2.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrefval2.ForeColor = System.Drawing.Color.Black
        Me.lblrefval2.Location = New System.Drawing.Point(507, 28)
        Me.lblrefval2.Name = "lblrefval2"
        Me.lblrefval2.Size = New System.Drawing.Size(120, 22)
        Me.lblrefval2.TabIndex = 240
        Me.lblrefval2.Text = "REF. VAL."
        Me.lblrefval2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblunit1
        '
        Me.lblunit1.BackColor = System.Drawing.Color.Transparent
        Me.lblunit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblunit1.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblunit1.ForeColor = System.Drawing.Color.Black
        Me.lblunit1.Location = New System.Drawing.Point(374, 28)
        Me.lblunit1.Name = "lblunit1"
        Me.lblunit1.Size = New System.Drawing.Size(60, 22)
        Me.lblunit1.TabIndex = 239
        Me.lblunit1.Text = "UNIT"
        Me.lblunit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblrefval1
        '
        Me.lblrefval1.BackColor = System.Drawing.Color.Transparent
        Me.lblrefval1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblrefval1.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrefval1.ForeColor = System.Drawing.Color.Black
        Me.lblrefval1.Location = New System.Drawing.Point(255, 28)
        Me.lblrefval1.Name = "lblrefval1"
        Me.lblrefval1.Size = New System.Drawing.Size(120, 22)
        Me.lblrefval1.TabIndex = 238
        Me.lblrefval1.Text = "REF. VAL."
        Me.lblrefval1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltest
        '
        Me.lbltest.BackColor = System.Drawing.Color.Transparent
        Me.lbltest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltest.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltest.ForeColor = System.Drawing.Color.Black
        Me.lbltest.Location = New System.Drawing.Point(62, 28)
        Me.lbltest.Name = "lbltest"
        Me.lbltest.Size = New System.Drawing.Size(194, 43)
        Me.lbltest.TabIndex = 237
        Me.lbltest.Text = "TEST"
        Me.lbltest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btndown
        '
        Me.btndown.BackColor = System.Drawing.Color.White
        Me.btndown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndown.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndown.Location = New System.Drawing.Point(92, 322)
        Me.btndown.Name = "btndown"
        Me.btndown.Size = New System.Drawing.Size(80, 23)
        Me.btndown.TabIndex = 233
        Me.btndown.Text = "Move Down"
        Me.btndown.UseVisualStyleBackColor = False
        '
        'btnup
        '
        Me.btnup.BackColor = System.Drawing.Color.White
        Me.btnup.Enabled = False
        Me.btnup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnup.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnup.Location = New System.Drawing.Point(6, 322)
        Me.btnup.Name = "btnup"
        Me.btnup.Size = New System.Drawing.Size(80, 23)
        Me.btnup.TabIndex = 232
        Me.btnup.Text = "Move Up"
        Me.btnup.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = Global.SIMPLE_LIS.My.Resources.Resources.add_16
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(618, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(88, 23)
        Me.btnAdd.TabIndex = 231
        Me.btnAdd.Text = "     Add New"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToDeleteRows = False
        Me.dgvResult.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResult.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.ColumnHeadersVisible = False
        Me.dgvResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colchk, Me.colparameter, Me.colsiref, Me.colsiunit, Me.colconversion, Me.colref, Me.colunits, Me.collabdetailid})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResult.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvResult.Location = New System.Drawing.Point(7, 70)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.RowHeadersVisible = False
        Me.dgvResult.RowTemplate.Height = 26
        Me.dgvResult.Size = New System.Drawing.Size(699, 246)
        Me.dgvResult.TabIndex = 229
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(744, 38)
        Me.ToolStrip1.TabIndex = 254
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSave
        '
        Me.tsSave.Image = CType(resources.GetObject("tsSave.Image"), System.Drawing.Image)
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(35, 35)
        Me.tsSave.Text = "Save"
        Me.tsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsClose
        '
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(40, 35)
        Me.tsClose.Text = "Close"
        Me.tsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'lblMisc
        '
        Me.lblMisc.BackColor = System.Drawing.Color.Transparent
        Me.lblMisc.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMisc.ForeColor = System.Drawing.Color.Black
        Me.lblMisc.Location = New System.Drawing.Point(20, 46)
        Me.lblMisc.Name = "lblMisc"
        Me.lblMisc.Size = New System.Drawing.Size(692, 17)
        Me.lblMisc.TabIndex = 127
        Me.lblMisc.Text = "HEMATOLOGY"
        Me.lblMisc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn1.HeaderText = "Parameter"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn2.HeaderText = "Result"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 160
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn3.HeaderText = "Units"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 220
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn4.HeaderText = "Reference  Range"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 190
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn5.HeaderText = "Reference  Range"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 118
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn6.HeaderText = "Units"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "collabdetailid"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'colchk
        '
        Me.colchk.HeaderText = "Visible?"
        Me.colchk.Name = "colchk"
        Me.colchk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colchk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colchk.Width = 54
        '
        'colparameter
        '
        Me.colparameter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.colparameter.DefaultCellStyle = DataGridViewCellStyle2
        Me.colparameter.HeaderText = "Parameter"
        Me.colparameter.Name = "colparameter"
        Me.colparameter.Width = 193
        '
        'colsiref
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colsiref.DefaultCellStyle = DataGridViewCellStyle3
        Me.colsiref.HeaderText = "colsiref"
        Me.colsiref.Name = "colsiref"
        Me.colsiref.Width = 118
        '
        'colsiunit
        '
        Me.colsiunit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colsiunit.DefaultCellStyle = DataGridViewCellStyle4
        Me.colsiunit.HeaderText = "colsiunit"
        Me.colsiunit.Name = "colsiunit"
        Me.colsiunit.Width = 60
        '
        'colconversion
        '
        Me.colconversion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colconversion.DefaultCellStyle = DataGridViewCellStyle5
        Me.colconversion.HeaderText = "colconversion"
        Me.colconversion.Name = "colconversion"
        Me.colconversion.Width = 74
        '
        'colref
        '
        Me.colref.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colref.DefaultCellStyle = DataGridViewCellStyle6
        Me.colref.HeaderText = "Reference  Range"
        Me.colref.Name = "colref"
        Me.colref.Width = 119
        '
        'colunits
        '
        Me.colunits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colunits.DefaultCellStyle = DataGridViewCellStyle7
        Me.colunits.HeaderText = "Units"
        Me.colunits.Name = "colunits"
        '
        'collabdetailid
        '
        Me.collabdetailid.HeaderText = "collabdetailid"
        Me.collabdetailid.Name = "collabdetailid"
        Me.collabdetailid.Visible = False
        '
        'frmManageResultParams
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(744, 439)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.panelmain)
        Me.Controls.Add(Me.lblMisc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageResultParams"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Result Parameters"
        Me.panelmain.ResumeLayout(False)
        Me.panelresult.ResumeLayout(False)
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dlgPrint As System.Windows.Forms.PrintDialog
    Friend WithEvents dlgPrintPreview As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents MiscPrintDocu As System.Drawing.Printing.PrintDocument

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents panelmain As System.Windows.Forms.Panel
    Friend WithEvents panelresult As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btndown As System.Windows.Forms.Button
    Friend WithEvents btnup As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Public WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblconversion As System.Windows.Forms.Label
    Friend WithEvents lblconventional As System.Windows.Forms.Label
    Friend WithEvents lblSI As System.Windows.Forms.Label
    Friend WithEvents lblunit2 As System.Windows.Forms.Label
    Friend WithEvents lblrefval2 As System.Windows.Forms.Label
    Friend WithEvents lblunit1 As System.Windows.Forms.Label
    Friend WithEvents lblrefval1 As System.Windows.Forms.Label
    Friend WithEvents lbltest As System.Windows.Forms.Label
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents lblMisc As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colchk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colparameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colsiref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colsiunit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colconversion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colunits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collabdetailid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class