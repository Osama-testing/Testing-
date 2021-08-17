using iMeeting.BAL;
using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testing_iMeeting.Controllers
{
    public class VenueContoller : Controller
    {
        readonly DB_Context _context;
   
        readonly IVenueRepository _VenueRepository;
        public VenueContoller()
        {
        }
        public VenueContoller(IVenueRepository repository, DB_Context dB_Context)
        {
            this._VenueRepository = repository;
            this._context = dB_Context;
        }
        // GET: Venue
        [HttpGet]
        public ActionResult Index()
        {
            //var a = _VenueRepository.GetVenue();

            return View();
        }
        [HttpPost]
        public ActionResult Add(string Name, string Location, int Limit)
        {
            VenueModel model = new VenueModel();
            model.RoomName = Name;
            model.Location = Location;
            model.Limit = Limit;
            if (ModelState.IsValid)
            {
                _VenueRepository.InsertVenue(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                _VenueRepository.DeleteVenue(id);
            }
            return RedirectToAction("Index");
        }
        public ActionResult GetById(int id)
        {
           if (id != 0)
            {
               VenueModel venue= _VenueRepository.GetById(id);
                return View(venue);
            }
            return RedirectToAction("Index");

        }
        
    }
}