using MiddelClass.Builder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiddelClass.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiddleClass"].ConnectionString;
        CollectionBuilder CD = new CollectionBuilder();

        public ActionResult Index()
        {
            ViewBag.SummerEdit = CD.GetSummerEditPage();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}