using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddelClass.Models
{
    public class ColorModel
    {
        public int ID { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public int Status { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
        public string Cby { get; set; }
        public string Uby { get; set; }
    }
}