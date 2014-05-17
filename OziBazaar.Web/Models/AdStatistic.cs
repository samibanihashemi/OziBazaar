using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OziBazaar.Web.Models
{
    public class AdStatistic
    {
        public int AdId { get; set; }
        public int TotalHit { get; set; }
        public int TotalUnqiueHit { get; set; }

    }
}