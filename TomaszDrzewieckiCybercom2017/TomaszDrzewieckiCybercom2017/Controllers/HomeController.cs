using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TomaszDrzewieckiCybercom2017.Controllers
{
    public class HomeController : Controller
    {

        
     Models.DBLibrary db = new Models.DBLibrary();
        // GET: Home
        public ActionResult Index()
        {
              //         db.TestDate();
            return View();
        }
       

        public ActionResult About()
        {
            ViewBag.Message = "Twoja Biblioteka";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Skontaktuj się ze mną.";
        
            return View();
        }
    }
}