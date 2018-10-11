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
            client = new SipClient("sipdomain.com", "Bob", "password");

            //create logger
            logger = new Logger();
            logger.WriteLog += new WriteLogEventHandler(OnWriteLog);
            client.Logger = logger;

            client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
            client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

            client.Connect();

            Register register = new Register();
            register.Uri = "sip:sipdomain.com";
            register.From = new ContactInfo("Bob", "sip:Bob@mydomain.com");
            register.To = new ContactInfo("Bob", "sip:Bob@mydomain.com");
            register.Header[StandardHeader.Contact] = "sip:Bob@" + client.LocalIPEndPoint.ToString();
            register.Expires = 3600;

            client.SendRequest(register);

            Console.WriteLine("Press ENTER to exit.");
            Console.Read();
            client.Disconnect();
        }

        private static void OnReceiveRequest(object sender, RequestEventArgs e)
        {
            Request incomingRequest = e.Request;

            if (incomingRequest.From.Address == "sip:alice@mydomain.com")
            {
                client.AcceptRequest(incomingRequest);
            }
            else
            {
                client.RejectRequest(incomingRequest);
            }
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


