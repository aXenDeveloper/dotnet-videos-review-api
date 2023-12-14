using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_videos_review_api.Models;
using dotnet_videos_review_api.Services.VideoService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_videos_review_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public ActionResult<List<Video>> Get()
        {
            return Ok(_videoService.GetVideos());
        }

        [HttpGet("{id}")]
        public ActionResult<Video> GetSingle(int id)
        {
            return Ok(_videoService.GetVideo(id));
        }

        [HttpPost]
        public ActionResult<Video> Post(Video video)
        {
            return Ok(_videoService.AddVideo(video));
        }
    }
}
