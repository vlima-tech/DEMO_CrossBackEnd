
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CrossBackEnd.Shared.Kernel.Core.Enums;

namespace CrossBackEnd.UI.Web.REST.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Summary")]
    public class SummaryController : Controller
    {
        // GET: api/Summary
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Summary/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int apiVersion, ControllerName controllerName, string actionName)
        {
            string route = "api/";

            switch(controllerName)
            {
                case ControllerName.CountryController:

                    break;
            }

            return "value";
        }
        
        // POST: api/Summary
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Summary/5
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