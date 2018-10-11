using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPhone.Core.Interface
{
    public interface IVerificationCodeSvc
    {
        bool AddVerificationCode(long verificationCode, long dialNo);
        bool AuthenticateVerificationCode(long verificationCode, long dialNo);
    }
}
