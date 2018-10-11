using System;
using Independentsoft.Sip;
using Independentsoft.Sip.Sdp;

namespace Sample
{
    class Program
    {
        private static SipClient client;

        public static void Main(string[] args)
        {
            client = new SipClient("sipdomain.com", "Bob", "password");

            client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
            client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

            client.Connect();
            client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString());

            Console.WriteLine("Send message to Alice or press \"q\" to exit.");
            string message = "";

            while (message != "q")
            {
                Console.Write("Bob:");
                message = Console.ReadLine();
                client.SendMessage("sip:Bob@mydomain.com", "sip:Alice@mydomain.com", message);
            }

            client.Disconnect();
        }

        private static void OnReceiveRequest(object sender, RequestEventArgs e)
        {
            client.AcceptRequest(e.Request);

            if (e.Request.Method == SipMethod.Message)
            {
                Console.WriteLine("Alice:" + e.Request.Body);
            }
        }

        private static void OnReceiveResponse(object sender, ResponseEventArgs e)
        {
        }
    }
}
