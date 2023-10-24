<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.grpDevices = New System.Windows.Forms.GroupBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.lblHost = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.btnKillADB = New System.Windows.Forms.Button()
        Me.btnStartADB = New System.Windows.Forms.Button()
        Me.btnListDevices = New System.Windows.Forms.Button()
        Me.lvDevices = New System.Windows.Forms.ListView()
        Me.contextDevices = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DisconnectDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectWirelesslyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpApps = New System.Windows.Forms.GroupBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.contextApps = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UninstallAPKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenOutputFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpInstall = New System.Windows.Forms.GroupBox()
        Me.btnInstallAPK = New System.Windows.Forms.Button()
        Me.lblDropHint = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtApkPath = New System.Windows.Forms.TextBox()
        Me.chkReplaceApp = New System.Windows.Forms.CheckBox()
        Me.lblAPK = New System.Windows.Forms.Label()
        Me.grpAppInfo = New System.Windows.Forms.GroupBox()
        Me.btnSaveAPK = New System.Windows.Forms.Button()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grpScreen = New System.Windows.Forms.GroupBox()
        Me.btnScreenRecord = New System.Windows.Forms.Button()
        Me.btnLaunchScreen = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.tmrPopulateDevices = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.grpDevices.SuspendLayout()
        Me.contextDevices.SuspendLayout()
        Me.grpApps.SuspendLayout()
        Me.contextApps.SuspendLayout()
        Me.grpInstall.SuspendLayout()
        Me.grpAppInfo.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpScreen.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDevices
        '
        Me.grpDevices.Controls.Add(Me.btnConnect)
        Me.grpDevices.Controls.Add(Me.lblHost)
        Me.grpDevices.Controls.Add(Me.txtHost)
        Me.grpDevices.Controls.Add(Me.btnKillADB)
        Me.grpDevices.Controls.Add(Me.btnStartADB)
        Me.grpDevices.Controls.Add(Me.btnListDevices)
        Me.grpDevices.Controls.Add(Me.lvDevices)
        Me.grpDevices.ForeColor = System.Drawing.Color.Cyan
        Me.grpDevices.Location = New System.Drawing.Point(12, 6)
        Me.grpDevices.Name = "grpDevices"
        Me.grpDevices.Size = New System.Drawing.Size(610, 126)
        Me.grpDevices.TabIndex = 0
        Me.grpDevices.TabStop = False
        Me.grpDevices.Text = "Devices"
        '
        'btnConnect
        '
        Me.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnect.Location = New System.Drawing.Point(484, 99)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(120, 23)
        Me.btnConnect.TabIndex = 8
        Me.btnConnect.Text = "Manual Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'lblHost
        '
        Me.lblHost.AutoSize = True
        Me.lblHost.Location = New System.Drawing.Point(443, 78)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(32, 13)
        Me.lblHost.TabIndex = 10
        Me.lblHost.Text = "Host:"
        '
        'txtHost
        '
        Me.txtHost.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHost.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHost.ForeColor = System.Drawing.Color.White
        Me.txtHost.Location = New System.Drawing.Point(484, 73)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(120, 23)
        Me.txtHost.TabIndex = 9
        Me.txtHost.Text = "IP:PORT"
        '
        'btnKillADB
        '
        Me.btnKillADB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKillADB.Location = New System.Drawing.Point(442, 45)
        Me.btnKillADB.Name = "btnKillADB"
        Me.btnKillADB.Size = New System.Drawing.Size(75, 23)
        Me.btnKillADB.TabIndex = 8
        Me.btnKillADB.Text = "Stop ADB"
        Me.btnKillADB.UseVisualStyleBackColor = True
        '
        'btnStartADB
        '
        Me.btnStartADB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartADB.Location = New System.Drawing.Point(521, 45)
        Me.btnStartADB.Name = "btnStartADB"
        Me.btnStartADB.Size = New System.Drawing.Size(83, 23)
        Me.btnStartADB.TabIndex = 7
        Me.btnStartADB.Text = "Start ADB"
        Me.btnStartADB.UseVisualStyleBackColor = True
        '
        'btnListDevices
        '
        Me.btnListDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListDevices.Location = New System.Drawing.Point(442, 16)
        Me.btnListDevices.Name = "btnListDevices"
        Me.btnListDevices.Size = New System.Drawing.Size(162, 23)
        Me.btnListDevices.TabIndex = 6
        Me.btnListDevices.Text = "List Devices"
        Me.btnListDevices.UseVisualStyleBackColor = True
        '
        'lvDevices
        '
        Me.lvDevices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDevices.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.lvDevices.ContextMenuStrip = Me.contextDevices
        Me.lvDevices.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDevices.ForeColor = System.Drawing.Color.White
        Me.lvDevices.FullRowSelect = True
        Me.lvDevices.HideSelection = False
        Me.lvDevices.Location = New System.Drawing.Point(6, 16)
        Me.lvDevices.MultiSelect = False
        Me.lvDevices.Name = "lvDevices"
        Me.lvDevices.Size = New System.Drawing.Size(430, 104)
        Me.lvDevices.TabIndex = 1
        Me.lvDevices.UseCompatibleStateImageBehavior = False
        Me.lvDevices.View = System.Windows.Forms.View.Details
        '
        'contextDevices
        '
        Me.contextDevices.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisconnectDeviceToolStripMenuItem, Me.ConnectWirelesslyToolStripMenuItem})
        Me.contextDevices.Name = "contextDevices"
        Me.contextDevices.Size = New System.Drawing.Size(175, 48)
        '
        'DisconnectDeviceToolStripMenuItem
        '
        Me.DisconnectDeviceToolStripMenuItem.Name = "DisconnectDeviceToolStripMenuItem"
        Me.DisconnectDeviceToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.DisconnectDeviceToolStripMenuItem.Text = "Disconnect Device"
        Me.DisconnectDeviceToolStripMenuItem.Visible = False
        '
        'ConnectWirelesslyToolStripMenuItem
        '
        Me.ConnectWirelesslyToolStripMenuItem.Name = "ConnectWirelesslyToolStripMenuItem"
        Me.ConnectWirelesslyToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ConnectWirelesslyToolStripMenuItem.Text = "Connect Wirelessly"
        Me.ConnectWirelesslyToolStripMenuItem.Visible = False
        '
        'grpApps
        '
        Me.grpApps.Controls.Add(Me.lblSearch)
        Me.grpApps.Controls.Add(Me.txtSearch)
        Me.grpApps.Controls.Add(Me.ListView1)
        Me.grpApps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpApps.ForeColor = System.Drawing.Color.Cyan
        Me.grpApps.Location = New System.Drawing.Point(0, 0)
        Me.grpApps.Name = "grpApps"
        Me.grpApps.Size = New System.Drawing.Size(338, 227)
        Me.grpApps.TabIndex = 1
        Me.grpApps.TabStop = False
        Me.grpApps.Text = "Apps"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(8, 19)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(44, 13)
        Me.lblSearch.TabIndex = 2
        Me.lblSearch.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(57, 14)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(275, 23)
        Me.txtSearch.TabIndex = 1
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.ContextMenuStrip = Me.contextApps
        Me.ListView1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.White
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(6, 42)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(326, 179)
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Package Name"
        Me.ColumnHeader1.Width = 280
        '
        'contextApps
        '
        Me.contextApps.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesToolStripMenuItem, Me.UninstallAPKToolStripMenuItem, Me.OpenOutputFolderToolStripMenuItem})
        Me.contextApps.Name = "contextApps"
        Me.contextApps.Size = New System.Drawing.Size(181, 70)
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PropertiesToolStripMenuItem.Text = "Fetch All Properties"
        '
        'UninstallAPKToolStripMenuItem
        '
        Me.UninstallAPKToolStripMenuItem.Name = "UninstallAPKToolStripMenuItem"
        Me.UninstallAPKToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UninstallAPKToolStripMenuItem.Text = "Uninstall APK"
        '
        'OpenOutputFolderToolStripMenuItem
        '
        Me.OpenOutputFolderToolStripMenuItem.Name = "OpenOutputFolderToolStripMenuItem"
        Me.OpenOutputFolderToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenOutputFolderToolStripMenuItem.Text = "Open Output Folder"
        '
        'grpInstall
        '
        Me.grpInstall.Controls.Add(Me.btnInstallAPK)
        Me.grpInstall.Controls.Add(Me.lblDropHint)
        Me.grpInstall.Controls.Add(Me.btnBrowse)
        Me.grpInstall.Controls.Add(Me.txtApkPath)
        Me.grpInstall.Controls.Add(Me.chkReplaceApp)
        Me.grpInstall.Controls.Add(Me.lblAPK)
        Me.grpInstall.ForeColor = System.Drawing.Color.Cyan
        Me.grpInstall.Location = New System.Drawing.Point(12, 372)
        Me.grpInstall.Name = "grpInstall"
        Me.grpInstall.Size = New System.Drawing.Size(338, 97)
        Me.grpInstall.TabIndex = 2
        Me.grpInstall.TabStop = False
        Me.grpInstall.Text = "Install App"
        '
        'btnInstallAPK
        '
        Me.btnInstallAPK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInstallAPK.Location = New System.Drawing.Point(252, 65)
        Me.btnInstallAPK.Name = "btnInstallAPK"
        Me.btnInstallAPK.Size = New System.Drawing.Size(80, 23)
        Me.btnInstallAPK.TabIndex = 16
        Me.btnInstallAPK.Text = "Install APK"
        Me.btnInstallAPK.UseVisualStyleBackColor = True
        '
        'lblDropHint
        '
        Me.lblDropHint.AutoSize = True
        Me.lblDropHint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDropHint.ForeColor = System.Drawing.Color.Teal
        Me.lblDropHint.Location = New System.Drawing.Point(96, 46)
        Me.lblDropHint.Name = "lblDropHint"
        Me.lblDropHint.Size = New System.Drawing.Size(128, 13)
        Me.lblDropHint.TabIndex = 15
        Me.lblDropHint.Text = "(Drag and Drop File Here)"
        '
        'btnBrowse
        '
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Location = New System.Drawing.Point(266, 21)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(66, 23)
        Me.btnBrowse.TabIndex = 14
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtApkPath
        '
        Me.txtApkPath.AllowDrop = True
        Me.txtApkPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.txtApkPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApkPath.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApkPath.ForeColor = System.Drawing.Color.White
        Me.txtApkPath.Location = New System.Drawing.Point(57, 21)
        Me.txtApkPath.Name = "txtApkPath"
        Me.txtApkPath.Size = New System.Drawing.Size(203, 23)
        Me.txtApkPath.TabIndex = 13
        '
        'chkReplaceApp
        '
        Me.chkReplaceApp.AutoSize = True
        Me.chkReplaceApp.Location = New System.Drawing.Point(57, 69)
        Me.chkReplaceApp.Name = "chkReplaceApp"
        Me.chkReplaceApp.Size = New System.Drawing.Size(127, 17)
        Me.chkReplaceApp.TabIndex = 12
        Me.chkReplaceApp.Text = "Replace Existing App"
        Me.chkReplaceApp.UseVisualStyleBackColor = True
        '
        'lblAPK
        '
        Me.lblAPK.AutoSize = True
        Me.lblAPK.Location = New System.Drawing.Point(8, 26)
        Me.lblAPK.Name = "lblAPK"
        Me.lblAPK.Size = New System.Drawing.Size(50, 13)
        Me.lblAPK.TabIndex = 11
        Me.lblAPK.Text = "APK File:"
        '
        'grpAppInfo
        '
        Me.grpAppInfo.Controls.Add(Me.btnSaveAPK)
        Me.grpAppInfo.Controls.Add(Me.ListView2)
        Me.grpAppInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpAppInfo.ForeColor = System.Drawing.Color.Cyan
        Me.grpAppInfo.Location = New System.Drawing.Point(0, 0)
        Me.grpAppInfo.Name = "grpAppInfo"
        Me.grpAppInfo.Size = New System.Drawing.Size(268, 227)
        Me.grpAppInfo.TabIndex = 3
        Me.grpAppInfo.TabStop = False
        Me.grpAppInfo.Text = "App Details"
        '
        'btnSaveAPK
        '
        Me.btnSaveAPK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAPK.Location = New System.Drawing.Point(6, 195)
        Me.btnSaveAPK.Name = "btnSaveAPK"
        Me.btnSaveAPK.Size = New System.Drawing.Size(256, 23)
        Me.btnSaveAPK.TabIndex = 1
        Me.btnSaveAPK.Text = "Save APK as..."
        Me.btnSaveAPK.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        Me.ListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView2.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.ListView2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.ForeColor = System.Drawing.Color.White
        Me.ListView2.FullRowSelect = True
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(6, 19)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(256, 170)
        Me.ListView2.TabIndex = 0
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'SplitContainer1
        '
        Me.SplitContainer1.ForeColor = System.Drawing.Color.White
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 139)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpApps)
        Me.SplitContainer1.Panel1MinSize = 80
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpAppInfo)
        Me.SplitContainer1.Panel2MinSize = 80
        Me.SplitContainer1.Size = New System.Drawing.Size(610, 227)
        Me.SplitContainer1.SplitterDistance = 338
        Me.SplitContainer1.TabIndex = 4
        '
        'grpScreen
        '
        Me.grpScreen.Controls.Add(Me.btnScreenRecord)
        Me.grpScreen.Controls.Add(Me.btnLaunchScreen)
        Me.grpScreen.ForeColor = System.Drawing.Color.Cyan
        Me.grpScreen.Location = New System.Drawing.Point(354, 372)
        Me.grpScreen.Name = "grpScreen"
        Me.grpScreen.Size = New System.Drawing.Size(268, 97)
        Me.grpScreen.TabIndex = 5
        Me.grpScreen.TabStop = False
        Me.grpScreen.Text = "Device Control"
        '
        'btnScreenRecord
        '
        Me.btnScreenRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScreenRecord.Location = New System.Drawing.Point(6, 50)
        Me.btnScreenRecord.Name = "btnScreenRecord"
        Me.btnScreenRecord.Size = New System.Drawing.Size(256, 23)
        Me.btnScreenRecord.TabIndex = 10
        Me.btnScreenRecord.Text = "Start Screen Recording"
        Me.btnScreenRecord.UseVisualStyleBackColor = True
        '
        'btnLaunchScreen
        '
        Me.btnLaunchScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLaunchScreen.Location = New System.Drawing.Point(6, 21)
        Me.btnLaunchScreen.Name = "btnLaunchScreen"
        Me.btnLaunchScreen.Size = New System.Drawing.Size(256, 23)
        Me.btnLaunchScreen.TabIndex = 9
        Me.btnLaunchScreen.Text = "Launch Screen Preview"
        Me.btnLaunchScreen.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Title = "Save APK as..."
        '
        'tmrPopulateDevices
        '
        Me.tmrPopulateDevices.Interval = 1500
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "APK Files|*.apk"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(634, 481)
        Me.Controls.Add(Me.grpScreen)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.grpInstall)
        Me.Controls.Add(Me.grpDevices)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GyroPalm Spectrum ADB"
        Me.grpDevices.ResumeLayout(False)
        Me.grpDevices.PerformLayout()
        Me.contextDevices.ResumeLayout(False)
        Me.grpApps.ResumeLayout(False)
        Me.grpApps.PerformLayout()
        Me.contextApps.ResumeLayout(False)
        Me.grpInstall.ResumeLayout(False)
        Me.grpInstall.PerformLayout()
        Me.grpAppInfo.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpScreen.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpDevices As GroupBox
    Friend WithEvents grpApps As GroupBox
    Friend WithEvents grpInstall As GroupBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents grpAppInfo As GroupBox
    Friend WithEvents ListView2 As ListView
    Friend WithEvents contextApps As ContextMenuStrip
    Friend WithEvents PropertiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UninstallAPKToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents grpScreen As GroupBox
    Friend WithEvents OpenOutputFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnSaveAPK As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents lvDevices As ListView
    Friend WithEvents btnListDevices As Button
    Friend WithEvents contextDevices As ContextMenuStrip
    Friend WithEvents DisconnectDeviceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnKillADB As Button
    Friend WithEvents btnStartADB As Button
    Friend WithEvents ConnectWirelesslyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tmrPopulateDevices As Timer
    Friend WithEvents btnConnect As Button
    Friend WithEvents lblHost As Label
    Friend WithEvents txtHost As TextBox
    Friend WithEvents btnLaunchScreen As Button
    Friend WithEvents btnScreenRecord As Button
    Friend WithEvents lblAPK As Label
    Friend WithEvents chkReplaceApp As CheckBox
    Friend WithEvents txtApkPath As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents lblDropHint As Label
    Friend WithEvents btnInstallAPK As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
