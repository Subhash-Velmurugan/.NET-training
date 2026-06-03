using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codechallenge9; 

public class CodeController : Controller
{
    northwindEntities db = new northwindEntities();
    public ActionResult GermanCustomers()
    {
        var customers = db.Customers
                          .Where(c => c.Country == "Germany")
                          .ToList();

        return View(customers);
    }
    public ActionResult CustomerByOrder()
    {
        var customer = db.Orders
                         .Where(o => o.OrderID == 10248)
                         .Select(o => o.Customer)
                         .FirstOrDefault();

        return View(customer);
    }
}
