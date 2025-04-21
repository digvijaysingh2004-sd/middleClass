using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddelClass.Models
{
    public class SizeModel
    {
        public int ID { get; set; }
        public string SizeName { get; set; }
        public int SizeValue { get; set; }
        public int Status { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
        public string Cby { get; set; }
        public string Uby { get; set; }
    }
}