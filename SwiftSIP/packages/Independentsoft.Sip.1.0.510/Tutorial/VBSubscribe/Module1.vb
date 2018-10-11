Imports System
Imports Independentsoft.Sip

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
        client.Subscribe("sip:Bob@mydomain.com", "sip:Alice@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString(), "presence", 3600)

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

