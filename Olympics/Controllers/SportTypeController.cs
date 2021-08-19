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
    public class SportTypeController : Controller
    {
        private SportTypeDBService _sportsDB;

        public SportTypeController(SportTypeDBService sportsDB)
        {
            _sportsDB = sportsDB;
        }


        // GET: SportTypeController
        public ActionResult Index()
        {
            return View(_sportsDB.AllSports());
        }

        // GET: SportTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SportTypeController/Create
        public ActionResult Create()
        {
            SportTypeModel newSport = new();
            return View(newSport);
        }

        // POST: SportTypeController/Create
        [HttpPost]
        public ActionResult Create(SportTypeModel sport)
        {
            _sportsDB.AddSport(sport);
            return RedirectToAction("Index");
        }

        // GET: SportTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SportTypeController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
                return View();
        }

        // GET: SportTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SportTypeController/Delete/5
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
