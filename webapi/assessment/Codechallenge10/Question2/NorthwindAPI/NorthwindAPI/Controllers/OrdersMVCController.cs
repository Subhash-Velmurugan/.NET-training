using NorthwindAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NorthwindAPI.Controllers
{
    public class OrdersMVCController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<OrderViewModel> orders;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri("https://localhost:44378/");

                var response =
                    await client.GetAsync("api/orders/stevenorders");

                orders =
                    await response.Content
                        .ReadAsAsync<List<OrderViewModel>>();
            }

            return View(orders);
        }
    }
}