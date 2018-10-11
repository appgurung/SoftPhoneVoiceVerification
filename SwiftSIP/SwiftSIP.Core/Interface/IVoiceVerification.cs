using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPhone.Core.Interface
{
    public interface IVoiceVerification
    {
        bool VoiceCall(long dialNo);
    }
}
