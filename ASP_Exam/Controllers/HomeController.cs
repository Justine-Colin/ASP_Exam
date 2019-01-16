using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Exam.Controllers
{
    public class HomeController : Controller
    {
        //Erreur 404, redirection depuis webconfig ligne 23
        public ActionResult Erreur404()
        {
            return View();
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewData["date"] = DateTime.Now;
            
            return View();
        }

        public string Heure()
        {
            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);
            var str = ("Il est " + hm.ToShortTimeString());
            return str;
        }
    }
}