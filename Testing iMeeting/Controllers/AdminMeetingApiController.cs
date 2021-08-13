using iMeeting.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

    }
}
