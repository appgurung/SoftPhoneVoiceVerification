using SoftPhone.API.Services;
using SoftPhone.Core.DB.REDCHEETAH.STAGING;
using SoftPhone.Infrastructure.Services;
using System.IO;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Configuration;

namespace SwiftSIP.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string url = ConfigurationManager.AppSettings["uri"];

            System.Uri uri = new System.Uri(url);

            return Redirect(uri.ToString());
        }

      
    }
}
