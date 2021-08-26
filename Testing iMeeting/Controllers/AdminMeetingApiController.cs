using iMeeting.BAL;
using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Testing_iMeeting.Controllers
{
    public class AdminMeetingApiController : ApiController
    {
        private readonly IAdminMeetingRepository adminMeetingRepository;
        public AdminMeetingApiController(IAdminMeetingRepository repository)
        {
            this.adminMeetingRepository = repository;
        }
        [HttpGet]
        public IHttpActionResult MeetingListByAdmin(string Filter)
        {
            return Ok(adminMeetingRepository.GetMeeting(Filter));
        }
        [HttpGet]
        public IHttpActionResult MeetingFilter(string Filter)
        {
            return Ok(adminMeetingRepository.FilterDate(Filter));
        }
        [HttpPost]
        public IHttpActionResult CreateMeeting(string Title,string Agenda,string Notes,string Links,DateTime DateTime,int Duration, string Location, [FromBody]List<int> user)
        {
            MeetingModel meeting = new MeetingModel();
            meeting.Title = Title;
            meeting.Agenda = Agenda;
            meeting.Notes = Notes;
            meeting.Links = Links;
            meeting.DateTime = DateTime;
            meeting.Duration = Duration;
            meeting.Location = Location;
            meeting.IsActive = 1;

           // Meet_Participants_Models participants_Models = new Meet_Participants_Models();
            adminMeetingRepository.CreateMeeting(meeting);
           // adminMeetingRepository.CreateMeetingParticipants(participants_Models);

            return Ok(1);



            //SqlConnection cn = new SqlConnection();
            //SqlCommand cmd = new SqlCommand();
            //cn.ConnectionString = "ConnectionString";
            //List<string> str = new List<string>();
            //cmd.Connection = cn;
            //cmd.Connection.Open();
            //cmd.CommandText = "SELECT code FROM employee WHERE Left = 'Y'";
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    str.Add(dr.GetValue(0).ToString());
            //}

            //foreach (string p in str)
            //{
            //    Console.WriteLine(p);
            //}

        }
        #region CreateFile
        //  [HttpPost]
        //public IHttpActionResult CreateMeeting()
        //{
        //    MeetingModel meeting = new MeetingModel();
        //    meeting.Agenda = HttpContext.Current.Request.Params["Agenda"];
        //    meeting.Notes = HttpContext.Current.Request.Params["Notes"];
        //    meeting.File = HttpContext.Current.Request.Params["file"];
        //    meeting.Links = HttpContext.Current.Request.Params["Url"];
        //    meeting.Notes = HttpContext.Current.Request.Params["Notes"];

        //    HttpResponseMessage result = null;
        //    var httpRequest = HttpContext.Current.Request;
        //    if (httpRequest.Files.Count > 0)
        //    {
        //        var docfiles = new List<string>();
        //        foreach (string file in httpRequest.Files)
        //        {
        //            var postedFile = httpRequest.Files[file];
        //            var filePath = HttpContext.Current.Server.MapPath("/Files" + postedFile.FileName); // name with saving the file 
        //            postedFile.SaveAs(filePath);
        //            docfiles.Add(filePath);
        //        }
        //        result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
        //    }
        //    else
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //    return Ok(1);

        //}
        #endregion
    }
}
