using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YoDo.Models;


namespace YoDo.Controllers
{
    public class HomeController : Controller
    {
        private static bool success;

        public IActionResult Index()
        {
            ViewBag.successDownload = false;

            if (success) {
                ViewBag.successDownload = true;
            }
            return View();
        }

        public IActionResult DownloadVideo(string videoUrl)
        {
            if (videoUrl == null || videoUrl.Equals(""))
            {
                success = false;
                return RedirectToAction(nameof(Index));
            }



            Video.SaveVideoToDisk(videoUrl);
            success = true;

            return RedirectToAction(nameof(Index));
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
