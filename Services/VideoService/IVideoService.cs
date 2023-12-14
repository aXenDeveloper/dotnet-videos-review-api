using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_videos_review_api.Services.VideoService
{
    public interface IVideoService
    {
        List<Models.Video> GetVideos();

        Models.Video GetVideo(int id);

        Models.Video AddVideo(Models.Video video);
    }
}
