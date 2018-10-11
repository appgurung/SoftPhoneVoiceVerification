using System;
using Independentsoft.Sip;

namespace Sample
{
    class Program
    {
        public static void Main(string[] args)
        {
            SipClient client = new SipClient("sipdomain.com", "Bob", "password");

            client.Connect();
            client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:Bob@mydomain.com");
            RequestResponse optionsRequestResponse = client.GetOptions("sip:Bob@mydomain.com", "sip:Alice@mydomain.com", "sip:Bob@mydomain.com");
            Response response = optionsRequestResponse.Response;

            Console.WriteLine("Accept=" + response.Header[StandardHeader.Accept]);
            Console.WriteLine("Allow=" + response.Header[StandardHeader.Allow]);
            Console.WriteLine("Supported=" + response.Header[StandardHeader.Supported]);
            Console.WriteLine("AcceptLanguage=" + response.Header[StandardHeader.AcceptLanguage]);
            Console.WriteLine("AcceptEncoding=" + response.Header[StandardHeader.AcceptEncoding]);

            Console.WriteLine("Press ENTER to exit.");
            Console.Read();
            client.Disconnect();
        }
    }
}


