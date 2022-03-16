using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class TrainingWeekDTO
    {
        public string Name { get; set; }
        public int ID { get; set; } 
        public List<TrainingDayDTO> TrainingDaysDTO { get; set; }

    }
}
