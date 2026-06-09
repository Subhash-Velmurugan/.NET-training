using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NorthwindAPI.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        NorthwindEntities1 db = new NorthwindEntities1();

        [HttpGet]
        [Route("stevenorders")]
        public IHttpActionResult GetStevenOrders()
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == 5)
                           .Select(o => new
                           {
                               o.OrderID,
                               o.CustomerID,
                               o.OrderDate,
                               o.ShipName
                           })
                           .ToList();

            return Ok(orders);
        }

        [HttpGet]
        [Route("customersbycountry")]
        public IHttpActionResult CustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country)
                              .Select(c => new
                              {
                                  c.CustomerID,
                                  c.CompanyName,
                                  c.ContactName,
                                  c.City,
                                  c.Country
                              })
                              .ToList();

            return Ok(customers);
        }
    }
}
