using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class ReviewDTO
    {
        public string Text { get; set; }

        public DateTime DateOfCreation { get; set; }

        public ClientDTO ReviewCreatorDTO { get; set; }
    }
}
