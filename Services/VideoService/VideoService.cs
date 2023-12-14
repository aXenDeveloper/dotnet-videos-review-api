using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_videos_review_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_videos_review_api.Services.VideoService
{
    public class VideoService : IVideoService
    {
        private static List<Video> videos = new List<Video> { new Video(), new Video(), };

        public Video AddVideo(Video video)
        {
            videos.Add(video);
            return video;
        }

        public Video GetVideo(int id)
        {
            var video = videos.FirstOrDefault(video => video.Id == id);

            if (video != null)
            {
                return video;
            }

            throw new Exception("Video not found");
        }

        [HttpPost]
        public List<Video> GetVideos()
        {
            return videos;
        }
    }
}
