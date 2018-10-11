using SoftPhone.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftPhone.Core.Enumerations
{
    public enum StatusType
    {
        [StringValue("SUCCESS")]
        SUCCESS = 0,
        [StringValue("PENDING")]
        PENDING = 1,
        [StringValue("FAILED")]
        FAILED  = 2
    }
}