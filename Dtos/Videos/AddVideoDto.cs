using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_videos_review_api.Dtos.Videos
{
    public class AddVideoDto
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Director { get; set; } = "";
        public int Review { get; set; } = 0;
    }
}
