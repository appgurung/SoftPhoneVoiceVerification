using System;
using System.IO;
using System.Speech.Synthesis;
using SoftPhone.Core.Interface;
using Ozeki.VoIP;
using Ozeki.Media;
using SoftPhone.Core.Helpers;
using SoftPhone.Core.Enumerations;

namespace SoftPhone.API.Services
{
    /// <summary>
    /// Text To Speech Service
    /// </summary>
    public class WindowsText2SpeechSvc : IWindowsText2SpeechSvc
    {
        static ISoftPhone _softphone;   // softphone object
        static IPhoneLine _phoneLine;   // phoneline object
        static IPhoneCall _call;
        static MediaConnector _connector;

        static GoogleTTS _googleAPI;
        static PhoneCallAudioSender _mediaSender;


        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(WindowsText2SpeechSvc));
        /// <summary>
        /// Generates text to speech using audio wav file using system seetings
        /// </summary>
        /// <param name="destionationNo"></param>
        /// <param name="verificationCode"></param>
        /// <returns></returns>
        public bool GenerateVoiceWithWindowsT2S(long destionationNo, long verificationCode)
        {
           try
            {
                using (var synth = new SpeechSynthesizer() { Volume = 100, Rate= -4})
                {
                    synth.SelectVoiceByHints(VoiceGender.Female);                
                    using (var stream = new MemoryStream())
                    { 
                        synth.SetOutputToWaveStream(stream);
                        synth.Speak(String.Format("Hello, your verification code is {0}, " +
                            "I repeat your verification code is {1}, " +
                            "I repeat your verification code is {2}", 
                            verificationCode, verificationCode, verificationCode));
                        byte[] bytes = stream.GetBuffer();
                        var path = System.Web.Hosting.HostingEnvironment.MapPath("~/File");
                        //_log.InfoFormat("Current path is {0}", path);
                        FileStream file = new FileStream(path + String.Format("\\{0}.wav", verificationCode.ToString()), FileMode.Create, FileAccess.Write);
                        stream.WriteTo(file);
                        file.Close();
                        stream.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                _log.ErrorFormat("Unable to generate voice file for {0} for the reason:: {1}", destionationNo, ex.Message);

                return false;
            }          

            return true;
        }


    }

    public class Text2SpeechSvc : IText2SpeechSvc
    {
        public bool GenerateVoice(long destionatioNo, long verificationCode, Enum speechProvider)
        {
            int provider = int.Parse(StringEnum.GetStringValue(speechProvider));
            WindowsText2SpeechSvc t2s = new WindowsText2SpeechSvc();
            
            if (provider == int.Parse(StringEnum.GetStringValue(Text2SpeechProviderType.WindowsT2S)))
                return t2s.GenerateVoiceWithWindowsT2S(destionatioNo, verificationCode);

            return true;

        }
    }
}

