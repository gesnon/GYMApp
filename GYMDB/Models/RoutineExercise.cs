using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDB.Models
{
    public class RoutineExercise
    {
        public int RoutineExerciseID { get; set; }
        public int TrainingDayID { get; set; }
        public int ExerciseID { get; set; }            
        public Exercise Exercise { get; set; }
    }
}
