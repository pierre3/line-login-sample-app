using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using LineLoginSampleApp.Models;

namespace LineLoginSampleApp.Controllers
{
    public class HomeController : Controller
    {
        private LineSettings lineSettings;
        public HomeController(IOptions<LineSettings> options)
        {
            lineSettings = options.Value;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PushMessage(string pushMessage)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;

            using (var line = new Line.Messaging.LineMessagingClient(lineSettings.MessagingAccessToken))
            {
                await line.PushMessageAsync(userId, pushMessage);
            }
            return View();
        }
    }
}
