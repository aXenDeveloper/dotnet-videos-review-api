using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_videos_review_api.Dtos.Videos;
using dotnet_videos_review_api.Models;

namespace dotnet_videos_review_api.Services.VideoService
{
    public interface IVideoService
    {
        Task<ServiceResponse<List<GetVideoDto>>> GetVideos();

        Task<ServiceResponse<GetVideoDto>> GetVideo(int id);

        Task<ServiceResponse<GetVideoDto>> AddVideo(AddVideoDto video);

        Task<ServiceResponse<GetVideoDto>> UpdateVideo(UpdateVideoDto video);

        Task<ServiceResponse<List<GetVideoDto>>> DeleteVideo(int id);
    }
}
