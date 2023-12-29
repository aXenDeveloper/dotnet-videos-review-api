using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp.PostgreSQL;
using dotnet_videos_review_api.Dtos.Videos;
using dotnet_videos_review_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_videos_review_api.Services.VideoService
{
    public class VideoService : IVideoService
    {
        private readonly VideosContext _context;

        public VideoService(VideosContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<GetVideoDto>> AddVideo(AddVideoDto video)
        {
            var dbCreateVideo = await _context
                .Videos
                .AddAsync(
                    new Video
                    {
                        Title = video.Title,
                        Description = video.Description,
                        Director = video.Director,
                        Review = video.Review
                    }
                );

            await _context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<GetVideoDto>();
            var getVideo = new GetVideoDto
            {
                Id = dbCreateVideo.Entity.Id,
                Title = dbCreateVideo.Entity.Title,
                Description = dbCreateVideo.Entity.Description,
                Director = dbCreateVideo.Entity.Director,
                Review = dbCreateVideo.Entity.Review
            };
            serviceResponse.Data = getVideo;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVideoDto>> GetVideo(int id)
        {
            var dbVideo = await _context.Videos.FirstOrDefaultAsync(video => video.Id == id);
            var serviceResponse = new ServiceResponse<GetVideoDto>();

            if (dbVideo != null)
            {
                var getVideoDto = new GetVideoDto
                {
                    Id = dbVideo.Id,
                    Title = dbVideo.Title,
                    Description = dbVideo.Description,
                    Director = dbVideo.Director,
                    Review = dbVideo.Review
                };
                serviceResponse.Data = getVideoDto;
                return serviceResponse;
            }

            throw new Exception("Video not found");
        }

        [HttpPost]
        public async Task<ServiceResponse<List<GetVideoDto>>> GetVideos()
        {
            var dbVideos = await _context.Videos.ToListAsync();
            var serviceResponse = new ServiceResponse<List<GetVideoDto>>();
            serviceResponse.Data = dbVideos
                .Select(
                    video =>
                        new GetVideoDto
                        {
                            Id = video.Id,
                            Title = video.Title,
                            Description = video.Description,
                            Director = video.Director,
                            Review = video.Review
                        }
                )
                .ToList();
            return serviceResponse;
        }

        [HttpPut]
        public async Task<ServiceResponse<GetVideoDto>> UpdateVideo(UpdateVideoDto video)
        {
            var dbVideo = await _context.Videos.FirstOrDefaultAsync(video => video.Id == video.Id);
            var serviceResponse = new ServiceResponse<GetVideoDto>();

            if (dbVideo != null)
            {
                dbVideo.Title = video.Title;
                dbVideo.Description = video.Description;
                dbVideo.Director = video.Director;
                dbVideo.Review = video.Review;

                _context.Videos.Update(dbVideo);
                await _context.SaveChangesAsync();

                var getVideoDto = new GetVideoDto
                {
                    Id = dbVideo.Id,
                    Title = dbVideo.Title,
                    Description = dbVideo.Description,
                    Director = dbVideo.Director,
                    Review = dbVideo.Review
                };
                serviceResponse.Data = getVideoDto;
                return serviceResponse;
            }

            throw new Exception("Video not found");
        }

        [HttpDelete]
        public async Task<ServiceResponse<List<GetVideoDto>>> DeleteVideo(int id)
        {
            var dbVideo = await _context.Videos.FirstOrDefaultAsync(video => video.Id == id);
            var serviceResponse = new ServiceResponse<List<GetVideoDto>>();

            if (dbVideo != null)
            {
                _context.Videos.Remove(dbVideo);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context
                    .Videos
                    .Select(
                        video =>
                            new GetVideoDto
                            {
                                Id = video.Id,
                                Title = video.Title,
                                Description = video.Description,
                                Director = video.Director,
                                Review = video.Review
                            }
                    )
                    .ToList();
                return serviceResponse;
            }

            throw new Exception("Video not found");
        }
    }
}
