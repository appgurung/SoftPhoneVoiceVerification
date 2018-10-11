using System;
using System.Net;
using Independentsoft.Sip;
using Independentsoft.Sip.Sdp;
using Independentsoft.Sip.Methods;
using Independentsoft.Sip.Responses;

namespace Sample
{
    class Program
    {
        private static SipClient controller;
        private static SipClient bob;
        private static SipClient alice;
        private static string controllerContact;
        private static string bobContact;
        private static string aliceContact;

        public static void Main(string[] args)
        {
            controller = new SipClient("mydomain.com", "Controller", "password");
            bob = new SipClient("mydomain.com", "Bob", "password");
            alice = new SipClient("mydomain.com", "Alice", "password");

            Logger logger = new Logger();
            logger.WriteLog += new WriteLogEventHandler(OnWriteLog);
            controller.Logger = logger;

            controller.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequestController);
            controller.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponseController);
            bob.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequestBob);
            bob.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponseBob);
            alice.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequestAlice);
            alice.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponseAlice);

            controller.Connect();
            bob.Connect();
            alice.Connect();

            controllerContact = "sip:Controller@" + controller.LocalIPEndPoint.ToString();
            bobContact = "sip:Bob@" + bob.LocalIPEndPoint.ToString();
            aliceContact = "sip:Alice@" + alice.LocalIPEndPoint.ToString();

            controller.Register("sip:mydomain.com", "sip:Controller@mydomain.com", controllerContact);
            bob.Register("sip:mydomain.com", "sip:Bob@mydomain.com", bobContact);
            alice.Register("sip:mydomain.com", "sip:Alice@mydomain.com", aliceContact);

            RequestResponse inviteBob = controller.Invite("sip:Controller@mydomain.com", "sip:Bob@mydomain.com", controllerContact, null, null);
            SessionDescription bobSession = inviteBob.Response.SessionDescription;

            bobSession.Connection.Address = "0.0.0.0";
            controller.Ack(inviteBob, bobSession);

            RequestResponse inviteAlice = controller.Invite("sip:Controller@mydomain.com", "sip:Alice@mydomain.com", controllerContact, null, null);
            SessionDescription aliceSession = inviteAlice.Response.SessionDescription;

            Dialog bobDialog = controller.GetDialog(inviteBob);

            RequestResponse reinviteBob = controller.Reinvite(bobDialog, aliceSession);
            SessionDescription bobSession2 = reinviteBob.Response.SessionDescription;

            controller.Ack(inviteAlice, bobSession2);
            controller.Ack(reinviteBob);

            Console.WriteLine("Press ENTER to exit.");
            Console.Read();

            controller.Disconnect();
            bob.Disconnect();
            alice.Disconnect();
        }

        private static void OnReceiveRequestController(object sender, RequestEventArgs e)
        {
        }

        private static void OnReceiveResponseController(object sender, ResponseEventArgs e)
        {
        }

        private static void OnReceiveRequestBob(object sender, RequestEventArgs e)
        {
            if (e.Request.Method == SipMethod.Invite)
            {
                SessionDescription session = new SessionDescription();

                Owner owner = new Owner();
                owner.Username = "Bob";
                owner.SessionID = 2890844526;
                owner.Version = 2890844526;
                owner.Address = "192.168.0.2";

                session.Owner = owner;
                session.Name = "SIP Call";

                Connection connection = new Connection();
                connection.Address = "192.168.0.2";
                session.Connection = connection;

                Time time = new Time(0, 0);
                session.Time.Add(time);

                Media media1 = new Media();
                media1.Type = "audio";
                media1.Port = 49170;
                media1.TransportProtocol = "RTP/AVP";
                media1.Attributes.Add("rtpmap", "0 pcmu/8000");
                session.Media.Add(media1);

                OK okResponse = new OK();
                okResponse.SessionDescription = session;
                okResponse.Contact = new Contact(bobContact);

                bob.SendResponse(okResponse, e.Request);
            }
            else
            {
                bob.AcceptRequest(e.Request);
            }
        }

        private static void OnReceiveResponseBob(object sender, ResponseEventArgs e)
        {
        }

        private static void OnReceiveRequestAlice(object sender, RequestEventArgs e)
        {
            if (e.Request.Method == SipMethod.Invite)
            {
                SessionDescription session = new SessionDescription();

                Owner owner = new Owner();
                owner.Username = "Alice";
                owner.SessionID = 2890844527;
                owner.Version = 2890844527;
                owner.Address = "192.168.0.3";

                session.Owner = owner;
                session.Name = "SIP Call";

                Connection connection = new Connection();
                connection.Address = "192.168.0.3";
                session.Connection = connection;

                Time time = new Time(0, 0);
                session.Time.Add(time);

                Media media1 = new Media();
                media1.Type = "audio";
                media1.Port = 3456;
                media1.TransportProtocol = "RTP/AVP";
                media1.Attributes.Add("rtpmap", "0 pcmu/8000");
                session.Media.Add(media1);

                OK okResponse = new OK();
                okResponse.SessionDescription = session;
                okResponse.Contact = new Contact(bobContact);

                bob.SendResponse(okResponse, e.Request);
            }
            else
            {
                alice.AcceptRequest(e.Request);
            }
        }

        private static void OnReceiveResponseAlice(object sender, ResponseEventArgs e)
        {
        }

        private static void OnWriteLog(object sender, WriteLogEventArgs e)
        {
            Console.Write(e.Log);
        }
    }
}

