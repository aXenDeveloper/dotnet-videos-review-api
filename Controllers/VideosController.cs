using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_videos_review_api.Dtos.Videos;
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
        public async Task<ActionResult<List<GetVideoDto>>> Get()
        {
            return Ok(await _videoService.GetVideos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetVideoDto>> GetSingle(int id)
        {
            return Ok(await _videoService.GetVideo(id));
        }

        [HttpPost]
        public async Task<ActionResult<GetVideoDto>> Post(AddVideoDto video)
        {
            return Ok(await _videoService.AddVideo(video));
        }

        [HttpPut]
        public async Task<ActionResult<GetVideoDto>> Put(UpdateVideoDto video)
        {
            var response = await _videoService.UpdateVideo(video);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GetVideoDto>>> Delete(int id)
        {
            var response = await _videoService.DeleteVideo(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
