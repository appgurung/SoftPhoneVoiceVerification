Imports System
Imports Independentsoft.Sip
Imports Independentsoft.Sip.Methods

Module Module1
    Private client As SipClient

    Public Sub Main(ByVal args() As String)

        client = New SipClient("sipdomain.com", "Bob", "password")

        Dim logger As Logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog
        client.Logger = logger

        AddHandler client.ReceiveRequest, AddressOf OnReceiveRequest
        AddHandler client.ReceiveResponse, AddressOf OnReceiveResponse


        client.Connect()
        client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString())

        Dim subscribe As Subscribe = New Subscribe
        subscribe.Uri = "sip:Alice@mydomain.com"
        subscribe.From = New ContactInfo("Bob", "sip:Bob@mydomain.com")
        subscribe.To = New ContactInfo("Alice", "sip:Alice@mydomain.com")
        subscribe.Contact = New Contact("Bob", "sip:Bob@" + client.LocalIPEndPoint.ToString())
        subscribe.Event = "presence"
        subscribe.Expires = 3600
        subscribe.AllowEvents = "dialog, presence"

        client.SendRequest(subscribe)

        Console.WriteLine("Press ENTER to exit.")
        Console.Read()
        client.Disconnect()

    End Sub

    Private Sub OnReceiveRequest(ByVal sender As Object, ByVal e As RequestEventArgs)
        Dim response As Response = client.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponse(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        Console.Write(e.Log)
    End Sub

End Module




