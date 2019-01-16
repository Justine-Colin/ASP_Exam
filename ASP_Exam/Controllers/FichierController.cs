using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Exam.Controllers
{
    public class FichierController : Controller
    {
        // GET: Fichier 
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UploadFichier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFichier(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string Nom = Path.GetFileName(file.FileName);
                    string Chemin = Path.Combine(Server.MapPath("~/FIchiersUpload"), Nom);
                    file.SaveAs(Chemin);
                }
                ViewBag.Message = "Le fichier a été ajouté au serveur !";
                return View();
            }
            catch
            {
                ViewBag.Message = "Le fichier n'as malheureusement pas pu être ajouté au serveur...";
                return View();
            }
        }
    }
}