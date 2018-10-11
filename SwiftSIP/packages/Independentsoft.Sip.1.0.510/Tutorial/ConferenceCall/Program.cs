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
        private static SipClient carol;
        private static SipClient bob;
        private static SipClient alice;
        private static string carolContact;
        private static string bobContact;
        private static string aliceContact;
        public static void Main(string[] args)
        {
            carol = new SipClient("mydomain.com", "Carol", "Carol");
            bob = new SipClient("mydomain.com", "Bob", "Bob");
            alice = new SipClient("mydomain.com", "Alice", "Alice");

            Logger logger = new Logger();
            logger.WriteLog += new WriteLogEventHandler(OnWriteLog);
            carol.Logger = logger;

            carol.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequestCarol);
            carol.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponseCarol);
            bob.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequestBob);
            bob.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponseBob);
            alice.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequestAlice);
            alice.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponseAlice);

            carol.Connect();
            bob.Connect();
            alice.Connect();

            carolContact = "sip:Carol@" + carol.LocalIPEndPoint.ToString();
            bobContact = "sip:Bob@" + bob.LocalIPEndPoint.ToString() + ";isfocus";
            aliceContact = "sip:Alice@" + alice.LocalIPEndPoint.ToString();

            carol.Register("sip:mydomain.com", "sip:Carol@mydomain.com", carolContact);
            bob.Register("sip:mydomain.com", "sip:Bob@mydomain.com", bobContact);
            alice.Register("sip:mydomain.com", "sip:Alice@mydomain.com", aliceContact);

            RequestResponse inviteBob = alice.Invite("sip:Alice@mydomain.com", "sip:Bob@mydomain.com", aliceContact, GenerateSessionDescription1());
            SessionDescription bobSession = inviteBob.Response.SessionDescription;
            alice.Ack(inviteBob);

            RequestResponse inviteAlice = bob.Invite("sip:Bob@mydomain.com", "sip:Alice@mydomain.com", bobContact, GenerateSessionDescription2());
            SessionDescription aliceSession = inviteAlice.Response.SessionDescription;
            bob.Ack(inviteAlice);

            RequestResponse inviteCarol = bob.Invite("sip:Bob@mydomain.com", "sip:Carol@mydomain.com", bobContact, GenerateSessionDescription2());
            SessionDescription carolSession = inviteCarol.Response.SessionDescription;
            bob.Ack(inviteCarol);


            Console.WriteLine("Press ENTER to exit.");
            Console.Read();

            carol.Disconnect();
            bob.Disconnect();
            alice.Disconnect();
        }

        private static void OnReceiveRequestCarol(object sender, RequestEventArgs e)
        {
            carol.AcceptRequest(e.Request);
        }

        private static void OnReceiveResponseCarol(object sender, ResponseEventArgs e)
        {
        }

        private static void OnReceiveRequestBob(object sender, RequestEventArgs e)
        {
            bob.AcceptRequest(e.Request);
        }

        private static void OnReceiveResponseBob(object sender, ResponseEventArgs e)
        {
        }

        private static void OnReceiveRequestAlice(object sender, RequestEventArgs e)
        {
            alice.AcceptRequest(e.Request);
        }

        private static void OnReceiveResponseAlice(object sender, ResponseEventArgs e)
        {
        }

        private static void OnWriteLog(object sender, WriteLogEventArgs e)
        {
            Console.Write(e.Log);
        }

        private static SessionDescription GenerateSessionDescription1()
        {
            SessionDescription session = new SessionDescription();

            Owner owner = new Owner();
            owner.Username = "Alice";
            owner.SessionID = 2890844526;
            owner.Version = 2890844526;
            owner.Address = "192.168.0.1";

            session.Owner = owner;
            session.Name = "SIP Call";

            Connection connection = new Connection();
            connection.Address = "192.168.0.1";
            session.Connection = connection;

            Time time = new Time(0, 0);
            session.Time.Add(time);

            Media media1 = new Media();
            media1.Type = "audio";
            media1.Port = 49170;
            media1.TransportProtocol = "RTP/AVP";
            media1.Attributes.Add("rtpmap", "0 pcmu/8000");
            session.Media.Add(media1);

            return session;
        }

        private static SessionDescription GenerateSessionDescription2()
        {
            SessionDescription session = new SessionDescription();

            Owner owner = new Owner();
            owner.Username = "Bob";
            owner.SessionID = 2890844526;
            owner.Version = 2890844526;
            owner.Address = "192.168.0.1";

            session.Owner = owner;
            session.Name = "SIP Call";

            Connection connection = new Connection();
            connection.Address = "192.168.0.1";
            session.Connection = connection;

            Time time = new Time(0, 0);
            session.Time.Add(time);

            Media media1 = new Media();
            media1.Type = "audio";
            media1.Port = 49170;
            media1.TransportProtocol = "RTP/AVP";
            media1.Attributes.Add("rtpmap", "0 pcmu/8000");
            session.Media.Add(media1);

            return session;
        }
    }
}


