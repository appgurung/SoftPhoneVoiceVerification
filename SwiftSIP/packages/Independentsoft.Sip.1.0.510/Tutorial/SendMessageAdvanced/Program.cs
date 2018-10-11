using System;
using Independentsoft.Sip;
using Independentsoft.Sip.Sdp;
using Independentsoft.Sip.Methods;

namespace Sample
{
    class Program
    {
        private static SipClient client;
        private static string latestReceivedCallID;

        public static void Main(string[] args)
        {
            client = new SipClient("sipdomain.com", "Bob", "password");

            //create logger
            client.Logger = new Logger("c:\\log1.txt");

            client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
            client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

            client.Connect();
            client.Register("sip:mydomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString());

            Console.WriteLine("Send message to Alice or press \"q\" to exit.");
            string body = "";

            while (body != "q")
            {
                Console.Write("Bob:");

                body = Console.ReadLine();

                Message message = new Message();
                message.Uri = "sip:Alice@mydomain.com";
                message.From = new ContactInfo("Bob", "sip:Bob@mydomain.com");
                message.To = new ContactInfo("Alice", "sip:Alice@mydomain.com");
                message.ContentType = "text/plain";
                message.Body = body;

                RequestResponse messageRequestResponse = client.SendRequest(message);

                if (messageRequestResponse.Request.CallID == latestReceivedCallID)
                {
                    Console.WriteLine("Alice has received the message");
                }
            }

            client.Disconnect();
        }

        private static void OnReceiveRequest(object sender, RequestEventArgs e)
        {
            if (e.Request.Method == SipMethod.Message)
            {
                client.AcceptRequest(e.Request);
                Console.WriteLine("Alice:" + e.Request.Body);
            }
        }

        private static void OnReceiveResponse(object sender, ResponseEventArgs e)
        {
            if (e.Response.StatusCode == 200)
            {
                latestReceivedCallID = e.Response.CallID;
            }
        }
    }
}
