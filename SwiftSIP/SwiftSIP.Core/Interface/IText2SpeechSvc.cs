using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPhone.Core.Interface
{
    public interface IText2SpeechSvc
    {
       bool GenerateVoice(long destionatioNo, long verificationCode, Enum speechProvider);
    }
}
