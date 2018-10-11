Imports System
Imports System.Net
Imports Independentsoft.Sip
Imports Independentsoft.Sip.Sdp
Imports Independentsoft.Sip.Methods
Imports Independentsoft.Sip.Responses

Module Module1

    Private controller As SipClient
    Private bob As SipClient
    Private alice As SipClient
    Private controllerContact As String
    Private bobContact As String
    Private aliceContact As String

    Public Sub Main(ByVal args() As String)

        controller = New SipClient("mydomain.com", "Controller", "password")
        bob = New SipClient("mydomain.com", "Bob", "password")
        alice = New SipClient("mydomain.com", "Alice", "password")

        Dim logger As Logger = New Logger
        AddHandler logger.WriteLog, AddressOf OnWriteLog
        controller.Logger = logger

        AddHandler controller.ReceiveRequest, AddressOf OnReceiveRequestController
        AddHandler controller.ReceiveResponse, AddressOf OnReceiveResponseController
        AddHandler bob.ReceiveRequest, AddressOf OnReceiveRequestBob
        AddHandler bob.ReceiveResponse, AddressOf OnReceiveResponseBob
        AddHandler alice.ReceiveRequest, AddressOf OnReceiveRequestAlice
        AddHandler alice.ReceiveResponse, AddressOf OnReceiveResponseAlice

        controller.Connect()
        bob.Connect()
        alice.Connect()

        controllerContact = "sip:Controller@" + controller.LocalIPEndPoint.ToString()
        bobContact = "sip:Bob@" + bob.LocalIPEndPoint.ToString()
        aliceContact = "sip:Alice@" + alice.LocalIPEndPoint.ToString()

        controller.Register("sip:mydomain.com", "sip:Controller@mydomain.com", controllerContact)
        bob.Register("sip:mydomain.com", "sip:Bob@mydomain.com", bobContact)
        alice.Register("sip:mydomain.com", "sip:Alice@mydomain.com", aliceContact)

        Dim inviteBob As RequestResponse = controller.Invite("sip:Controller@mydomain.com", "sip:Bob@mydomain.com", controllerContact, Nothing, Nothing)
        Dim bobSession As SessionDescription = inviteBob.Response.SessionDescription

        bobSession.Connection.Address = "0.0.0.0"
        controller.Ack(inviteBob, bobSession)

        Dim inviteAlice As RequestResponse = controller.Invite("sip:Controller@mydomain.com", "sip:Alice@mydomain.com", controllerContact, Nothing, Nothing)
        Dim aliceSession As SessionDescription = inviteAlice.Response.SessionDescription

        Dim bobDialog As Dialog = controller.GetDialog(inviteBob)

        Dim reinviteBob As RequestResponse = controller.Reinvite(bobDialog, aliceSession)
        Dim bobSession2 As SessionDescription = reinviteBob.Response.SessionDescription

        controller.Ack(inviteAlice, bobSession2)
        controller.Ack(reinviteBob)

        Console.WriteLine("Press ENTER to exit.")
        Console.Read()

        controller.Disconnect()
        bob.Disconnect()
        alice.Disconnect()
    End Sub

    Private Sub OnReceiveRequestController(ByVal sender As Object, ByVal e As RequestEventArgs)
    End Sub

    Private Sub OnReceiveResponseController(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnReceiveRequestBob(ByVal sender As Object, ByVal e As RequestEventArgs)
        If e.Request.Method = SipMethod.Invite Then
            Dim session As SessionDescription = New SessionDescription

            Dim owner As Owner = New Owner
            owner.Username = "Bob"
            owner.SessionID = 2890844526
            owner.Version = 2890844526
            owner.Address = "192.168.0.2"

            session.Owner = owner
            session.Name = "SIP Call"

            Dim connection As Connection = New Connection
            connection.Address = "192.168.0.2"
            session.Connection = connection

            Dim time As Time = New Time(0, 0)
            session.Time.Add(time)

            Dim media1 As Media = New Media
            media1.Type = "audio"
            media1.Port = 49170
            media1.TransportProtocol = "RTP/AVP"
            media1.Attributes.Add("rtpmap", "0 pcmu/8000")
            session.Media.Add(media1)

            Dim okResponse As OK = New OK
            okResponse.SessionDescription = session
            okResponse.Contact = New Contact(bobContact)

            bob.SendResponse(okResponse, e.Request)
        Else
            bob.AcceptRequest(e.Request)
        End If
    End Sub

    Private Sub OnReceiveResponseBob(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnReceiveRequestAlice(ByVal sender As Object, ByVal e As RequestEventArgs)
        If e.Request.Method = SipMethod.Invite Then
            Dim session As SessionDescription = New SessionDescription

            Dim owner As Owner = New Owner
            owner.Username = "Alice"
            owner.SessionID = 2890844527
            owner.Version = 2890844527
            owner.Address = "192.168.0.3"

            session.Owner = owner
            session.Name = "SIP Call"

            Dim connection As Connection = New Connection
            connection.Address = "192.168.0.3"
            session.Connection = connection

            Dim time As Time = New Time(0, 0)
            session.Time.Add(time)

            Dim media1 As Media = New Media
            media1.Type = "audio"
            media1.Port = 3456
            media1.TransportProtocol = "RTP/AVP"
            media1.Attributes.Add("rtpmap", "0 pcmu/8000")
            session.Media.Add(media1)

            Dim okResponse As OK = New OK
            okResponse.SessionDescription = session
            okResponse.Contact = New Contact(bobContact)

            bob.SendResponse(okResponse, e.Request)
        Else
            alice.AcceptRequest(e.Request)
        End If
    End Sub

    Private Sub OnReceiveResponseAlice(ByVal sender As Object, ByVal e As ResponseEventArgs)
    End Sub

    Private Sub OnWriteLog(ByVal sender As Object, ByVal e As WriteLogEventArgs)
        Console.Write(e.Log)
    End Sub

End Module

