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
        public IActionResult Index()
        {
            return View(_pitchService.GetAllPitches());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new PitchCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PitchCreateViewModel pitch)
        {
            if(!ModelState.IsValid)
            {
                return View(pitch);
            }

            await _pitchService.AddPitch(pitch);

            return RedirectToAction("Index", "Pitch");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(_pitchService.GetPitchWithId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PitchCreateViewModel pitch)
        {
            if(!ModelState.IsValid)
            {
                return View(pitch);
            }

            await _pitchService.UpdatePitch(pitch);

            return RedirectToAction("Index", "Pitch");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _pitchService.DeletePitch(id);

            return RedirectToAction("Index", "Pitch");
        }

        [HttpPost]
        public IActionResult Details(Guid id)
        {
            return View(_pitchService.GetPitchWithId(id));
        }
    }
}