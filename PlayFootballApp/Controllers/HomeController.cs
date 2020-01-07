using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayFootballApp.BusinessLogic.Interfaces;
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

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult FindEvents()
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return View(_pitchService.GetPitchAvability(userId));
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
