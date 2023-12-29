using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_videos_review_api.Models;

namespace dotnet_videos_review_api.Dtos.Videos
{
    public class GetVideoDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Director { get; set; } = "";
        public int Review { get; set; } = 0;
    }
}
