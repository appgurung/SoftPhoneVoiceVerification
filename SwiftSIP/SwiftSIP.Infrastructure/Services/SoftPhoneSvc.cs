using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ozeki.Media;
using Ozeki.VoIP;
using SoftPhone.Core.Interface;
using System.Configuration;
using SoftPhone.Core.Enumerations;
using SoftPhone.Core.Helpers;
using SoftPhone.Core.DB.REDCHEETAH.STAGING;
using System.Diagnostics;

namespace SoftPhone.Infrastructure.Services
{
    public class SoftPhoneSvc : ISoftPhoneSvc
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(SoftPhoneSvc));

        static ISoftPhone _softphone;   // softphone object
        static IPhoneLine _phoneLine;   // phoneline object
        static IOzPhoneCall _call;
        static int _speechProvider = 0;

        static Microphone _microphone;
        static Speaker _speaker;
        static MediaConnector _connector;
        static PhoneCallAudioSender _mediaSender;
        static PhoneCallAudioReceiver _mediaReceiver;
        static WaveStreamPlayback _wavPlayer;
        static GoogleTTS _googleAPI;


        public static string _phoneNo = string.Empty;
        public static string _code = string.Empty;

        public bool InitiateCall(long dialNo,int code, Enum speechProvider)
        {

            _speechProvider = int.Parse(StringEnum.GetStringValue(speechProvider));

            _phoneNo = dialNo.ToString();
            _code = code.ToString();
            // Create a softphone object with RTP port range 5000-10000
            _softphone = SoftPhoneFactory.CreateSoftPhone(5000, 10000);

            // SIP account registration data, (supplied by your VoIP service provider)
            var registrationRequired = false;
            var userName = ConfigurationManager.AppSettings["userName"];
            var displayName = ConfigurationManager.AppSettings["displayName"];
            var authenticationId = ConfigurationManager.AppSettings["authenticationId"];
            var registerPassword = ConfigurationManager.AppSettings["registerPassword"];
            var domainHost = ConfigurationManager.AppSettings["domainHost"];
            var domainPort = int.Parse(ConfigurationManager.AppSettings["domainPort"]);

            var account = new SIPAccount(registrationRequired, displayName, userName, authenticationId, registerPassword, domainHost, domainPort);

            // Send SIP regitration request
            RegisterAccount(account);
            if (_speechProvider == int.Parse(StringEnum.GetStringValue(Text2SpeechProviderType.WindowsT2S)))
            {
                var path = System.Web.Hosting.HostingEnvironment.MapPath("~/File");

                _wavPlayer = new WaveStreamPlayback(path + String.Format("\\{0}.wav", _code));
            }
            _mediaSender = new PhoneCallAudioSender();
            _connector = new MediaConnector();
            // Prevents the termination of the application
            Console.ReadLine();

            return true;

        }

        public void RegisterAccount(SIPAccount account)
        {
            try
            {
                _phoneLine = _softphone.CreatePhoneLine(account);
                _phoneLine.RegistrationStateChanged += line_RegStateChanged;
                _softphone.RegisterPhoneLine(_phoneLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during SIP registration: " + ex);
                _log.ErrorFormat("Error during SIP registration: {0}", ex);
            }
        }

        public void line_RegStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            if (e.State == RegState.NotRegistered || e.State == RegState.Error)
                _log.Info("SIP Registration failed!");

            if (e.State == RegState.RegistrationSucceeded)
            {
                _log.Info("SIP Registration succeeded - Online!");
                CreateCall();
            }
        }

        public bool CreateCall()
        {
            try
            {
                var numberToDial = _phoneNo;
                _call = _softphone.CreateCallObject(_phoneLine, numberToDial);
                _call.CallStateChanged += call_CallStateChanged;
                _call.Start();
                _log.InfoFormat("Call created for {0} is:: {1}", _phoneNo, true);
                return true;
            }
            catch(Exception ex)
            {
                _log.ErrorFormat("Unable to create call for {0} for the reason:: {1}", _phoneNo, ex.StackTrace);
                return false;
            }
        }

        public void call_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            _log.InfoFormat("Call state for {0} is {1}.", _phoneNo ,e.State);

            if (e.State == CallState.Answered)
            {
                if (_speechProvider == int.Parse(StringEnum.GetStringValue(Text2SpeechProviderType.WindowsT2S)))
                    SetupWavPlayer();
                else if (_speechProvider == int.Parse(StringEnum.GetStringValue(Text2SpeechProviderType.GoogleT2S)))
                    SetupGoogleTextToSpeech();
                
                _log.InfoFormat("Call answered for: {0}", _phoneNo);
            }
            
            if(e.State == CallState.Cancelled)
            {
                _log.InfoFormat("Call for {0} is {1}", _phoneNo, e.State);
            }

            if(e.State == CallState.Completed)
            {
                _log.InfoFormat("Call for {0} is completed", _phoneNo);
            }
        }

        public void SetupDevices()
        {
                _connector.Connect(_microphone, _mediaSender);
                _connector.Connect(_mediaReceiver, _speaker);

                _mediaSender.AttachToCall(_call);
                _mediaReceiver.AttachToCall(_call);

                _microphone.Start();
                _speaker.Start();
        }

        public void SetupWavPlayer()
        {
                _connector.Connect(_wavPlayer, _mediaSender);

                _mediaSender.AttachToCall(_call);

                _wavPlayer.Start();

                HangUpTimer();

                _log.InfoFormat("The mp3 player is streaming for: {0}", _phoneNo);
        }

        public void SetupGoogleTextToSpeech()
        {
            try
            {
                _googleAPI = new GoogleTTS(GoogleLanguage.English_United_Kingdom);

                _mediaSender.AttachToCall(_call);
                _connector.Connect(_googleAPI, _mediaSender);

                RCStaging db = new RCStaging();

                var verificationDetails = db.RedCheetahVerifications
                    .Where(x => x.PhoneNo == _phoneNo.ToString())
                    .FirstOrDefault();

                _googleAPI.AddAndStartText(String.Format("Hello, You Verification Code is {0}, " +
                    "I repeat your verification code is {1}", verificationDetails.VerificationCode, verificationDetails.VerificationCode));
                HangUpTimer();
                _log.InfoFormat("Reading out text for {0}", _phoneNo);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Google text 2 speech not workiing for {0}, for the reason {1} ", _phoneNo, ex.Message);
            }

        }

        public void HangUpTimer()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (true)
            {
                var elasped = sw.ElapsedMilliseconds / 1000;
                if (elasped == int.Parse(ConfigurationManager.AppSettings["hangupTime"])) //Hangup call after 20 secs
                {
                    _call.HangUp();
                }
               
            }
        }
    }
}