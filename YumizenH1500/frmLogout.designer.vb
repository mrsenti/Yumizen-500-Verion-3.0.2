﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogout))
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtUsername = New DevExpress.XtraEditors.TextEdit()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.AutoSizeMode = True
        Me.SeparatorControl1.Location = New System.Drawing.Point(4, 136)
        Me.SeparatorControl1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.SeparatorControl1.Size = New System.Drawing.Size(392, 19)
        Me.SeparatorControl1.TabIndex = 98
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(128, 86)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Properties.Appearance.Options.UseFont = True
        Me.txtPassword.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPassword.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.txtPassword.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(230, 28)
        Me.txtPassword.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.Appearance.Options.UseForeColor = True
        Me.btnSave.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[True]
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.btnSave.Location = New System.Drawing.Point(288, 163)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 46)
        Me.btnSave.TabIndex = 93
        Me.btnSave.Text = "Login"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(128, 34)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Properties.Appearance.Options.UseFont = True
        Me.txtUsername.Properties.Appearance.Options.UseTextOptions = True
        Me.txtUsername.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtUsername.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.txtUsername.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtUsername.Size = New System.Drawing.Size(230, 28)
        Me.txtUsername.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 27)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(106, 102)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 100
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(127, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(127, 68)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Password:"
        '
        'frmLogout
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(409, 223)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Authentication Window"
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
