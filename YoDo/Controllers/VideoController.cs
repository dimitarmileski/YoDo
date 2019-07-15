using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.YouTube.Samples;

namespace YoDo.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upload(string id)
        {
            System.Diagnostics.Debug.WriteLine("YouTube Data API: Upload Video");
            System.Diagnostics.Debug.WriteLine("==============================");

            string fullVideoPath = @"C:\Users\User\Desktop\" + "airplane.mp4";

            try
            {
                UploadVideo uploadVideo = new UploadVideo();
                uploadVideo.Run(fullVideoPath).Wait();

                if (uploadVideo.VideoId != null)
                    ViewBag.VideoId = uploadVideo.VideoId;
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    System.Diagnostics.Debug.WriteLine("Error: " + e.Message);
                }
            }

            System.Diagnostics.Debug.WriteLine("Press any key to continue...");

            return View();
        }


        //GET Convert
        public IActionResult Convert() {
            return View();
        }


        public IActionResult Delete()
        {
            return View();
        }
    }
}