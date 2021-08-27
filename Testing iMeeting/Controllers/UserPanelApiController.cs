using ClosedXML.Excel;
using iMeeting.BAL;
using iMeeting.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Testing_iMeeting.Controllers
{
    public class UserPanelApiController : ApiController
    {
        private readonly IUserpanelRespository _UserpanelRespository;
        private ApplicationDbContext _contextApplication;
        string currentLoginUserId;
        public UserPanelApiController(IUserpanelRespository repository)
        {
            //id = User.Identity.GetUserId();
            currentLoginUserId = RequestContext.Principal.Identity.GetUserId();
            this._UserpanelRespository = repository;
            _contextApplication = new ApplicationDbContext();

        }
        [HttpGet]
        public IHttpActionResult Get()
        {

            var a = _UserpanelRespository.GetMeeting();
            
            return Ok(a);
        }
        [HttpGet]
        public IHttpActionResult Filters(String Filter)
        {
            var a = _UserpanelRespository.FliterMeeting(Filter, currentLoginUserId);
            return Ok(a);
        }


        [HttpGet]
        public IHttpActionResult FilterByDate(string Filter)
        {
            var a = _UserpanelRespository.FilterDate(Filter);
            return Ok(a);
        }

        [HttpPost]
        public IHttpActionResult UpdateMeetingStatus(int Meeting_Id,int Status)
      {
                var a = _UserpanelRespository.GetById(Meeting_Id);
                Meeting_Participants participants = new Meeting_Participants();
                participants.Table_Id = a.Table_Id;
                participants.Prticipants_Id = currentLoginUserId;//-- fetch from login user
                participants.Status = Status;
                participants.Id = a.Id;
                _UserpanelRespository.UpdateMeetingStatus(participants);
                return Ok(1);
        }

    }
}
