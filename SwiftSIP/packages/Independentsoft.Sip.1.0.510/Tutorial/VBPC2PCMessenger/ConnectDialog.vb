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

Public Class ConnectDialog
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents remotePortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents remoteIPAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents localIPAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents localAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents localNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents button2 As System.Windows.Forms.Button
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents remotePort As System.Windows.Forms.TextBox
    Friend WithEvents remoteIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents localIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents localAddress As System.Windows.Forms.TextBox
    Friend WithEvents localName As System.Windows.Forms.TextBox
    Friend WithEvents remoteAddress As System.Windows.Forms.TextBox
    Friend WithEvents remoteName As System.Windows.Forms.TextBox
    Friend WithEvents localPort As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.remotePort = New System.Windows.Forms.TextBox
        Me.remoteIPAddress = New System.Windows.Forms.TextBox
        Me.remoteAddress = New System.Windows.Forms.TextBox
        Me.remoteName = New System.Windows.Forms.TextBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.localPort = New System.Windows.Forms.TextBox
        Me.localIPAddress = New System.Windows.Forms.TextBox
        Me.localAddress = New System.Windows.Forms.TextBox
        Me.localName = New System.Windows.Forms.TextBox
        Me.button2 = New System.Windows.Forms.Button
        Me.button1 = New System.Windows.Forms.Button
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.remotePort)
        Me.groupBox2.Controls.Add(Me.remoteIPAddress)
        Me.groupBox2.Controls.Add(Me.remoteAddress)
        Me.groupBox2.Controls.Add(Me.remoteName)
        Me.groupBox2.Location = New System.Drawing.Point(7, 122)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(352, 96)
        Me.groupBox2.TabIndex = 5
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Remote Computer"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(16, 64)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(72, 16)
        Me.label4.TabIndex = 10
        Me.label4.Text = "IP Address"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(16, 40)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(72, 16)
        Me.label5.TabIndex = 9
        Me.label5.Text = "Address"
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(24, 16)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(64, 16)
        Me.label6.TabIndex = 8
        Me.label6.Text = "Name"
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'remotePort
        '
        Me.remotePort.Location = New System.Drawing.Point(280, 64)
        Me.remotePort.Name = "remotePort"
        Me.remotePort.Size = New System.Drawing.Size(56, 20)
        Me.remotePort.TabIndex = 11
        Me.remotePort.Text = "14060"
        '
        'remoteIPAddress
        '
        Me.remoteIPAddress.Location = New System.Drawing.Point(96, 62)
        Me.remoteIPAddress.Name = "remoteIPAddress"
        Me.remoteIPAddress.Size = New System.Drawing.Size(176, 20)
        Me.remoteIPAddress.TabIndex = 12
        Me.remoteIPAddress.Text = "192.168.2.101"
        '
        'remoteAddress
        '
        Me.remoteAddress.Location = New System.Drawing.Point(96, 38)
        Me.remoteAddress.Name = "remoteAddress"
        Me.remoteAddress.Size = New System.Drawing.Size(240, 20)
        Me.remoteAddress.TabIndex = 5
        Me.remoteAddress.Text = "Alice@mydomain.com"
        '
        'remoteName
        '
        Me.remoteName.Location = New System.Drawing.Point(96, 14)
        Me.remoteName.Name = "remoteName"
        Me.remoteName.Size = New System.Drawing.Size(240, 20)
        Me.remoteName.TabIndex = 13
        Me.remoteName.Text = "Alice"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.localPort)
        Me.groupBox1.Controls.Add(Me.localIPAddress)
        Me.groupBox1.Controls.Add(Me.localAddress)
        Me.groupBox1.Controls.Add(Me.localName)
        Me.groupBox1.Location = New System.Drawing.Point(7, 10)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(352, 104)
        Me.groupBox1.TabIndex = 4
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "My Computer"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(16, 72)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(72, 16)
        Me.label3.TabIndex = 6
        Me.label3.Text = "IP Address"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(16, 48)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(72, 16)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Address"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(24, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 16)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Name"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'localPort
        '
        Me.localPort.Location = New System.Drawing.Point(280, 72)
        Me.localPort.Name = "localPort"
        Me.localPort.Size = New System.Drawing.Size(48, 20)
        Me.localPort.TabIndex = 7
        Me.localPort.Text = "13060"
        '
        'localIPAddress
        '
        Me.localIPAddress.Location = New System.Drawing.Point(96, 72)
        Me.localIPAddress.Name = "localIPAddress"
        Me.localIPAddress.Size = New System.Drawing.Size(176, 20)
        Me.localIPAddress.TabIndex = 8
        Me.localIPAddress.Text = "192.168.2.101"
        '
        'localAddress
        '
        Me.localAddress.Location = New System.Drawing.Point(96, 48)
        Me.localAddress.Name = "localAddress"
        Me.localAddress.Size = New System.Drawing.Size(232, 20)
        Me.localAddress.TabIndex = 9
        Me.localAddress.Text = "Bob@mydomain.com"
        '
        'localName
        '
        Me.localName.Location = New System.Drawing.Point(96, 24)
        Me.localName.Name = "localName"
        Me.localName.Size = New System.Drawing.Size(232, 20)
        Me.localName.TabIndex = 10
        Me.localName.Text = "Bob"
        '
        'button2
        '
        Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.button2.Location = New System.Drawing.Point(199, 226)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(88, 24)
        Me.button2.TabIndex = 7
        Me.button2.Text = "Cancel"
        '
        'button1
        '
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.button1.Location = New System.Drawing.Point(95, 226)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(88, 24)
        Me.button1.TabIndex = 6
        Me.button1.Text = "OK"
        '
        'ConnectDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(366, 260)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Name = "ConnectDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ConnectDialog"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ReadOnly Property LocalNameText() As String
        Get
            Return localName.Text
        End Get
    End Property

    Public ReadOnly Property LocalAddressText() As String
        Get
            Return localAddress.Text
        End Get
    End Property

    Public ReadOnly Property LocalIPAddressText() As String
        Get
            Return localIPAddress.Text
        End Get
    End Property

    Public ReadOnly Property LocalPortText() As String
        Get
            Return localPort.Text
        End Get
    End Property

    Public ReadOnly Property RemoteNameText() As String
        Get
            Return remoteName.Text
        End Get
    End Property

    Public ReadOnly Property RemoteAddressText() As String
        Get
            Return remoteAddress.Text
        End Get
    End Property

    Public ReadOnly Property RemoteIPAddressText() As String
        Get
            Return remoteIPAddress.Text
        End Get
    End Property

    Public ReadOnly Property RemotePortText() As String
        Get
            Return remotePort.Text
        End Get
    End Property


End Class
