using iMeeting.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Testing_iMeeting.Controllers
{
    public class HomeController : Controller
    {
        private DB_Context _context;

        // GET: Home
        public ActionResult Index()
        {


            // Part 1: create list of strings.
            List<string> animals = new List<string>();
            animals.Add("bird");
            animals.Add("bee");
            animals.Add("cat");

            // Part 2: use string.Join and pass the list as an argument.
            string result = string.Join(",", animals);
            Console.WriteLine($"RESULT: {result}");
            ///////
            string id;
            id = User.Identity.GetUserId();
          //  id = RequestContext.Principal.Identity.GetUserId();

            ViewBag.CustomerName = (string)TempData.Peek("Message");
            string test = System.Web.HttpContext.Current.User.Identity.GetUserId();
            //SqlConnection cn = new SqlConnection(@"Data Source=172.16.14.150;initial catalog=Osama_iMeeting1;persist security info=True;user id=qaserver;password=apple123!@#");
            //string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //SqlCommand cmd = new SqlCommand("Select * from AspNetUsers", cn);
            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(ds);
            //var jsonString = JsonConvert.SerializeObject(ds);

            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult Upload()
        { 
            //var filesToDelete = HttpContext.Current.Request.Params["filesToDelete"]; this is for API

            string userName = Request.Form["Agenda"];

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("/Files") + fileName); //File will be saved in application root
            }
            return Json("Uploaded " + Request.Files.Count + " files");
        }
    }


}
