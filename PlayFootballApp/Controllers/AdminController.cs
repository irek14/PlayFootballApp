using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayFootballApp.BusinessLogic.Interfaces;

namespace PlayFootballApp.WWW.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPitchAvability(DateTime startDate, DateTime endDate)
        {
            bool result = _adminService.AddPitchAvability(startDate, endDate);

            if(result)
                return Json("Ok");

            return Json("Error");
        }
    }
}