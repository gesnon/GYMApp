using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class GetRoutineDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TrainingWeekDTO> TrainingWeeksDTO { get; set; }
    }
}
