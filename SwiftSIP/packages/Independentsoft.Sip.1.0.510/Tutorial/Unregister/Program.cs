using System;
using Independentsoft.Sip;
using Independentsoft.Sip.Methods;

namespace Sample
{
    class Program
    {
        private static Logger logger;
        private static SipClient client;

        public static void Main(string[] args)
        {
            client = new SipClient("sipdomain.com", ProtocolType.Tcp, "Bob", "password");

            logger = new Logger();
            logger.WriteLog += new WriteLogEventHandler(OnWriteLog);
            client.Logger = logger;

            client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
            client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

            client.Connect();
            client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:address1@mydomain.com");
            client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:address2@mydomain.com");
            client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:address3@mydomain.com");

            Console.WriteLine("Press ENTER to unregister contact sip:address3@mydomain.com.");
            Console.Read();

            client.Unregister("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:address3@mydomain.com");

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

