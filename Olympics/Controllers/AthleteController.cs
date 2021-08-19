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
    public class AthleteController : Controller
    {
        // GET: AthleteController
        private ParticipantDBService _participants;

        public AthleteController(ParticipantDBService participants)
        {
            _participants = participants;
        }

        public ActionResult Index()
        {
            return View(_participants.All());
        }

        public ActionResult FilterList(ParticipantModel model)
        {
            var dbModel = _participants.All();
            
            if (model.SortFilter.filterByCountryId != 0)
            {
                dbModel.Athlete = dbModel.Athlete.Where(c => c.CountryId == model.SortFilter.filterByCountryId).ToList();
            }
            if (model.SortFilter.filterBySport != null)
            {

                dbModel.Athlete = dbModel.Athlete.Where(s => s.Sports.Contains(model.SortFilter.filterBySport)).
                    OrderBy(a => a.CountryName).ToList();

            }


           






            //if (model.SortFilter.orderBy != "")
            //{
            //    dbModel.Athlete = dbModel.Athlete.OrderByDescending(a => a.LastName == model.SortFilter.orderBy);
            //}

            return View("Index", dbModel);
        }

        //public AcceptedResult OrderBy (ParticipantModel participant)
        //{
        //    var dbModel = _participants.All();
            
        //    //dbModel.Athlete = dbModel.Athlete.OrderBy(a => a.FirstName).ToList();

        //    return View("Index");
        //}



        // GET: AthleteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AthleteController/Create
        public ActionResult Create()
        {
            
            return View(_participants.AddParticipant());
        }

        // POST: AthleteController/Create
        [HttpPost]
        public ActionResult Create(ParticipantModel participant)
        {
            _participants.SaveAthlete(participant);
             return RedirectToAction("Index");
        }

        // GET: AthleteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AthleteController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            { 
                return View();
            }
        }

        // GET: AthleteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AthleteController/Delete/5
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
