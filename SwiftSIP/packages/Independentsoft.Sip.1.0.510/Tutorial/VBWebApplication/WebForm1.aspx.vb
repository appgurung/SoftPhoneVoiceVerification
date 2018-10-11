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

Public Class WebForm1
    Inherits System.Web.UI.Page

    Private client As SipClient

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents log As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents port As System.Web.UI.WebControls.TextBox
    Protected WithEvents password As System.Web.UI.WebControls.TextBox
    Protected WithEvents username As System.Web.UI.WebControls.TextBox
    Protected WithEvents domain As System.Web.UI.WebControls.TextBox
    Protected WithEvents from As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        client = New SipClient(domain.Text, Int32.Parse(port.Text), ProtocolType.Udp, username.Text, password.Text)

        Dim logger As Logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog
        client.Logger = logger

        AddHandler client.ReceiveRequest, AddressOf OnReceiveRequest
        AddHandler client.ReceiveResponse, AddressOf OnReceiveResponse

        client.Connect()

        Dim contact As String = "sip:" + client.LocalIPEndPoint.ToString()

        client.Register(domain.Text, from.Text, contact)
    End Sub

    Private Sub OnReceiveRequest(ByVal sender As Object, ByVal e As RequestEventArgs)
        client.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponse(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        log.Text = log.Text + e.Log
    End Sub
End Class
