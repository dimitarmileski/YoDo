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

        public async Task<IActionResult> Upload()
        {
            System.Diagnostics.Debug.WriteLine("YouTube Data API: Upload Video");
            System.Diagnostics.Debug.WriteLine("==============================");

            try
            {
                new UploadVideo().Run().Wait();
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

        public IActionResult Delete() {
            return View();
        }
    }
}