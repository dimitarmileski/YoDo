using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.YouTube.Samples;
using YoDo.Models;

namespace YoDo.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index() {
            return View();
        }

        //public IActionResult Upload()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Upload(string id, string videoTitle, string videoTags, string videoCategorySelected, string videoDesc)
        {
            System.Diagnostics.Debug.WriteLine("YouTube Data API: Upload Video");
            System.Diagnostics.Debug.WriteLine("==============================");

            string fullVideoPath = @"C:\Users\User\Desktop\" + "airplane.mp4";

            try
            {
                UploadVideo uploadVideo = new UploadVideo();
                uploadVideo.Run(fullVideoPath, videoTitle, videoTags, videoCategorySelected, videoDesc).Wait();

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

        //POST Convert
        [HttpPost]
        [ActionName("Convert")]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Convert(string fileName, string formatSelected){

            string inputName = fileName.Split(".")[0];
            string inputFormat = fileName.Split(".")[1];

            Video.Convert(inputName, inputFormat, inputName, formatSelected);

            return View();
        }


        public IActionResult Delete()
        {
            return View();
        }
    }
}