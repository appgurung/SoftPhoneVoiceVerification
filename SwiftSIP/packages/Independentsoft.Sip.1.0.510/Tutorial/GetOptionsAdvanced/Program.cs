using System;
using Independentsoft.Sip;
using Independentsoft.Sip.Methods;

namespace Sample
{
    class Program
    {
        public static void Main(string[] args)
        {
            SipClient client = new SipClient("sipdomain.com", "Bob", "password");

            client.Connect();
            client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:Bob@mydomain.com");

            Options options = new Options();
            options.Uri = "sip:Alice@mydomain.com";
            options.From = new ContactInfo("Bob", "sip:Bob@mydomain.com");
            options.To = new ContactInfo("Alice", "sip:Alice@mydomain.com");
            options.Contact = new Contact("Bob", "sip:Bob@mydomain.com");

            RequestResponse optionsRequestResponse = client.SendRequest(options);
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

