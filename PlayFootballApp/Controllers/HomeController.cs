using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayFootballApp.BusinessLogic.Interfaces;
using PlayFootballApp.BusinessLogic.Models.Home;
using PlayFootballApp.Models;

namespace PlayFootballApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPitchService _pitchService;
        public HomeController(IPitchService pitchService)
        {
            _pitchService = pitchService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SearchPitchViewModel() {StartDate = DateTime.Now, EndDate = DateTime.Now });
        }

        [HttpPost]
        public IActionResult Index(SearchPitchViewModel search)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("FindEvents", "Home", search);
            }

            return View(search);
        }

        [Authorize]
        public IActionResult FindEvents(SearchPitchViewModel search)
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            int distanceInMeters = int.MaxValue;

            if(search.LocalisationX != 0 && search.LocalisationY != 0)
            {
                search.Distance = search.Distance.Replace(".", ",");
                double distanceInKm = double.Parse(search.Distance);
                distanceInMeters = (int)(distanceInKm * 1000);
            }

            var result = _pitchService.GetPitchAvability(userId, search.StartDate, search.EndDate, search.SpotNumber, search.LocalisationX, search.LocalisationY, distanceInMeters);
            result.Search = search;

            return View(result);
        }

        [HttpPost]
        public IActionResult Reserve(Guid id, int spots)
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            bool result = _pitchService.ReserveSpot(id, spots, userId);

            if(result)
                return Json("Ok");

            return Json("Error");
        }

        [HttpPost]
        public IActionResult Resign(Guid id)
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            bool result = _pitchService.ResignSpot(id, userId);

            if (result)
                return Json("Ok");

            return Json("Error");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
