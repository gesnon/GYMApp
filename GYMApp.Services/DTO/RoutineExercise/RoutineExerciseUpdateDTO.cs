using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class RoutineExerciseUpdateDTO
    {
        public int RoutineExerciseID { get; set; }
        public int ExerciseID { get; set; }
        public int TrainingDayID { get; set; }
        public string  Set { get; set; }
    }
}
