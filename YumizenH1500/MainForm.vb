Imports SimpleTCP

Imports System.IO
Imports System.Text

Imports Bluegrams.Application
Imports System.Environment

Public Class MainForm

    'ASCII Values
    Public SOH As String = Char.ConvertFromUtf32(1)
    Public STX As String = Char.ConvertFromUtf32(2)
    Public ETX As String = Char.ConvertFromUtf32(3)
    Public EOT As String = Char.ConvertFromUtf32(4)
    Public ENQ As String = Char.ConvertFromUtf32(5)
    Public ACK As String = Char.ConvertFromUtf32(6)
    Public NAK As String = Char.ConvertFromUtf32(21)
    Public ETB As String = Char.ConvertFromUtf32(23)
    Public LF As String = Char.ConvertFromUtf32(10)
    Public CR As String = Char.ConvertFromUtf32(13)
    Public DLE As String = Char.ConvertFromUtf32(16)
    'ENd ASCII

    Dim MessageType As String

    Dim IP As System.Net.IPAddress
    Dim WithEvents Server As New SimpleTcpServer()

    'String manipulation in "Received Data"
    Dim PatientID As String
    Dim PatientName As String
    Dim PatientSex As String
    Dim PatientSexFinal As String
    Dim PatientBdate As String
    Dim PatientBdateFinal As String
    Dim MainID As String
    Dim SampleID As String
    Dim OrderID As String
    Dim ControlID As String
    Dim ctrl_val As String
    Dim ResultName As String
    Dim ResultValue As String
    Dim Instrument As String
    Dim Serial As String
    Dim Section As String
    Dim SubSection As String = "CBC"
    Dim QueryStatus As Boolean = False
    Dim SampleID_Final As String
    Dim DateReceived As String
    Dim TimeReceived As String
    'END

    'String manipulation "Query Data"
    Dim QRSampleID As String
    Dim QRMainID As String
    Dim PatientID_Out As String
    Dim PatientName_Out As String
    Dim PatientBDate_Out As String
    Dim PatientSex_Out As String

    Dim OrderSampleID_Out As String
    Dim OrderTest_Out As String

    Public TestList As New List(Of String)

    Dim PatientName_Final As String
    Dim PatientLastName As String
    Dim PatientFirstName As String
    'END

    'Variables for retrieving data in the database
    Dim unit, range, unit_conv, range_conv, age_group, patient_id, test_name, test_code, test_group, order_no As String
    Dim DefaultUnit As Integer = 0

    'Write to TraceComm.log FIle
    Dim CommLog As FileStream
    Dim CommWriter As StreamWriter
    Dim TraceComm As String = "TraceComm.log"
    'END

    'Write to ConnectionString.log File
    Dim ConnectionLog As FileStream
    Dim ConnectionWriter As StreamWriter
    Dim ConnectionString As String = "ConnectionString.log"

    Dim Settings As String = "Settings.config"
    Dim SettingsContent As String = ""

    Dim Segment As String = ""
    Dim Packets As String = ""

    Dim HeaderOutput As String
    Dim PatientOutput As String
    Dim OrderOutput As String
    Dim Terminator As String

    Private Sub GetMachineSettings()
        Dim path As String = Application.StartupPath & "\" & Settings
        Dim reader = File.OpenText(path)

        Dim line As String = Nothing

        Dim lines As Integer = 0

        SettingsContent = reader.ReadLine()

    End Sub

    Private Sub SaveMachineSettings()
        CommLog = New FileStream(Settings, FileMode.Create, FileAccess.Write)
        CommWriter = New StreamWriter(CommLog)
        CommWriter.WriteLine(txtMachine.Text & "_" & txtSerial.Text)
        CommWriter.Close()
        CommLog.Close()

        SettingsContent = txtMachine.Text & "_" & txtSerial.Text
        LoadSettings()
    End Sub

    Private Sub LoadSettings()
        GetMachineSettings()
        ' Get the path to the Application Data folder
        Dim FolderPath As String = GetFolderPath(SpecialFolder.LocalApplicationData) & "\AppSupport\"

        'Create Folder
        Directory.CreateDirectory(FolderPath)

        PortableSettingsProvider.SettingsFileName = SettingsContent & ".cs"
        PortableSettingsProvider.SettingsDirectory = FolderPath
    End Sub

    Private Sub LoadAllSettings()
        Try

            'Retrieve saved settings for default use
            With My.Settings
                'Display ComPort and Machine Settings in textbox
                cboIPAddress.Text = .IPAddress
                cboPort.Text = .Port
                'txtMachine.Text = "YumizenH500"
                If .Machine <> "" Then
                    txtMachine.Text = .Machine
                Else
                    txtMachine.Text = ""
                End If
                txtSerial.Text = .SerialNo
                txtSection.Text = .Section
                cboLocation.Text = .Location

                'Server Setting
                txtServerName.Text = .HostName
                txtRoot.Text = .UID
                txtPassword.Text = .PWD
                txtDBName.Text = .DBName

                'Machine Settings
                Instrument = .Machine
                Serial = .SerialNo
                Section = .Section

                'For Two Way Process
                If .ReceivingStatus = 1 Then
                    chkReceiving.CheckState = CheckState.Checked
                Else
                    chkReceiving.CheckState = CheckState.Unchecked
                End If

                If .Pro = 1 Then
                    chkPro.CheckState = CheckState.Checked
                Else
                    chkPro.CheckState = CheckState.Unchecked
                End If

                '###############################################################################################################################################################
                Me.Text = "Analyzer Driver " & .Machine & "(" & cboIPAddress.Text & ")"
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                )
            Exit Sub
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.ReceivedText.Text = ""
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim path As String = Application.StartupPath & "\" & Settings
            ' This text is added only once to the file.
            If File.Exists(path) = True Then
                LoadSettings()
                LoadAllSettings()
            End If

            Server.StringEncoder = Encoding.UTF8
            Server.Delimiter = &HD

            IP = System.Net.IPAddress.Parse(cboIPAddress.Text)
            Server.Start(IP, Convert.ToInt32(cboPort.Text))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (MessageBox.Show("Are you sure you want to close the application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            'NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            'NotifyIcon1.BalloonTipTitle = txtMachine.Text & " (" & ComPortsBox.Text & ") " & "Communication"
            'NotifyIcon1.BalloonTipText = "Do not close this application!"
            'NotifyIcon1.ShowBalloonTip(5000)
            'Me.Hide()
            ShowInTaskbar = False
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.WindowState = FormWindowState.Normal
        Me.Show()
        ShowInTaskbar = True
        NotifyIcon1.Visible = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        frmLogin.Show()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cboIPAddress.Text = "" Or cboPort.Text = "" Or txtSerial.Text = "" Or txtMachine.Text = "" Or txtDBName.Text = "" Or txtRoot.Text = "" Or txtSection.Text = "" Or txtSerial.Text = "" Or
            txtServerName.Text = "" Then
            MessageBox.Show("Please fill all required parameteres.", "Null Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            SaveMachineSettings()

            With My.Settings
                'Save To Configuration Settings
                .IPAddress = cboIPAddress.Text
                .Port = cboPort.Text
                .Machine = txtMachine.Text
                .SerialNo = txtSerial.Text
                .Section = txtSection.Text

                .HostName = txtServerName.Text
                .UID = txtRoot.Text
                .PWD = txtPassword.Text
                .DBName = txtDBName.Text
                .Location = cboLocation.Text

                If Me.chkReceiving.CheckState = CheckState.Checked Then
                    .ReceivingStatus = 1
                Else
                    .ReceivingStatus = 0
                End If

                If Me.chkPro.CheckState = CheckState.Checked Then
                    .Pro = 1
                Else
                    .Pro = 0
                End If

                .ConnectionString = "SERVER = " & .HostName & "; DATABASE = " & .DBName & "; UID = " & .UID & "; PWD = " & .PWD & ";"
                .Save()
                '###########################################################################################################################################################

                'Get Executable Path for saving
                Dim path As String = Application.ExecutablePath

                'Parameteres for table machines
                rs.Parameters.Clear()
                rs.Parameters.AddWithValue("@path", path)

                conn.ConnectionString = .ConnectionString
                conn.Open()
                rs.Connection = conn
                rs.CommandText = "SELECT * FROM `machines` WHERE `name` = '" & txtMachine.Text & "' AND `serial_no` = '" & txtSerial.Text & "'"
                reader = rs.ExecuteReader
                reader.Read()
                If reader.HasRows Then
                    conn.Close()
                    conn.ConnectionString = .ConnectionString
                    conn.Open()
                    rs.Connection = conn
                    rs.CommandText = "UPDATE `machines` SET " _
                        & "`name` = '" & txtMachine.Text & "'," _
                        & "`test_name` = '" & txtSection.Text & "'," _
                        & "`serial_no` = '" & txtSerial.Text & "'," _
                        & "`com_port` = '" & cboIPAddress.Text & "'," _
                        & "`baud_rate`= '" & cboPort.Text & "'," _
                        & "`status` = 'Disconnected'," _
                        & "`location` = @path" _
                        & " WHERE `name` = '" & txtMachine.Text & "' AND `serial_no` = '" & txtSerial.Text & "'"
                    rs.ExecuteNonQuery()
                    conn.Close()
                Else
                    conn.Close()
                    conn.ConnectionString = .ConnectionString
                    conn.Open()
                    rs.Connection = conn
                    rs.CommandText = "INSERT INTO `machines` (`name`, `test_name`, `serial_no`, `com_port`, `baud_rate`, `status`, `location`) VALUES ('" & txtMachine.Text & "', '" & txtSection.Text & "', '" & txtSerial.Text & "', '" & cboIPAddress.Text & "', '" & cboPort.Text & "', 'Disconnected', @path)"
                    rs.ExecuteNonQuery()
                    conn.Close()
                End If
                conn.Close()

                MessageBox.Show("Settings saved! " & vbNewLine & "Please restart the application to take effect.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '#############################################################################################################################################################
                End
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Function Data_Converter(ByVal Raw_Data As String) As String
        Raw_Data = Raw_Data.Replace(STX, "<STX>")
        Raw_Data = Raw_Data.Replace(ETX, "<ETX>")
        Raw_Data = Raw_Data.Replace(SOH, "<SOH>")
        'Raw_Data = Raw_Data.Replace(LF, "<LF>")
        Raw_Data = Raw_Data.Replace(CR, "<CR>")
        Raw_Data = Raw_Data.Replace(NAK, "<NAK>")
        Raw_Data = Raw_Data.Replace(ENQ, "<ENQ>")
        Raw_Data = Raw_Data.Replace(EOT, "<EOT>")
        Raw_Data = Raw_Data.Replace(DLE, "<DLE>")
        Raw_Data = Raw_Data.Replace(ETB, "<ETB>")
        Raw_Data = Raw_Data.Replace(ACK, "<ACK>")
        Return Raw_Data
    End Function

    'MessageBox.Show("Result " & Segment.Split("|").GetValue(3).ToString)
    Private Sub Server_DataRecieved(sender As Object, e As SimpleTCP.Message) Handles Server.DataReceived
        'e.ReplyLine(ACK)
        'Dim myMessage = e.MessageString.Substring(0, e.MessageString.Length - 1)
        'Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(myMessage)))
        'Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))
        'Me.Invoke(Sub() ReadData(myMessage))
        Dim myMessage = e.MessageString.Substring(0, 1)
        Dim _gyte() As Byte = Encoding.UTF8.GetBytes(ACK)

        If myMessage = ENQ Then

            Me.Invoke(Sub()
                          ' ClearData()
                          Me.ReceivedText.Text = ""
                      End Sub)

            'Reply ACK if ENQ is received
            'e.ReplyLine(ACK)
            e.Reply(_gyte)
            'Dispaly Sent and Received Packets to RichTextBox
            Me.Invoke(Sub() ReadData("******************************Start-of-Communication*******************************"))
            Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(myMessage)))
            Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))
            Threading.Thread.Sleep(500)
        ElseIf myMessage = STX Then
            ''Reply ACK if STX is received
            'e.ReplyLine(ACK)
            ''Display Sent and Received Packets to RichTextBox
            'Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))))
            'Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))
            'Split packets into segments
            Packets = Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))
            Segment = Packets.Split("|").GetValue(0)
            'Conditions on received segments
            'If Segment <= 7 Then

            'Conditions on received segments
            If (Segment(6).ToString = "H") Then
                'Header packet is received
                ctrl_val = Packets.Split("|").GetValue(11)

                e.Reply(_gyte)
                ''Display Sent and Received Packets to RichTextBox
                Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))))
                Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))
                'Threading.Thread.Sleep(500)
            ElseIf (Segment(6).ToString = "P") Then
                'Patient packet is received

                If Packets.Split("|").Count > 8 Then
                    PatientID = Packets.Split("|").GetValue(3).ToString()
                    PatientName = Packets.Split("|").GetValue(5).ToString()

                    'Debug.WriteLine($"Patient Char length: {Packets.Split("|").Length}")

                    '#################---For Pentra ES60---#############################################
                    'PatientName = PatientName.Split("<").GetValue(0).ToString & vbCrLf
                    '#################---For Pentra ES60---#############################################

                    PatientName = PatientName.Replace("^", ", ").ToString().TrimEnd

                    PatientBdate = Packets.Split("|").GetValue(7).ToString().TrimEnd

                    If Not PatientBdate.ToString = "" Then
                        PatientBdateFinal = DateTime.ParseExact(PatientBdate.Trim, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy")
                    Else
                        PatientBdateFinal = ""
                    End If

                    PatientSex = Packets.Split("|").GetValue(8).ToString()
                    PatientSex = PatientSex.Split("<").GetValue(0).ToString & vbCrLf

                    If Not PatientSex = "" Then
                        PatientSex = PatientSex(0).ToString
                        If RemoveWhitespace(PatientSex) = "M" Then
                            PatientSexFinal = "Male"
                        ElseIf RemoveWhitespace(PatientSex) = "F" Then
                            PatientSexFinal = "Female"
                        Else
                            PatientSexFinal = ""
                        End If
                    Else
                        PatientSexFinal = ""
                    End If
                Else
                    PatientID = ""
                PatientName = ""
                PatientBdate = ""
                PatientSex = ""
                PatientBdateFinal = ""
                PatientSexFinal = ""
            End If
            'Threading.Thread.Sleep(500)
            e.Reply(_gyte)
            ''Display Sent and Received Packets to RichTextBox
            Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))))
                    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))
                ElseIf (Segment(6).ToString = "O") Then
                    'Order
                    If Packets.Split("|").GetValue(6).ToString().Trim = "" Then

                        DateReceived = Now.ToString("yyyy-MM-dd")
                        'DateReceived = DateTime.ParseExact(Packets.Split("|").GetValue(7).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                        TimeReceived = Now.ToString("hh:mm:ss tt")
                        'TimeReceived = DateTime.ParseExact(Packets.Split("|").GetValue(7).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("hh:mm:ss tt")
                    Else
                        'DateReceived = Now 'DateTime.ParseExact(Packets.Split("|").GetValue(6).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                        DateReceived = DateTime.ParseExact(Packets.Split("|").GetValue(6).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                        'TimeReceived = Now.ToShortTimeString 'DateTime.ParseExact(Packets.Split("|").GetValue(6).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("hh:mm:ss tt")
                        TimeReceived = DateTime.ParseExact(Packets.Split("|").GetValue(6).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("hh:mm:ss tt")
                    End If

                    ''DateReceived = Now 'DateTime.ParseExact(Packets.Split("|").GetValue(6).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                    'DateReceived = DateTime.ParseExact(Packets.Split("|").GetValue(7).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                    ''TimeReceived = Now.ToShortTimeString 'DateTime.ParseExact(Packets.Split("|").GetValue(6).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("hh:mm:ss tt")
                    'TimeReceived = DateTime.ParseExact(Packets.Split("|").GetValue(7).ToString().Trim, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("hh:mm:ss tt")

                    SampleID = Packets.Split("|").GetValue(2).ToString().Trim

                    'OrderID = StrConv(SampleID.Split("^").GetValue(0).ToString, VbStrConv.Uppercase)
                    OrderID = Packets.Split("|").GetValue(15).ToString().Trim
                    OrderID = StrConv(OrderID.Split("^").GetValue(0).ToString, VbStrConv.Uppercase)

                    If OrderID.Trim = "CTRL" Then
                        'SampleID_Final = StrConv(SampleID.Split("^").GetValue(4).ToString.TrimEnd, VbStrConv.Uppercase)
                        MainID = RemoveWhitespace(SampleID.Split("^").GetValue(4).ToString)
                    Else
                        'SampleID_Final = StrConv(SampleID.Split("^").GetValue(0).ToString.TrimEnd, VbStrConv.Uppercase)
                        MainID = RemoveWhitespace(SampleID.Split("^").GetValue(0).ToString)
                    End If

                    'If ctrl_val = "P" Then
                    '    MainID = RemoveWhitespace(SampleID.Split("^").GetValue(0).ToString)
                    'ElseIf ctrl_val = "D" Then
                    '    MainID = RemoveWhitespace(SampleID.Split("^").GetValue(0).ToString)
                    'ElseIf ctrl_val = "Q" Then
                    '    MainID = RemoveWhitespace(SampleID.Split("^").GetValue(0).ToString)
                    'ElseIf ctrl_val = "F" Then
                    '    MainID = RemoveWhitespace(SampleID.Split("^").GetValue(0).ToString)
                    'Else
                    '    MainID = RemoveWhitespace(SampleID)
                    'End If

                    'If SampleID.Split("^").Length > 1 Then
                    '    MainID = RemoveWhitespace(SampleID.Split("^").GetValue(0).ToString)
                    'ElseIf ctrl_val.Length = "D" Then
                    '    MainID = RemoveWhitespace(SampleID.Split("^").GetValue(0).ToString)
                    'Else
                    '    MainID = RemoveWhitespace(SampleID)
                    'End If

                    'MainID = RemoveWhitespace(SampleID)
                    e.Reply(_gyte)
                    ''Display Sent and Received Packets to RichTextBox
                    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))))
                    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))

                    Disconnect()
                    getRun_Number(MainID, Section, SubSection)

                    Disconnect()
                    Me.Invoke(Sub() IdentifyOrder(MainID, RemoveWhitespace(PatientID), PatientName, Instrument, Serial, Section, MainID, PatientSexFinal, PatientBdateFinal, DateReceived, TimeReceived))
                    'Threading.Thread.Sleep(500)
                ElseIf (Segment(6).ToString = "R") Then
                    'Result packet is received
                    ResultName = Packets.Split("|").GetValue(2).ToString().Trim
                    ResultName = ResultName.Split("^").GetValue(3).ToString.Trim

                    'ResultName = Replace(Packets.Split("|").GetValue(2).ToString(), "^", " ").Trim
                    'ResultName = ResultName.Split(" "c)(0)
                    ResultValue = Packets.Split("|").GetValue(3).ToString()

                    'OrderID = Packets.Split("|").GetValue(15).ToString().Trim

                    e.Reply(_gyte)
                    ''Display Sent and Received Packets to RichTextBox
                    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))))
                    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))

                    If OrderID.Trim = "CTRL" Then
                        Me.Invoke(Sub() InsertControl(MainID, ResultName, ResultValue.TrimEnd, Instrument, Serial, Section, DateReceived, MainID, DateReceived, TimeReceived))
                    Else
                        Me.Invoke(Sub() InsertResultData(MainID, ResultName, ResultValue.TrimEnd, Instrument, Serial, MainID, DateReceived, TimeReceived))
                    End If

                    'If ctrl_val = "P" Then
                    '    Me.Invoke(Sub() InsertResultData(MainID, ResultName, ResultValue.TrimEnd, Instrument, Serial, MainID, DateReceived, TimeReceived))
                    'ElseIf ctrl_val = "D" Then
                    '    'Me.Invoke(Sub() InsertControl(MainID, ResultName, ResultValue.TrimEnd, Instrument, Serial, Section, DateReceived, MainID, DateReceived, TimeReceived))
                    '    Me.Invoke(Sub() InsertResultData(MainID, ResultName, ResultValue.TrimEnd, Instrument, Serial, MainID, DateReceived, TimeReceived))
                    'ElseIf ctrl_val = "Q" Then
                    '    Me.Invoke(Sub() InsertControl(MainID, ResultName, ResultValue.TrimEnd, Instrument, Serial, Section, DateReceived, MainID, DateReceived, TimeReceived))
                    'ElseIf ctrl_val = "F" Then
                    '    Me.Invoke(Sub() InsertControl(MainID, ResultName, ResultValue.TrimEnd, Instrument, Serial, Section, DateReceived, MainID, DateReceived, TimeReceived))
                    'Else
                    '    Me.Invoke(Sub() InsertResultData(MainID, ResultName, ResultValue.TrimEnd, Instrument, Serial, MainID, DateReceived, TimeReceived))
                    'End If

                    'Me.Invoke(Sub() InsertResultData(MainID, ResultName, ResultValue.TrimEnd, Instrument, Serial, MainID, DateReceived, TimeReceived))
                    'Threading.Thread.Sleep(500)
                ElseIf (Segment(6).ToString = "Q") Then
                    'Query packet is received
                    QRSampleID = Packets.Split("|").GetValue(2).ToString().Trim
                    QRMainID = StrConv(QRSampleID.Split("^").GetValue(1).ToString.Trim, VbStrConv.Uppercase)

                    'Add SampleID to the List
                    lvSampleID.Items.Add(QRMainID)

                    QueryStatus = True

                    e.Reply(_gyte)
                    ''Display Sent and Received Packets to RichTextBox
                    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))))
                    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))
                    ' Threading.Thread.Sleep(500)
                ElseIf (Segment(6).ToString = "L") Then

                    'Terminator packet is received
                    'Threading.Thread.Sleep(500)
                    e.Reply(_gyte)
                    ''Display Sent and Received Packets to RichTextBox
                    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))))
                    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))

                    'ElseIf (Segment(6).ToString = "C") Then

                    '    'Reply ACK if STX is received
                    '    'e.ReplyLine(ACK)
                    '    'Display Sent and Received Packets to RichTextBox
                    '    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))))
                    '    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))

                    '    ' Threading.Thread.Sleep(500)
                    'ElseIf (Segment(6).ToString = "M") Then

                    '    'Reply ACK if STX is received
                    '    ' e.ReplyLine(ACK)
                    '    'Display Sent and Received Packets to RichTextBox
                    '    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(e.MessageString.Substring(0, e.MessageString.Length - 1))))
                    '    Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ACK)))
                    '    'Threading.Thread.Sleep(500)

                Else

                    e.Reply(_gyte)

                End If

            'Else

            '    e.Reply(_gyte)

            'End If

        ElseIf myMessage = EOT Then
            Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(myMessage)))
            Me.Invoke(Sub() ReadData("******************************End-of-Communication*******************************"))
            If QueryStatus = True Then
                For a = 0 To Me.lvSampleID.Items.Count - 1 Step 1
                    Connect()
                    rs.Connection = conn
                    rs.CommandText = "SELECT `tmpWorklist`.`sample_id`, `tmpWorklist`.`patient_id`, `tmpWorklist`.`patient_name`, `tmpWorklist`.`sex`, `tmpWorklist`.`bdate`, `patient_order`.`mode` FROM `tmpWorklist`, `patient_order` WHERE `tmpWorklist`.`sample_id` = '" & lvSampleID.Items(a).SubItems(0).Text & "' LIMIT 1"
                    reader = rs.ExecuteReader
                    reader.Read()
                    If reader.HasRows Then
                        PatientID_Out = reader(1).ToString
                        PatientName_Out = Replace(reader(2).ToString, ", ", "^")

                        PatientLastName = Split(PatientName_Out, "^").GetValue(0)
                        PatientFirstName = Split(PatientName_Out, "^").GetValue(1)

                        If PatientFirstName.Length <= 19 Then
                            PatientName_Final = PatientLastName & "^" & PatientFirstName
                        ElseIf PatientFirstName.Length >= 20 Then
                            PatientName_Final = PatientLastName & "^" & PatientFirstName.Substring(0, 19)
                        End If

                        'PatientBDate_Out = DateTime.ParseExact(reader(4), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyyMMdd")
                        PatientSex_Out = reader(3).ToString.Substring(0, 1)
                        OrderSampleID_Out = reader(0).ToString
                        Disconnect()

                        MainID = OrderSampleID_Out

                        Me.Invoke(Sub() ReadData("******************************Query-Start*******************************"))
                        'This part is for Yumizen H500/550 /Sending query to machine
                        HeaderOutput = "1H|\^&|||SBSI LIS|||||||P|LIS2-A2|" & FormatDateRegex()
                        PatientOutput = "2P|1||" & PatientID_Out & "||" & PatientName_Final & "||" & PatientBDate_Out & "|" & PatientSex_Out & "|||||"
                        OrderOutput = "3O|1|" & OrderSampleID_Out & "||^^^DIF|R|" & FormatDateRegex() & "|||||N||||||||||||||Q|||||"
                        Terminator = "4L|1|"
                        'End

                        'Checksum for Packects
                        Dim SumHeader As String = CheckSum(HeaderOutput & CR & ETX)
                        Dim SumPatient As String = CheckSum(PatientOutput & CR & ETX)
                        Dim SumOrder As String = CheckSum(OrderOutput & CR & ETX)
                        Dim SumTerminator As String = CheckSum(Terminator & CR & ETX)
                        'End Checksum

                        'Sending Packects to Instrument
                        'Send ENQ
                        e.ReplyLine(ENQ)
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(ENQ)))
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(ACK)))
                        Threading.Thread.Sleep(500)
                        'End ENQ
                        'Send Header
                        e.ReplyLine(STX & HeaderOutput & CR & ETX & SumHeader & CR & LF)
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(STX & HeaderOutput & CR & ETX & SumHeader & CR)))
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(ACK)))
                        Threading.Thread.Sleep(500)
                        'End Header
                        'Send Patient
                        e.ReplyLine(STX & PatientOutput & CR & ETX & SumPatient & CR & LF)
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(STX & PatientOutput & CR & ETX & SumPatient & CR)))
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(ACK)))
                        Threading.Thread.Sleep(500)
                        'End Patient
                        'Send Order
                        e.ReplyLine(STX & OrderOutput & CR & ETX & SumOrder & CR & LF)
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(STX & OrderOutput & CR & ETX & SumOrder & CR)))
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(ACK)))
                        Threading.Thread.Sleep(500)
                        'End Order
                        'Send Terminator
                        e.ReplyLine(STX & Terminator & CR & ETX & SumTerminator & CR & LF)
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(STX & Terminator & CR & ETX & SumTerminator & CR)))
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Instrument] : " & Data_Converter(ACK)))
                        Threading.Thread.Sleep(500)
                        'End Terminator
                        'Send EOT
                        e.ReplyLine(EOT)
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(EOT)))
                        Me.Invoke(Sub() ReadData("******************************Query-End*******************************"))
                        'End EOT
                        'End sending Packets to Instrument

                        'Set QueryStatus to False
                        'End QueryStatus
                        Disconnect()
                    Else
                        Me.Invoke(Sub() ReadData(System.DateTime.Now & " [Host] : " & Data_Converter(EOT)))
                        Me.Invoke(Sub() ReadData("******************************No Sample*******************************"))
                        ''This part is for Yumizen H500/550 /Sending query to machine
                        'HeaderOutput = "1H|\^&|||SBSI LIS|||||||P|LIS2-A2|" & FormatDateRegex()
                        'Terminator = "4L|1|"
                        ''End

                        ''Checksum for Packects
                        'Dim SumHeader As String = CheckSum(HeaderOutput & CR & ETX)
                        'Dim SumPatient As String = CheckSum(PatientOutput & CR & ETX)
                        'Dim SumOrder As String = CheckSum(OrderOutput & CR & ETX)
                        'Dim SumTerminator As String = CheckSum(Terminator & CR & ETX)
                        ''End Checksum

                        ''Sending Packects to Instrument
                        ''Send ENQ
                        'e.ReplyLine(ENQ)
                        'Me.Invoke(Sub() ReadData(Data_Converter(ENQ)))
                        'Me.Invoke(Sub() ReadData(Data_Converter(ACK)))
                        'Threading.Thread.Sleep(500)
                        ''End ENQ
                        ''Send Header
                        'e.ReplyLine(STX & HeaderOutput & CR & ETX & SumHeader & CR & LF)
                        'Me.Invoke(Sub() ReadData(Data_Converter(STX & HeaderOutput & CR & ETX & SumHeader & CR)))
                        'Me.Invoke(Sub() ReadData(Data_Converter(ACK)))
                        'Threading.Thread.Sleep(500)
                        ''End Header
                        ''Send Terminator
                        'e.ReplyLine(STX & Terminator & CR & ETX & SumTerminator & CR & LF)
                        'Me.Invoke(Sub() ReadData(Data_Converter(STX & Terminator & CR & ETX & SumTerminator & CR)))
                        'Me.Invoke(Sub() ReadData(Data_Converter(ACK)))
                        'Threading.Thread.Sleep(500)
                        ''Send EOT
                        'e.ReplyLine(EOT)
                        'Me.Invoke(Sub() ReadData(Data_Converter(EOT)))
                        ''End EOT
                        ''End sending Packets to Instrument

                        'Set QueryStatus to False
                        QueryStatus = False
                        'End QueryStatus
                        Disconnect()
                    End If
                    Disconnect()
                Next
                QueryStatus = False
                lvSampleID.Items.Clear()
            End If

        End If

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            IP = System.Net.IPAddress.Parse(cboIPAddress.Text)
            Server.Start(IP, Convert.ToInt32(cboPort.Text))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub ReadData(Message As String)
        ReceivedText.Text &= Message & vbCrLf
        ReceivedText.SelectionStart = ReceivedText.Text.Length
        ReceivedText.SelectionLength = 0
    End Sub

    Private Sub ClearData()
        ReceivedText.Text = ""
    End Sub
    Private Sub IdentifyOrder(ByVal OrderID As String, ByVal PatientID As String, ByVal PatientName As String, ByVal Instrument As String, ByVal SerialNo As String, ByVal Section As String, ByVal MainID As String, ByVal PatientGender As String, ByVal PatientBirthDate As String, ByVal DateReceived As String, ByVal TimeReceived As String)
        rs.Parameters.Clear()
        rs.Parameters.AddWithValue("@sample_id", OrderID)
        rs.Parameters.AddWithValue("@mainID", OrderID)

        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT `ctrl_id` FROM `control_setting` WHERE `ctrl_id` LIKE @sample_id"
        reader = rs.ExecuteReader
        reader.Read()
        If reader.HasRows Then
            Disconnect()
        Else
            Disconnect()
            DisplayOrder(OrderID, PatientID, PatientName, Instrument, SerialNo, Section, MainID, PatientGender, PatientBirthDate, DateReceived, TimeReceived)
        End If
        Disconnect()
    End Sub

    Private Sub DisplayOrder(ByVal OrderID As String, ByVal PatientID As String, ByVal PatientName As String, ByVal Instrument As String, ByVal SerialNo As String, ByVal Section As String, ByVal MainID As String, ByVal PatientGender As String, ByVal PatientBirthDate As String, ByVal DateReceived As String, ByVal TimeReceived As String)
        'LoadSampleID()

        rs.Parameters.Clear()
        rs.Parameters.AddWithValue("@sampleid", OrderID)
        rs.Parameters.AddWithValue("@mainid", MainID)
        rs.Parameters.AddWithValue("@patient_id", PatientID)
        rs.Parameters.AddWithValue("@name", PatientName)
        rs.Parameters.AddWithValue("@sex", PatientGender)
        rs.Parameters.AddWithValue("@bdate", PatientBirthDate)
        rs.Parameters.AddWithValue("@date", DateReceived)
        rs.Parameters.AddWithValue("@time", TimeReceived)
        rs.Parameters.AddWithValue("@status", "Result Received")
        rs.Parameters.AddWithValue("@instrument", Instrument & "_" & SerialNo)
        rs.Parameters.AddWithValue("@location", cboLocation.Text)
        rs.Parameters.AddWithValue("@section", Section)
        rs.Parameters.AddWithValue("@sub_section", SubSection)
        rs.Parameters.AddWithValue("@time_checked_in", DateReceived & " " & CDate(TimeReceived).ToString("HH:mm:ss"))

        If My.Settings.ReceivingStatus = 1 Then
            Connect()
            rs.Connection = conn
            rs.CommandText = "SELECT `main_id` FROM `tmpWorklist` WHERE `main_id` = @mainid"
            reader = rs.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                Disconnect()
                'Update Worklist
                'UpdateRecordwthoutMSG("UPDATE `tmpWorklist` SET `status` = @status, `instrument` = @instrument WHERE main_id = @mainid AND `testtype` = @section AND `status` = 'Processing'")
                UpdateRecordwthoutMSG("UPDATE `tmpWorklist` SET `status` = @status, `instrument` = @instrument WHERE main_id = @mainid AND `testtype` = @section AND `status` = 'Processing' AND `sub_section` = @sub_section")
            Else
                Disconnect()
                'Save Order to Worklist
                'SaveRecordwthoutMSG("INSERT INTO `tmpWorklist` (`sample_id`, `patient_id`, `patient_name`, `sex`, `bdate`, `status`, `date`, `time`, `main_id`, `instrument`, `testtype`, `location`) VALUES " _
                '        & "(" _
                '        & "@sampleid," _
                '        & "@patient_id," _
                '        & "@name," _
                '        & "@sex," _
                '        & "@bdate," _
                '        & "@status," _
                '        & "@date," _
                '        & "@time," _
                '        & "@mainid," _
                '        & "@instrument," _
                '        & "@section," _
                '        & "@location" _
                '        & ")"
                '        )
                'If My.Settings.Pro = 0 Then

                SaveRecordwthoutMSG("INSERT INTO `tmpWorklist` (`sample_id`, `patient_id`, `patient_name`, `sex`, `bdate`, `status`, `date`, `time`, `main_id`, `instrument`, `testtype`, `location`,`sub_section`) VALUES " _
                        & "(" _
                        & "@sampleid," _
                        & "@patient_id," _
                        & "@name," _
                        & "@sex," _
                        & "@bdate," _
                        & "@status," _
                        & "@date," _
                        & "@time," _
                        & "@mainid," _
                        & "@instrument," _
                        & "@section," _
                        & "@location," _
                        & "@sub_section" _
                        & ")"
                        )

                    SaveRecordwthoutMSG("INSERT INTO `specimen_tracking` (`sample_id`, `received`, `extracted`, `section`, `sub_section`) VALUES " _
                        & "(" _
                        & "@mainid," _
                        & "@time_checked_in," _
                        & "@time_checked_in," _
                        & "@section," _
                        & "@sub_section" _
                        & ")"
                        )
                'End If

            End If
                Disconnect()
        Else
            Disconnect()
            'UpdateRecordwthoutMSG("UPDATE `tmpWorklist` SET `status` = @status, `instrument` = @instrument WHERE main_id = @mainid AND testtype = @section")
            UpdateRecordwthoutMSG("UPDATE `tmpWorklist` SET `status` = @status, `instrument` = @instrument WHERE main_id = @mainid AND testtype = @section AND `sub_section` = @sub_section")
        End If
    End Sub

    Private Sub InsertResultData(ByVal OrderID As String, ByVal ResultName As String, ByVal ResultValue As String, ByVal Instrument As String, ByVal SerialNo As String, ByVal MainID As String, ByVal DateReceived As String, ByVal TimeReceived As String)
        rs.Parameters.Clear()
        rs.Parameters.AddWithValue("@UniversalID", ResultName)
        rs.Parameters.AddWithValue("@Measurement", ResultValue)
        rs.Parameters.AddWithValue("@sample_id", MainID)
        rs.Parameters.AddWithValue("@patient_id", PatientID)
        rs.Parameters.AddWithValue("@channel", ResultName)
        rs.Parameters.AddWithValue("@date", DateReceived & " " & CDate(TimeReceived).ToString("HH:mm:ss"))
        rs.Parameters.AddWithValue("@instrument", Instrument & "_" & SerialNo)
        rs.Parameters.AddWithValue("@Section", txtSection.Text)
        rs.Parameters.AddWithValue("@Sub_Section", SubSection)

        'Test names and units for SI Unit
        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT `specimen`, `test_code`, `order_no`, `test_group`, `si_unit`, `conventional_unit` FROM `specimen` where `channel` = @channel AND `instrument` = @instrument AND `status` = 'Enable'"
        reader = rs.ExecuteReader
        reader.Read()
        If reader.HasRows Then
            test_name = reader(0).ToString
            test_code = reader(1).ToString
            order_no = reader(2).ToString
            test_group = reader(3).ToString
            unit = reader(4).ToString
            unit_conv = reader(5).ToString
            Disconnect()

            'Check for duplicate result if exist save result to `rerun_result` table
            Connect()
            rs.Connection = conn
            rs.CommandText = "SELECT `test_code`, `sample_id`, `status` FROM `tmpResult` WHERE `test_code` = '" & test_code & "' AND `sample_id` = @sample_id"
            reader = rs.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                If reader(2) = 0 Then
                    Disconnect()
                    UpdateRecordwthoutMSG("UPDATE `tmpResult` SET " _
                            & "`measurement` = @Measurement," _
                            & "`date` = @date," _
                            & "`instrument` = @instrument," _
                            & "`status` = 1" _
                            & " WHERE `sample_id` = @sample_id AND `test_code` = '" & test_code & "' AND `status` = 0"
                            )

                    SaveRecordwthoutMSG("INSERT INTO `rerun_result` (`universal_id`, `measurement`, `test_code`, `sample_id`, `date`, `patient_id`, `order_no`, `units`, `unit_conv`, `instrument`, `status`, `test_group`, `section`,`sub_section`) VALUES " _
                            & "(" _
                            & "'" & test_name & "', @Measurement, '" & test_code & "', @sample_id, @date, @patient_id, '" & order_no & "', '" & unit & "', '" & unit_conv & "', @instrument, 1, '" & test_group & "', @Section, @Sub_Section" _
                            & ")"
                            )
                    'ElseIf reader(2) = 1 Then
                    '    Disconnect()
                    '    'Save Result
                    '    SaveRecordwthoutMSG("INSERT INTO `rerun_result` (`universal_id`, `measurement`, `test_code`, `sample_id`, `date`, `patient_id`, `order_no`, `units`, `unit_conv`, `instrument`, `status`, `test_group`, `section`) VALUES " _
                    '        & "(" _
                    '        & "'" & test_name & "', @Measurement, '" & test_code & "', @sample_id, @date, @patient_id, '" & order_no & "', '" & unit & "', '" & unit_conv & "', @instrument, 1, '" & test_group & "', @Section" _
                    '        & ")"
                    '        )

                ElseIf reader(2) > 0 Then
                    Disconnect()
                    'Save Result
                    SaveRecordwthoutMSG("INSERT INTO `rerun_result` (`universal_id`, `measurement`, `test_code`, `sample_id`, `date`, `patient_id`, `order_no`, `units`, `unit_conv`, `instrument`, `status`, `test_group`, `section`,`sub_section`) VALUES " _
                        & "(" _
                        & "'" & test_name & "', @Measurement, '" & test_code & "', @sample_id, @date, @patient_id, '" & order_no & "', '" & unit & "', '" & unit_conv & "', @instrument, '" & ctr_run & "', '" & test_group & "', @Section, @Sub_Section" _
                        & ")"
                        )
                End If
            Else
                Disconnect()
                If My.Settings.ReceivingStatus = 1 Then
                    'Save Result
                    SaveRecordwthoutMSG("INSERT INTO `tmpResult` (`universal_id`, `measurement`, `test_code`, `sample_id`, `date`, `patient_id`, `order_no`, `units`, `unit_conv`, `instrument`, `status`, `test_group`, `section`,`sub_section`) VALUES " _
                        & "(" _
                        & "'" & test_name & "', @Measurement, '" & test_code & "', @sample_id, @date, @patient_id, '" & order_no & "', '" & unit & "', '" & unit_conv & "', @instrument, 1, '" & test_group & "', @Section, @Sub_Section" _
                        & ")"
                        )

                    SaveRecordwthoutMSG("INSERT INTO `rerun_result` (`universal_id`, `measurement`, `test_code`, `sample_id`, `date`, `patient_id`, `order_no`, `units`, `unit_conv`, `instrument`, `status`, `test_group`, `section`,`sub_section`) VALUES " _
                            & "(" _
                            & "'" & test_name & "', @Measurement, '" & test_code & "', @sample_id, @date, @patient_id, '" & order_no & "', '" & unit & "', '" & unit_conv & "', @instrument, 1, '" & test_group & "', @Section, @Sub_Section" _
                            & ")"
                            )
                End If
            End If
            Disconnect()
            'End check for result

            ''Save Results to Worksheet table
            'Connect()
            'rs.Connection = conn
            'rs.CommandText = "UPDATE `worksheet` SET `" & test_code & "` = @Measurement" _
            '    & " WHERE `main_id` = @sample_id"
            'rs.ExecuteNonQuery()
            'Disconnect()
            ''End Update Worksheet
        End If
        Disconnect()
    End Sub

    Private ctr_run As Integer
    Private Function getRun_Number(ByVal id As String, ByVal sec As String, ByVal sub_sec As String) As Integer

        Connect()
        rs.Connection = conn
        rs.Parameters.Clear()
        rs.Parameters.AddWithValue("@sample_id", id.Trim)
        rs.Parameters.AddWithValue("@Section", sec)
        rs.Parameters.AddWithValue("@Sub_Sections", sub_sec)
        rs.CommandText = "SELECT IF(MAX(CAST(`status` AS INT))  IS NULL,2,MAX(CAST(`status` AS INT) + 1))  as run_num FROM `rerun_result` where `sample_id` = @sample_id AND section = @Section AND sub_section = @Sub_Sections"
        reader = rs.ExecuteReader
        reader.Read()
        If reader.HasRows Then

            ctr_run = reader(0).ToString

        End If
        Disconnect()

        Return ctr_run
    End Function

    Private Sub InsertControl(ByVal ControlID As String, ByVal ResultName As String, ByVal ResultValue As String, ByVal Instrument As String, ByVal SerialNo As String, ByVal Section As String, RunDate As Date, LotNo As String, ByVal DateReceived As String, ByVal TimeReceived As String)
        rs.Parameters.Clear()
        rs.Parameters.AddWithValue("@UniversalID", ResultName)
        rs.Parameters.AddWithValue("@Measurement", ResultValue)
        rs.Parameters.AddWithValue("@sample_id", ControlID)
        rs.Parameters.AddWithValue("@patient_id", PatientID)
        rs.Parameters.AddWithValue("@channel", ResultName)
        rs.Parameters.AddWithValue("@date", RunDate)
        rs.Parameters.AddWithValue("@month", RunDate.Month)
        rs.Parameters.AddWithValue("@year", RunDate.Year)
        rs.Parameters.AddWithValue("@instrument", Instrument.Trim & "_" & SerialNo)
        rs.Parameters.AddWithValue("@section", Section)
        rs.Parameters.AddWithValue("@LOTNo", LotNo)

        'Test Names
        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT `specimen`, `test_code`, `si_unit` FROM `specimen` where `channel` = @channel AND `instrument` = @instrument"
        reader = rs.ExecuteReader
        reader.Read()
        If reader.HasRows Then
            test_name = reader(0).ToString
            test_code = reader(1).ToString
            unit = reader(2).ToString

            Disconnect()
            SaveRecordwthoutMSG("INSERT INTO `control_result` (`universal_id`, `measurement`, `test_code`, `sample_id`, `date`, `month`, `year`, `instrument`, `test_type`, `unit`, `lot_no`) VALUES " _
                & "(" _
                & "'" & test_name & "'," _
                & "@Measurement," _
                & "'" & test_code & "'," _
                & "@sample_id," _
                & "@date," _
                & "@month," _
                & "@year," _
                & "@instrument," _
                & "@section," _
                & "'" & unit & "'," _
                & "@LOTNo" _
                & ")"
                )
        Else
            Disconnect()
            test_name = ""
            test_code = ""
            unit = ""
        End If
        Disconnect()
    End Sub
End Class
