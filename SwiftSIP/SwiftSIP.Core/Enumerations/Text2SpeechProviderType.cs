using SoftPhone.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftPhone.Core.Enumerations
{
    public enum Text2SpeechProviderType
    {
        [StringValue("2")]
        GoogleT2S = 2,
        [StringValue("1")]
        WindowsT2S  = 1,
    }
}