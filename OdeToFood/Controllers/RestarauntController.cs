using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class RestarauntController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();

        //
        // GET: /Restaraunt/

        public ActionResult Index()
        {
            return View(db.Restaraunts.ToList());
        }

      

        //
        // GET: /Restaraunt/Create
        //[Authorize(Roles="Admin")]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Restaraunt/Create

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaraunt restaraunt)
        {
            if (ModelState.IsValid)
            {
                db.Restaraunts.Add(restaraunt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaraunt);
        }

        //
        // GET: /Restaraunt/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Restaraunt restaraunt = db.Restaraunts.Find(id);
            if (restaraunt == null)
            {
                return HttpNotFound();
            }
            return View(restaraunt);
        }

        //
        // POST: /Restaraunt/Edit/5

        [HttpPost]
        public ActionResult Edit(Restaraunt restaraunt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaraunt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaraunt);
        }

        //
        // GET: /Restaraunt/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Restaraunt restaraunt = db.Restaraunts.Find(id);
            if (restaraunt == null)
            {
                return HttpNotFound();
            }
            return View(restaraunt);
        }

        //
        // POST: /Restaraunt/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaraunt restaraunt = db.Restaraunts.Find(id);
            db.Restaraunts.Remove(restaraunt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}