using System;
using Independentsoft.Sip;
using Independentsoft.Sip.Methods;

namespace Sample 
{
    class Program
    {
        private static SipClient client;

        public static void Main(string[] args)
        {
            client = new SipClient("sipdomain.com", "Bob", "password");

            Logger logger = new Logger();
            logger.WriteLog += new WriteLogEventHandler(OnWriteLog);
            client.Logger = logger;

            client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
            client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

            client.Connect();
            client.Register("sip:mydomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint);

            Subscribe subscribe = new Subscribe();
            subscribe.Uri = "sip:Alice@mydomain.com";
            subscribe.From = new ContactInfo("Bob", "sip:Bob@mydomain.com");
            subscribe.To = new ContactInfo("Alice", "sip:Alice@mydomain.com");
            subscribe.Contact = new Contact("Bob", "sip:Bob@" + client.LocalIPEndPoint);
            subscribe.Event = "presence";
            subscribe.Expires = 3600;
            subscribe.AllowEvents = "dialog, presence";

            client.SendRequest(subscribe);

            Console.WriteLine("Press ENTER to exit.");
            Console.Read();
            client.Disconnect();
        }

        private static void OnReceiveRequest(object sender, RequestEventArgs e)
        {
            Response response = client.AcceptRequest(e.Request);
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

