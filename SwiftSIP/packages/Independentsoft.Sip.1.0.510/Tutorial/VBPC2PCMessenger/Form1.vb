''
'' SIP .NET samples
'' Copyright (c) 2013 - Independensoft.
''
'' This file is part of Independentsoft SIP .NET. The source code in this file 
'' is only intended as a supplement to the documentation, and is provided 
'' "as is", without warranty of any kind, either expressed or implied.
''
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports Independentsoft.Sip
Imports Independentsoft.Sip.Sdp
Imports Independentsoft.Sip.Methods
Imports Independentsoft.Sip.Responses
Imports Independentsoft.Sip.Presence

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private Delegate Sub UpdateTextCallback(ByVal text As String)
    Private client As SipClient
    Private localContactInfo As ContactInfo
    Private remoteContactInfo As ContactInfo
    Private localName As String
    Private localAddress As String
    Private localIPAddress As String
    Private localPort As String
    Private remoteName As String
    Private remoteAddress As String
    Private remoteIPAddress As String
    Private remotePort As String

    Private receiveFileSocket As Socket
    Private receiveFileName As String
    Private receiveFileSize As Long
    Private fileName As String
    Private responseSessionDescription As SessionDescription

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        If Not (client Is Nothing) Then
            client.Disconnect()
        End If

        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents textBox1 As System.Windows.Forms.TextBox
    Friend WithEvents exitMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents textBox2 As System.Windows.Forms.TextBox
    Friend WithEvents sendButton As System.Windows.Forms.Button
    Friend WithEvents sendFileMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents fileMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents connectMenuItem As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.exitMenuItem = New System.Windows.Forms.MenuItem
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.textBox2 = New System.Windows.Forms.TextBox
        Me.sendButton = New System.Windows.Forms.Button
        Me.sendFileMenuItem = New System.Windows.Forms.MenuItem
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.fileMenuItem = New System.Windows.Forms.MenuItem
        Me.connectMenuItem = New System.Windows.Forms.MenuItem
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'textBox1
        '
        Me.textBox1.BackColor = System.Drawing.SystemColors.Window
        Me.textBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textBox1.Location = New System.Drawing.Point(0, 0)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.textBox1.Size = New System.Drawing.Size(360, 630)
        Me.textBox1.TabIndex = 2
        Me.textBox1.Text = ""
        '
        'exitMenuItem
        '
        Me.exitMenuItem.Index = 2
        Me.exitMenuItem.Text = "Exit"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.textBox2)
        Me.groupBox1.Controls.Add(Me.sendButton)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.groupBox1.Location = New System.Drawing.Point(0, 558)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(360, 72)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        '
        'textBox2
        '
        Me.textBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textBox2.Location = New System.Drawing.Point(3, 16)
        Me.textBox2.Multiline = True
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(279, 53)
        Me.textBox2.TabIndex = 1
        Me.textBox2.Text = ""
        '
        'sendButton
        '
        Me.sendButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.sendButton.Location = New System.Drawing.Point(282, 16)
        Me.sendButton.Name = "sendButton"
        Me.sendButton.Size = New System.Drawing.Size(75, 53)
        Me.sendButton.TabIndex = 0
        Me.sendButton.Text = "Send"
        '
        'sendFileMenuItem
        '
        Me.sendFileMenuItem.Index = 1
        Me.sendFileMenuItem.Text = "Send File"
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.fileMenuItem})
        '
        'fileMenuItem
        '
        Me.fileMenuItem.Index = 0
        Me.fileMenuItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.connectMenuItem, Me.sendFileMenuItem, Me.exitMenuItem})
        Me.fileMenuItem.Text = "File"
        '
        'connectMenuItem
        '
        Me.connectMenuItem.Index = 0
        Me.connectMenuItem.Text = "Connect"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 630)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.textBox1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "PC2PC Messenger"
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub sendButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendButton.Click
        Dim requestResponse As RequestResponse = client.SendMessage(localContactInfo, remoteContactInfo, textBox2.Text)

        If requestResponse.Response.StatusCode = 200 Then
            Append(localContactInfo.Name + ": " + textBox2.Text)
        Else
            Append("Send failed !!!")
        End If

        textBox2.Clear()
    End Sub

    Private Sub connectMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connectMenuItem.Click
        Dim dialog As ConnectDialog = New ConnectDialog

        If dialog.ShowDialog() = DialogResult.OK Then
            Me.localName = dialog.LocalNameText
            Me.localPort = dialog.LocalPortText
            Me.localAddress = dialog.LocalAddressText
            Me.localIPAddress = dialog.LocalIPAddressText
            Me.localPort = dialog.LocalPortText
            Me.remoteName = dialog.RemoteNameText
            Me.remotePort = dialog.RemotePortText
            Me.remoteAddress = dialog.RemoteAddressText
            Me.remoteIPAddress = dialog.RemoteIPAddressText
            Me.remotePort = dialog.RemotePortText

            localContactInfo = New ContactInfo(dialog.LocalNameText, dialog.LocalAddressText)
            remoteContactInfo = New ContactInfo(dialog.RemoteNameText, dialog.RemoteAddressText)

            client = New SipClient(dialog.RemoteIPAddressText, Int32.Parse(dialog.RemotePortText), Independentsoft.Sip.ProtocolType.Udp)

            client.Logger = New Logger("c:\\temp\\" + dialog.LocalNameText + ".txt")

            AddHandler client.ReceiveRequest, AddressOf OnReceiveRequest
            AddHandler client.ReceiveResponse, AddressOf OnReceiveResponse

            Dim hostEntry As IPHostEntry = Dns.GetHostEntry(dialog.localIPAddress.Text)

            Dim address As IPAddress = hostEntry.AddressList(0)

            If hostEntry.AddressList.Length > 1 Then
                For i As Integer = 0 To hostEntry.AddressList.Length - 1
                    If hostEntry.AddressList(i) IsNot Nothing AndAlso hostEntry.AddressList(i).ToString().IndexOf(":") = -1 Then
                        address = hostEntry.AddressList(i)
                        Exit For
                    End If
                Next
            End If

            Dim localIPEndPoint As New IPEndPoint(address, Int32.Parse(dialog.localPort.Text))
            client.Bind(localIPEndPoint)

            Me.Text += " - " + dialog.LocalNameText
        End If


    End Sub

    Private Sub OnReceiveRequest(ByVal sender As Object, ByVal e As RequestEventArgs)
        If e.Request.Method = SipMethod.Message Then
            client.AcceptRequest(e.Request)
            Append(remoteContactInfo.Name + ": " + e.Request.Body)
        ElseIf e.Request.Method = SipMethod.Invite Then
            Dim receivedSessionDescription As SessionDescription = e.Request.SessionDescription

            receiveFileName = receivedSessionDescription.Media(0).Attributes(0).Value
            receiveFileSize = Int64.Parse(receivedSessionDescription.Media(0).Attributes(1).Value)

            Dim fileTransferPort As Integer = ReceiveFile()

            Dim session As SessionDescription = New SessionDescription
            session.Version = 0

            Dim owner As Owner = New Owner
            owner.Username = localName
            owner.SessionID = 1
            owner.Version = 1
            owner.Address = localIPAddress

            session.Owner = owner
            session.Name = "FileTransfer"

            Dim connection As Connection = New Connection
            connection.Address = localIPAddress

            session.Connection = connection

            Dim time As Time = New Time(0, 0)
            session.Time.Add(time)

            Dim media1 As Media = New Media
            media1.Type = "filetransfer"
            media1.TransportProtocol = "TCP"
            media1.Port = fileTransferPort
            session.Media.Add(media1)

            Dim ok As OK = New OK
            ok.SessionDescription = session
            ok.Contact = New Contact("sip:" + localName + "@" + client.LocalIPEndPoint.ToString())

            client.SendResponse(ok, e.Request)
        Else
            client.RejectRequest(e.Request)
        End If

    End Sub

    Private Function ReceiveFile() As Integer
        receiveFileSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)

        Dim localhostEnTry As IPHostEntry = Dns.Resolve(Dns.GetHostName())
        Dim localAddress As IPAddress = localhostEnTry.AddressList(0)
        Dim localIPEndPoint As IPEndPoint = New IPEndPoint(localAddress, 0)

        receiveFileSocket.Bind(localIPEndPoint)
        receiveFileSocket.Listen(5)

        localIPEndPoint = CType(receiveFileSocket.LocalEndPoint, IPEndPoint)

        Dim receiveFileThread As Thread = New Thread(New ThreadStart(AddressOf ReceiveFileListener))
        receiveFileThread.IsBackground = True
        receiveFileThread.Start()

        Return localIPEndPoint.Port
    End Function

    Private Sub ReceiveFileListener()
        Append("Receive file c:\\temp\\" & receiveFileName)
        Append("File size: " & receiveFileSize)

        Dim file As FileStream = New FileStream("c:\\temp\\" + receiveFileName, FileMode.Create)

        Dim receiveBuffer() As Byte = New Byte(8192) {}
        Dim size As Long = 0

        Dim acceptSocket As Socket = receiveFileSocket.Accept()

        While (size < receiveFileSize)
            Dim receivedSize As Integer = acceptSocket.Receive(receiveBuffer)
            size += receivedSize

            file.Write(receiveBuffer, 0, receivedSize)
        End While

        file.Close()

        Append("File transfer completed.")

        acceptSocket.Shutdown(SocketShutdown.Both)
        acceptSocket.Close()

        receiveFileSocket.Shutdown(SocketShutdown.Both)
        receiveFileSocket.Close()
    End Sub



    Private Sub OnReceiveResponse(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub sendFileMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendFileMenuItem.Click
        Dim dialog As OpenFileDialog = New OpenFileDialog
        dialog.Multiselect = False

        If dialog.ShowDialog() = DialogResult.OK Then
            fileName = dialog.FileName
            Dim fileInfo As FileInfo = New FileInfo(fileName)

            Dim session As SessionDescription = New SessionDescription
            session.Version = 0

            Dim owner As Owner = New Owner
            owner.Username = localName
            owner.SessionID = 1
            owner.Version = 1
            owner.Address = localIPAddress

            session.Owner = owner
            session.Name = "FileTransfer"

            Dim connection As Connection = New Connection
            connection.Address = localIPAddress

            session.Connection = connection

            Dim time As Time = New Time(0, 0)
            session.Time.Add(time)

            Dim media1 As Media = New Media
            media1.Type = "filetransfer"
            media1.TransportProtocol = "TCP"
            media1.Attributes.Add("name", fileInfo.Name)
            media1.Attributes.Add("size", fileInfo.Length.ToString())
            session.Media.Add(media1)

            Dim invite As Invite = New Invite
            invite.Uri = remoteAddress
            invite.From = localContactInfo
            invite.To = remoteContactInfo
            invite.Contact = New Contact("sip:" + localName + "@" + client.LocalIPEndPoint.ToString())
            invite.ContentType = "application/sdp"
            invite.Body = session.ToString()

            Dim inviteRequestResponse As RequestResponse = client.SendRequest(invite)

            If inviteRequestResponse.Response.StatusCode = 200 Then
                client.Ack(inviteRequestResponse)
                responseSessionDescription = inviteRequestResponse.Response.SessionDescription

                Append("Sending file " + fileName)

                Dim sendFileThread As Thread = New Thread(New ThreadStart(AddressOf SendFile))
                sendFileThread.IsBackground = True
                sendFileThread.Start()
            End If
        End If

    End Sub

    Private Sub SendFile()
        Dim sendFileSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)

        Dim remoteFileTransferPort As Integer = responseSessionDescription.Media(0).Port
        Dim remoteIPEndPoint As IPEndPoint = New IPEndPoint(Dns.Resolve(remoteIPAddress).AddressList(0), remoteFileTransferPort)

        Dim file As FileStream = New FileStream(fileName, FileMode.Open)
        Dim buffer() As Byte = New Byte(file.Length) {}
        file.Read(buffer, 0, buffer.Length)

        sendFileSocket.Connect(remoteIPEndPoint)
        sendFileSocket.Send(buffer)
        sendFileSocket.Close()

        file.Close()
        Append("File transfer completed.")
    End Sub


    Private Sub exitMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Append(ByVal text As String)
        Dim update As UpdateTextCallback = New UpdateTextCallback(AddressOf AppendText)
        BeginInvoke(update, New Object() {text})
    End Sub

    Private Sub AppendText(ByVal text As String)
        textBox1.AppendText(Environment.NewLine() + text)
    End Sub
End Class
