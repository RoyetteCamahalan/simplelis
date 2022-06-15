<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResultDesigner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResultDesigner))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsmain = New System.Windows.Forms.ToolStrip()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsPrint = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.tsradtemplatemain = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LoadFromTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsNewTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExternalTemplateManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.colchk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colfieldname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colfieldtypedesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coloptionvalues = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collaboratorydetailsid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colfieldtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coluuid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collocationx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collocationy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coldefaultvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collaboratoryresultdetailid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collabeltext = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colwidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colheight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelsidebar = New System.Windows.Forms.Panel()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.txtpanelheight = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsmain.SuspendLayout()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelsidebar.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsmain
        '
        Me.tsmain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsPrint, Me.tsClose, Me.tsradtemplatemain})
        Me.tsmain.Location = New System.Drawing.Point(0, 0)
        Me.tsmain.Name = "tsmain"
        Me.tsmain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsmain.Size = New System.Drawing.Size(922, 38)
        Me.tsmain.TabIndex = 43
        Me.tsmain.Text = "ToolStrip1"
        '
        'tsSave
        '
        Me.tsSave.Image = Global.SIMPLE_LIS.My.Resources.Resources.ic_save
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(35, 35)
        Me.tsSave.Text = "Save"
        Me.tsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsPrint
        '
        Me.tsPrint.Image = CType(resources.GetObject("tsPrint.Image"), System.Drawing.Image)
        Me.tsPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrint.Name = "tsPrint"
        Me.tsPrint.Size = New System.Drawing.Size(36, 36)
        Me.tsPrint.Text = "Print"
        Me.tsPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsPrint.ToolTipText = "CTRL+P-Print"
        Me.tsPrint.Visible = False
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
        'tsradtemplatemain
        '
        Me.tsradtemplatemain.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadFromTemplateToolStripMenuItem, Me.SaveAsNewTemplateToolStripMenuItem, Me.ExternalTemplateManagementToolStripMenuItem})
        Me.tsradtemplatemain.Image = Global.SIMPLE_LIS.My.Resources.Resources.ic_template
        Me.tsradtemplatemain.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsradtemplatemain.Name = "tsradtemplatemain"
        Me.tsradtemplatemain.Size = New System.Drawing.Size(73, 35)
        Me.tsradtemplatemain.Text = "Templates"
        Me.tsradtemplatemain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsradtemplatemain.Visible = False
        '
        'LoadFromTemplateToolStripMenuItem
        '
        Me.LoadFromTemplateToolStripMenuItem.Image = Global.SIMPLE_LIS.My.Resources.Resources.ic_template
        Me.LoadFromTemplateToolStripMenuItem.Name = "LoadFromTemplateToolStripMenuItem"
        Me.LoadFromTemplateToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.LoadFromTemplateToolStripMenuItem.Text = "Load from templates"
        '
        'SaveAsNewTemplateToolStripMenuItem
        '
        Me.SaveAsNewTemplateToolStripMenuItem.Image = Global.SIMPLE_LIS.My.Resources.Resources.ic_save
        Me.SaveAsNewTemplateToolStripMenuItem.Name = "SaveAsNewTemplateToolStripMenuItem"
        Me.SaveAsNewTemplateToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.SaveAsNewTemplateToolStripMenuItem.Text = "Save as template"
        '
        'ExternalTemplateManagementToolStripMenuItem
        '
        Me.ExternalTemplateManagementToolStripMenuItem.Image = Global.SIMPLE_LIS.My.Resources.Resources.ic_template
        Me.ExternalTemplateManagementToolStripMenuItem.Name = "ExternalTemplateManagementToolStripMenuItem"
        Me.ExternalTemplateManagementToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.ExternalTemplateManagementToolStripMenuItem.Text = "External Template Management"
        Me.ExternalTemplateManagementToolStripMenuItem.ToolTipText = "Opens the directory of template to edit templates using MS Word"
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToDeleteRows = False
        Me.dgvResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.dgvResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colchk, Me.colfieldname, Me.colfieldtypedesc, Me.coloptionvalues, Me.collaboratorydetailsid, Me.colfieldtype, Me.coluuid, Me.collocationx, Me.collocationy, Me.coldefaultvalue, Me.collaboratoryresultdetailid, Me.collabeltext, Me.colwidth, Me.colheight})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResult.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvResult.Location = New System.Drawing.Point(3, 93)
        Me.dgvResult.Name = "dgvResult"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResult.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvResult.RowHeadersVisible = False
        Me.dgvResult.RowTemplate.Height = 26
        Me.dgvResult.Size = New System.Drawing.Size(257, 234)
        Me.dgvResult.TabIndex = 230
        '
        'colchk
        '
        Me.colchk.HeaderText = ""
        Me.colchk.Name = "colchk"
        Me.colchk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colchk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colchk.Width = 30
        '
        'colfieldname
        '
        Me.colfieldname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colfieldname.DefaultCellStyle = DataGridViewCellStyle2
        Me.colfieldname.HeaderText = "Name"
        Me.colfieldname.Name = "colfieldname"
        Me.colfieldname.ReadOnly = True
        '
        'colfieldtypedesc
        '
        Me.colfieldtypedesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colfieldtypedesc.DefaultCellStyle = DataGridViewCellStyle3
        Me.colfieldtypedesc.HeaderText = "Type"
        Me.colfieldtypedesc.Name = "colfieldtypedesc"
        Me.colfieldtypedesc.ReadOnly = True
        Me.colfieldtypedesc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'coloptionvalues
        '
        Me.coloptionvalues.HeaderText = "coloptionvalues"
        Me.coloptionvalues.Name = "coloptionvalues"
        Me.coloptionvalues.Visible = False
        '
        'collaboratorydetailsid
        '
        Me.collaboratorydetailsid.HeaderText = "laboratorydetailsid"
        Me.collaboratorydetailsid.Name = "collaboratorydetailsid"
        Me.collaboratorydetailsid.Visible = False
        '
        'colfieldtype
        '
        Me.colfieldtype.HeaderText = "colfieldtype"
        Me.colfieldtype.Name = "colfieldtype"
        Me.colfieldtype.Visible = False
        '
        'coluuid
        '
        Me.coluuid.HeaderText = "coluuid"
        Me.coluuid.Name = "coluuid"
        Me.coluuid.Visible = False
        '
        'collocationx
        '
        Me.collocationx.HeaderText = "collocationx"
        Me.collocationx.Name = "collocationx"
        Me.collocationx.Visible = False
        '
        'collocationy
        '
        Me.collocationy.HeaderText = "collocationy"
        Me.collocationy.Name = "collocationy"
        Me.collocationy.Visible = False
        '
        'coldefaultvalue
        '
        Me.coldefaultvalue.HeaderText = "coldefaultvalue"
        Me.coldefaultvalue.Name = "coldefaultvalue"
        Me.coldefaultvalue.Visible = False
        '
        'collaboratoryresultdetailid
        '
        Me.collaboratoryresultdetailid.HeaderText = "collaboratoryresultdetailid"
        Me.collaboratoryresultdetailid.Name = "collaboratoryresultdetailid"
        Me.collaboratoryresultdetailid.Visible = False
        '
        'collabeltext
        '
        Me.collabeltext.HeaderText = "collabeltext"
        Me.collabeltext.Name = "collabeltext"
        Me.collabeltext.Visible = False
        '
        'colwidth
        '
        Me.colwidth.HeaderText = "colwidth"
        Me.colwidth.Name = "colwidth"
        Me.colwidth.Visible = False
        '
        'colheight
        '
        Me.colheight.HeaderText = "colheight"
        Me.colheight.Name = "colheight"
        Me.colheight.Visible = False
        '
        'panelsidebar
        '
        Me.panelsidebar.Controls.Add(Me.btnpreview)
        Me.panelsidebar.Controls.Add(Me.txtpanelheight)
        Me.panelsidebar.Controls.Add(Me.Label2)
        Me.panelsidebar.Controls.Add(Me.btnAdd)
        Me.panelsidebar.Controls.Add(Me.dgvResult)
        Me.panelsidebar.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelsidebar.Location = New System.Drawing.Point(659, 38)
        Me.panelsidebar.Name = "panelsidebar"
        Me.panelsidebar.Size = New System.Drawing.Size(263, 330)
        Me.panelsidebar.TabIndex = 231
        '
        'btnpreview
        '
        Me.btnpreview.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnpreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpreview.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpreview.ForeColor = System.Drawing.Color.White
        Me.btnpreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnpreview.Location = New System.Drawing.Point(3, 3)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(256, 31)
        Me.btnpreview.TabIndex = 235
        Me.btnpreview.Text = "Preview Design"
        Me.btnpreview.UseVisualStyleBackColor = False
        '
        'txtpanelheight
        '
        Me.txtpanelheight.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.txtpanelheight.Location = New System.Drawing.Point(89, 40)
        Me.txtpanelheight.Name = "txtpanelheight"
        Me.txtpanelheight.Size = New System.Drawing.Size(170, 22)
        Me.txtpanelheight.TabIndex = 234
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "Panel Height:"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = Global.SIMPLE_LIS.My.Resources.Resources.add_16
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(171, 68)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(88, 23)
        Me.btnAdd.TabIndex = 232
        Me.btnAdd.Text = "     Add New"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn2.HeaderText = "coloptionvalues"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "coloptionvalues"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "laboratorydetailsid"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "colfieldtype"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "coluuid"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "collocationx"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "collocationy"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "coldefaultvalue"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "collaboratoryresultdetailid"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "collabeltext"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "colwidth"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "colheight"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'frmResultDesigner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 368)
        Me.Controls.Add(Me.panelsidebar)
        Me.Controls.Add(Me.tsmain)
        Me.IsMdiContainer = True
        Me.Name = "frmResultDesigner"
        Me.Text = "Lab Result Designer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsmain.ResumeLayout(False)
        Me.tsmain.PerformLayout()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelsidebar.ResumeLayout(False)
        Me.panelsidebar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tsmain As System.Windows.Forms.ToolStrip
    Public WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Public WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents panelsidebar As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtpanelheight As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents tsPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colchk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colfieldname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colfieldtypedesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coloptionvalues As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collaboratorydetailsid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colfieldtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coluuid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collocationx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collocationy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coldefaultvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collaboratoryresultdetailid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collabeltext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colwidth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colheight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsradtemplatemain As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents LoadFromTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsNewTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExternalTemplateManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
