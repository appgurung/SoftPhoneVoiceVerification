''
'' SIP .NET samples
'' Copyright (c) 2013 - Independensoft.
''
'' This file is part of Independentsoft SIP .NET. The source code in this file 
'' is only intended as a supplement to the documentation, and is provided 
'' "as is", without warranty of any kind, either expressed or implied.
''

Imports Independentsoft.Sip
Imports Independentsoft.Sip.Sdp
Imports Independentsoft.Sip.Methods
Imports Independentsoft.Sip.Responses
Imports Independentsoft.Sip.Presence

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private client1 As SipClient
    Private client2 As SipClient
    Delegate Sub UpdateTextCallback(ByVal text As String)
    Private entityTag As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents subscribeButton As System.Windows.Forms.Button
    Friend WithEvents port2 As System.Windows.Forms.TextBox
    Friend WithEvents protocol2 As System.Windows.Forms.ComboBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents contact2 As System.Windows.Forms.TextBox
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents to2 As System.Windows.Forms.TextBox
    Friend WithEvents registerButton2 As System.Windows.Forms.Button
    Friend WithEvents from2 As System.Windows.Forms.TextBox
    Friend WithEvents password2 As System.Windows.Forms.TextBox
    Friend WithEvents username2 As System.Windows.Forms.TextBox
    Friend WithEvents domain2 As System.Windows.Forms.TextBox
    Friend WithEvents log2 As System.Windows.Forms.TextBox
    Friend WithEvents disconnectButton2 As System.Windows.Forms.Button
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents disconnectButton1 As System.Windows.Forms.Button
    Friend WithEvents port1 As System.Windows.Forms.TextBox
    Friend WithEvents protocol1 As System.Windows.Forms.ComboBox
    Friend WithEvents removeButton As System.Windows.Forms.Button
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents contact1 As System.Windows.Forms.TextBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents expires As System.Windows.Forms.TextBox
    Friend WithEvents refreshButton As System.Windows.Forms.Button
    Friend WithEvents offlineButton As System.Windows.Forms.Button
    Friend WithEvents onlineButton As System.Windows.Forms.Button
    Friend WithEvents registerButton1 As System.Windows.Forms.Button
    Friend WithEvents from1 As System.Windows.Forms.TextBox
    Friend WithEvents password1 As System.Windows.Forms.TextBox
    Friend WithEvents username1 As System.Windows.Forms.TextBox
    Friend WithEvents domain1 As System.Windows.Forms.TextBox
    Friend WithEvents log1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.subscribeButton = New System.Windows.Forms.Button
        Me.port2 = New System.Windows.Forms.TextBox
        Me.protocol2 = New System.Windows.Forms.ComboBox
        Me.label7 = New System.Windows.Forms.Label
        Me.contact2 = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.label12 = New System.Windows.Forms.Label
        Me.to2 = New System.Windows.Forms.TextBox
        Me.registerButton2 = New System.Windows.Forms.Button
        Me.from2 = New System.Windows.Forms.TextBox
        Me.password2 = New System.Windows.Forms.TextBox
        Me.username2 = New System.Windows.Forms.TextBox
        Me.domain2 = New System.Windows.Forms.TextBox
        Me.log2 = New System.Windows.Forms.TextBox
        Me.disconnectButton2 = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.disconnectButton1 = New System.Windows.Forms.Button
        Me.port1 = New System.Windows.Forms.TextBox
        Me.protocol1 = New System.Windows.Forms.ComboBox
        Me.removeButton = New System.Windows.Forms.Button
        Me.label6 = New System.Windows.Forms.Label
        Me.contact1 = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.expires = New System.Windows.Forms.TextBox
        Me.refreshButton = New System.Windows.Forms.Button
        Me.offlineButton = New System.Windows.Forms.Button
        Me.onlineButton = New System.Windows.Forms.Button
        Me.registerButton1 = New System.Windows.Forms.Button
        Me.from1 = New System.Windows.Forms.TextBox
        Me.password1 = New System.Windows.Forms.TextBox
        Me.username1 = New System.Windows.Forms.TextBox
        Me.domain1 = New System.Windows.Forms.TextBox
        Me.log1 = New System.Windows.Forms.TextBox
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.subscribeButton)
        Me.groupBox2.Controls.Add(Me.port2)
        Me.groupBox2.Controls.Add(Me.protocol2)
        Me.groupBox2.Controls.Add(Me.label7)
        Me.groupBox2.Controls.Add(Me.contact2)
        Me.groupBox2.Controls.Add(Me.label8)
        Me.groupBox2.Controls.Add(Me.label9)
        Me.groupBox2.Controls.Add(Me.label10)
        Me.groupBox2.Controls.Add(Me.label11)
        Me.groupBox2.Controls.Add(Me.label12)
        Me.groupBox2.Controls.Add(Me.to2)
        Me.groupBox2.Controls.Add(Me.registerButton2)
        Me.groupBox2.Controls.Add(Me.from2)
        Me.groupBox2.Controls.Add(Me.password2)
        Me.groupBox2.Controls.Add(Me.username2)
        Me.groupBox2.Controls.Add(Me.domain2)
        Me.groupBox2.Controls.Add(Me.log2)
        Me.groupBox2.Controls.Add(Me.disconnectButton2)
        Me.groupBox2.Location = New System.Drawing.Point(518, 6)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(500, 760)
        Me.groupBox2.TabIndex = 3
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "User2"
        '
        'subscribeButton
        '
        Me.subscribeButton.Location = New System.Drawing.Point(344, 48)
        Me.subscribeButton.Name = "subscribeButton"
        Me.subscribeButton.Size = New System.Drawing.Size(120, 23)
        Me.subscribeButton.TabIndex = 49
        Me.subscribeButton.Text = "Subscribe"
        '
        'port2
        '
        Me.port2.Location = New System.Drawing.Point(224, 24)
        Me.port2.Name = "port2"
        Me.port2.Size = New System.Drawing.Size(40, 20)
        Me.port2.TabIndex = 48
        Me.port2.Text = "5060"
        '
        'protocol2
        '
        Me.protocol2.Items.AddRange(New Object() {"UDP", "TCP"})
        Me.protocol2.Location = New System.Drawing.Point(264, 24)
        Me.protocol2.Name = "protocol2"
        Me.protocol2.Size = New System.Drawing.Size(48, 21)
        Me.protocol2.TabIndex = 47
        Me.protocol2.Text = "UDP"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(26, 144)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(64, 16)
        Me.label7.TabIndex = 33
        Me.label7.Text = "Contact:"
        Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'contact2
        '
        Me.contact2.Enabled = False
        Me.contact2.Location = New System.Drawing.Point(96, 144)
        Me.contact2.Name = "contact2"
        Me.contact2.ReadOnly = True
        Me.contact2.Size = New System.Drawing.Size(216, 20)
        Me.contact2.TabIndex = 32
        Me.contact2.Text = ""
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(26, 120)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(64, 16)
        Me.label8.TabIndex = 31
        Me.label8.Text = "To:"
        Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(18, 96)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(72, 16)
        Me.label9.TabIndex = 30
        Me.label9.Text = "From:"
        Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(26, 72)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(64, 16)
        Me.label10.TabIndex = 29
        Me.label10.Text = "Password:"
        Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(18, 48)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(72, 16)
        Me.label11.TabIndex = 28
        Me.label11.Text = "Username:"
        Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(18, 24)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(72, 16)
        Me.label12.TabIndex = 27
        Me.label12.Text = "Domain:"
        Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'to2
        '
        Me.to2.Location = New System.Drawing.Point(96, 120)
        Me.to2.Name = "to2"
        Me.to2.Size = New System.Drawing.Size(216, 20)
        Me.to2.TabIndex = 26
        Me.to2.Text = "sip:Bob@mydomain.com"
        '
        'registerButton2
        '
        Me.registerButton2.Location = New System.Drawing.Point(344, 16)
        Me.registerButton2.Name = "registerButton2"
        Me.registerButton2.Size = New System.Drawing.Size(120, 23)
        Me.registerButton2.TabIndex = 22
        Me.registerButton2.Text = "Register"
        '
        'from2
        '
        Me.from2.Location = New System.Drawing.Point(96, 96)
        Me.from2.Name = "from2"
        Me.from2.Size = New System.Drawing.Size(216, 20)
        Me.from2.TabIndex = 21
        Me.from2.Text = "sip:Alice@mydomain.com"
        '
        'password2
        '
        Me.password2.Location = New System.Drawing.Point(96, 72)
        Me.password2.Name = "password2"
        Me.password2.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.password2.Size = New System.Drawing.Size(216, 20)
        Me.password2.TabIndex = 19
        Me.password2.Text = "Alice"
        '
        'username2
        '
        Me.username2.Location = New System.Drawing.Point(96, 48)
        Me.username2.Name = "username2"
        Me.username2.Size = New System.Drawing.Size(216, 20)
        Me.username2.TabIndex = 18
        Me.username2.Text = "Alice"
        '
        'domain2
        '
        Me.domain2.Location = New System.Drawing.Point(96, 24)
        Me.domain2.Name = "domain2"
        Me.domain2.Size = New System.Drawing.Size(128, 20)
        Me.domain2.TabIndex = 17
        Me.domain2.Text = "mydomain.com"
        '
        'log2
        '
        Me.log2.Location = New System.Drawing.Point(10, 208)
        Me.log2.Multiline = True
        Me.log2.Name = "log2"
        Me.log2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.log2.Size = New System.Drawing.Size(480, 544)
        Me.log2.TabIndex = 20
        Me.log2.Text = ""
        '
        'disconnectButton2
        '
        Me.disconnectButton2.Location = New System.Drawing.Point(344, 80)
        Me.disconnectButton2.Name = "disconnectButton2"
        Me.disconnectButton2.Size = New System.Drawing.Size(120, 23)
        Me.disconnectButton2.TabIndex = 48
        Me.disconnectButton2.Text = "Disconnect"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.disconnectButton1)
        Me.groupBox1.Controls.Add(Me.port1)
        Me.groupBox1.Controls.Add(Me.protocol1)
        Me.groupBox1.Controls.Add(Me.removeButton)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.contact1)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.expires)
        Me.groupBox1.Controls.Add(Me.refreshButton)
        Me.groupBox1.Controls.Add(Me.offlineButton)
        Me.groupBox1.Controls.Add(Me.onlineButton)
        Me.groupBox1.Controls.Add(Me.registerButton1)
        Me.groupBox1.Controls.Add(Me.from1)
        Me.groupBox1.Controls.Add(Me.password1)
        Me.groupBox1.Controls.Add(Me.username1)
        Me.groupBox1.Controls.Add(Me.domain1)
        Me.groupBox1.Controls.Add(Me.log1)
        Me.groupBox1.Location = New System.Drawing.Point(6, 6)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(500, 760)
        Me.groupBox1.TabIndex = 2
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "User1"
        '
        'disconnectButton1
        '
        Me.disconnectButton1.Location = New System.Drawing.Point(328, 176)
        Me.disconnectButton1.Name = "disconnectButton1"
        Me.disconnectButton1.Size = New System.Drawing.Size(120, 23)
        Me.disconnectButton1.TabIndex = 47
        Me.disconnectButton1.Text = "Disconnect"
        '
        'port1
        '
        Me.port1.Location = New System.Drawing.Point(224, 24)
        Me.port1.Name = "port1"
        Me.port1.Size = New System.Drawing.Size(40, 20)
        Me.port1.TabIndex = 46
        Me.port1.Text = "5060"
        '
        'protocol1
        '
        Me.protocol1.Items.AddRange(New Object() {"UDP", "TCP"})
        Me.protocol1.Location = New System.Drawing.Point(264, 24)
        Me.protocol1.Name = "protocol1"
        Me.protocol1.Size = New System.Drawing.Size(48, 21)
        Me.protocol1.TabIndex = 45
        Me.protocol1.Text = "UDP"
        '
        'removeButton
        '
        Me.removeButton.Location = New System.Drawing.Point(328, 144)
        Me.removeButton.Name = "removeButton"
        Me.removeButton.Size = New System.Drawing.Size(120, 23)
        Me.removeButton.TabIndex = 16
        Me.removeButton.Text = "Remove State"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(24, 120)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(64, 16)
        Me.label6.TabIndex = 15
        Me.label6.Text = "Contact:"
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'contact1
        '
        Me.contact1.Enabled = False
        Me.contact1.Location = New System.Drawing.Point(96, 120)
        Me.contact1.Name = "contact1"
        Me.contact1.ReadOnly = True
        Me.contact1.Size = New System.Drawing.Size(216, 20)
        Me.contact1.TabIndex = 14
        Me.contact1.Text = ""
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(24, 144)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 16)
        Me.label5.TabIndex = 13
        Me.label5.Text = "Expires:"
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(16, 96)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(72, 16)
        Me.label4.TabIndex = 12
        Me.label4.Text = "From:"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(24, 72)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(64, 16)
        Me.label3.TabIndex = 11
        Me.label3.Text = "Password:"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(16, 48)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(72, 16)
        Me.label2.TabIndex = 10
        Me.label2.Text = "Username:"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 16)
        Me.label1.TabIndex = 9
        Me.label1.Text = "Domain:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'expires
        '
        Me.expires.Location = New System.Drawing.Point(96, 144)
        Me.expires.Name = "expires"
        Me.expires.Size = New System.Drawing.Size(216, 20)
        Me.expires.TabIndex = 8
        Me.expires.Text = "7200"
        '
        'refreshButton
        '
        Me.refreshButton.Location = New System.Drawing.Point(328, 112)
        Me.refreshButton.Name = "refreshButton"
        Me.refreshButton.Size = New System.Drawing.Size(120, 23)
        Me.refreshButton.TabIndex = 7
        Me.refreshButton.Text = "Refresh"
        '
        'offlineButton
        '
        Me.offlineButton.Location = New System.Drawing.Point(328, 80)
        Me.offlineButton.Name = "offlineButton"
        Me.offlineButton.Size = New System.Drawing.Size(120, 23)
        Me.offlineButton.TabIndex = 6
        Me.offlineButton.Text = "Set Offline"
        '
        'onlineButton
        '
        Me.onlineButton.Location = New System.Drawing.Point(328, 48)
        Me.onlineButton.Name = "onlineButton"
        Me.onlineButton.Size = New System.Drawing.Size(120, 23)
        Me.onlineButton.TabIndex = 5
        Me.onlineButton.Text = "Set Online"
        '
        'registerButton1
        '
        Me.registerButton1.Location = New System.Drawing.Point(328, 16)
        Me.registerButton1.Name = "registerButton1"
        Me.registerButton1.Size = New System.Drawing.Size(120, 23)
        Me.registerButton1.TabIndex = 4
        Me.registerButton1.Text = "Register"
        '
        'from1
        '
        Me.from1.Location = New System.Drawing.Point(96, 96)
        Me.from1.Name = "from1"
        Me.from1.Size = New System.Drawing.Size(216, 20)
        Me.from1.TabIndex = 3
        Me.from1.Text = "sip:Bob@mydomain.com"
        '
        'password1
        '
        Me.password1.Location = New System.Drawing.Point(96, 72)
        Me.password1.Name = "password1"
        Me.password1.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.password1.Size = New System.Drawing.Size(216, 20)
        Me.password1.TabIndex = 2
        Me.password1.Text = "Bob"
        '
        'username1
        '
        Me.username1.Location = New System.Drawing.Point(96, 48)
        Me.username1.Name = "username1"
        Me.username1.Size = New System.Drawing.Size(216, 20)
        Me.username1.TabIndex = 1
        Me.username1.Text = "Bob"
        '
        'domain1
        '
        Me.domain1.Location = New System.Drawing.Point(96, 24)
        Me.domain1.Name = "domain1"
        Me.domain1.Size = New System.Drawing.Size(128, 20)
        Me.domain1.TabIndex = 0
        Me.domain1.Text = "mydomain.com"
        '
        'log1
        '
        Me.log1.Location = New System.Drawing.Point(8, 208)
        Me.log1.Multiline = True
        Me.log1.Name = "log1"
        Me.log1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.log1.Size = New System.Drawing.Size(480, 544)
        Me.log1.TabIndex = 2
        Me.log1.Text = ""
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 773)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "Form1"
        Me.Text = "Publish"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub registerButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles registerButton1.Click
        Dim protocol As ProtocolType = ProtocolType.Udp

        If (protocol1.Text = "TCP") Then
            protocol = ProtocolType.Tcp
        End If

        client1 = New SipClient(domain1.Text, Int32.Parse(port1.Text), protocol, username1.Text, password1.Text)

        Dim logger As Logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog1
        client1.Logger = logger

        AddHandler client1.ReceiveRequest, AddressOf OnReceiveRequest1
        AddHandler client1.ReceiveResponse, AddressOf OnReceiveResponse1

        client1.Connect()

        contact1.Text = "sip:" + username1.Text + "@" + client1.LocalIPEndPoint.ToString()

        client1.Register(domain1.Text, from1.Text, contact1.Text)
    End Sub

    Private Sub onlineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles onlineButton.Click
        Dim tuple As Tuple = New Tuple
        tuple.ID = Guid.NewGuid().ToString()
        tuple.Status = New Status(BasicStatus.Open)

        Dim presenceDescription As PresenceDescription = New PresenceDescription(from1.Text)
        presenceDescription.Tuples.Add(tuple)

        If (entityTag Is Nothing) Then
            Dim publishResponseRequest As RequestResponse = client1.PublishEventState(from1.Text, "presence", Int32.Parse(expires.Text), presenceDescription)
            entityTag = publishResponseRequest.Response.Header(StandardHeader.SipETag)
        Else
            Dim modifyResponseRequest As RequestResponse = client1.ModifyEventState(from1.Text, "presence", entityTag, Int32.Parse(expires.Text), presenceDescription)
            entityTag = modifyResponseRequest.Response.Header(StandardHeader.SipETag)
        End If
    End Sub

    Private Sub offlineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles offlineButton.Click
        Dim tuple As Tuple = New Tuple
        tuple.ID = Guid.NewGuid().ToString()
        tuple.Status = New Status(BasicStatus.Closed)

        Dim presenceDescription As PresenceDescription = New PresenceDescription(from1.Text)
        presenceDescription.Tuples.Add(tuple)

        If (entityTag Is Nothing) Then
            Dim publishResponseRequest As RequestResponse = client1.PublishEventState(from1.Text, "presence", Int32.Parse(expires.Text), presenceDescription)
            entityTag = publishResponseRequest.Response.Header(StandardHeader.SipETag)
        Else
            Dim modifyResponseRequest As RequestResponse = client1.ModifyEventState(from1.Text, "presence", entityTag, Int32.Parse(expires.Text), presenceDescription)
            entityTag = modifyResponseRequest.Response.Header(StandardHeader.SipETag)
        End If
    End Sub

    Private Sub refreshButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refreshButton.Click
        Dim refreshResponseRequest As RequestResponse = client1.RefreshEventState(from1.Text, "presence", entityTag, Int32.Parse(expires.Text))
        entityTag = refreshResponseRequest.Response.Header(StandardHeader.SipETag)
    End Sub

    Private Sub removeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeButton.Click
        client1.RemoveEventState(from1.Text, "presence", entityTag)
        entityTag = Nothing
    End Sub

    Private Sub disconnectButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconnectButton1.Click
        client1.Disconnect()
    End Sub

    Private Sub OnReceiveRequest1(ByVal sender As Object, ByVal e As RequestEventArgs)
        client1.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponse1(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog1(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        Append1(e.Log)
    End Sub

    Private Sub Append1(ByVal text As String)
        Dim update As UpdateTextCallback = New UpdateTextCallback(AddressOf AppendText1)
        BeginInvoke(update, New Object() {text})
    End Sub

    Private Sub AppendText1(ByVal text As String)
        log1.AppendText(text)
    End Sub

    Private Sub registerButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles registerButton2.Click

        Dim protocol As ProtocolType = ProtocolType.Udp

        If (protocol2.Text = "TCP") Then
            protocol = ProtocolType.Tcp
        End If

        client2 = New SipClient(domain2.Text, Int32.Parse(port2.Text), protocol, username2.Text, password2.Text)

        Dim logger As Logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog2
        client2.Logger = logger

        AddHandler client2.ReceiveRequest, AddressOf OnReceiveRequest2
        AddHandler client2.ReceiveResponse, AddressOf OnReceiveResponse2

        client2.Connect()

        contact2.Text = "sip:" + username2.Text + "@" + client2.LocalIPEndPoint.ToString()

        client2.Register(domain2.Text, from2.Text, contact2.Text)

    End Sub

    Private Sub subscribeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subscribeButton.Click
        client2.Subscribe(from2.Text, to2.Text, contact2.Text, "presence", 3600)
    End Sub

    Private Sub disconnectButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconnectButton2.Click
        client2.Disconnect()
    End Sub

    Private Sub OnReceiveRequest2(ByVal sender As Object, ByVal e As RequestEventArgs)
        client2.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponse2(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog2(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        Append2(e.Log)
    End Sub

    Private Sub Append2(ByVal text As String)
        Dim update As UpdateTextCallback = New UpdateTextCallback(AddressOf AppendText2)
        BeginInvoke(update, New Object() {text})
    End Sub

    Private Sub AppendText2(ByVal text As String)
        log2.AppendText(text)
    End Sub

End Class
