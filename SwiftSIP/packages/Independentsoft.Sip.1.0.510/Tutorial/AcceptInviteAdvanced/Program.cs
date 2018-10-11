using System;
using Independentsoft.Sip;
using Independentsoft.Sip.Sdp;
using Independentsoft.Sip.Methods;
using Independentsoft.Sip.Responses;

namespace Sample
{
    class Program
    {
        private static SipClient client;

        public static void Main(string[] args)
        {
            client = new SipClient("sipdomain.com", "Bob", "password");
            client.Logger = new Logger("c:\\log1.txt");

            client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
            client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

            client.Connect();
            client.Register("sip:mydomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString());

            Console.WriteLine("Press ENTER to exit.");
            Console.Read();
            client.Disconnect();
        }

        private static void OnReceiveRequest(object sender, RequestEventArgs e)
        {
            if (e.Request.Method == SipMethod.Invite && e.Request.SessionDescription == null)
            {
                OK ok = new OK();
                ok.SessionDescription = GenerateSessionDescription();
                client.SendResponse(ok, e.Request);
            }
            else
            {
                client.AcceptRequest(e.Request);
            }
        }

        private static void OnReceiveResponse(object sender, ResponseEventArgs e)
        {
        }

        private static SessionDescription GenerateSessionDescription()
        {
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

            return session;
        }
    }
}
