﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Tutorial_5_Two_Factor.Controllers
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

        [HttpPost]
        public ActionResult Login()
        {
            var username = Request["username"];
            var password = Request["password"];

            if (username == "test" && password == "test")
            {
                var request = (HttpWebRequest)WebRequest.Create("https://rest.nexmo.com/sms/json");

                var secret = "TEST_SECRET";

                var postData = "api_key=544ee798";
                postData += "&api_secret=mAqcbhGihzr22630";
                postData += "&to=41794772279";
                postData += "&from=\"\"NEXMO\"\"";
                postData += "&text=\"" + secret + "\"";
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                ViewBag.Message = responseString;
            }
            else
            {
                ViewBag.Message = "Wrong Credentials";
            }
            return View();
        }

        [HttpPost]
        public void TokenLogin()
        {
            var token = Request["token"];

            if (token == "TEST_SECRET")
            {
                // -> "Token is correct";
            }
            else
            {
                 // -> "Token is wrong";
            }
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}