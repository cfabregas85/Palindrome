using reCAPTCHA.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carlos_Palindrome.Models;

namespace Carlos_Palindrome.Controllers
{
    public class HomeController : Controller
    {
        Value obj = new Value();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidator]
        public ActionResult Index(Value number)
        {
            if (ModelState.IsValid)
            {
                string aux = obj.Check_Palindrome(number._Number);
                ViewBag.message = aux;
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application Description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}