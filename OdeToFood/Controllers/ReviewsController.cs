using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {

        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index([Bind(Prefix="id")] int restarauntId)
        {
            var restaraunt = _db.Restaraunts.Find(restarauntId);
            if (restaraunt != null)
            {
                return View(restaraunt);
            }
            return HttpNotFound();


        }

        [HttpGet]
        public ActionResult Create(int restarauntId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestarauntReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestarauntId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }
        [HttpPost]
        //public ActionResult Edit([Bind(Exclude="ReviewerName")]RestarauntReview review)
        public ActionResult Edit(RestarauntReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified; //this is not new, so dont insert, only update existing
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestarauntId });
            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
