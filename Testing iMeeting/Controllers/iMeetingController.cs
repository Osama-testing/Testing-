﻿using iMeeting.BAL;
using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testing_iMeeting.Controllers
{
    public class iMeetingController : Controller
    {
        DB_Context db = new DB_Context();

        // GET: iMeeting *VENUE CRUD BY ADMIN*
        [Authorize(Roles = "Admin")]
        public ActionResult Venue()
        {
            return View();
        }

        // GET: iMeeting *Meeting CRUD BY ADMIN*
        [Authorize(Roles = "Admin")]
        public ActionResult Meeting()
        {
            return View();
        }   
        
        // GET: iMeeting *MEETING LIST BY USER*
        [Authorize]
        public ActionResult MeetingList()
        {

            return View();
        }



    }
}