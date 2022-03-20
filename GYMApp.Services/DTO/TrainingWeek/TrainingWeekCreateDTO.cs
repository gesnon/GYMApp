using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class TrainingWeekCreateDTO
    {
        public string Name { get; set; }                     
        public int RoutineID { get; set; }
        public List<TrainingDayCreateDTO> TrainingDaysCreateDTO { get; set; }
    }
}
