using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class TrainingDayDTO
    {
        public string Name { get; set; }

        public int ID { get; set; } 
        public  List<ExerciseGetDTO> Exercises { get; set; }


    }
}
