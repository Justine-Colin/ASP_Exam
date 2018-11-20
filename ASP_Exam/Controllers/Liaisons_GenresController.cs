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
    public class Liaisons_GenresController : Controller
    {
        private BiblioContext db = new BiblioContext();

        // GET: Liaisons_Genres
        public ActionResult Index()
        {
            return View(db.Liaisons_Genres.ToList());
        }

        // GET: Liaisons_Genres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liaisons_Genres liaisons_Genres = db.Liaisons_Genres.Find(id);
            if (liaisons_Genres == null)
            {
                return HttpNotFound();
            }
            return View(liaisons_Genres);
        }

        // GET: Liaisons_Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Liaisons_Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Liaisons_Genres")] Liaisons_Genres liaisons_Genres)
        {
            if (ModelState.IsValid)
            {
                db.Liaisons_Genres.Add(liaisons_Genres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(liaisons_Genres);
        }

        // GET: Liaisons_Genres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liaisons_Genres liaisons_Genres = db.Liaisons_Genres.Find(id);
            if (liaisons_Genres == null)
            {
                return HttpNotFound();
            }
            return View(liaisons_Genres);
        }

        // POST: Liaisons_Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Liaisons_Genres")] Liaisons_Genres liaisons_Genres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liaisons_Genres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liaisons_Genres);
        }

        // GET: Liaisons_Genres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liaisons_Genres liaisons_Genres = db.Liaisons_Genres.Find(id);
            if (liaisons_Genres == null)
            {
                return HttpNotFound();
            }
            return View(liaisons_Genres);
        }

        // POST: Liaisons_Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Liaisons_Genres liaisons_Genres = db.Liaisons_Genres.Find(id);
            db.Liaisons_Genres.Remove(liaisons_Genres);
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
