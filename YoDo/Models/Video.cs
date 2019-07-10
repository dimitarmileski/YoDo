using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary;
namespace YoDo.Models
{
    public class Video
    {
        public static void SaveVideoToDisk(string link)
        {

            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                   Environment.OSVersion.Platform == PlatformID.MacOSX)
                 ? Environment.GetEnvironmentVariable("HOME")
                 : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(link); // gets a Video object with info about the video
            System.IO.File.WriteAllBytes(homePath + @"\Downloads\" + video.FullName, video.GetBytes());
        }
    }

   
}
