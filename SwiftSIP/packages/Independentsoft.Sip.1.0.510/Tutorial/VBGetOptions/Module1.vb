Imports System
Imports Independentsoft.Sip

Module Module1
    Public Sub Main(ByVal args() As String)

        Dim client As SipClient = New SipClient("sipdomain.com", "Bob", "password")

        client.Connect()
        client.Register("sip:sipdomain.com", "sip:Bob@mydomain.com", "sip:Bob@mydomain.com")
        Dim optionsRequestResponse As RequestResponse = client.GetOptions("sip:Bob@mydomain.com", "sip:Alice@mydomain.com", "sip:Bob@mydomain.com")
        Dim response As Response = optionsRequestResponse.Response

        Console.WriteLine("Accept=" + response.Header(StandardHeader.Accept))
        Console.WriteLine("Allow=" + response.Header(StandardHeader.Allow))
        Console.WriteLine("Supported=" + response.Header(StandardHeader.Supported))
        Console.WriteLine("AcceptLanguage=" + response.Header(StandardHeader.AcceptLanguage))
        Console.WriteLine("AcceptEncoding=" + response.Header(StandardHeader.AcceptEncoding))

        Console.WriteLine("Press ENTER to exit.")
        Console.Read()
        client.Disconnect()

    End Sub
End Module

