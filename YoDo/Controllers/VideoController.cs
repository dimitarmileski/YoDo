using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.YouTube.Samples;
using YoDo.Models;
using System.IO;

namespace YoDo.Controllers
{
    public class VideoController : Controller
    {

        //GET Upload
        public IActionResult Index() {
            return View();
        }


        //POST Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(string id, string videoPath, string videoTitle, string videoTags, string videoCategorySelected, string videoDesc)
        {
            System.Diagnostics.Debug.WriteLine("YouTube Data API: Upload Video");
            System.Diagnostics.Debug.WriteLine("==============================");


            videoPath = Path.GetFullPath(videoPath, @"C:\Users\User\Desktop");

            try
            {
                UploadVideo uploadVideo = new UploadVideo();
                uploadVideo.Run(videoPath, videoTitle, videoTags, videoCategorySelected, videoDesc).Wait();

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
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Convert(string fileName, string formatSelected){

            string inputName = fileName.Split(".")[0];
            string inputFormat = fileName.Split(".")[1];

            Video.Convert(inputName, inputFormat, inputName, formatSelected);

            return View();
        }

        //GET Delete
        public IActionResult Delete()
        {
            return View();
        }


        //GET Search 
        public IActionResult Search() {


            return View();
        }

        //POST Search
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Search() {


        //    return View();
        //}
    }
}