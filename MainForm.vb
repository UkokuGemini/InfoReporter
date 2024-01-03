Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Reflection.Emit
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports NativeWifi

Public Class MainForm
    Const HeadText As String = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & "?>"
    Const DesFileName As String = "Info.xml"
    Dim InfoPath As String = Directory.GetCurrentDirectory & "\Info.xml"
    Dim WebDavUrl, WebDavUser, WebDavPassword As String
    Dim TickInterval As Integer = 1
    Dim MinUploadInterval As Integer = 1
    Dim MinUploadTime As Date
    Dim ContentAll As String = ""
    Dim Once As Boolean = True
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "InfoRepoter" & "[Ver." & My.Application.Info.Version.ToString & "]"
        ReadSettingXml()
        InfoRecord()
        Timer1.Interval = 3000
        Timer1.Enabled = True
        Me.CenterToScreen()
        MinUploadTime = DateAdd(DateInterval.Hour, MinUploadInterval, Now)
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Sub InfoRecord()
        RichTextBox_Info.Text = ""
        AppendAllText(HeadText & vbCrLf & "<InfoRepoter>" & vbCrLf & "<HostName>")
        AppendAllText(Dns.GetHostName, True)
        AppendAllText("</HostName>" & vbCrLf)
        AppendAllText("<Wlan>")
        AppendAllText(GetWifi(), True)
        AppendAllText("</Wlan>" & vbCrLf & "<HostIp>" & vbCrLf)
        For i = 0 To Dns.GetHostEntry(Dns.GetHostName).AddressList.Count - 1
            AppendAllText("<Ip>")
            AppendAllText(Dns.GetHostEntry(Dns.GetHostName).AddressList(i).ToString, True)
            AppendAllText("</Ip>" & vbCrLf)
        Next
        AppendAllText("</HostIp>" & vbCrLf & "<Time>")
        AppendAllText(Format(Now, "yyyy-MM-dd HH:mm:ss"), True)
        AppendAllText("</Time>" & vbCrLf & "</InfoRepoter>")
        IO.File.WriteAllText(InfoPath, ContentAll)
        ContentAll = ""
    End Sub
    Public Sub AppendAllText(ByVal Str As String, Optional Mark As Boolean = False)
        If Mark Then
            RichTextBox_Info.Select(RichTextBox_Info.Text.Length, 0) '选中开始
            RichTextBox_Info.SelectionFont = New Font(RichTextBox_Info.Font, FontStyle.Bold)
            RichTextBox_Info.SelectionColor = Color.DodgerBlue
            RichTextBox_Info.AppendText(Str)
            RichTextBox_Info.Select(RichTextBox_Info.Text.Length, 0)
            RichTextBox_Info.SelectionFont = RichTextBox_Info.Font
            RichTextBox_Info.SelectionColor = Color.Black
        Else
            RichTextBox_Info.AppendText(Str)
        End If
        ContentAll &= Str
    End Sub
    Function CompareInfo() As Boolean
        Dim XmlArr As New ArrayList
        If IO.File.Exists(InfoPath) Then
            Try
                Dim SettingXml As String = IO.File.ReadAllText(InfoPath)
                If SettingXml.Length > 0 Then
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.Load(InfoPath)
                    Dim IpStr As String = CType(xmlDoc.SelectSingleNode("InfoRepoter").SelectSingleNode("HostIp"), XmlElement).InnerXml
                    Dim SplitIpStr As String() = IpStr.Replace("<Ip>", "").Split("</Ip>")
                    For i = 0 To SplitIpStr.Count - 1
                        XmlArr.Add(SplitIpStr(i).Replace("/Ip>", ""))
                    Next
                End If
            Catch ex As Exception
            End Try
            Dim IpArr As New ArrayList
            For i = 0 To Dns.GetHostEntry(Dns.GetHostName).AddressList.Count - 1
                IpArr.Add(Dns.GetHostEntry(Dns.GetHostName).AddressList(i).ToString)
            Next
            Dim Res As Boolean = False
            Dim FitNum As Integer = 0
            For i = 0 To IpArr.Count - 1
                If XmlArr.Contains(IpArr(i).ToString) Then
                    FitNum += 1
                End If
            Next
            If FitNum < IpArr.Count Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        InfoRecord()
        Timer1.Interval = 60000 * Math.Max(TickInterval, 1)
        If Now > MinUploadTime Then
            MinUploadTime = DateAdd(DateInterval.Hour, MinUploadInterval, Now)
            Once = True
        End If
        If Once = False AndAlso CompareInfo() Then
            ToolStripStatusLabel_Res.Text = "【" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "】:无变更."
        Else
            Once = False
            UploadWebDAVFile(InfoPath, DesFileName, WebDavUrl & "/InfoRecord/" & Dns.GetHostName & "/", WebDavUser, WebDavPassword)
            ToolStripStatusLabel_Res.Text = "【" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "】:已发布."
        End If
        ToolStripStatusLabel_Next.Text = "下次检查时间:【" & Format(DateAdd(DateInterval.Second, 0.001 * Timer1.Interval, Now), "yyyy-MM-dd HH:mm:ss") & "】"
    End Sub
    Private Sub 立即查询ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 立即查询ToolStripMenuItem.Click
        InfoRecord()
    End Sub
    Private Sub 立即标识ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 立即标识ToolStripMenuItem.Click
        Timer1_Tick(Nothing, Nothing)
    End Sub
    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.WindowState = FormWindowState.Normal
            Me.CenterToScreen()
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
        End If
    End Sub
    Function GetWifi() As String
        Dim SSIDName As String = ""
        Try
            Dim wlan = New WlanClient()
            Dim connectedSsids = New List(Of String)
            For Each wlanInterface As WlanClient.WlanInterface In wlan.Interfaces
                Dim ssid As Wlan.Dot11Ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid
                connectedSsids.Add(New [String](Encoding.ASCII.GetChars(ssid.SSID, 0, CInt(ssid.SSIDLength))))
                For Each item As String In connectedSsids
                    SSIDName += item
                Next
            Next
        Catch ex As Exception

        End Try
        Return SSIDName
    End Function
    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            ShowInTaskbar = False
        Else
            ShowInTaskbar = True
        End If
    End Sub
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        NotifyIcon1.Visible = False
        NotifyIcon1.Dispose()
    End Sub
    Private Sub TextBox_Log_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Log.TextChanged
        TextBox_Log.SelectionStart = TextBox_Log.Text.Length
    End Sub
    Private Sub 强制发布ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 强制发布ToolStripMenuItem.Click
        Once = True
        Timer1_Tick(Nothing, Nothing)
    End Sub
    Function ReadSettingXml() As Boolean
        Dim Res As Boolean = True
        Dim SettingPath As String = Directory.GetCurrentDirectory & "\InfoReporter_Settings.Xml"
        Try
            Dim SettingXml As String = ""
            If IO.File.Exists(SettingPath) Then
                SettingXml = IO.File.ReadAllText(SettingPath)
            End If
            If SettingXml.Length > 0 Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(SettingPath)
                WebDavUrl = CType(xmlDoc.SelectSingleNode("InfoRepoter").SelectSingleNode("WebDavUrl"), XmlElement).InnerText
                WebDavUser = CType(xmlDoc.SelectSingleNode("InfoRepoter").SelectSingleNode("WebDavUser"), XmlElement).InnerText
                WebDavPassword = CType(xmlDoc.SelectSingleNode("InfoRepoter").SelectSingleNode("WebDavPassword"), XmlElement).InnerText
                TickInterval = Convert.ToInt32(CType(xmlDoc.SelectSingleNode("InfoRepoter").SelectSingleNode("TickInterval"), XmlElement).InnerText)
                MinUploadInterval = Convert.ToInt32(CType(xmlDoc.SelectSingleNode("InfoRepoter").SelectSingleNode("MinUploadInterval"), XmlElement).InnerText)
            End If
        Catch ex As Exception
            Res = False
        End Try
        Return Res
    End Function
    Public Function UploadWebDAVFile(ByVal fileToUpload As String, ByVal DesName As String, ByVal UpUrl As String, ByVal UserName As String, ByVal PassWord As String, Optional Log As Boolean = False) As Boolean
        Dim Success As Boolean = False
        Dim fileLength As Long = My.Computer.FileSystem.GetFileInfo(fileToUpload).Length
        UpUrl = UpUrl.TrimEnd("/"c) & "/" & DesName
        Dim request As HttpWebRequest = DirectCast(System.Net.HttpWebRequest.Create(UpUrl), HttpWebRequest)
        request.Credentials = New NetworkCredential(UserName.Trim(), PassWord.Trim())
        request.Method = WebRequestMethods.Http.Put
        request.ContentLength = fileLength
        '*** This is required for our WebDav server ***
        request.SendChunked = True
        request.Headers.Add("Translate: f")
        request.AllowWriteStreamBuffering = True
        Dim s As IO.Stream = Nothing
        Try
            s = request.GetRequestStream()
        Catch ex As Exception
            TextBox_Log.Text &= vbCrLf & ">>" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "【WevDav】:上传错误." & ex.Message
        End Try
        Dim fs As New IO.FileStream(fileToUpload, IO.FileMode.Open, IO.FileAccess.Read)
        Dim byteTransferRate As Integer = 1024
        Dim bytes(byteTransferRate - 1) As Byte
        Dim bytesRead As Integer = 0
        Dim totalBytesRead As Long = 0
        Try
            Do
                bytesRead = fs.Read(bytes, 0, bytes.Length)
                If bytesRead > 0 Then
                    totalBytesRead += bytesRead
                    s.Write(bytes, 0, bytesRead)
                End If
            Loop While bytesRead > 0
            s.Close()
            s.Dispose()
            s = Nothing
        Catch ex As Exception
        End Try
        fs.Close()
        fs.Dispose()
        fs = Nothing
        Dim response As HttpWebResponse = Nothing
        Try
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            Dim code As HttpStatusCode = response.StatusCode
            response.Close()
            response = Nothing
            If totalBytesRead = fileLength AndAlso code = HttpStatusCode.Created Then
                TextBox_Log.Text &= vbCrLf & ">>" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "【WevDav】上传成功  " & IO.Path.GetFileName(DesName)
                Success = True
            Else
                TextBox_Log.Text &= vbCrLf & ">>" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "【WevDav】:上传失败:" & IO.Path.GetFileName(DesName)
            End If
        Catch ex As Exception
            TextBox_Log.Text &= vbCrLf & ">>" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "【WevDav】 上传错误." & ex.Message
        End Try
        Return Success
    End Function
End Class
