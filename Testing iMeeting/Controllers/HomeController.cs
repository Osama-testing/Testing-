using ClosedXML.Excel;
using iMeeting.BAL;
using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testing_iMeeting.Controllers
{
    public class HomeController : Controller
    {


    
        public ActionResult Index()
        {         
            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";
            return View();
        }
       // [Authorize]

        public ActionResult Userpanel()
        {
            return View();
        }



    }
}