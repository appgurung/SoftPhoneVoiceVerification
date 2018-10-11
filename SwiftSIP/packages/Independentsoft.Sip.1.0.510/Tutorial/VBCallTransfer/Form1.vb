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

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private client1 As SipClient
    Private client2 As SipClient
    Private client3 As SipClient
    Delegate Sub UpdateTextCallback(ByVal text As String)
    Private callDialog As Dialog

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        If Not (client1 Is Nothing) Then
            client1.Disconnect()
        End If

        If Not (client2 Is Nothing) Then
            client2.Disconnect()
        End If

        If Not (client3 Is Nothing) Then
            client3.Disconnect()
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
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents disconnectButton2 As System.Windows.Forms.Button
    Friend WithEvents port2 As System.Windows.Forms.TextBox
    Friend WithEvents protocol2 As System.Windows.Forms.ComboBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents contact2 As System.Windows.Forms.TextBox
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents registerButton2 As System.Windows.Forms.Button
    Friend WithEvents from2 As System.Windows.Forms.TextBox
    Friend WithEvents password2 As System.Windows.Forms.TextBox
    Friend WithEvents username2 As System.Windows.Forms.TextBox
    Friend WithEvents domain2 As System.Windows.Forms.TextBox
    Friend WithEvents log2 As System.Windows.Forms.TextBox
    Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents disconnectButton3 As System.Windows.Forms.Button
    Friend WithEvents port3 As System.Windows.Forms.TextBox
    Friend WithEvents protocol3 As System.Windows.Forms.ComboBox
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents contact3 As System.Windows.Forms.TextBox
    Friend WithEvents label15 As System.Windows.Forms.Label
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents registerButton3 As System.Windows.Forms.Button
    Friend WithEvents from3 As System.Windows.Forms.TextBox
    Friend WithEvents password3 As System.Windows.Forms.TextBox
    Friend WithEvents username3 As System.Windows.Forms.TextBox
    Friend WithEvents domain3 As System.Windows.Forms.TextBox
    Friend WithEvents log3 As System.Windows.Forms.TextBox
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents transferButton As System.Windows.Forms.Button
    Friend WithEvents callButton As System.Windows.Forms.Button
    Friend WithEvents disconnectButton1 As System.Windows.Forms.Button
    Friend WithEvents port1 As System.Windows.Forms.TextBox
    Friend WithEvents protocol1 As System.Windows.Forms.ComboBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents contact1 As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents registerButton1 As System.Windows.Forms.Button
    Friend WithEvents from1 As System.Windows.Forms.TextBox
    Friend WithEvents password1 As System.Windows.Forms.TextBox
    Friend WithEvents username1 As System.Windows.Forms.TextBox
    Friend WithEvents domain1 As System.Windows.Forms.TextBox
    Friend WithEvents log1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.disconnectButton2 = New System.Windows.Forms.Button
        Me.port2 = New System.Windows.Forms.TextBox
        Me.protocol2 = New System.Windows.Forms.ComboBox
        Me.label7 = New System.Windows.Forms.Label
        Me.contact2 = New System.Windows.Forms.TextBox
        Me.label9 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.label12 = New System.Windows.Forms.Label
        Me.registerButton2 = New System.Windows.Forms.Button
        Me.from2 = New System.Windows.Forms.TextBox
        Me.password2 = New System.Windows.Forms.TextBox
        Me.username2 = New System.Windows.Forms.TextBox
        Me.domain2 = New System.Windows.Forms.TextBox
        Me.log2 = New System.Windows.Forms.TextBox
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.disconnectButton3 = New System.Windows.Forms.Button
        Me.port3 = New System.Windows.Forms.TextBox
        Me.protocol3 = New System.Windows.Forms.ComboBox
        Me.label13 = New System.Windows.Forms.Label
        Me.contact3 = New System.Windows.Forms.TextBox
        Me.label15 = New System.Windows.Forms.Label
        Me.label16 = New System.Windows.Forms.Label
        Me.label17 = New System.Windows.Forms.Label
        Me.label18 = New System.Windows.Forms.Label
        Me.registerButton3 = New System.Windows.Forms.Button
        Me.from3 = New System.Windows.Forms.TextBox
        Me.password3 = New System.Windows.Forms.TextBox
        Me.username3 = New System.Windows.Forms.TextBox
        Me.domain3 = New System.Windows.Forms.TextBox
        Me.log3 = New System.Windows.Forms.TextBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.transferButton = New System.Windows.Forms.Button
        Me.callButton = New System.Windows.Forms.Button
        Me.disconnectButton1 = New System.Windows.Forms.Button
        Me.port1 = New System.Windows.Forms.TextBox
        Me.protocol1 = New System.Windows.Forms.ComboBox
        Me.label6 = New System.Windows.Forms.Label
        Me.contact1 = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.registerButton1 = New System.Windows.Forms.Button
        Me.from1 = New System.Windows.Forms.TextBox
        Me.password1 = New System.Windows.Forms.TextBox
        Me.username1 = New System.Windows.Forms.TextBox
        Me.domain1 = New System.Windows.Forms.TextBox
        Me.log1 = New System.Windows.Forms.TextBox
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.disconnectButton2)
        Me.groupBox2.Controls.Add(Me.port2)
        Me.groupBox2.Controls.Add(Me.protocol2)
        Me.groupBox2.Controls.Add(Me.label7)
        Me.groupBox2.Controls.Add(Me.contact2)
        Me.groupBox2.Controls.Add(Me.label9)
        Me.groupBox2.Controls.Add(Me.label10)
        Me.groupBox2.Controls.Add(Me.label11)
        Me.groupBox2.Controls.Add(Me.label12)
        Me.groupBox2.Controls.Add(Me.registerButton2)
        Me.groupBox2.Controls.Add(Me.from2)
        Me.groupBox2.Controls.Add(Me.password2)
        Me.groupBox2.Controls.Add(Me.username2)
        Me.groupBox2.Controls.Add(Me.domain2)
        Me.groupBox2.Controls.Add(Me.log2)
        Me.groupBox2.Location = New System.Drawing.Point(340, 5)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(336, 716)
        Me.groupBox2.TabIndex = 51
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "User2"
        '
        'disconnectButton2
        '
        Me.disconnectButton2.Location = New System.Drawing.Point(96, 184)
        Me.disconnectButton2.Name = "disconnectButton2"
        Me.disconnectButton2.Size = New System.Drawing.Size(88, 23)
        Me.disconnectButton2.TabIndex = 47
        Me.disconnectButton2.Text = "Disconnect"
        '
        'port2
        '
        Me.port2.Location = New System.Drawing.Point(224, 24)
        Me.port2.Name = "port2"
        Me.port2.Size = New System.Drawing.Size(40, 20)
        Me.port2.TabIndex = 46
        Me.port2.Text = "5060"
        '
        'protocol2
        '
        Me.protocol2.Items.AddRange(New Object() {"UDP", "TCP"})
        Me.protocol2.Location = New System.Drawing.Point(264, 24)
        Me.protocol2.Name = "protocol2"
        Me.protocol2.Size = New System.Drawing.Size(48, 21)
        Me.protocol2.TabIndex = 45
        Me.protocol2.Text = "UDP"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(32, 120)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(56, 16)
        Me.label7.TabIndex = 15
        Me.label7.Text = "Contact:"
        Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'contact2
        '
        Me.contact2.Enabled = False
        Me.contact2.Location = New System.Drawing.Point(96, 120)
        Me.contact2.Name = "contact2"
        Me.contact2.ReadOnly = True
        Me.contact2.Size = New System.Drawing.Size(216, 20)
        Me.contact2.TabIndex = 14
        Me.contact2.Text = ""
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(24, 96)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(64, 16)
        Me.label9.TabIndex = 12
        Me.label9.Text = "From:"
        Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(24, 72)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(64, 16)
        Me.label10.TabIndex = 11
        Me.label10.Text = "Password:"
        Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(24, 48)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(64, 16)
        Me.label11.TabIndex = 10
        Me.label11.Text = "Username:"
        Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(24, 24)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(64, 16)
        Me.label12.TabIndex = 9
        Me.label12.Text = "Domain:"
        Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'registerButton2
        '
        Me.registerButton2.Location = New System.Drawing.Point(96, 152)
        Me.registerButton2.Name = "registerButton2"
        Me.registerButton2.Size = New System.Drawing.Size(88, 23)
        Me.registerButton2.TabIndex = 4
        Me.registerButton2.Text = "Register"
        '
        'from2
        '
        Me.from2.Location = New System.Drawing.Point(96, 96)
        Me.from2.Name = "from2"
        Me.from2.Size = New System.Drawing.Size(216, 20)
        Me.from2.TabIndex = 3
        Me.from2.Text = "sip:Alice@mydomain.com"
        '
        'password2
        '
        Me.password2.Location = New System.Drawing.Point(96, 72)
        Me.password2.Name = "password2"
        Me.password2.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.password2.Size = New System.Drawing.Size(216, 20)
        Me.password2.TabIndex = 2
        Me.password2.Text = "Alice"
        '
        'username2
        '
        Me.username2.Location = New System.Drawing.Point(96, 48)
        Me.username2.Name = "username2"
        Me.username2.Size = New System.Drawing.Size(216, 20)
        Me.username2.TabIndex = 1
        Me.username2.Text = "Alice"
        '
        'domain2
        '
        Me.domain2.Location = New System.Drawing.Point(96, 24)
        Me.domain2.Name = "domain2"
        Me.domain2.Size = New System.Drawing.Size(128, 20)
        Me.domain2.TabIndex = 0
        Me.domain2.Text = "mydomain.com"
        '
        'log2
        '
        Me.log2.Location = New System.Drawing.Point(8, 216)
        Me.log2.Multiline = True
        Me.log2.Name = "log2"
        Me.log2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.log2.Size = New System.Drawing.Size(320, 496)
        Me.log2.TabIndex = 2
        Me.log2.Text = ""
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.disconnectButton3)
        Me.groupBox3.Controls.Add(Me.port3)
        Me.groupBox3.Controls.Add(Me.protocol3)
        Me.groupBox3.Controls.Add(Me.label13)
        Me.groupBox3.Controls.Add(Me.contact3)
        Me.groupBox3.Controls.Add(Me.label15)
        Me.groupBox3.Controls.Add(Me.label16)
        Me.groupBox3.Controls.Add(Me.label17)
        Me.groupBox3.Controls.Add(Me.label18)
        Me.groupBox3.Controls.Add(Me.registerButton3)
        Me.groupBox3.Controls.Add(Me.from3)
        Me.groupBox3.Controls.Add(Me.password3)
        Me.groupBox3.Controls.Add(Me.username3)
        Me.groupBox3.Controls.Add(Me.domain3)
        Me.groupBox3.Controls.Add(Me.log3)
        Me.groupBox3.Location = New System.Drawing.Point(676, 5)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(336, 716)
        Me.groupBox3.TabIndex = 50
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "User3"
        '
        'disconnectButton3
        '
        Me.disconnectButton3.Location = New System.Drawing.Point(96, 184)
        Me.disconnectButton3.Name = "disconnectButton3"
        Me.disconnectButton3.Size = New System.Drawing.Size(88, 23)
        Me.disconnectButton3.TabIndex = 47
        Me.disconnectButton3.Text = "Disconnect"
        '
        'port3
        '
        Me.port3.Location = New System.Drawing.Point(224, 24)
        Me.port3.Name = "port3"
        Me.port3.Size = New System.Drawing.Size(40, 20)
        Me.port3.TabIndex = 46
        Me.port3.Text = "5060"
        '
        'protocol3
        '
        Me.protocol3.Items.AddRange(New Object() {"UDP", "TCP"})
        Me.protocol3.Location = New System.Drawing.Point(264, 24)
        Me.protocol3.Name = "protocol3"
        Me.protocol3.Size = New System.Drawing.Size(48, 21)
        Me.protocol3.TabIndex = 45
        Me.protocol3.Text = "UDP"
        '
        'label13
        '
        Me.label13.Location = New System.Drawing.Point(32, 120)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(56, 16)
        Me.label13.TabIndex = 15
        Me.label13.Text = "Contact:"
        Me.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'contact3
        '
        Me.contact3.Enabled = False
        Me.contact3.Location = New System.Drawing.Point(96, 120)
        Me.contact3.Name = "contact3"
        Me.contact3.ReadOnly = True
        Me.contact3.Size = New System.Drawing.Size(216, 20)
        Me.contact3.TabIndex = 14
        Me.contact3.Text = ""
        '
        'label15
        '
        Me.label15.Location = New System.Drawing.Point(24, 96)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(64, 16)
        Me.label15.TabIndex = 12
        Me.label15.Text = "From:"
        Me.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label16
        '
        Me.label16.Location = New System.Drawing.Point(24, 72)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(64, 16)
        Me.label16.TabIndex = 11
        Me.label16.Text = "Password:"
        Me.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label17
        '
        Me.label17.Location = New System.Drawing.Point(24, 48)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(64, 16)
        Me.label17.TabIndex = 10
        Me.label17.Text = "Username:"
        Me.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label18
        '
        Me.label18.Location = New System.Drawing.Point(24, 24)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(64, 16)
        Me.label18.TabIndex = 9
        Me.label18.Text = "Domain:"
        Me.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'registerButton3
        '
        Me.registerButton3.Location = New System.Drawing.Point(96, 152)
        Me.registerButton3.Name = "registerButton3"
        Me.registerButton3.Size = New System.Drawing.Size(88, 23)
        Me.registerButton3.TabIndex = 4
        Me.registerButton3.Text = "Register"
        '
        'from3
        '
        Me.from3.Location = New System.Drawing.Point(96, 96)
        Me.from3.Name = "from3"
        Me.from3.Size = New System.Drawing.Size(216, 20)
        Me.from3.TabIndex = 3
        Me.from3.Text = "sip:Carol@mydomain.com"
        '
        'password3
        '
        Me.password3.Location = New System.Drawing.Point(96, 72)
        Me.password3.Name = "password3"
        Me.password3.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.password3.Size = New System.Drawing.Size(216, 20)
        Me.password3.TabIndex = 2
        Me.password3.Text = "Carol"
        '
        'username3
        '
        Me.username3.Location = New System.Drawing.Point(96, 48)
        Me.username3.Name = "username3"
        Me.username3.Size = New System.Drawing.Size(216, 20)
        Me.username3.TabIndex = 1
        Me.username3.Text = "Carol"
        '
        'domain3
        '
        Me.domain3.Location = New System.Drawing.Point(96, 24)
        Me.domain3.Name = "domain3"
        Me.domain3.Size = New System.Drawing.Size(128, 20)
        Me.domain3.TabIndex = 0
        Me.domain3.Text = "mydomain.com"
        '
        'log3
        '
        Me.log3.Location = New System.Drawing.Point(8, 216)
        Me.log3.Multiline = True
        Me.log3.Name = "log3"
        Me.log3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.log3.Size = New System.Drawing.Size(320, 496)
        Me.log3.TabIndex = 2
        Me.log3.Text = ""
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.transferButton)
        Me.groupBox1.Controls.Add(Me.callButton)
        Me.groupBox1.Controls.Add(Me.disconnectButton1)
        Me.groupBox1.Controls.Add(Me.port1)
        Me.groupBox1.Controls.Add(Me.protocol1)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.contact1)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.registerButton1)
        Me.groupBox1.Controls.Add(Me.from1)
        Me.groupBox1.Controls.Add(Me.password1)
        Me.groupBox1.Controls.Add(Me.username1)
        Me.groupBox1.Controls.Add(Me.domain1)
        Me.groupBox1.Controls.Add(Me.log1)
        Me.groupBox1.Location = New System.Drawing.Point(4, 5)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(336, 716)
        Me.groupBox1.TabIndex = 49
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "User1"
        '
        'transferButton
        '
        Me.transferButton.Location = New System.Drawing.Point(200, 152)
        Me.transferButton.Name = "transferButton"
        Me.transferButton.Size = New System.Drawing.Size(128, 23)
        Me.transferButton.TabIndex = 49
        Me.transferButton.Text = "Transfer call to User3"
        '
        'callButton
        '
        Me.callButton.Location = New System.Drawing.Point(104, 152)
        Me.callButton.Name = "callButton"
        Me.callButton.Size = New System.Drawing.Size(88, 23)
        Me.callButton.TabIndex = 48
        Me.callButton.Text = "Call User2"
        '
        'disconnectButton1
        '
        Me.disconnectButton1.Location = New System.Drawing.Point(8, 184)
        Me.disconnectButton1.Name = "disconnectButton1"
        Me.disconnectButton1.Size = New System.Drawing.Size(88, 23)
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
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(32, 120)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(56, 16)
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
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(24, 96)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(64, 16)
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
        Me.label2.Location = New System.Drawing.Point(24, 48)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 16)
        Me.label2.TabIndex = 10
        Me.label2.Text = "Username:"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(24, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 16)
        Me.label1.TabIndex = 9
        Me.label1.Text = "Domain:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'registerButton1
        '
        Me.registerButton1.Location = New System.Drawing.Point(8, 152)
        Me.registerButton1.Name = "registerButton1"
        Me.registerButton1.Size = New System.Drawing.Size(88, 23)
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
        Me.log1.Location = New System.Drawing.Point(8, 216)
        Me.log1.Multiline = True
        Me.log1.Name = "log1"
        Me.log1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.log1.Size = New System.Drawing.Size(320, 496)
        Me.log1.TabIndex = 2
        Me.log1.Text = ""
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "Form1"
        Me.Text = "Call Transfer"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox3.ResumeLayout(False)
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


    Private Sub callButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles callButton.Click
        Dim session As SessionDescription = New SessionDescription
        session.Version = 0

        Dim owner As Owner = New Owner
        owner.Username = "root"
        owner.SessionID = 2980
        owner.Version = 2980
        owner.Address = "192.168.0.1"

        session.Owner = owner
        session.Name = "SIP Call"

        Dim connection As Connection = New Connection
        Connection.Address = "192.168.0.1"

        session.Connection = Connection

        Dim time As Time = New Time(0, 0)
        session.Time.Add(time)

        Dim media1 As Media = New Media
        media1.Type = "audio"
        media1.Port = 13598
        media1.TransportProtocol = "RTP/AVP"
        media1.MediaFormats.Add("3")
        media1.MediaFormats.Add("0")
        media1.MediaFormats.Add("8")
        media1.MediaFormats.Add("101")

        media1.Attributes.Add("rtpmap:", "3 GSM/8000")
        media1.Attributes.Add("rtpmap:", "0 PCMU/8000")
        media1.Attributes.Add("rtpmap:", "8 PCMA/8000")
        media1.Attributes.Add("rtpmap:", "101 telephone-event/8000")
        media1.Attributes.Add("fmtp:", "101 0-16")
        media1.Attributes.Add("rtpmap:", "silenceSupp:off - - - -")

        session.Media.Add(media1)

        Dim invite As Invite = New Invite
        invite.Uri = from2.Text
        invite.From = New ContactInfo(from1.Text)
        invite.To = New ContactInfo(from2.Text)
        invite.Contact = New Contact(contact1.Text)
        invite.ContentType = "application/sdp"
        invite.Body = session.ToString()

        Dim inviteRequestResponse As RequestResponse = client1.SendRequest(invite)
        callDialog = client1.GetDialog(inviteRequestResponse)

        client1.Ack(inviteRequestResponse)
    End Sub

    Private Sub transferButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles transferButton.Click
        client1.Refer(callDialog, from3.Text)
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

    Private Sub registerButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles registerButton3.Click

        Dim protocol As ProtocolType = ProtocolType.Udp

        If (protocol3.Text = "TCP") Then
            protocol = ProtocolType.Tcp
        End If

        client3 = New SipClient(domain3.Text, Int32.Parse(port3.Text), protocol, username3.Text, password3.Text)

        Dim logger As Logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog3
        client3.Logger = logger

        AddHandler client3.ReceiveRequest, AddressOf OnReceiveRequest3
        AddHandler client3.ReceiveResponse, AddressOf OnReceiveResponse3

        client3.Connect()

        contact3.Text = "sip:" + username3.Text + "@" + client3.LocalIPEndPoint.ToString()

        client3.Register(domain3.Text, from3.Text, contact3.Text)

    End Sub

    Private Sub disconnectButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconnectButton3.Click
        client3.Disconnect()
    End Sub

    Private Sub OnReceiveRequest3(ByVal sender As Object, ByVal e As RequestEventArgs)
        client3.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponse3(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog3(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        Append3(e.Log)
    End Sub

    Private Sub Append3(ByVal text As String)
        Dim update As UpdateTextCallback = New UpdateTextCallback(AddressOf AppendText3)
        BeginInvoke(update, New Object() {text})
    End Sub

    Private Sub AppendText3(ByVal text As String)
        log3.AppendText(text)
    End Sub
End Class
