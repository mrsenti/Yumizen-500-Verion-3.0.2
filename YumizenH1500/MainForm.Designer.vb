<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.tmACK = New System.Windows.Forms.Timer(Me.components)
        Me.txtServerName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtDBName = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtRoot = New DevExpress.XtraEditors.TextEdit()
        Me.ReceivedText = New System.Windows.Forms.RichTextBox()
        Me.tmConnect = New System.Windows.Forms.Timer(Me.components)
        Me.tbDbaseSettings = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage5 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl3 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage7 = New DevExpress.XtraTab.XtraTabPage()
        Me.lvSampleID = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnConnect = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDisconnect = New DevExpress.XtraEditors.SimpleButton()
        Me.lblConnection = New DevExpress.XtraEditors.LabelControl()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSection = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tbRSSettings = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.chkPro = New System.Windows.Forms.CheckBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.chkReceiving = New System.Windows.Forms.CheckBox()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.cboIPAddress = New DevExpress.XtraEditors.TextEdit()
        Me.cboPort = New DevExpress.XtraEditors.TextEdit()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.cboLocation = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMachine = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSerial = New DevExpress.XtraEditors.TextEdit()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.LogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OPenDebuggerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tmReadData = New System.Windows.Forms.Timer(Me.components)
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDBName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRoot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDbaseSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDbaseSettings.SuspendLayout()
        Me.XtraTabPage5.SuspendLayout()
        CType(Me.XtraTabControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl3.SuspendLayout()
        Me.XtraTabPage7.SuspendLayout()
        CType(Me.txtSection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRSSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbRSSettings.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.cboIPAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.cboLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMachine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl6.Appearance.Options.UseForeColor = True
        Me.LabelControl6.Location = New System.Drawing.Point(26, 17)
        Me.LabelControl6.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl6.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl6.TabIndex = 124
        Me.LabelControl6.Text = "Machine Name:"
        '
        'tmACK
        '
        Me.tmACK.Enabled = True
        Me.tmACK.Interval = 500
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(134, 12)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.txtServerName.Properties.Appearance.Options.UseForeColor = True
        Me.txtServerName.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.txtServerName.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtServerName.Size = New System.Drawing.Size(259, 20)
        Me.txtServerName.TabIndex = 110
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl5.Appearance.Options.UseForeColor = True
        Me.LabelControl5.Location = New System.Drawing.Point(16, 96)
        Me.LabelControl5.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl5.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl5.TabIndex = 117
        Me.LabelControl5.Text = "Database Name:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(16, 45)
        Me.LabelControl4.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl4.TabIndex = 116
        Me.LabelControl4.Text = "Username:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(16, 18)
        Me.LabelControl1.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 114
        Me.LabelControl1.Text = "Server Name:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(16, 71)
        Me.LabelControl2.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl2.TabIndex = 115
        Me.LabelControl2.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(134, 64)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.txtPassword.Properties.Appearance.Options.UseForeColor = True
        Me.txtPassword.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.txtPassword.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(259, 20)
        Me.txtPassword.TabIndex = 112
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(134, 90)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.txtDBName.Properties.Appearance.Options.UseForeColor = True
        Me.txtDBName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDBName.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.txtDBName.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtDBName.Size = New System.Drawing.Size(259, 20)
        Me.txtDBName.TabIndex = 113
        '
        'txtRoot
        '
        Me.txtRoot.Location = New System.Drawing.Point(134, 38)
        Me.txtRoot.Name = "txtRoot"
        Me.txtRoot.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.txtRoot.Properties.Appearance.Options.UseForeColor = True
        Me.txtRoot.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.txtRoot.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtRoot.Size = New System.Drawing.Size(259, 20)
        Me.txtRoot.TabIndex = 111
        '
        'ReceivedText
        '
        Me.ReceivedText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReceivedText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReceivedText.Location = New System.Drawing.Point(0, 0)
        Me.ReceivedText.Name = "ReceivedText"
        Me.ReceivedText.ReadOnly = True
        Me.ReceivedText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.ReceivedText.Size = New System.Drawing.Size(827, 334)
        Me.ReceivedText.TabIndex = 0
        Me.ReceivedText.Text = ""
        '
        'tmConnect
        '
        Me.tmConnect.Enabled = True
        '
        'tbDbaseSettings
        '
        Me.tbDbaseSettings.AppearancePage.Header.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.tbDbaseSettings.AppearancePage.Header.Options.UseFont = True
        Me.tbDbaseSettings.Enabled = False
        Me.tbDbaseSettings.Location = New System.Drawing.Point(433, 12)
        Me.tbDbaseSettings.Name = "tbDbaseSettings"
        Me.tbDbaseSettings.SelectedTabPage = Me.XtraTabPage5
        Me.tbDbaseSettings.Size = New System.Drawing.Size(408, 154)
        Me.tbDbaseSettings.TabIndex = 136
        Me.tbDbaseSettings.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage5})
        '
        'XtraTabPage5
        '
        Me.XtraTabPage5.Controls.Add(Me.txtServerName)
        Me.XtraTabPage5.Controls.Add(Me.LabelControl5)
        Me.XtraTabPage5.Controls.Add(Me.LabelControl4)
        Me.XtraTabPage5.Controls.Add(Me.LabelControl1)
        Me.XtraTabPage5.Controls.Add(Me.LabelControl2)
        Me.XtraTabPage5.Controls.Add(Me.txtPassword)
        Me.XtraTabPage5.Controls.Add(Me.txtDBName)
        Me.XtraTabPage5.Controls.Add(Me.txtRoot)
        Me.XtraTabPage5.Name = "XtraTabPage5"
        Me.XtraTabPage5.Size = New System.Drawing.Size(406, 121)
        Me.XtraTabPage5.Text = "Database Settings"
        '
        'XtraTabControl3
        '
        Me.XtraTabControl3.AppearancePage.Header.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XtraTabControl3.AppearancePage.Header.Options.UseFont = True
        Me.XtraTabControl3.Location = New System.Drawing.Point(12, 172)
        Me.XtraTabControl3.Name = "XtraTabControl3"
        Me.XtraTabControl3.SelectedTabPage = Me.XtraTabPage7
        Me.XtraTabControl3.Size = New System.Drawing.Size(829, 367)
        Me.XtraTabControl3.TabIndex = 137
        Me.XtraTabControl3.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage7})
        '
        'XtraTabPage7
        '
        Me.XtraTabPage7.Controls.Add(Me.ReceivedText)
        Me.XtraTabPage7.Controls.Add(Me.lvSampleID)
        Me.XtraTabPage7.Name = "XtraTabPage7"
        Me.XtraTabPage7.Size = New System.Drawing.Size(827, 334)
        Me.XtraTabPage7.Text = "Communication Log"
        '
        'lvSampleID
        '
        Me.lvSampleID.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvSampleID.Location = New System.Drawing.Point(630, 86)
        Me.lvSampleID.Name = "lvSampleID"
        Me.lvSampleID.Size = New System.Drawing.Size(160, 186)
        Me.lvSampleID.TabIndex = 2
        Me.lvSampleID.UseCompatibleStateImageBehavior = False
        Me.lvSampleID.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "SampleID"
        Me.ColumnHeader1.Width = 118
        '
        'btnClear
        '
        Me.btnClear.ImageOptions.Image = CType(resources.GetObject("btnClear.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(541, 547)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(96, 26)
        Me.btnClear.TabIndex = 142
        Me.btnClear.Text = "&Clear Log"
        '
        'btnConnect
        '
        Me.btnConnect.ImageOptions.Image = CType(resources.GetObject("btnConnect.ImageOptions.Image"), System.Drawing.Image)
        Me.btnConnect.Location = New System.Drawing.Point(307, 547)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(96, 26)
        Me.btnConnect.TabIndex = 141
        Me.btnConnect.Text = "&Connect"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.ImageOptions.Image = CType(resources.GetObject("btnDisconnect.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDisconnect.Location = New System.Drawing.Point(409, 547)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(96, 26)
        Me.btnDisconnect.TabIndex = 140
        Me.btnDisconnect.Text = "&Disconnect"
        '
        'lblConnection
        '
        Me.lblConnection.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.lblConnection.Appearance.Options.UseForeColor = True
        Me.lblConnection.Location = New System.Drawing.Point(12, 552)
        Me.lblConnection.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.lblConnection.LookAndFeel.UseDefaultLookAndFeel = False
        Me.lblConnection.Name = "lblConnection"
        Me.lblConnection.Size = New System.Drawing.Size(147, 13)
        Me.lblConnection.TabIndex = 139
        Me.lblConnection.Text = "Connection Status: Connected"
        '
        'btnEdit
        '
        Me.btnEdit.ImageOptions.Image = CType(resources.GetObject("btnEdit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(643, 547)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(96, 26)
        Me.btnEdit.TabIndex = 138
        Me.btnEdit.Text = "&Edit"
        '
        'txtSection
        '
        Me.txtSection.Location = New System.Drawing.Point(120, 66)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtSection.Properties.Items.AddRange(New Object() {"Hematology", "Chemistry"})
        Me.txtSection.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.txtSection.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtSection.Size = New System.Drawing.Size(270, 20)
        Me.txtSection.TabIndex = 130
        '
        'tbRSSettings
        '
        Me.tbRSSettings.AppearancePage.Header.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.tbRSSettings.AppearancePage.Header.Options.UseFont = True
        Me.tbRSSettings.Enabled = False
        Me.tbRSSettings.Location = New System.Drawing.Point(12, 12)
        Me.tbRSSettings.Name = "tbRSSettings"
        Me.tbRSSettings.SelectedTabPage = Me.XtraTabPage1
        Me.tbRSSettings.Size = New System.Drawing.Size(415, 154)
        Me.tbRSSettings.TabIndex = 135
        Me.tbRSSettings.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.chkPro)
        Me.XtraTabPage1.Controls.Add(Me.LabelControl7)
        Me.XtraTabPage1.Controls.Add(Me.chkReceiving)
        Me.XtraTabPage1.Controls.Add(Me.LabelControl8)
        Me.XtraTabPage1.Controls.Add(Me.cboIPAddress)
        Me.XtraTabPage1.Controls.Add(Me.cboPort)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(413, 121)
        Me.XtraTabPage1.Text = "Server Settings"
        '
        'chkPro
        '
        Me.chkPro.AutoSize = True
        Me.chkPro.Checked = True
        Me.chkPro.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPro.Location = New System.Drawing.Point(118, 96)
        Me.chkPro.Name = "chkPro"
        Me.chkPro.Size = New System.Drawing.Size(60, 17)
        Me.chkPro.TabIndex = 134
        Me.chkPro.Text = "LIS Pro"
        Me.chkPro.UseVisualStyleBackColor = True
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl7.Appearance.Options.UseForeColor = True
        Me.LabelControl7.Location = New System.Drawing.Point(24, 20)
        Me.LabelControl7.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl7.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl7.TabIndex = 120
        Me.LabelControl7.Text = "Server IP Address:"
        '
        'chkReceiving
        '
        Me.chkReceiving.AutoSize = True
        Me.chkReceiving.Checked = True
        Me.chkReceiving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReceiving.Location = New System.Drawing.Point(118, 73)
        Me.chkReceiving.Name = "chkReceiving"
        Me.chkReceiving.Size = New System.Drawing.Size(146, 17)
        Me.chkReceiving.TabIndex = 133
        Me.chkReceiving.Text = "Enable Two Way Process"
        Me.chkReceiving.UseVisualStyleBackColor = True
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl8.Appearance.Options.UseForeColor = True
        Me.LabelControl8.Location = New System.Drawing.Point(24, 46)
        Me.LabelControl8.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl8.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl8.TabIndex = 122
        Me.LabelControl8.Text = "Server Port:"
        '
        'cboIPAddress
        '
        Me.cboIPAddress.Location = New System.Drawing.Point(118, 16)
        Me.cboIPAddress.Name = "cboIPAddress"
        Me.cboIPAddress.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.cboIPAddress.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboIPAddress.Size = New System.Drawing.Size(270, 20)
        Me.cboIPAddress.TabIndex = 101
        '
        'cboPort
        '
        Me.cboPort.Location = New System.Drawing.Point(118, 42)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.cboPort.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboPort.Size = New System.Drawing.Size(270, 20)
        Me.cboPort.TabIndex = 102
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.LabelControl16)
        Me.XtraTabPage3.Controls.Add(Me.cboLocation)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl12)
        Me.XtraTabPage3.Controls.Add(Me.txtMachine)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl11)
        Me.XtraTabPage3.Controls.Add(Me.txtSerial)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl6)
        Me.XtraTabPage3.Controls.Add(Me.txtSection)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(413, 121)
        Me.XtraTabPage3.Text = "Machine Settings"
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl16.Appearance.Options.UseForeColor = True
        Me.LabelControl16.Location = New System.Drawing.Point(26, 95)
        Me.LabelControl16.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl16.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl16.TabIndex = 131
        Me.LabelControl16.Text = "Location:"
        '
        'cboLocation
        '
        Me.cboLocation.Location = New System.Drawing.Point(120, 92)
        Me.cboLocation.Name = "cboLocation"
        Me.cboLocation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLocation.Properties.Items.AddRange(New Object() {"OPD", "ER", "Laboratory"})
        Me.cboLocation.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.cboLocation.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLocation.Size = New System.Drawing.Size(270, 20)
        Me.cboLocation.TabIndex = 132
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl12.Appearance.Options.UseForeColor = True
        Me.LabelControl12.Location = New System.Drawing.Point(26, 69)
        Me.LabelControl12.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl12.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl12.TabIndex = 129
        Me.LabelControl12.Text = "Section:"
        '
        'txtMachine
        '
        Me.txtMachine.EditValue = ""
        Me.txtMachine.Location = New System.Drawing.Point(120, 14)
        Me.txtMachine.Name = "txtMachine"
        Me.txtMachine.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.txtMachine.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtMachine.Size = New System.Drawing.Size(270, 20)
        Me.txtMachine.TabIndex = 126
        Me.txtMachine.Tag = ""
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl11.Appearance.Options.UseForeColor = True
        Me.LabelControl11.Location = New System.Drawing.Point(26, 43)
        Me.LabelControl11.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl11.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl11.TabIndex = 127
        Me.LabelControl11.Text = "Serial No.:"
        '
        'txtSerial
        '
        Me.txtSerial.Location = New System.Drawing.Point(120, 40)
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.txtSerial.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtSerial.Size = New System.Drawing.Size(270, 20)
        Me.txtSerial.TabIndex = 128
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "SBSI LIS"
        Me.NotifyIcon1.Visible = True
        '
        'LogsToolStripMenuItem
        '
        Me.LogsToolStripMenuItem.Name = "LogsToolStripMenuItem"
        Me.LogsToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.LogsToolStripMenuItem.Text = "Logs"
        '
        'ChangeUserToolStripMenuItem
        '
        Me.ChangeUserToolStripMenuItem.Name = "ChangeUserToolStripMenuItem"
        Me.ChangeUserToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ChangeUserToolStripMenuItem.Text = "Change User"
        '
        'OPenDebuggerToolStripMenuItem
        '
        Me.OPenDebuggerToolStripMenuItem.Name = "OPenDebuggerToolStripMenuItem"
        Me.OPenDebuggerToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.OPenDebuggerToolStripMenuItem.Text = "Open Debugger"
        '
        'mnuStrip
        '
        Me.mnuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OPenDebuggerToolStripMenuItem, Me.ChangeUserToolStripMenuItem, Me.LogsToolStripMenuItem})
        Me.mnuStrip.Name = "ContextMenuStrip1"
        Me.mnuStrip.Size = New System.Drawing.Size(159, 70)
        '
        'tmReadData
        '
        Me.tmReadData.Interval = 500
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(745, 547)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 26)
        Me.btnSave.TabIndex = 134
        Me.btnSave.Text = "&Save"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 580)
        Me.Controls.Add(Me.tbDbaseSettings)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.lblConnection)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.tbRSSettings)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.XtraTabControl3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Analyzer Driver Tester"
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDBName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRoot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDbaseSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDbaseSettings.ResumeLayout(False)
        Me.XtraTabPage5.ResumeLayout(False)
        Me.XtraTabPage5.PerformLayout()
        CType(Me.XtraTabControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl3.ResumeLayout(False)
        Me.XtraTabPage7.ResumeLayout(False)
        CType(Me.txtSection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRSSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbRSSettings.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage1.PerformLayout()
        CType(Me.cboIPAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        Me.XtraTabPage3.PerformLayout()
        CType(Me.cboLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMachine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tmACK As Timer
    Friend WithEvents txtServerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDBName As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtRoot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ReceivedText As RichTextBox
    Friend WithEvents tmConnect As Timer
    Friend WithEvents tbDbaseSettings As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabControl3 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage7 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnConnect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDisconnect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblConnection As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtSection As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents tbRSSettings As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents chkReceiving As CheckBox
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLocation As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMachine As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSerial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents LogsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OPenDebuggerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuStrip As ContextMenuStrip
    Friend WithEvents tmReadData As Timer
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboIPAddress As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboPort As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkPro As CheckBox
    Friend WithEvents lvSampleID As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
