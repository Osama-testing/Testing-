using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iMeeting.DAL;

namespace Testing_iMeeting.Controllers
{
    public class VenueModelsController : Controller
    {
        private DB_Context db = new DB_Context();

        // GET: VenueModels
        public ActionResult Index()
        {
            return View(db.Venue.ToList());
        }

        // GET: VenueModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueModel venueModel = db.Venue.Find(id);
            if (venueModel == null)
            {
                return HttpNotFound();
            }
            return View(venueModel);
        }

        // GET: VenueModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VenueModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RoomName,Location,Limit,IsActive")] VenueModel venueModel)
        {
            if (ModelState.IsValid)
            {
                db.Venue.Add(venueModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venueModel);
        }

        // GET: VenueModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueModel venueModel = db.Venue.Find(id);
            if (venueModel == null)
            {
                return HttpNotFound();
            }
            return View(venueModel);
        }

        // POST: VenueModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RoomName,Location,Limit,IsActive")] VenueModel venueModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venueModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venueModel);
        }

        // GET: VenueModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueModel venueModel = db.Venue.Find(id);
            if (venueModel == null)
            {
                return HttpNotFound();
            }
            return View(venueModel);
        }

        // POST: VenueModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VenueModel venueModel = db.Venue.Find(id);
            db.Venue.Remove(venueModel);
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
