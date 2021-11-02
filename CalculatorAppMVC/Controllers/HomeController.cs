using CalculatorAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Calculator cal)
        {
            int a, b;
            a = cal.value1;
            b = cal.value2;
            if (cal.calculate == "Topla")
            {
                cal.result = a + b;
            }
            else if (cal.calculate == "Çıkar")
            {
                cal.result = a - b;
            }
            else if (cal.calculate == "Çarp")
            {
                cal.result = a * b;
            }
            else if (cal.calculate == "Böl")
            {
                cal.result = a / b;
            }


            TempData["result"] = cal.result;

            return View();
        }

        public IActionResult SonucSayfası()
        {
            var snc = TempData["result"];

            TempData.Keep();

            return View();
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
