using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPhone.Core.Interface
{
    public interface IWindowsText2SpeechSvc
    {
        bool GenerateVoiceWithWindowsT2S(long destionatioNo, long verificationCode);

    }
}
