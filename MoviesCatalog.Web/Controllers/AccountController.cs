using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MoviesCatalog.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult login()
        {
            if (WebSecurity.IsAuthenticated)
                return RedirectToAction("index", "Movies");
            return View();
        }

        [HttpPost]
        public ActionResult Authorization(string email, string password)
        {
            if (WebSecurity.Login(email, password, persistCookie: true))
            {
                return RedirectToAction("index", "Movies");
            }
            return View("login");
        }

    }
}
