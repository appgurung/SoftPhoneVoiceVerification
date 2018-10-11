Imports System
Imports Independentsoft.Sip
Imports Independentsoft.Sip.Sdp
Imports Independentsoft.Sip.Methods

Module Module1
    Private client As SipClient
    Private latestReceivedCallID As String

    Public Sub Main(ByVal args() As String)

        client = New SipClient("sipdomain.com", "Bob", "password")

        'create logger
        client.Logger = New Logger("c:\\log1.txt")

        AddHandler client.ReceiveRequest, AddressOf OnReceiveRequest
        AddHandler client.ReceiveResponse, AddressOf OnReceiveResponse

        client.Connect()
        client.Register("sip:mydomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString())

        Console.WriteLine("Send message to Alice or press ""q"" to exit.")
        Dim body As String = ""

        While (body <> "q")
            Console.Write("Bob:")

            body = Console.ReadLine()

            Dim message As Message = New Message
            message.Uri = "sip:Alice@mydomain.com"
            message.From = New ContactInfo("Bob", "sip:Bob@mydomain.com")
            message.To = New ContactInfo("Alice", "sip:Alice@mydomain.com")
            message.ContentType = "text/plain"
            message.Body = body

            Dim messageRequestResponse As RequestResponse = client.SendRequest(message)

            If (messageRequestResponse.Request.CallID = latestReceivedCallID) Then
                Console.WriteLine("Alice has received the message")
            End If
        End While

        client.Disconnect()

    End Sub

    Private Sub OnReceiveRequest(ByVal sender As Object, ByVal e As RequestEventArgs)
        If (e.Request.Method = SipMethod.Message) Then
            client.AcceptRequest(e.Request)
            Console.WriteLine("Alice:" + e.Request.Body)
        End If
    End Sub

    Private Sub OnReceiveResponse(ByVal sender As Object, ByVal e As ResponseEventArgs)
        If (e.Response.StatusCode = 200) Then
            latestReceivedCallID = e.Response.CallID
        End If
    End Sub
End Module
