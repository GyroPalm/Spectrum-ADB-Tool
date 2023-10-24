Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.IO.Compression

Public Class Form1

    Dim statAppName = "N/A"
    Dim statAppVersion = "N/A"
    Dim statVersionCode = "N/A"
    Dim statMinSDK = "N/A"
    Dim statTargetSDK = "N/A"
    Dim statAppSize = "N/A"
    Dim statPackage = "N/A"
    Dim loadedFileName As String = ""
    Dim originalItems As New List(Of ListViewItem)
    Dim lastNumDevices As Integer = 0

    Public Sub FetchAndPopulateApps()
        ListView1.Items.Clear()
        originalItems = New List(Of ListViewItem)

        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = "shell pm list packages -f"
        procStartInfo.RedirectStandardOutput = True
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()

        Dim reader As System.IO.StreamReader = proc.StandardOutput
        Dim result As String = reader.ReadToEnd()

        proc.WaitForExit()

        ' Parse the output using more focused Regular Expression
        Dim regex As New Regex("package:(.*?\.apk)=(.*)")
        Dim matches As MatchCollection = regex.Matches(result)

        For Each match As Match In matches
            Dim filePath As String = match.Groups(1).Value
            Dim packageName As String = match.Groups(2).Value

            If Not String.IsNullOrEmpty(packageName) Then
                Dim item As New ListViewItem(New String() {packageName})
                item.Tag = filePath
                ListView1.Items.Add(item)
                originalItems.Add(item.Clone()) ' Clone the item and add to originalItems list
            End If
        Next
    End Sub

    Public Function GetAppSize(ByVal filePath As String) As String
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = $"shell ls -l {filePath}"
        procStartInfo.RedirectStandardOutput = True
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()

        Dim reader As System.IO.StreamReader = proc.StandardOutput
        Dim result As String = reader.ReadToEnd().Trim()

        proc.WaitForExit()

        ' Parse the output to extract the file size.
        ' Assume output is like "-rw-r--r-- 1 system system 12345 2023-10-22 12:34 /data/app/package-name"
        Dim fileSize As String = "Unknown"
        If Not String.IsNullOrEmpty(result) Then
            Dim parts() As String = result.Split(" "c)
            If parts.Length >= 5 Then
                fileSize = parts(4) ' The size will be at index 4.
            End If
        End If

        Return fileSize
    End Function

    Public Function GetAppVersion(packageName As String) As String
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = $"shell dumpsys package {packageName}"
        procStartInfo.RedirectStandardOutput = True
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()

        Dim reader As System.IO.StreamReader = proc.StandardOutput
        Dim result As String = reader.ReadToEnd()

        proc.WaitForExit()

        ' Extract version using Regex, accounting for potential extra spaces or characters
        Dim versionPattern As String = "versionName\s*=\s*([\d\.]+)"
        Dim regex As New Regex(versionPattern, RegexOptions.IgnoreCase)
        Dim match As Match = regex.Match(result)

        If match.Success Then
            Return match.Groups(1).Value
        Else
            Return "Unknown"
        End If
    End Function

    Public Function GetVersionCode(packageName As String) As String
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = $"shell dumpsys package {packageName.Trim()}"
        procStartInfo.RedirectStandardOutput = True
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()

        Dim reader As System.IO.StreamReader = proc.StandardOutput
        Dim result As String = reader.ReadToEnd()

        proc.WaitForExit()

        Dim regex As New Regex("versionCode=(\d+)")
        Dim match As Match = regex.Match(result)

        If match.Success Then
            Return match.Groups(1).Value
        End If

        Return "Unknown"
    End Function

    Public Function GetMinSDK(packageName As String) As String
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = $"shell dumpsys package {packageName.Trim()}"
        procStartInfo.RedirectStandardOutput = True
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()

        Dim reader As System.IO.StreamReader = proc.StandardOutput
        Dim result As String = reader.ReadToEnd()

        proc.WaitForExit()

        Dim regex As New Regex("minSdk=(\d+)")
        Dim match As Match = regex.Match(result)

        If match.Success Then
            Return match.Groups(1).Value
        End If

        Return "Unknown"
    End Function

    Public Function GetTargetSDK(packageName As String) As String
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = $"shell dumpsys package {packageName.Trim()}"
        procStartInfo.RedirectStandardOutput = True
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()

        Dim reader As System.IO.StreamReader = proc.StandardOutput
        Dim result As String = reader.ReadToEnd()

        proc.WaitForExit()

        Dim regex As New Regex("targetSdk=(\d+)")
        Dim match As Match = regex.Match(result)

        If match.Success Then
            Return match.Groups(1).Value
        End If

        Return "Unknown"
    End Function

    Public Function BytesToString(ByVal byteCount As Long) As String
        Dim sizes As String() = {"B", "KB", "MB", "GB", "TB"}
        Dim order As Integer = 0

        While byteCount >= 1024 AndAlso order < sizes.Length - 1
            order += 1
            byteCount /= 1024
        End While

        Return String.Format("{0:0.0} {1}", byteCount, sizes(order))
    End Function

    Public Sub FetchAPK(ByVal filePath As String, ByVal fileName As String)

        Dim destinationPath As String = System.IO.Path.Combine(Application.StartupPath & "\apps", fileName)

        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = $"pull {filePath} ""{destinationPath}"""
        procStartInfo.RedirectStandardOutput = True
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()

        Dim reader As System.IO.StreamReader = proc.StandardOutput
        Dim result As String = reader.ReadToEnd().Trim()

        proc.WaitForExit()

        loadedFileName = destinationPath

        If result.Contains("bytes in") Then ' Check for success
            'MessageBox.Show($"APK details loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show($"Failed to download APK. adb output: {result}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Function GetAppName(filePath As String) As String
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = IO.Path.Combine(Application.StartupPath, "aapt.exe")
        procStartInfo.Arguments = $"dump badging """ & filePath & """ | findstr ""application-label:"""
        procStartInfo.RedirectStandardOutput = True
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()

        Dim reader As System.IO.StreamReader = proc.StandardOutput
        Dim result As String = reader.ReadToEnd()

        proc.WaitForExit()

        Dim appName As String = "Unknown"

        ' Use regex to find application-label
        Dim match As Match = Regex.Match(result, "application-label:'(.*?)'")
        If match.Success Then
            appName = match.Groups(1).Value
        End If

        Return appName
    End Function

    Public Sub MakeDirectoryIfNotExist(ByVal dirPath As String)
        Try
            If My.Computer.FileSystem.DirectoryExists(dirPath) <> True Then
                My.Computer.FileSystem.CreateDirectory(dirPath)
            End If
        Catch
        End Try
    End Sub

    Public Sub DeleteDirectory(ByVal dirPath As String)
        Try
            If My.Computer.FileSystem.DirectoryExists(dirPath) = True Then
                My.Computer.FileSystem.DeleteDirectory(dirPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
        Catch
        End Try
    End Sub

    Public Sub UnpackResources()
        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\adb.exe") = False Then
                MsgBox("Welcome. Loading Spectrum ADB...")
                IO.File.WriteAllBytes(Application.StartupPath & "\adb.exe", My.Resources.adb)
                IO.File.WriteAllBytes(Application.StartupPath & "\aapt.exe", My.Resources.aapt)
                'Extract scrcpy
                IO.File.WriteAllBytes(Application.StartupPath & "\scr.zip", My.Resources.scr)
                MakeDirectoryIfNotExist(Application.StartupPath & "\scr")
                ExtractFolder(Application.StartupPath & "\scr.zip", Application.StartupPath & "\scr")
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\scr.zip") Then
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\scr.zip")
                End If
            End If
        Catch ex As Exception
            MsgBox("Failed to unpack ADB and AAPT required resources.")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UnpackResources()
        FetchAndPopulateApps()
        InitializeDetailsListView()
        btnListDevices.PerformClick()
    End Sub

    Private Sub InitializeDetailsListView()
        ' Create Columns
        ListView2.Columns.Add("Property", 95)
        ListView2.Columns.Add("Value", 155)

        ' Create Items
        ListView2.Items.Add(New ListViewItem({"App Name", statAppName}))
        ListView2.Items.Add(New ListViewItem({"Version", statAppVersion}))
        ListView2.Items.Add(New ListViewItem({"Version Code", statVersionCode}))
        ListView2.Items.Add(New ListViewItem({"Min SDK", statMinSDK}))
        ListView2.Items.Add(New ListViewItem({"Target SDK", statTargetSDK}))
        ListView2.Items.Add(New ListViewItem({"Size", statAppSize}))
        ListView2.Items.Add(New ListViewItem({"Package", statPackage}))

        lvDevices.Columns.Add("Name", 120)
        lvDevices.Columns.Add("Device ID", 140)
        lvDevices.Columns.Add("Battery %", 80)
        lvDevices.Columns.Add("Is Charging", 80)
    End Sub

    Private Sub updateStatusUI()
        ' Update only the subitems that have changed
        ListView2.Items(0).SubItems(1).Text = statAppName
        ListView2.Items(1).SubItems(1).Text = statAppVersion
        ListView2.Items(2).SubItems(1).Text = statVersionCode
        ListView2.Items(3).SubItems(1).Text = statMinSDK
        ListView2.Items(4).SubItems(1).Text = statTargetSDK
        ListView2.Items(5).SubItems(1).Text = statAppSize
        ListView2.Items(6).SubItems(1).Text = statPackage
    End Sub

    Private Sub ListView2_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles ListView2.ItemSelectionChanged
        e.Item.Selected = False
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ListView1.Items.Clear()

        Dim searchTerm As String = txtSearch.Text.ToLower()

        For Each item As ListViewItem In originalItems
            Dim appName As String = item.SubItems(0).Text.ToLower()

            If appName.Contains(searchTerm) Then
                ListView1.Items.Add(item.Clone())
            End If
        Next
    End Sub

    Private Sub OpenOutputFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenOutputFolderToolStripMenuItem.Click
        Try
            Process.Start(Application.StartupPath & "\apps")
        Catch ex As Exception
            MsgBox("Failed to open output folder.")
        End Try
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropertiesToolStripMenuItem.Click
        GetAppInfo()
    End Sub

    Private Sub btnSaveAPK_Click(sender As Object, e As EventArgs) Handles btnSaveAPK.Click
        If My.Computer.FileSystem.FileExists(loadedFileName) Then
            SaveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            SaveFileDialog1.Filter = "APK Files|*.apk"
            Dim defaultName As String = IO.Path.GetFileName(loadedFileName)
            SaveFileDialog1.FileName = defaultName
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim destinationPath As String = SaveFileDialog1.FileName
                My.Computer.FileSystem.CopyFile(loadedFileName, destinationPath, True)
                MsgBox("APK saved successfully!")
            End If
        Else
            MsgBox("Please select an app and fetch properties first!")
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        GetAppInfo()
    End Sub

    Public Sub GetAppInfo()
        If ListView1.SelectedIndices.Count = 1 Then
            MsgBox("Fetching app details...")
            MakeDirectoryIfNotExist(Application.StartupPath & "\apps")
            Dim fileName As String = ListView1.SelectedItems(0).Text.Trim()
            fileName = fileName.Replace(".", "_") & ".apk"
            FetchAPK(ListView1.SelectedItems(0).Tag, fileName)  'We must download the APK to get its name

            Dim appName As String = GetAppName(Application.StartupPath & "\apps\" & fileName)
            statAppName = appName

            Dim filePath As String = ListView1.SelectedItems(0).Tag
            Dim packageName As String = ListView1.SelectedItems(0).Text.Trim()

            Dim fileSize As String = BytesToString(GetAppSize(filePath))
            statAppSize = fileSize
            Dim appVersion As String = GetAppVersion(packageName)
            statAppVersion = appVersion
            statPackage = packageName

            statVersionCode = GetVersionCode(packageName)
            statMinSDK = GetMinSDK(packageName)
            statTargetSDK = GetTargetSDK(packageName)
            updateStatusUI()
        End If
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Dim filePath As String = ListView1.SelectedItems(0).Tag
        Dim packageName As String = ListView1.SelectedItems(0).Text.Trim()
        Dim fileSize As String = BytesToString(GetAppSize(filePath))
        Dim appVersion As String = GetAppVersion(packageName)
        statAppVersion = appVersion
        statAppSize = fileSize
        statPackage = packageName
        updateStatusUI()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Garbage cleanup
        DeleteDirectory(Application.StartupPath & "\apps")
    End Sub

    Public Sub PopulateDevicesList()
        lvDevices.Items.Clear()

        ' Step 1: Get a list of connected devices
        Dim deviceList As New List(Of String)()

        Dim listProcInfo As New ProcessStartInfo()
        listProcInfo.FileName = "adb"
        listProcInfo.Arguments = "devices"
        listProcInfo.RedirectStandardOutput = True
        listProcInfo.UseShellExecute = False
        listProcInfo.CreateNoWindow = True

        Dim listProc As New Process()
        listProc.StartInfo = listProcInfo
        listProc.Start()

        Dim listReader As System.IO.StreamReader = listProc.StandardOutput
        Dim listResult As String = listReader.ReadToEnd()

        listProc.WaitForExit()

        Dim lines() As String = listResult.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        For Each line In lines.Skip(1)
            If String.IsNullOrWhiteSpace(line) Then Continue For
            Dim parts() As String = line.Split(vbTab)
            If parts.Length > 1 Then
                deviceList.Add(parts(0).Trim())
            End If
        Next

        ' Step 2: Fetch details for each device and populate ListView
        For Each deviceID In deviceList
            ' Fetch device name
            Dim nameProcInfo As New ProcessStartInfo()
            nameProcInfo.FileName = "adb"
            nameProcInfo.Arguments = $"-s {deviceID} shell dumpsys bluetooth_manager"
            nameProcInfo.RedirectStandardOutput = True
            nameProcInfo.UseShellExecute = False
            nameProcInfo.CreateNoWindow = True

            Dim nameProc As New Process()
            nameProc.StartInfo = nameProcInfo
            nameProc.Start()

            Dim nameReader As System.IO.StreamReader = nameProc.StandardOutput
            Dim nameResult As String = nameReader.ReadToEnd().Trim()

            nameProc.WaitForExit()

            Dim nameRegex As New Regex("name: (.+)")
            Dim nameMatch As Match = nameRegex.Match(nameResult)
            Dim deviceName As String = If(nameMatch.Success, nameMatch.Groups(1).Value.Trim(), "Unknown")

            ' Fetch battery and charging info
            Dim detailsProcInfo As New ProcessStartInfo()
            detailsProcInfo.FileName = "adb"
            detailsProcInfo.Arguments = $"-s {deviceID} shell dumpsys battery"
            detailsProcInfo.RedirectStandardOutput = True
            detailsProcInfo.UseShellExecute = False
            detailsProcInfo.CreateNoWindow = True

            Dim detailsProc As New Process()
            detailsProc.StartInfo = detailsProcInfo
            detailsProc.Start()

            Dim detailsReader As System.IO.StreamReader = detailsProc.StandardOutput
            Dim detailsResult As String = detailsReader.ReadToEnd()

            detailsProc.WaitForExit()

            Dim battRegex As New Regex("level: (\d+)")
            Dim battMatch As Match = battRegex.Match(detailsResult)
            Dim battPercent As String = If(battMatch.Success, battMatch.Groups(1).Value, "Unknown")

            Dim chargeRegex As New Regex("AC powered: (\w+)")
            Dim chargeMatch As Match = chargeRegex.Match(detailsResult)
            Dim isACCharging As String = If(chargeMatch.Success AndAlso chargeMatch.Groups(1).Value = "true", "True", "False")
            Dim usbRegex As New Regex("USB powered: (\w+)")
            Dim usbMatch As Match = usbRegex.Match(detailsResult)
            Dim isUsbCharging As String = If(usbMatch.Success AndAlso usbMatch.Groups(1).Value = "true", "True", "False")
            Dim isCharging As String = "False"
            If isACCharging = "True" Or isUsbCharging = "True" Then
                isCharging = "True"
            End If

            ' Create a new ListViewItem and populate its columns
            Dim item As New ListViewItem(New String() {deviceName, deviceID, battPercent, isCharging})
            lvDevices.Items.Add(item)
        Next

        If lvDevices.Items.Count > 0 Then
            FetchAndPopulateApps()
        End If
    End Sub

    Public Sub DetachDevice(deviceID As String)
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = $"-s {deviceID} disconnect"
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()
        proc.WaitForExit()

        PopulateDevicesList()
    End Sub

    Public Sub UninstallApp(packageName As String)
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = $"uninstall {packageName}"
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()
        proc.WaitForExit()

        MsgBox("App has been uninstalled: " & packageName)
    End Sub

    Public Sub ServerAction(adbStart As Boolean)
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        If adbStart Then
            procStartInfo.Arguments = "start-server"
        Else
            procStartInfo.Arguments = "kill-server"
        End If
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()
        proc.WaitForExit()

        If adbStart Then
            MsgBox("ADB Server started!")
        Else
            MsgBox("ADB Server stopped!")
        End If
    End Sub

    Public Sub InstallApp(apkPath As String, Optional isReplace As Boolean = False)
        Dim args As String = "install"
        If isReplace Then args &= " -r"
        args &= $" ""{apkPath}"""

        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = "adb"
        procStartInfo.Arguments = args
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()
        proc.WaitForExit()

        Dim appName As String = GetAppName(apkPath)
        MsgBox(appName & " has been installed!")
    End Sub

    Private Sub btnListDevices_Click(sender As Object, e As EventArgs) Handles btnListDevices.Click
        PopulateDevicesList()
    End Sub

    Private Sub DisconnectDeviceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisconnectDeviceToolStripMenuItem.Click
        If lvDevices.SelectedItems.Count = 1 Then
            Dim deviceID As String = lvDevices.SelectedItems(0).SubItems(1).Text
            DetachDevice(deviceID)
        End If
    End Sub

    Public Function IsWebBasedDeviceID(ByVal deviceID As String) As Boolean
        Dim pattern As String = "^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}(:\d+)?$"
        Dim regex As New Regex(pattern)
        Return regex.IsMatch(deviceID)
    End Function

    Private Sub lvDevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvDevices.SelectedIndexChanged
        If lvDevices.SelectedItems.Count = 1 Then
            Dim deviceID As String = lvDevices.SelectedItems(0).SubItems(1).Text
            If IsWebBasedDeviceID(deviceID) Then    'wireless connection
                DisconnectDeviceToolStripMenuItem.Visible = True
                ConnectWirelesslyToolStripMenuItem.Visible = False
            Else    'Physical connection
                DisconnectDeviceToolStripMenuItem.Visible = False
                ConnectWirelesslyToolStripMenuItem.Visible = True
            End If
        End If
    End Sub

    Public Sub ConnectDeviceTCP(ByVal deviceID As String, ByVal port As String)
        lastNumDevices = lvDevices.Items.Count

        ' Fetch device IP
        Dim ipProcInfo As New ProcessStartInfo()
        ipProcInfo.FileName = "adb"
        ipProcInfo.Arguments = $"-s {deviceID} shell ip route"
        ipProcInfo.RedirectStandardOutput = True
        ipProcInfo.UseShellExecute = False
        ipProcInfo.CreateNoWindow = True

        Dim ipProc As New Process()
        ipProc.StartInfo = ipProcInfo
        ipProc.Start()

        Dim ipReader As System.IO.StreamReader = ipProc.StandardOutput
        Dim ipResult As String = ipReader.ReadToEnd()

        ipProc.WaitForExit()

        Dim ipRegex As New Regex("\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")
        Dim ipMatches As MatchCollection = ipRegex.Matches(ipResult)
        Dim ipAddress As String = If(ipMatches.Count > 0, ipMatches(ipMatches.Count - 1).Value, "Unknown")

        ' Step 1: Set the device to tcpip mode
        Dim tcpipProcInfo As New ProcessStartInfo()
        tcpipProcInfo.FileName = "adb"
        tcpipProcInfo.Arguments = $"-s {deviceID} tcpip {port}"
        tcpipProcInfo.CreateNoWindow = True
        tcpipProcInfo.UseShellExecute = False

        Dim tcpipProc As New Process()
        tcpipProc.StartInfo = tcpipProcInfo
        tcpipProc.Start()
        tcpipProc.WaitForExit()

        ' Step 2: Connect to the device using the fetched IP
        If ipAddress <> "Unknown" Then
            Dim connectProcInfo As New ProcessStartInfo()
            connectProcInfo.FileName = "adb"
            connectProcInfo.Arguments = $"connect {ipAddress}:{port}"
            connectProcInfo.CreateNoWindow = True
            connectProcInfo.UseShellExecute = False

            Dim connectProc As New Process()
            connectProc.StartInfo = connectProcInfo
            connectProc.Start()
            connectProc.WaitForExit()

            tmrPopulateDevices.Start()
        Else
            ' Handle the case where the IP is unknown
            ' Perhaps show a message box or log it
            MsgBox("Failed to retrieve IP address of device. Please connect manually.")
        End If
    End Sub

    Private Sub ConnectWirelesslyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectWirelesslyToolStripMenuItem.Click
        If lvDevices.SelectedItems.Count = 1 Then
            MsgBox("One moment please. Connecting...")
            Dim deviceID As String = lvDevices.SelectedItems(0).SubItems(1).Text
            ConnectDeviceTCP(deviceID, "5555")
        End If

    End Sub

    Private Sub tmrPopulateDevices_Tick(sender As Object, e As EventArgs) Handles tmrPopulateDevices.Tick
        tmrPopulateDevices.Stop()
        PopulateDevicesList()

        If lvDevices.Items.Count > lastNumDevices Then
            MsgBox("Device has wirelessly connected successfully! You may unplug it now.")
        End If
    End Sub

    Private Sub txtHost_GotFocus(sender As Object, e As EventArgs) Handles txtHost.GotFocus
        If txtHost.Text = "IP:PORT" Then
            txtHost.Clear()
        End If
    End Sub

    Public Sub ManualConnect(ByVal hostname As String)
        If IsWebBasedDeviceID(hostname) Or hostname.Contains("vimpaact.com") Then
            Dim procStartInfo As New ProcessStartInfo()
            procStartInfo.FileName = "adb"
            procStartInfo.Arguments = $"connect {hostname}"
            procStartInfo.UseShellExecute = False
            procStartInfo.CreateNoWindow = True

            Dim proc As New Process()
            proc.StartInfo = procStartInfo
            proc.Start()
            proc.WaitForExit()

            tmrPopulateDevices.Start()
        Else
            MsgBox("The hostname is invalid. Please check and try again.")
        End If

    End Sub

    Public Sub LaunchScreenControl(ByVal deviceID As String)
        Dim procStartInfo As New ProcessStartInfo()
        procStartInfo.FileName = $"{Application.StartupPath}\scr\scrcpy.exe"
        procStartInfo.Arguments = $"-s {deviceID}"
        procStartInfo.UseShellExecute = False
        procStartInfo.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = procStartInfo
        proc.Start()
    End Sub

    Public Sub StartScreenRecord(deviceID As String)
        Dim videosPath As String = IO.Path.Combine(Application.StartupPath, "videos")
        MakeDirectoryIfNotExist(videosPath)

        Dim mp4FileName As String = $"screenrecord_{DateTime.Now.ToString("yyyyMMddHHmmss")}.mp4"
        Dim mp4FilePath As String = IO.Path.Combine(videosPath, mp4FileName)
        mp4FilePath = """" & mp4FilePath & """"  ' Add quotes around the path

        Dim procInfo As New ProcessStartInfo()
        procInfo.FileName = $"{Application.StartupPath}\scr\scrcpy.exe"
        procInfo.Arguments = $"-s {deviceID} --record={mp4FilePath}"
        procInfo.CreateNoWindow = True
        procInfo.UseShellExecute = False

        Dim proc As New Process()
        proc.StartInfo = procInfo
        proc.Start()
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        ManualConnect(txtHost.Text)
    End Sub

    Private Sub btnLaunchScreen_Click(sender As Object, e As EventArgs) Handles btnLaunchScreen.Click
        If lvDevices.SelectedItems.Count = 1 Then
            Dim deviceID As String = lvDevices.SelectedItems(0).SubItems(1).Text
            LaunchScreenControl(deviceID)

        Else
            MsgBox("Please first select a device to show.")
        End If
    End Sub

    Public Sub ExtractFolder(zipPath As String, dirPath As String)
        ZipFile.ExtractToDirectory(zipPath, dirPath)
    End Sub

    Private Sub btnScreenRecord_Click(sender As Object, e As EventArgs) Handles btnScreenRecord.Click
        If lvDevices.SelectedItems.Count = 1 Then
            Dim deviceID As String = lvDevices.SelectedItems(0).SubItems(1).Text
            StartScreenRecord(deviceID)

        Else
            MsgBox("Please first select a device to show.")
        End If
    End Sub

    Private Sub UninstallAPKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallAPKToolStripMenuItem.Click
        If ListView1.SelectedIndices.Count = 1 Then
            Dim packageName As String = ListView1.SelectedItems(0).Text.Trim()
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to uninstall this app?", "Spectrum ADB", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
            ElseIf result = DialogResult.No Then
            ElseIf result = DialogResult.Yes Then
                UninstallApp(packageName)
                FetchAndPopulateApps()
                txtSearch.Clear()
            End If

        Else
            MsgBox("Please select an app to uninstall.")
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtApkPath.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnInstallAPK_Click(sender As Object, e As EventArgs) Handles btnInstallAPK.Click
        If My.Computer.FileSystem.FileExists(txtApkPath.Text) Then
            btnInstallAPK.Enabled = False
            MsgBox("Now installing. One moment please...")
            Dim replaceApp As Boolean = chkReplaceApp.Checked
            InstallApp(txtApkPath.Text, replaceApp)
            btnInstallAPK.Enabled = True
            FetchAndPopulateApps()
        Else
            MsgBox("Please select a valid APK file!")
        End If
    End Sub

    Private Sub txtApkPath_DragEnter(sender As Object, e As DragEventArgs) Handles txtApkPath.DragEnter
        ' Check if the data being dragged is a file
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtApkPath_DragDrop(sender As Object, e As DragEventArgs) Handles txtApkPath.DragDrop
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        ' Check if only one file was dropped and it's an APK file
        If files.Length = 1 AndAlso IO.Path.GetExtension(files(0)).ToLower() = ".apk" Then
            txtApkPath.Text = files(0)
        Else
            MsgBox("Please drop only one APK file!")
        End If
    End Sub

    Private Sub btnKillADB_Click(sender As Object, e As EventArgs) Handles btnKillADB.Click
        ServerAction(False)
    End Sub

    Private Sub btnStartADB_Click(sender As Object, e As EventArgs) Handles btnStartADB.Click
        ServerAction(True)
    End Sub
End Class
