using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayFootballApp.BusinessLogic.Interfaces;
using PlayFootballApp.BusinessLogic.Models.Pitch;

namespace PlayFootballApp.WWW.Controllers
{
    public class PitchController : Controller
    {
        private readonly IPitchService _pitchService;

        public PitchController(IPitchService pitchService)
        {
            _pitchService = pitchService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new PitchCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PitchCreateViewModel pitch)
        {
            //TODO: Consider validation for hours
            if(!ModelState.IsValid)
            {
                return View(pitch);
            }

            await _pitchService.AddPitch(pitch);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
    }
}