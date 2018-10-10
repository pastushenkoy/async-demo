using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreDeadlock.Models;

namespace AspNetCoreDeadlock.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Deadlock()
        {
            StartWork().Wait();

            return View();
        }

        private async Task StartWork()
        {
            await Task.Delay(100);
        }
    }
}
