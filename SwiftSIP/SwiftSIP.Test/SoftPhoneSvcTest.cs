using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftPhone.Infrastructure.Services;

namespace SoftPhone.Test
{
    [TestClass]
    public class SoftPhoneSvcTest
    {
        [TestMethod]
        public void InitateCallTest()
        {

            SoftPhoneSvc client = new SoftPhoneSvc();

            client.InitiateCall(07036569723, new Random().Next(9999), Core.Enumerations.Text2SpeechProviderType.GoogleT2S);

            
        }
    }
}
