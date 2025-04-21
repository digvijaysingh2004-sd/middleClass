using MiddelClass.Builder;
using MiddelClass.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MiddelClass.Controllers
{
    public class AccountController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiddleClass"].ConnectionString;
        AccountBuilder AB = new AccountBuilder();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AdminLogin(AdminloginModel ad)
        {
            if (string.IsNullOrEmpty(ad.UserId) || string.IsNullOrEmpty(ad.Password))
            {
                TempData["MSG"] = "Oops! User ID and Password are required.";
                TempData.Keep("MSG");
                return RedirectToAction("Admin");
            }

            // Ensure method exists before using it
            var existingUser = AB.GetAdminLogin(ad.UserId);

            if (existingUser != null && existingUser.Password != ad.Password)
            {
                TempData["MSG"] = "Oops! Password is incorrect.";
                TempData.Keep("MSG");
                return RedirectToAction("Admin");
            }
            else if (existingUser == null)
            {
                TempData["MSG"] = "Oops! User ID does not exist.";
                TempData.Keep("MSG");
                return RedirectToAction("Admin");
            }

            var admin = AB.GetAdminLogin(ad.UserId);

            Session["empid"] = admin.EmployeeId;
            Session["usertype"] = admin.UserType;

            string fullName = BuildFullName(admin.FirstName, admin.MiddelName, admin.LastName);
            Session["name"] = !string.IsNullOrEmpty(fullName) ? fullName : "No-Name";

            return RedirectToAction("../Admin/Admin/Index");
        }

        private string BuildFullName(string firstName, string middleName, string lastName)
        {
            var nameParts = new List<string>();
            if (!string.IsNullOrEmpty(firstName)) nameParts.Add(firstName);
            if (!string.IsNullOrEmpty(middleName)) nameParts.Add(middleName);
            if (!string.IsNullOrEmpty(lastName)) nameParts.Add(lastName);

            return string.Join(" ", nameParts);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");  
        }
    }
}