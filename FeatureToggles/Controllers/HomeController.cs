using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeatureToggles.Models;
using FeatureToggles.Toggles;
using Microsoft.Extensions.Options;

namespace FeatureToggles.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyFeatureToggle> _myFeatureToggle;

        public HomeController(IOptions<MyFeatureToggle> myFeatureToggle)
        {
            _myFeatureToggle = myFeatureToggle;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = _myFeatureToggle.Value.IsEnabled ? "Toggle is enabled" : "Toggle is disabled";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
