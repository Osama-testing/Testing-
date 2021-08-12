using ClosedXML.Excel;
using iMeeting.BAL;
using iMeeting.DAL;
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
        readonly DB_Context _context;
        public UserPanelApiController(IUserpanelRespository repository, DB_Context dB_Context)
        {
            this._UserpanelRespository = repository;
            this._context = dB_Context;

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
            var a = _UserpanelRespository.FliterMeeting(Filter);
            return Ok(a);
        }


        [HttpGet]
        public IHttpActionResult FilterByDate(string Filter)
        {
            var a = _UserpanelRespository.FilterDate(Filter);
            return Ok(a);
        }

    }
}
