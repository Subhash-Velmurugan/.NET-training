using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindAPI.Models
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
    }
}