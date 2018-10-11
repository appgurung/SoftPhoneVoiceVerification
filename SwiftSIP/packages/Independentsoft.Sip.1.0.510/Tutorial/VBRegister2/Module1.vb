Imports System.Net
Imports Independentsoft.Sip

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

        'IPHostEntry localhost = Dns.Resolve("mycomputer"); 
        'client.LocalIPEndPoint = new IPEndPoint(localhost.AddressList[0],5060);

        Dim localAddress As System.Net.IPAddress = System.Net.IPAddress.Parse("192.168.2.2")
        client.LocalIPEndPoint = New System.Net.IPEndPoint(localAddress, 5060)

        client.Connect()

        client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString())

        Console.WriteLine("Press ENTER to exit.")
        Console.Read()
        client.Disconnect()
    End Sub

    Private Sub OnReceiveRequest(ByVal sender As Object, ByVal e As RequestEventArgs)
        'accept any request from server or another sip user agent
        client.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponse(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        Console.Write(e.Log)
    End Sub

End Module



