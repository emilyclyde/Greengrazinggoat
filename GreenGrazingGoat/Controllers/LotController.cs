using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenGrazingGoat.DAL;
using GreenGrazingGoat.Models;

namespace GreenGrazingGoat.Controllers
{
    public class LotController : Controller
    {
        private GreenContext db = new GreenContext();

        // GET: Lot
        public ActionResult Index(string searchString )
        {
          var lots = from l in db.Lots
                      select l;

          if (!String.IsNullOrEmpty(searchString))
          {
            lots = lots.Where(l => l.LotAddress.Contains(searchString));
          }
          return View(lots.ToList());
            //return View(db.Lots.ToList());
        }

        // GET: Lot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = db.Lots.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            return View(lot);
        }

        // GET: Lot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LotID,GoatID,CustomerID,GoatName,CustomerFirst,CustomerLast,LotAddress,LotDescription")] Lot lot)
        {
            if (ModelState.IsValid)
            {
                db.Lots.Add(lot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lot);
        }

        // GET: Lot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = db.Lots.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            return View(lot);
        }

        // POST: Lot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LotID,GoatID,CustomerID,GoatName,CustomerFirst,CustomerLast,LotAddress,LotDescription")] Lot lot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lot);
        }

        // GET: Lot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = db.Lots.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            return View(lot);
        }

        // POST: Lot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lot lot = db.Lots.Find(id);
            db.Lots.Remove(lot);
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
