using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class TrainingDayCreateDTO
    {
        public string Name { get; set; }                     
        public int TrainingWeekID { get; set; }
        public List<RoutineExerciseCreateDTO> RoutineExercises { get; set; }
    }
}
