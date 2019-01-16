using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_Exam.Models;
using ASP_Exam.ViewModels;

namespace ASP_Exam.Controllers
{
    public class LivresController : Controller
    {
        private BiblioContext db = new BiblioContext();

        private IDal dal = new Dal();
        public LivresController() : this(new Dal())
        { }
        private LivresController(IDal dalIoc)
        { dal = dalIoc; }

        // GET: Livres
        public ActionResult Index()
        {
            var livres = db.Livres.Include(l => l.Auteur).Include(l => l.Serie).Include(l => l.ID_LGenre).OrderBy(l => l.L_Titre);
            return View(livres.ToList());
        }

        // GET: Livres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livres livres = db.Livres.Find(id);
            if (livres == null)
            {
                return HttpNotFound();
            }
            return View(livres);
        }

        // GET: Livres/Create
        public ActionResult Create()
        {
            ViewBag.ID_Auteur = new SelectList(db.Auteurs, "ID_Auteur", "A_Nom");
            ViewBag.ID_Serie = new SelectList(db.Series, "ID_Serie", "S_Nom");
            ViewBag.ID_Genres = new SelectList(db.Genres, "ID_Genres", "G_Nom");
            return View();
        }

        // POST: Livres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Livres,L_Titre,L_Edition,ID_Auteur,ID_Serie,ID_LGenre")] Livres livres)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ID_Auteur = new SelectList(db.Auteurs, "ID_Auteur", "A_Nom", livres.ID_Auteur);
                ViewBag.ID_Serie = new SelectList(db.Series, "ID_Serie", "S_Nom", livres.ID_Serie);
                return View(livres);
            }                
            else
            {
                db.Livres.Add(livres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: Livres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livres livres = db.Livres.Find(id);
            if (livres == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Auteur = new SelectList(db.Auteurs, "ID_Auteur", "A_Nom", livres.ID_Auteur);
            ViewBag.ID_Serie = new SelectList(db.Series, "ID_Serie", "S_Nom", livres.ID_Serie);
            ViewBag.ID_Genres = new SelectList(db.Genres, "ID_Genres", "G_Nom");
            return View(livres);
        }

        // POST: Livres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Livres,L_Titre,L_Edition,ID_Auteur,ID_Serie,ID_LGenre")] Livres livres)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.ID_Auteur = new SelectList(db.Auteurs, "ID_Auteur", "A_Nom", livres.ID_Auteur);
                ViewBag.ID_Serie = new SelectList(db.Series, "ID_Serie", "S_Nom", livres.ID_Serie);
                return View(livres);
            }
            else
            {
                db.Entry(livres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

        // GET: Livres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livres livres = db.Livres.Find(id);
            if (livres == null)
            {
                return HttpNotFound();
            }
            return View(livres);
        }

        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livres livres = db.Livres.Find(id);
            db.Livres.Remove(livres);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET : Livres/Search/String
        public ActionResult Search(string search)
        {
            if (search == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RechercheVM RVM = new RechercheVM();
            RVM.LLivres = dal.SearchLivre(search);
            if (RVM.LLivres.Count() > 0)
                return View(RVM);
            return View();
        }

        // POST : Livres/Search/String
        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        public ActionResult a(int id)
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
