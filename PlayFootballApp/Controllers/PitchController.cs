using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayFootballApp.BusinessLogic.Models.Pitch;

namespace PlayFootballApp.WWW.Controllers
{
    public class PitchController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View(new PitchCreateViewModel());
        }
    }
}