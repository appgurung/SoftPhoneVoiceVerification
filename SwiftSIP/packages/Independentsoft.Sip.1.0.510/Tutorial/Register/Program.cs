using System;
using Independentsoft.Sip;

namespace Sample
{
    class Program
    {
        private static Logger logger;
        private static SipClient client;

        public static void Main(string[] args)
        {
            client = new SipClient("sipdomain.com", "Bob", "password");

            //create logger
            logger = new Logger();
            logger.WriteLog += new WriteLogEventHandler(OnWriteLog);
            client.Logger = logger;

            client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
            client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

            client.Connect();

            client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:Bob@" + client.LocalIPEndPoint.ToString());

            Console.WriteLine("Press ENTER to exit.");
            Console.Read();
            client.Disconnect();
        }

        private static void OnReceiveRequest(object sender, RequestEventArgs e)
        {
            //accept any request from server or another sip user agent
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

