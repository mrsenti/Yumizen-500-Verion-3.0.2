Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Thread
Imports System.Text.RegularExpressions

Imports System.Text
Imports DevExpress

Module modClass
    Public Sub SaveRecord(ByVal SQL As String)
        Connect()
        rs.Connection = conn
        rs.CommandText = SQL
        rs.ExecuteNonQuery()
        Disconnect()
        MessageBox.Show("New record has been successfuly save.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub SaveRecordwthoutMSG(ByVal SQL As String)
        Connect()
        rs.Connection = conn
        rs.CommandText = SQL
        rs.ExecuteNonQuery()
        Disconnect()
    End Sub

    Public Sub UpdateRecord(ByVal SQL As String)
        Connect()
        rs.Connection = conn
        rs.CommandText = SQL
        rs.ExecuteNonQuery()
        Disconnect()
        MessageBox.Show("The selected record has been successfuly update.", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub UpdateRecordwthoutMSG(ByVal SQL As String)
        Connect()
        rs.Connection = conn
        rs.CommandText = SQL
        rs.ExecuteNonQuery()
        Disconnect()
    End Sub

    Public Sub DeleteRecord(ByVal DeleteFromTable As String, ByVal DeleteIdentifier As String, ByVal DeleteID As String)
        If (MessageBox.Show("Are you sure you want to delete the selected record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            Connect()
            rs.Connection = conn
            rs.CommandText = "DELETE FROM " & DeleteFromTable & " WHERE " & DeleteIdentifier & " LIKE '" & DeleteID & "'"
            rs.ExecuteNonQuery()
            Disconnect()
            MessageBox.Show("The selected record has been successfully deleted.", "Record Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub DeleteRecordSQL(ByVal SQL As String)
        If (MessageBox.Show("Are you sure you want to delete the selected record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            Connect()
            rs.Connection = conn
            rs.CommandText = SQL
            rs.ExecuteNonQuery()
            Disconnect()
            MessageBox.Show("The selected record has been successfully deleted.", "Record Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub DeleteRecordWithoutMsg(ByVal DeleteFromTable As String, ByVal DeleteIdentifier As String, ByVal DeleteID As String)
        Connect()
        rs.Connection = conn
        rs.CommandText = "DELETE FROM " & DeleteFromTable & " WHERE " & DeleteIdentifier & " LIKE '" & DeleteID & "'"
        rs.ExecuteNonQuery()
        Disconnect()
    End Sub

    Public Sub MaterialStyleDataGrid(ByRef DTview As DataGridView)
        DTview.Rows.Clear()
        DTview.Font = New Font("Segoe UI", 12, FontStyle.Regular)

        DTview.BorderStyle = BorderStyle.None
        'DTview.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
        'DTview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249)
        'DTview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

        DTview.DefaultCellStyle.SelectionBackColor = Color.LightGray
        DTview.DefaultCellStyle.SelectionForeColor = Color.Black
        DTview.BackgroundColor = Color.White
        DTview.EnableHeadersVisualStyles = False
        DTview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DTview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        'DTview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(42, 88, 173)
        DTview.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray
    End Sub

    Public Sub AutoGenID(ByVal ITem As String)
        Randomize()
        Dim a As Integer
        a = Rnd() * 9999999
        ITem = a.ToString
    End Sub

    Public Sub AutoLoadCombo(ByVal cboContent As ComboBox, ByVal TableName As String, ByVal ColumnValue As Integer, ByVal ColumnOrder As String)
        cboContent.Items.Clear()
        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT * FROM " & TableName & " ORDER BY " & ColumnOrder
        reader = rs.ExecuteReader
        While reader.Read
            cboContent.Items.Add(reader(ColumnValue))
        End While
        Disconnect()
    End Sub

    Public Sub AutoLoadComboDev(ByVal cboContent As XtraEditors.ComboBoxEdit, ByVal TableName As String, ByVal ColumnValue As Integer, ByVal ColumnOrder As String)
        cboContent.Properties.Items.Clear()
        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT * FROM " & TableName & " ORDER BY " & ColumnOrder
        reader = rs.ExecuteReader
        While reader.Read
            cboContent.Properties.Items.Add(reader(ColumnValue))
        End While
        Disconnect()
    End Sub

    Public Sub AutoLoadComboDistinct(ByVal cboContent As ComboBox, ByVal TableName As String, ByVal DistinctName As String, ByVal ColumnOrder As String)
        cboContent.Items.Clear()
        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT DISTINCT " & DistinctName & " FROM " & TableName & " ORDER BY " & ColumnOrder
        reader = rs.ExecuteReader
        While reader.Read
            cboContent.Items.Add(reader(DistinctName))
        End While
        Disconnect()
    End Sub

    Public Sub AutoLoadComboWithCondition(ByVal cboContent As ComboBox, ByVal TableName As String, ByVal strWHERE As String, ByVal strLIKE As String, ByVal ColumnValue As Integer, ByVal ColumnOrder As String)
        cboContent.Items.Clear()
        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT * FROM " & TableName & " WHERE " & strWHERE & " LIKE '" & strLIKE & "' ORDER BY " & ColumnOrder
        reader = rs.ExecuteReader
        While reader.Read
            cboContent.Items.Add(reader(ColumnValue))
        End While
        Disconnect()
    End Sub

    Public Sub LoadRecordsOnLV(ByRef lvList As ListView, ByVal TableName As String, ByVal NumFields As Integer, ByVal Sort As String)
        lvList.Items.Clear()

        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT * FROM " & TableName & " ORDER BY '" & Sort & "'"
        reader = rs.ExecuteReader
        While reader.Read
            iItem = New ListViewItem(reader(0).ToString, 0)
            iItem.Checked = False
            For x As Integer = 1 To NumFields Step 1
                iItem.SubItems.Add(reader(x).ToString())
            Next
            lvList.Items.Add(iItem)
        End While
        Disconnect()
    End Sub

    Public Sub LoadRecordsOnLVWithCondition(ByRef lvList As ListView, ByVal TableName As String, ByVal NumFields As Integer, ByVal strWhere As String, ByVal strLike As String, ByVal Sort As String)
        lvList.Items.Clear()

        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT * FROM " & TableName & " WHERE " & strWhere & " LIKE '" & strLike & "' ORDER BY '" & Sort & "'"
        reader = rs.ExecuteReader
        While reader.Read
            iItem = New ListViewItem(reader(0).ToString, 0)
            iItem.Checked = False
            For x As Integer = 1 To NumFields Step 1
                iItem.SubItems.Add(reader(x).ToString())
            Next
            lvList.Items.Add(iItem)
        End While
        Disconnect()
    End Sub

    Public Sub LoadRecordsOnLVWithTwoCondition(ByRef lvList As ListView, ByVal TableName As String, ByVal NumFields As Integer, ByVal strWhere1 As String, ByVal strLike1 As String, ByVal strWhere2 As String, ByVal strLike2 As String, ByVal Sort As String)
        lvList.Items.Clear()

        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT * FROM " & TableName & " WHERE " & strWhere1 & " LIKE '" & strLike1 & "' OR " & strWhere2 & " LIKE '" & strLike2 & "' ORDER BY '" & Sort & "'"
        reader = rs.ExecuteReader
        While reader.Read
            iItem = New ListViewItem(reader(0).ToString, 0)
            iItem.Checked = False
            For x As Integer = 1 To NumFields Step 1
                iItem.SubItems.Add(reader(x).ToString())
            Next
            lvList.Items.Add(iItem)
        End While
        Disconnect()
    End Sub

    Public Sub LoadRecordsOnLVSQL(ByRef lvList As ListView, ByVal SQL As String, ByVal NumFields As Integer)
        lvList.Items.Clear()

        Connect()
        rs.Connection = conn
        rs.CommandText = SQL
        reader = rs.ExecuteReader
        While reader.Read
            iItem = New ListViewItem(reader(0).ToString, 0)
            iItem.Checked = False
            For x As Integer = 1 To NumFields Step 1
                iItem.SubItems.Add(reader(x).ToString())
            Next
            lvList.Items.Add(iItem)
        End While
        Disconnect()
    End Sub

    Public Sub LoadRecordsOnLVSQLNoClear(ByRef lvList As ListView, ByVal SQL As String, ByVal NumFields As Integer)
        'lvList.Items.Clear()

        Connect()
        rs.Connection = conn
        rs.CommandText = SQL
        reader = rs.ExecuteReader
        While reader.Read
            iItem = New ListViewItem(reader(0).ToString, 0)
            iItem.Checked = False
            For x As Integer = 1 To NumFields Step 1
                iItem.SubItems.Add(reader(x).ToString())
            Next
            lvList.Items.Add(iItem)
        End While
        Disconnect()
    End Sub

    Public Sub SearchRecordsOnLV(ByRef lvList As ListView, ByVal TableName As String, ByVal NumFields As Integer, ByVal strWhere As String, ByVal strLike As String, ByVal Sort As String)
        lvList.Items.Clear()

        Connect()
        rs.Connection = conn
        rs.CommandText = "SELECT * FROM " & TableName & " WHERE " & strWhere & " LIKE '" & strLike & "%' ORDER BY '" & Sort & "'"
        reader = rs.ExecuteReader
        While reader.Read
            iItem = New ListViewItem(reader(0).ToString, 0)
            iItem.Checked = False
            For x As Integer = 1 To NumFields Step 1
                iItem.SubItems.Add(reader(x).ToString())
            Next
            lvList.Items.Add(iItem)
        End While
        Disconnect()
    End Sub

    '----------------------for License Key generation-------------------------------
    Public Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" & _
                                      "{impersonationLevel=impersonate}!\\" & _
                                      computer & "\root\cimv2")
        Dim processor As Object = wmi.ExecQuery("Select * from " & _
                                                "Win32_Processor")
        Dim cpu_ids As String = ""
        For Each cpu As Object In processor
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids = _
            cpu_ids.Substring(2)
        Return cpu_ids
    End Function

    '---------------------------------RegEx----------------------------------------

    Public Function FormatDateRegex() As String
        Dim str As String
        str = Regex.Replace(Now.ToString("yyyy/MM/dd hh:mm:ss"), "[\/\ \:/AM]", "")
        Return str
    End Function

    Public Function FormatBDateRegex(ByVal dtPicker As DateTimePicker) As String
        Dim str As String
        str = Regex.Replace(dtPicker.Value.ToString("yyyy/MM/dd hh:mm:ss"), "[\/\ \:/AM]", "")
        Return str
    End Function

    Public Function FormatBDateRegex_String(ByVal bDate As String) As String
        Dim str As String
        str = Regex.Replace(bDate, "[\/\ \:/AM]", "")
        Return str
    End Function

    Public Function CheckSum(ByVal strValue As String) As String
        Dim aList As New ListBox

        aList.Items.Clear()

        Dim HexValue As String
        Dim str As String = strValue
        Dim abData As Byte()

        Dim i As Long
        Dim sum As Double

        abData = Encoding.Default.GetBytes(str)

        Dim strOutput As String

        For i = 0 To abData.Length - 1
            aList.Items.Add(abData(i) & vbCrLf)
            sum += CDbl(aList.Items(i))
        Next i

        HexValue = Hex(sum Mod 256).ToString
        If HexValue.Length = 1 Then
            strOutput = "0" & HexValue
        Else
            strOutput = HexValue
        End If

        Return strOutput

    End Function

    Public Sub SelectResult(ByVal SQL As String, ByVal Value As Integer, ByVal MEASUREMENT As XtraEditors.TextEdit)
        Connect()
        rs.Connection = conn
        rs.CommandText = SQL
        reader = rs.ExecuteReader
        reader.Read()
        If reader.HasRows Then
            MEASUREMENT.Text = reader(Value).ToString
        End If
        Disconnect()
    End Sub

    Function RemoveWhitespace(ByVal fullString As String) As String
        If fullString = "" Then
            Return fullString
        End If

        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
    End Function

End Module