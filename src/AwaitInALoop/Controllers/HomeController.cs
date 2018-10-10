using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AwaitInTheLoop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AwaitInTheLoop()
        {
            for (var i = 0; i < 5; i++)
            {
                await StartWork();
            }

            return View("Awaited");
        }

        public async Task<IActionResult> AwaitOutsideLoop()
        {
            var tasks = new List<Task>();

            for (var i = 0; i < 5; i++)
            {
                tasks.Add(StartWork());
            }

            await Task.WhenAll(tasks);

            return View("Awaited");
        }

        private async Task StartWork()
        {
            await Task.Delay(1000);
        }
    }
}
