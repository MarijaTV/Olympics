using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.Models;
using Olympics.Services;

namespace Olympics.Controllers
{
    public class CountryController : Controller
    {
        // GET: CountryController
        private CountryDBService _countryDB;

        public CountryController(CountryDBService countryDB)
        {
            _countryDB = countryDB;
        }

        public ActionResult Index()
        {
            return View(_countryDB.AllCountries());
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            CountryModel newCountry = new();
            return View(newCountry);
        }

        // POST: CountryController/Create
        [HttpPost]
      
        public ActionResult Create(CountryModel countryModel)
        {
            _countryDB.AddCountry(countryModel);
            return RedirectToAction("Index");
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CountryController/Edit/5
        [HttpPost]
   
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CountryController/Delete/5
        [HttpPost]
     
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
