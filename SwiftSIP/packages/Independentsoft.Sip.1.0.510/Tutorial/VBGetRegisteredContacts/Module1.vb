Imports System
Imports Independentsoft.Sip

Module Module1
    Sub Main(ByVal args() As String)

        Dim client As SipClient = New SipClient("sipdomain.com", "Bob", "password")

        client.Connect()
        Dim contacts() As Contact = client.GetRegisteredContacts("sip:sipdomain.com", "sip:Bob@mydomain.com")
        client.Disconnect()

        Dim i As Integer
        For i = 0 To contacts.Length - 1
            Console.WriteLine("Name=" + contacts(i).Name)
            Console.WriteLine("Address=" + contacts(i).Address)
            Console.WriteLine("Expires=" + contacts(i).Expires)
        Next

        Console.WriteLine("Press ENTER to exit.")
        Console.Read()

    End Sub
End Module

