Imports System
Imports Independentsoft.Sip
Imports Independentsoft.Sip.Methods

Module Module1

    Private logger As Logger
    Private client As SipClient

    Public Sub Main(ByVal args() As String)

        client = New SipClient("sipdomain.com", ProtocolType.Tcp, "Bob", "password")

        logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog
        client.Logger = logger

        AddHandler client.ReceiveRequest, AddressOf OnReceiveRequest
        AddHandler client.ReceiveResponse, AddressOf OnReceiveResponse

        client.Connect()
        client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:address1@mydomain.com")
        client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:address2@mydomain.com")
        client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:address3@mydomain.com")

        Console.WriteLine("Press ENTER to unregister contact sip:address3@mydomain.com.")
        Console.Read()

        client.Unregister("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:address3@mydomain.com")

        Console.WriteLine("Press ENTER to exit.")
        Console.Read()
        client.Disconnect()

    End Sub

    Private Sub OnReceiveRequest(ByVal sender As Object, ByVal e As RequestEventArgs)
        client.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponse(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        Console.Write(e.Log)
    End Sub

End Module



