using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using iMeeting.BAL;
using iMeeting.DAL;
using Newtonsoft.Json;
using Unity;

namespace Testing_iMeeting.Controllers
{
    public class VenueApiController : ApiController
    {
        private readonly IVenueRepository _VenueRepository;

        public VenueApiController(IVenueRepository repository)
        {
            this._VenueRepository = repository;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var a = _VenueRepository.GetVenue();
            return Ok(a);
        }
        [HttpPost]
        public IHttpActionResult Add(VenueModel model)
        {
            _VenueRepository.InsertVenue(model);
            return Ok(1);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int? Id)
        {
            _VenueRepository.DeleteVenue(Id);
            return Ok(1);
        }
        [HttpGet]
        public IHttpActionResult GetById(int? Id)
        {
            var a =_VenueRepository.GetById(Id);
            return Ok(a);
        }
        [HttpPut]
        public IHttpActionResult UpdateVenue(VenueModel venue)
        {
            _VenueRepository.UpdateVenue(venue);
            return Ok(1);
        }
        [HttpGet]
        public IHttpActionResult test()
        {
            List<string> UserList = new List<string>();
            UserList.Add("Mahesh Chand");
            UserList.Add("Praveen Kumar");
            UserList.Add("Raj Kumar");
            string sJSONResponse = JsonConvert.SerializeObject(UserList);

            return Ok(sJSONResponse);
        }



    }
}