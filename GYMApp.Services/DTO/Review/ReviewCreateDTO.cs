using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class ReviewCreateDTO
    {
        public string Text { get; set; }        

        public int CreatorID { get; set; }

        public int TrainerID { get; set; }
    }
}
