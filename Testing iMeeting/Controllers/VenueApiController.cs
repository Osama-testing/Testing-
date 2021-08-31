using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using iMeeting.BAL;
using iMeeting.DAL;
using Newtonsoft.Json;
using Unity;

namespace Testing_iMeeting.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VenueApiController : ApiController
    {
        #region Constructor
        private readonly IVenueRepository _VenueRepository;
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public VenueApiController(IVenueRepository repository)
        {
            this._VenueRepository = repository;
        }
        #endregion

        #region Venue-CRUD
        [HttpGet]
        public IHttpActionResult Get()
        {
            var a = _VenueRepository.GetVenue();
            return Ok(a);
        }
        [HttpPost]
        public IHttpActionResult Add(VenueModel model)
        {
            if (ModelState.IsValid)
            {
               _VenueRepository.InsertVenue(model);
                return Ok(1);
            }
            else
            {
                return Ok(0);
            }
        }
        [HttpDelete]
        public IHttpActionResult Delete(int? Id)
        {
            if (ModelState.IsValid)
            {
                _VenueRepository.DeleteVenue(Id);
                return Ok(1);
            }
            else
            {
                return Ok(0);
            }
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
            if (ModelState.IsValid)
            {
                _VenueRepository.UpdateVenue(venue);
                return Ok(1);
            }
            else
            {
                return Ok(0);
            }
        }
        #endregion


        [HttpGet]
        public IHttpActionResult GetUsersData()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT Id,FullName,Designation,Email from AspNetUsers";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);
            conn.Close();
            return Ok(dataTable);
        }
        [HttpDelete]
        public IHttpActionResult DellUsersData(string Id)
        {
            if (ModelState.IsValid)
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string sql = "DELETE FROM AspNetUsers WHERE Id ='" + Id + "';";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteReader();
                conn.Close();
                return Ok(1);
            }
            else
            {
                return Ok(0);
            }
        }




    }
}