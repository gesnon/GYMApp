using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class RoutineExerciseGetDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExerciseID { get; set; }
        public string Set { get; set; }
    }
}
