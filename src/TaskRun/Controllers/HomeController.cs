using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskRun.Models;

namespace TaskRun.Controllers
{
    public class HomeController : Controller
    {
        private StringBuilder _sb = new StringBuilder();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TaskRun()
        {
            WriteThreadId("Before");

            await Task.Run(() => 
            {
                WriteThreadId("Inside");
                Thread.Sleep(2000);
            });

            WriteThreadId("After");

            ViewBag.Message = _sb.ToString();

            return View();
        }

        private void WriteThreadId(string stage)
        {
            _sb.AppendLine($"{stage} Task.Run(): {Thread.CurrentThread.ManagedThreadId}</br>");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
