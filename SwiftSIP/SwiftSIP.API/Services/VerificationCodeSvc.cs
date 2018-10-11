using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftPhone.Core.DB.REDCHEETAH.STAGING;
using SoftPhone.Core.Interface;
using SoftPhone.Core.Enumerations;
using SoftPhone.Core.Helpers;


namespace SoftPhone.API.Services
{
    public class VerificationCodeSvc : IVerificationCodeSvc
    {
        private readonly RCStaging _db;

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(VerificationCodeSvc));

        public VerificationCodeSvc(RCStaging db)
        {
            db = new RCStaging();
            _db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="verificationCode"></param>
        /// <param name="dialNo"></param>
        /// <returns></returns>
        public bool AddVerificationCode(long verificationCode, long dialNo)
        {
            try
            {
                RedCheetahVerification verification = new RedCheetahVerification()
                {
                    Guid = Guid.NewGuid().ToString(),
                    VerificationCode = verificationCode.ToString(),
                    PhoneNo = dialNo.ToString(),
                    TimeStamp = DateTime.Now.ToLongDateString() + "@" + DateTime.Now.ToLongTimeString(),
                    VerificationStatus = StringEnum.GetStringValue(StatusType.PENDING)
                };

                _db.RedCheetahVerifications.Add(verification);

                _db.Entry(verification).State = System.Data.Entity.EntityState.Added;

                _db.SaveChanges();

                _log.InfoFormat("Verification code for {0} is {1}", dialNo, verificationCode);

                return true;
            }
            catch(Exception ex)
            {
                _log.ErrorFormat("Unable to save verification details for reason:: {0}", ex.StackTrace);
                return false;
            }           
        }

        public bool AuthenticateVerificationCode(long verificationCode, long dialNo)
        {
            try
            {
                var verificationDetails = _db.RedCheetahVerifications
                    .Where(x=>x.PhoneNo == dialNo.ToString() && x.VerificationCode == verificationCode.ToString())
                    .FirstOrDefault();

                if (verificationDetails != null)
                {
                    verificationDetails.VerificationStatus = StringEnum.GetStringValue(StatusType.SUCCESS);

                    _db.Entry(verificationDetails).State = System.Data.Entity.EntityState.Modified;

                    _db.SaveChanges();
                    _log.InfoFormat("Verification status for {0} is {1}", dialNo, StringEnum.GetStringValue(StatusType.SUCCESS));
                }
                else
                {
                    verificationDetails.VerificationStatus = StringEnum.GetStringValue(StatusType.FAILED);

                    _db.Entry(verificationDetails).State = System.Data.Entity.EntityState.Modified;

                    _db.SaveChanges();

                    _log.InfoFormat("Verification status for {0} is {1}", dialNo, StringEnum.GetStringValue(StatusType.FAILED));

                    return false;
                }
            }
            catch(Exception ex)
            {
                _log.FatalFormat("Unable to authenticate for {0} for te reason:: {1}", dialNo, ex.Message);
                return false;
            }
            return true;
        }
    }
}