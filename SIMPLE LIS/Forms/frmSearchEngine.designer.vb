<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchEngine
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchEngine))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnIgnoreCreateNew = New System.Windows.Forms.Button()
        Me.btnSelRec = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblFilterby = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbFilterby = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.prgrefresh = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.dgGeneric = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        CType(Me.dgGeneric,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnIgnoreCreateNew
        '
        Me.btnIgnoreCreateNew.BackColor = System.Drawing.Color.White
        Me.btnIgnoreCreateNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIgnoreCreateNew.Location = New System.Drawing.Point(664, 442)
        Me.btnIgnoreCreateNew.Name = "btnIgnoreCreateNew"
        Me.btnIgnoreCreateNew.Size = New System.Drawing.Size(201, 31)
        Me.btnIgnoreCreateNew.TabIndex = 2
        Me.btnIgnoreCreateNew.Text = "Ignore and Create New [Ctr + N]"
        Me.btnIgnoreCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIgnoreCreateNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIgnoreCreateNew.UseVisualStyleBackColor = false
        '
        'btnSelRec
        '
        Me.btnSelRec.BackColor = System.Drawing.Color.White
        Me.btnSelRec.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelRec.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSelRec.Location = New System.Drawing.Point(868, 442)
        Me.btnSelRec.Name = "btnSelRec"
        Me.btnSelRec.Size = New System.Drawing.Size(175, 31)
        Me.btnSelRec.TabIndex = 3
        Me.btnSelRec.Text = "Select Record"
        Me.btnSelRec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSelRec.UseVisualStyleBackColor = false
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1058, 25)
        Me.ToolStrip1.TabIndex = 172
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsClose
        '
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(42, 22)
        Me.tsClose.Text = "Close"
        Me.tsClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"),System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(11, 436)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1034, 42)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 173
        Me.PictureBox1.TabStop = false
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(622, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search [F3]"
        '
        'txtSearch
        '
        Me.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtSearch.Location = New System.Drawing.Point(689, 15)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(276, 23)
        Me.txtSearch.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.lblFilterby)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmbFilterby)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(1, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1058, 43)
        Me.Panel1.TabIndex = 171
        '
        'lblFilterby
        '
        Me.lblFilterby.AutoSize = true
        Me.lblFilterby.Location = New System.Drawing.Point(390, 20)
        Me.lblFilterby.Name = "lblFilterby"
        Me.lblFilterby.Size = New System.Drawing.Size(46, 13)
        Me.lblFilterby.TabIndex = 210
        Me.lblFilterby.Text = "Filter by"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(971, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(52, 27)
        Me.Button1.TabIndex = 209
        Me.Button1.Text = "  "
        Me.Button1.UseVisualStyleBackColor = false
        '
        'cmbFilterby
        '
        Me.cmbFilterby.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbFilterby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterby.FormattingEnabled = true
        Me.cmbFilterby.Location = New System.Drawing.Point(439, 16)
        Me.cmbFilterby.Name = "cmbFilterby"
        Me.cmbFilterby.Size = New System.Drawing.Size(176, 21)
        Me.cmbFilterby.TabIndex = 208
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Location = New System.Drawing.Point(-2, 37)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1062, 2)
        Me.GroupBox4.TabIndex = 183
        Me.GroupBox4.TabStop = false
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 480)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1058, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'prgrefresh
        '
        Me.prgrefresh.Location = New System.Drawing.Point(333, 228)
        Me.prgrefresh.Maximum = 1000000
        Me.prgrefresh.Name = "prgrefresh"
        Me.prgrefresh.Size = New System.Drawing.Size(482, 28)
        Me.prgrefresh.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.prgrefresh.TabIndex = 184
        Me.prgrefresh.Visible = false
        '
        'BackgroundWorker1
        '
        '
        'lblLoading
        '
        Me.lblLoading.AutoSize = true
        Me.lblLoading.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblLoading.ForeColor = System.Drawing.Color.Blue
        Me.lblLoading.Location = New System.Drawing.Point(641, 212)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(164, 13)
        Me.lblLoading.TabIndex = 185
        Me.lblLoading.Text = "Retrieving record(s). Please wait"
        Me.lblLoading.Visible = false
        '
        'Timer1
        '
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = true
        Me.lblRecordCount.BackColor = System.Drawing.Color.AliceBlue
        Me.lblRecordCount.Location = New System.Drawing.Point(28, 450)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(39, 13)
        Me.lblRecordCount.TabIndex = 186
        Me.lblRecordCount.Text = "0 rows"
        '
        'dgGeneric
        '
        Me.dgGeneric.AllowUserToAddRows = false
        Me.dgGeneric.AllowUserToDeleteRows = false
        Me.dgGeneric.AllowUserToResizeRows = false
        Me.dgGeneric.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgGeneric.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgGeneric.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGeneric.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgGeneric.ColumnHeadersHeight = 30
        Me.dgGeneric.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.dgGeneric.Location = New System.Drawing.Point(11, 76)
        Me.dgGeneric.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.dgGeneric.Name = "dgGeneric"
        Me.dgGeneric.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGeneric.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgGeneric.RowHeadersWidth = 25
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgGeneric.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgGeneric.Size = New System.Drawing.Size(1032, 347)
        Me.dgGeneric.TabIndex = 188
        '
        'frmSearchEngine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1058, 502)
        Me.ControlBox = false
        Me.Controls.Add(Me.dgGeneric)
        Me.Controls.Add(Me.lblRecordCount)
        Me.Controls.Add(Me.lblLoading)
        Me.Controls.Add(Me.prgrefresh)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnIgnoreCreateNew)
        Me.Controls.Add(Me.btnSelRec)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmSearchEngine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Central Database Lookup Window"
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.dgGeneric,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents btnSelRec As System.Windows.Forms.Button
    Friend WithEvents btnIgnoreCreateNew As System.Windows.Forms.Button
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents prgrefresh As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmbFilterby As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblFilterby As System.Windows.Forms.Label
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents dgGeneric As System.Windows.Forms.DataGridView
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property
End Class
