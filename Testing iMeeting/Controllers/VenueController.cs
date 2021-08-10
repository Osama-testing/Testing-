using iMeeting.BAL;
using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testing_iMeeting.Controllers
{
    public class VenueController : Controller
    {
        readonly IVenueRepository _VenueRepository;
        public VenueController()
        {
        }
        public VenueController(IVenueRepository repository)
        {
            this._VenueRepository = repository;
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