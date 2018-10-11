using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftPhone.API.Services;
using SoftPhone.Core.Interface;
using SoftPhone.Infrastructure.Services;

namespace SwiftSIP.Test
{
    [TestClass]
    public class Text2SpeechSvcTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Text2SpeechSvc text2speechsvc = new Text2SpeechSvc();

            bool resp = text2speechsvc.GenerateVoice(07036569723, new Random().Next(9999), 
                SoftPhone.Core.Enumerations.Text2SpeechProviderType.GoogleT2S);

            Assert.IsTrue(resp);
        }
    }
}
