using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_Exam.Models;

namespace ASP_Exam.Controllers
{
    public class AuteursController : Controller
    {
        private BiblioContext db = new BiblioContext();

        // GET: Auteurs
        public ActionResult Index()
        {
            return View(db.Auteurs.ToList());
        }

        // GET: Auteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteurs auteurs = db.Auteurs.Find(id);
            if (auteurs == null)
            {
                return HttpNotFound();
            }
            return View(auteurs);
        }

        // GET: Auteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Auteur,A_Nom,A_Prenom")] Auteurs auteurs)
        {
            if (ModelState.IsValid)
            {
                db.Auteurs.Add(auteurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auteurs);
        }

        // GET: Auteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteurs auteurs = db.Auteurs.Find(id);
            if (auteurs == null)
            {
                return HttpNotFound();
            }
            return View(auteurs);
        }

        // POST: Auteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Auteur,A_Nom,A_Prenom")] Auteurs auteurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auteurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auteurs);
        }

        // GET: Auteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteurs auteurs = db.Auteurs.Find(id);
            if (auteurs == null)
            {
                return HttpNotFound();
            }
            return View(auteurs);
        }

        // POST: Auteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auteurs auteurs = db.Auteurs.Find(id);
            db.Auteurs.Remove(auteurs);
            db.SaveChanges();
            return RedirectToAction("Index");
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
