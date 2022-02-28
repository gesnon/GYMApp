using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class TrainerProfileDTO
    {
        public string FullName { get; set; }
        public string Comments { get; set; }
        public List<ReviewDTO> ReviewsDTO { get; set; }

    }
}
