
using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using CrossBackEnd.GeoLocation.Application.Interfaces;

namespace CrossBackEnd.UI.Web.REST.API.Controllers.GeoLocation
{
    [Produces("application/json")]
    [Route("api/GeoLocation/Country")]
    public class CountryController : Controller
    {
        private readonly ICountryAppService _countryAppService;

        public CountryController(ICountryAppService countryAppService)
        {
            this._countryAppService = countryAppService;
        }

        // GET: api/GeoLocation/Country
        [HttpGet]
        public JsonResult Get()
        {
            return Json(this._countryAppService.GetAll());
        }

        // GET: api/GeoLocation/Country/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(Guid id)
        {
            return Json(this._countryAppService.SearchById(id));
        }

        // POST: api/GeoLocation/Country
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GeoLocation/Country/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}