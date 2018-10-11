Imports System
Imports Independentsoft.Sip
Imports Independentsoft.Sip.Sdp
Imports Independentsoft.Sip.Methods
Imports Independentsoft.Sip.Responses

Module Module1
    Private client As SipClient

    Public Sub Main(ByVal args() As String)

        client = New SipClient("sipdomain.com", "Bob", "password")
        client.Logger = New Logger("c:\\log1.txt")

        AddHandler client.ReceiveRequest, AddressOf OnReceiveRequest
        AddHandler client.ReceiveResponse, AddressOf OnReceiveResponse

        client.Connect()
        client.Register("sip:mydomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString())

        Console.WriteLine("Press ENTER to exit.")
        Console.Read()
        client.Disconnect()

    End Sub

    Private Sub OnReceiveRequest(ByVal sender As Object, ByVal e As RequestEventArgs)
        If e.Request.Method = SipMethod.Invite And e.Request.SessionDescription Is Nothing Then
            Dim ok As OK = New OK
            ok.SessionDescription = GenerateSessionDescription()
            client.SendResponse(ok, e.Request)
        Else
            client.AcceptRequest(e.Request)
        End If
    End Sub

    Private Sub OnReceiveResponse(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Function GenerateSessionDescription() As SessionDescription
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

        Return session

    End Function
End Module

