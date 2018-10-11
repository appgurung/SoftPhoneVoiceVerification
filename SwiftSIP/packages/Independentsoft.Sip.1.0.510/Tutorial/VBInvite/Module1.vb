Imports System
Imports Independentsoft.Sip
Imports Independentsoft.Sip.Sdp

Module Module1
    Private logger As Logger
    Private client As SipClient

    Public Sub Main(ByVal args() As String)

        client = New SipClient("sipdomain.com", "Bob", "password")

        logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog
        client.Logger = logger

        AddHandler client.ReceiveRequest, AddressOf OnReceiveRequest
        AddHandler client.ReceiveResponse, AddressOf OnReceiveResponse
        client.Connect()

        Dim session As SessionDescription = New SessionDescription
        session.Version = 0

        Dim owner As Owner = New Owner
        owner.Username = "Bob"
        owner.SessionID = 16264
        owner.Version = 18299
        owner.Address = "192.168.0.1"

        session.Owner = owner
        session.Name = "SIP Call"

        Dim connection As Connection = New Connection
        connection.Address = "192.168.0.1"

        session.Connection = connection

        Dim time As Time = New Time(0, 0)
        session.Time.Add(time)

        Dim media1 As Media = New Media
        media1.Type = "audio"
        media1.Port = 25282
        media1.TransportProtocol = "RTP/AVP"
        media1.MediaFormats.Add("0")
        media1.MediaFormats.Add("101")

        media1.Attributes.Add("rtpmap", "0 pcmu/8000")
        media1.Attributes.Add("rtpmap", "101 telephone-event/8000")
        media1.Attributes.Add("fmtp", "101 0-11")

        session.Media.Add(media1)

        Dim inviteRequestResponse As RequestResponse = client.Invite("sip:Bob@mydomain.com", "sip:Alice@mydomain.com", "sip:Bob" + client.LocalIPEndPoint.ToString(), session)
        client.Ack(inviteRequestResponse)

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

