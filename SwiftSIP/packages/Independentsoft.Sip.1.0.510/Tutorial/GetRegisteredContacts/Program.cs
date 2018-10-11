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
            Contact[] contacts = client.GetRegisteredContacts("sip:sipdomain.com", "sip:Bob@mydomain.com");
            client.Disconnect();

            for (int i = 0; i < contacts.Length; i++)
            {
                Console.WriteLine("Name=" + contacts[i].Name);
                Console.WriteLine("Address=" + contacts[i].Address);
                Console.WriteLine("Expires=" + contacts[i].Expires);
            }

            Console.WriteLine("Press ENTER to exit.");
            Console.Read();
        }
    }
}
