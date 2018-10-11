Imports System
Imports Independentsoft.Sip
Imports Independentsoft.Sip.Methods

Module Module1
    Private logger As Logger
    Private client As SipClient

    Public Sub Main(ByVal args() As String)

        client = New SipClient("sipdomain.com", "Bob", "password")

        'create logger
        logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog
        client.Logger = logger

        AddHandler client.ReceiveRequest, AddressOf OnReceiveRequest
        AddHandler client.ReceiveResponse, AddressOf OnReceiveResponse

        client.Connect()

        Dim register As Register = New Register
        register.Uri = "sip:sipdomain.com"
        register.From = New ContactInfo("Bob", "sip:Bob@mydomain.com")
        register.To = New ContactInfo("Bob", "sip:Bob@mydomain.com")
        register.Header(StandardHeader.Contact) = "sip:Bob@" + client.LocalIPEndPoint.ToString()
        register.Expires = 3600

        client.SendRequest(register)

        Console.WriteLine("Press ENTER to exit.")
        Console.Read()
        client.Disconnect()
    End Sub

    Private Sub OnReceiveRequest(ByVal sender As Object, ByVal e As RequestEventArgs)
        Dim incomingRequest As Request = e.Request

        If incomingRequest.From.Address = "sip:alice@mydomain.com" Then
            client.AcceptRequest(incomingRequest)
        Else
            client.RejectRequest(incomingRequest)
        End If
    End Sub

    Private Sub OnReceiveResponse(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        Console.Write(e.Log)
    End Sub
End Module





