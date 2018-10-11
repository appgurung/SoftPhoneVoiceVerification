using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftPhone.Core.Enumerations;
using SoftPhone.Core.Interface;
using SoftPhone.Infrastructure.Services;

namespace SoftPhone.API.Services
{
    public class VoiceVerificationSvc : IVoiceVerification
    {
        private readonly ISoftPhoneSvc _softPhone;
        private readonly IText2SpeechSvc _itext2SpeechSvc;
        private readonly IVerificationCodeSvc _verification;

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(WindowsText2SpeechSvc));

        public VoiceVerificationSvc(ISoftPhoneSvc softPhone, IText2SpeechSvc itext2SpeechSvc, IVerificationCodeSvc verification)
        {
            _softPhone = softPhone;
            _itext2SpeechSvc = itext2SpeechSvc;
            _verification = verification;
        }
        /// <summary>
        /// Accepts Phone Number
        /// </summary>
        /// <param name="dialNo"></param>
        /// <returns></returns>
        public bool VoiceCall(long dialNo)
        {
            try
            {
                var code = new Random().Next(9999);
                if (_itext2SpeechSvc.GenerateVoice(dialNo, code, Text2SpeechProviderType.WindowsT2S) == true)
                {
                    if(_verification.AddVerificationCode(code, dialNo) == true)
                        _softPhone.InitiateCall(dialNo, code, Text2SpeechProviderType.WindowsT2S);
                }
                return true;
            }
            catch(Exception ex)
            {
                _log.ErrorFormat("Unable to complete call for {0} due to error:: {1}", dialNo, ex.Message);
                return false;
            }
        }
    }
}