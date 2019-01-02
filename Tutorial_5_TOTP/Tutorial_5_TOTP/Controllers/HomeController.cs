using Google.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tutorial_5_TOTP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SetupAuthentication()
        {
            
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            var setupInfo = tfa.GenerateSetupCode("Tutorial_5_TOTP", "timoniori@gmail.com", "MY_SECRET_KEY", 300, 300);

            string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;
            string manualEntrySetupCode = setupInfo.ManualEntryKey;

            ViewBag.Message = "<h2>QR-Code:</h2> <br><br> <img src='" + qrCodeImageUrl + "' /> <br><br><h2>Token for manual entry</h2> <br>" + manualEntrySetupCode;

            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            var username = Request["username"];
            var password = Request["password"];
            var token = Request["token"];

            if (username == "test" && password == "test")
            {
                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                bool isCorrectPIN = tfa.ValidateTwoFactorPIN("MY_SECRET_KEY", token);

                if (isCorrectPIN)
                {
                    ViewBag.Message = "Login and Token Correct"; // and redirect for session handling
                }
                else
                {
                    ViewBag.Message = "Wrong Credentials and/or token";
                }
            }
            else
            {
                ViewBag.Message = "Wrong Credentials";
            }


            return View();
        }
    }
}