using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftPhone.Core.Interface
{
    public interface ISoftPhoneSvc
    {

        bool InitiateCall(long dialNo,int code, Enum speechProvider);

        void RegisterAccount(SIPAccount account);

        void line_RegStateChanged(object sender, RegistrationStateChangedArgs e);

        void SetupDevices();
        void SetupWavPlayer();

        void SetupGoogleTextToSpeech();

        bool CreateCall();

        void call_CallStateChanged(object sender, CallStateChangedArgs e);

        void HangUpTimer();
        
    }
}