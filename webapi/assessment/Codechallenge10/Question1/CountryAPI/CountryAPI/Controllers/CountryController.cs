using CountryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CountryAPI.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> countries = new List<Country>()
    {
        new Country
        {
            ID = 1,
            CountryName = "India",
            Capital = "New Delhi"
        },
        new Country
        {
            ID = 2,
            CountryName = "Japan",
            Capital = "Tokyo"
        }
    };
        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            return Ok(countries);
        }
        [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }
        [HttpPost]
        public IHttpActionResult AddCountry(Country country)
        {
            countries.Add(country);

            return Ok(countries);
        }
        
        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, Country country)
        {
            var existingCountry = countries.FirstOrDefault(c => c.ID == id);

            if (existingCountry == null)
                return NotFound();

            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;

            return Ok("Country Updated Successfully");
        }
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);

            if (country == null)
                return NotFound();

            countries.Remove(country);

            return Ok("Country Deleted Successfully");
        }
    }
}
