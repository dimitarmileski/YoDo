using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YoDo.Models;
using VideoLibrary;

namespace YoDo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DownloadVideo(string videoUrl) {
            if (videoUrl == null || videoUrl.Equals("")) {
                return RedirectToAction(nameof(Index));
            }
            SaveVideoToDisk(videoUrl);
            return RedirectToAction(nameof(Index));
        }

        void SaveVideoToDisk(string link)
        {
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(link); // gets a Video object with info about the video
            System.IO.File.WriteAllBytes(@"C:\Users\User\Downloads\" + video.FullName, video.GetBytes());
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
