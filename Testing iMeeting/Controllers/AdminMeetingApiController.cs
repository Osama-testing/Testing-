using iMeeting.BAL;
using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Http;
using Testing_iMeeting.Email_Service;

namespace Testing_iMeeting.Controllers
{
    //  [Authorize(Roles = "Admin")]
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
        public IHttpActionResult CreateMeeting(string Title, string Agenda, string Notes, string Links, DateTime DateTime, int Duration, string Location, [FromBody]List<string> user)
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
            meeting.EndTime = DateTime.AddMinutes(Duration);
            meeting.Location = Location;
            meeting.IsActive = 1;
            meeting.Participants = Participants;
            adminMeetingRepository.CreateMeeting(meeting);
            ///////////////////////////////////////////////////////////////    
            int User_Id = int.Parse(_context.Meeting
                         .OrderByDescending(p => p.Id)
                         .Select(r => r.Id)
                         .First().ToString());
            //////////////////////////////////////////////////////////////
            StringBuilder Users = new StringBuilder();

            for (int i = 0; i < user.Count(); i++)
            {
                var _user = user.ElementAt(i);
                string userName = (from x in _contextApplication.Users
                                   where x.Id == _user
                                   select x.FullName).SingleOrDefault();
                Users.Append(userName);
                Users.AppendLine(" , ");
            }


            for (int i = 0; i < user.Count(); i++)
            {
                var _user = user.ElementAt(i);
                participants.Id = User_Id;
                participants.Status = 0;
                participants.Prticipants_Id = _user;
                adminMeetingRepository.CreateMeetingParticipants(participants);
                string userEmail = (from x in _contextApplication.Users
                                    where x.Id == _user
                                    select x.Email).SingleOrDefault();

                ///////////////////////////////////////////////////////////////
                EmailSender emailSender = new EmailSender();
                string body = emailSender.PopulateBody(Title, Agenda, Location, DateTime, Duration, Users.ToString());
                emailSender.SendHtmlFormattedEmail("Meeting Invitation ", body, userEmail);

            }
            return Ok(1);
        }
        [HttpGet]
        public IHttpActionResult CancelMeeting(int Id)
        {
            var a = adminMeetingRepository.GetById(Id);
            MeetingModel meetingModel = new MeetingModel();
            meetingModel.Id = a.Id;
            meetingModel.Title = a.Title;
            meetingModel.Agenda = a.Agenda;
            meetingModel.Notes = a.Notes;
            meetingModel.File = a.File;
            meetingModel.Links = a.Links;
            meetingModel.DateTime = a.DateTime;
            meetingModel.EndTime = a.EndTime;
            meetingModel.Duration = a.Duration;
            meetingModel.Location = a.Location;
            meetingModel.Participants = a.Participants;
            meetingModel.IsActive = 0;
            adminMeetingRepository.CancelMeeting(meetingModel);
            return Ok(1);
        }
        [HttpGet]
        public IHttpActionResult EndMeeting(int? Id)
        {
            DateTime now = DateTime.Now;
            now = now.AddMinutes(-1);
            var a = adminMeetingRepository.GetById(Id);
            MeetingModel meetingModel = new MeetingModel();
            meetingModel.Id = a.Id;
            meetingModel.Title = a.Title;
            meetingModel.Agenda = a.Agenda;
            meetingModel.Notes = a.Notes;
            meetingModel.File = a.File;
            meetingModel.Links = a.Links;
            meetingModel.DateTime = a.DateTime;
            meetingModel.EndTime = now;
            meetingModel.Duration = a.Duration;
            meetingModel.Location = a.Location;
            meetingModel.Participants = a.Participants;
            meetingModel.IsActive = 1;
            adminMeetingRepository.CancelMeeting(meetingModel);
            return Ok(1);
        }
        [HttpGet]
        public IHttpActionResult FetchParticipants(int? Id)
        {
            var a = _context.Meeting_Participants.Where(x => x.Id == Id).ToList();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < a.Count(); i++)
            {
                var _user = a.ElementAt(i);
                string Ids = _user.Prticipants_Id;
                var query = _contextApplication.Users.Where(m => m.Id == Ids).Select(m => m.FullName).FirstOrDefault();

                sb.Append(query);
                sb.Append(",");
            }
            return Ok(sb.ToString());
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
