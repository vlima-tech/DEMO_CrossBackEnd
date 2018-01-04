
using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CrossBackEnd.GeoLocation.Application.Interfaces;
using CrossBackEnd.GeoLocation.Application.ViewModels;
using System.Collections.Generic;

namespace CrossBackEnd.UI.Web.REST.API.Controllers.v1._0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[area]/[controller]")]
    [Produces("application/json")]
    [Area("GeoLocation")]
    public class CountryController : Controller
    {
        private readonly ICountryAppService _countryAppService;

        public CountryController(ICountryAppService countryAppService)
        {
            this._countryAppService = countryAppService;
        }

        // GET: api/v1.0/GeoLocation/Country
        [HttpGet]
        public JsonResult Index()
        {
            List<CountryViewModel> countries = new List<CountryViewModel>();

            foreach (var item in this._countryAppService.GetAll().ReturnResult)
                countries.Add(item);

            //return Json(this._countryAppService.GetAll());
            return Json(countries);
        }

        // GET: api/GeoLocation/Country/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Details(Guid id)
        {
            return Json(this._countryAppService.SearchById(id));
        }

        // GET: Teste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teste/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Teste/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teste/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Teste/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teste/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}