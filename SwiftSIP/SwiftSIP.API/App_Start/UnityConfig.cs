using System;
using Unity;
using SoftPhone.Core.Interface;
using SoftPhone.Infrastructure.Services;
using SoftPhone.API.Services;
using System.Web.Mvc;
using Unity.AspNet.Mvc;

namespace SoftPhone.API
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IWindowsText2SpeechSvc, WindowsText2SpeechSvc>();
            container.RegisterType<ISoftPhoneSvc, SoftPhoneSvc>();
            container.RegisterType<IText2SpeechSvc, Text2SpeechSvc>();
            container.RegisterType<IVerificationCodeSvc, VerificationCodeSvc>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}