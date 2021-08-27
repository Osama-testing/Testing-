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
        private DB_Context _context;
        private ApplicationDbContext _contextApplication;

        public AdminMeetingApiController(IAdminMeetingRepository repository, DB_Context dB_Context)
        {
            this.adminMeetingRepository = repository;
            this._context = dB_Context;
            _contextApplication = new ApplicationDbContext();
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
        public IHttpActionResult CreateMeeting(string Title,string Agenda,string Notes,string Links,DateTime DateTime,int Duration, string Location, [FromBody]List<string> user)
        {
            MeetingModel meeting = new MeetingModel();
            string Participants = string.Join(",", user);

            Meeting_Participants participants = new Meeting_Participants();
            meeting.Title = Title;
            meeting.Agenda = Agenda;      
            meeting.Notes = Notes;
            meeting.Links = Links;       
            meeting.DateTime = DateTime;
            meeting.Duration = Duration;
            meeting.Location = Location;
            meeting.IsActive = 1;
            meeting.Participants = Participants;
            adminMeetingRepository.CreateMeeting(meeting);
            ///////////////////////////////////////////////////////////////    
            int User_Id = int.Parse(_context.Meeting
                         .OrderByDescending(p => p.Id)
                         .Select(r => r.Id)
                         .First().ToString());       
            for (int i = 0; i < user.Count(); i++)
            {
                var _user = user.ElementAt(i);
                participants.Id = User_Id;
                participants.Status = 0;
                participants.Prticipants_Id = _user;               
                adminMeetingRepository.CreateMeetingParticipants(participants);
                //string userEmail = (from x in _contextApplication.Users
                //                    where x.Id == _user
                //                    select x.Email).SingleOrDefault();
            }             
            return Ok(1);
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
