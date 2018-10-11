Imports System
Imports System.Net
Imports Independentsoft.Sip
Imports Independentsoft.Sip.Sdp
Imports Independentsoft.Sip.Methods
Imports Independentsoft.Sip.Responses

Module Module1

    Private carol As SipClient
    Private bob As SipClient
    Private alice As SipClient
    Private carolContact As String
    Private bobContact As String
    Private aliceContact As String

    Public Sub Main(ByVal args As String())

        carol = New SipClient("mydomain.com", "Carol", "Carol")
        bob = New SipClient("mydomain.com", "Bob", "Bob")
        alice = New SipClient("mydomain.com", "Alice", "Alice")

        Dim logger As Logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog
        carol.Logger = logger

        AddHandler carol.ReceiveRequest, AddressOf OnReceiveRequestCarol
        AddHandler carol.ReceiveResponse, AddressOf OnReceiveResponseCarol
        AddHandler bob.ReceiveRequest, AddressOf OnReceiveRequestBob
        AddHandler bob.ReceiveResponse, AddressOf OnReceiveResponseBob
        AddHandler alice.ReceiveRequest, AddressOf OnReceiveRequestAlice
        AddHandler alice.ReceiveResponse, AddressOf OnReceiveResponseAlice

        carol.Connect()
        bob.Connect()
        alice.Connect()

        carolContact = "sip:Carol@" + carol.LocalIPEndPoint.ToString
        bobContact = "sip:Bob@" + bob.LocalIPEndPoint.ToString + ";isfocus"
        aliceContact = "sip:Alice@" + alice.LocalIPEndPoint.ToString
        carol.Register("sip:mydomain.com", "sip:Carol@mydomain.com", carolContact)
        bob.Register("sip:mydomain.com", "sip:Bob@mydomain.com", bobContact)
        alice.Register("sip:mydomain.com", "sip:Alice@mydomain.com", aliceContact)

        Dim inviteBob As RequestResponse = alice.Invite("sip:Alice@mydomain.com", "sip:Bob@mydomain.com", aliceContact, GenerateSessionDescription1)
        Dim bobSession As SessionDescription = inviteBob.Response.SessionDescription
        alice.Ack(inviteBob)

        Dim inviteAlice As RequestResponse = bob.Invite("sip:Bob@mydomain.com", "sip:Alice@mydomain.com", bobContact, GenerateSessionDescription2)
        Dim aliceSession As SessionDescription = inviteAlice.Response.SessionDescription
        bob.Ack(inviteAlice)

        Dim inviteCarol As RequestResponse = bob.Invite("sip:Bob@mydomain.com", "sip:Carol@mydomain.com", bobContact, GenerateSessionDescription2)
        Dim carolSession As SessionDescription = inviteCarol.Response.SessionDescription
        bob.Ack(inviteCarol)

        Console.WriteLine("Press ENTER to exit.")
        Console.Read()

        carol.Disconnect()
        bob.Disconnect()
        alice.Disconnect()

    End Sub

    Private Sub OnReceiveRequestCarol(ByVal sender As Object, ByVal e As RequestEventArgs)
        carol.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponseCarol(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnReceiveRequestBob(ByVal sender As Object, ByVal e As RequestEventArgs)
        bob.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponseBob(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnReceiveRequestAlice(ByVal sender As Object, ByVal e As RequestEventArgs)
        alice.AcceptRequest(e.Request)
    End Sub

    Private Sub OnReceiveResponseAlice(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        Console.Write(e.Log)
    End Sub

    Private Function GenerateSessionDescription1() As SessionDescription
        Dim session As SessionDescription = New SessionDescription
        Dim owner As Owner = New Owner
        owner.Username = "Alice"
        owner.SessionID = 2890844526
        owner.Version = 2890844526
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
        media1.Port = 49170
        media1.TransportProtocol = "RTP/AVP"
        media1.Attributes.Add("rtpmap", "0 pcmu/8000")
        session.Media.Add(media1)
        Return session
    End Function

    Private Function GenerateSessionDescription2() As SessionDescription
        Dim session As SessionDescription = New SessionDescription
        Dim owner As Owner = New Owner
        owner.Username = "Bob"
        owner.SessionID = 2890844526
        owner.Version = 2890844526
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
        media1.Port = 49170
        media1.TransportProtocol = "RTP/AVP"
        media1.Attributes.Add("rtpmap", "0 pcmu/8000")
        session.Media.Add(media1)
        Return session
    End Function
End Module

