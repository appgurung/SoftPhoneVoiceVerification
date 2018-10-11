using SoftPhone.API.Services;
using SoftPhone.Core.DB.REDCHEETAH.STAGING;
using SoftPhone.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwiftSIP.API.Controllers
{
    /// <summary>
    /// Use this API to make call verification
    /// </summary>
    [RoutePrefix("api/v1/softphone")]
    public class SoftPhoneController : ApiController
    {

        /// <summary>
        /// This method accepts valid phoneNo is the the format e.g: 070XXXXXXXX
        /// </summary>
        /// <param name="dialNo">This is the phoneNo you want to verify</param>
        /// <returns>Returns Json response</returns>
        [AcceptVerbs("Get", "Post")]
        [Route("initiateVoiceCall")]
        public string InitiateVoiceCall(long dialNo)
        {
            if(dialNo.ToString().StartsWith("234")
                || dialNo.ToString().StartsWith("+234"))
            {
                dynamic retVal = new
                {
                    ResponseCode = "03",
                    ResponseMessage = "Invalid phone nuymber, please use the format: 070XXXXXXXX",
                    IsCallInitiated = false,
                    VerificationStatus = SoftPhone.Core.Helpers.StringEnum.GetStringValue(SoftPhone.Core.Enumerations.StatusType.FAILED)
                };

                return (Newtonsoft.Json.JsonConvert.SerializeObject(retVal));
            }

            var call = new VoiceVerificationSvc(new SoftPhoneSvc(), new Text2SpeechSvc(), new VerificationCodeSvc(new RCStaging()));

            if (call.VoiceCall(dialNo) == true) {

                dynamic retVal = new {
                    ResponseCode = "00",
                    ResponseMessage = "Call Initiation Successful",
                    IsCallInitiated = true,
                    VerificationStatus = SoftPhone.Core.Helpers.StringEnum.GetStringValue(SoftPhone.Core.Enumerations.StatusType.PENDING)
                };

                return (Newtonsoft.Json.JsonConvert.SerializeObject(retVal));
            }
            else
            {
                dynamic retVal = new
                {
                    ResponseCode = "02",
                    ResponseMessage = "Call Initiation Failed",
                    IsCallInitiated = false,
                    VerificationStatus = SoftPhone.Core.Helpers.StringEnum.GetStringValue(SoftPhone.Core.Enumerations.StatusType.FAILED)
                };

                return (Newtonsoft.Json.JsonConvert.SerializeObject(retVal));
            }
        }
        /// <summary>
        /// This method verifies verification code.
        /// </summary>
        /// <param name="dialNo">The phone number in the format 070XXXXXXXX</param>
        /// <param name="verificationCode">A 4 digit code to be verified</param>
        /// <returns>Returns Json response</returns>

        [AcceptVerbs("Get", "Post")]
        [Route("authenticateVerificationCode")]
        public string authenticateVerification(long dialNo, long verificationCode)
        {
            var verify = new VerificationCodeSvc(new RCStaging());

            if (verify.AuthenticateVerificationCode(verificationCode, dialNo) == true)
            {
                object retVal = new
                {
                    ResponseCode = "00",
                    ResponseMessage = "Success",
                    VerificationStatus = SoftPhone.Core.Helpers.StringEnum.GetStringValue(SoftPhone.Core.Enumerations.StatusType.SUCCESS)
                };

                return (Newtonsoft.Json.JsonConvert.SerializeObject(retVal));
            }
            else
            {
                object retVal = new
                {
                    ResponseCode = "02",
                    ResponseMessage = "Failure",
                    VerificationStatus = SoftPhone.Core.Helpers.StringEnum.GetStringValue(SoftPhone.Core.Enumerations.StatusType.FAILED)
                };

                return (Newtonsoft.Json.JsonConvert.SerializeObject(retVal));
            }
        }
    }
}
