using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftPhone.Infrastructure.Services;
using SoftPhone.API.Services;
using SoftPhone.Core.DB.REDCHEETAH.STAGING;
namespace SoftPhone.Test
{
    [TestClass]
    public class VoiceVerificationSvcTest
    {
        [TestMethod]
        public void VoiceCallTest()
        {
            var call = new VoiceVerificationSvc(new SoftPhoneSvc(), new Text2SpeechSvc(), new VerificationCodeSvc(new RCStaging()));

            call.VoiceCall(07036569723);
        }
    }
}
