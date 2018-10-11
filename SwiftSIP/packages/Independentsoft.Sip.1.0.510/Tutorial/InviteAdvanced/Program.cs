using System;
using Independentsoft.Sip;
using Independentsoft.Sip.Sdp;
using Independentsoft.Sip.Methods;

namespace Sample
{
    class Program
    {
        private static Logger logger;
        private static SipClient client;

        public static void Main(string[] args)
        {
            client = new SipClient("sipdomain.com", "Bob", "password");

            logger = new Logger();
            logger.WriteLog += new WriteLogEventHandler(OnWriteLog);
            client.Logger = logger;

            client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
            client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

            client.Connect();

            SessionDescription session = new SessionDescription();
            session.Version = 0;

            Owner owner = new Owner();
            owner.Username = "Bob";
            owner.SessionID = 16264;
            owner.Version = 18299;
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
            media1.Port = 25282;
            media1.TransportProtocol = "RTP/AVP";
            media1.MediaFormats.Add("0");
            media1.MediaFormats.Add("101");

            media1.Attributes.Add("rtpmap", "0 pcmu/8000");
            media1.Attributes.Add("rtpmap", "101 telephone-event/8000");
            media1.Attributes.Add("fmtp", "101 0-11");

            session.Media.Add(media1);

            Invite invite = new Invite();
            invite.Uri = "sip:Alice@mydomain.com";
            invite.From = new ContactInfo("Bob", "sip:Bob@mydomain.com");
            invite.To = new ContactInfo("Alice", "sip:Alice@mydomain.com");
            invite.Contact = new Contact("Bob", "sip:Bob@" + client.LocalIPEndPoint.ToString());
            invite.ContentType = "application/sdp";
            invite.Body = session.ToString();

            RequestResponse inviteRequestResponse = client.SendRequest(invite);

            client.Ack(inviteRequestResponse);

            Console.WriteLine("Press ENTER to exit.");
            Console.Read();
            client.Disconnect();
        }

        private static void OnReceiveRequest(object sender, RequestEventArgs e)
        {
            client.AcceptRequest(e.Request);
        }

        private static void OnReceiveResponse(object sender, ResponseEventArgs e)
        {
        }

        private static void OnWriteLog(object sender, WriteLogEventArgs e)
        {
            Console.Write(e.Log);
        }
    }
}

