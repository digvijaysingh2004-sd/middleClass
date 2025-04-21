using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddelClass.Models
{
    public class AdminloginModel
    {
        public int ID { get; set; }
        public string EmployeeId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> SubStart { get; set; }
        public Nullable<System.DateTime> SubSend { get; set; }
        public Nullable<System.DateTime> Cdate { get; set; }
        public Nullable<System.DateTime> Udate { get; set; }
        public string Cby { get; set; }
        public string Uby { get; set; }
    }
}