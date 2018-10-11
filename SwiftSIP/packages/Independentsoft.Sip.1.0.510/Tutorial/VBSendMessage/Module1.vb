Imports System
Imports Independentsoft.Sip

Module Module1
    Private client As SipClient

    Public Sub Main(ByVal args() As String)

        client = New SipClient("sipdomain.com", "Bob", "password")

        AddHandler client.ReceiveRequest, AddressOf OnReceiveRequest
        AddHandler client.ReceiveResponse, AddressOf OnReceiveResponse

        client.Connect()

        client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString())

        Console.WriteLine("Send message to Alice or press ""q"" to exit.")

        Dim message As String = ""

        While (message <> "q")

            Console.Write("Bob:")
            message = Console.ReadLine()
            client.SendMessage("sip:Bob@mydomain.com", "sip:Alice@mydomain.com", message)

        End While
        client.Disconnect()
    End Sub

    Private Sub OnReceiveRequest(ByVal sender As Object, ByVal e As RequestEventArgs)
        client.AcceptRequest(e.Request)

        If (e.Request.Method = SipMethod.Message) Then
            Console.WriteLine("Alice:" + e.Request.Body)
        End If
    End Sub

    Private Sub OnReceiveResponse(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

End Module


