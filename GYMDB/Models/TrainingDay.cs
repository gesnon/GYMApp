﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDB.Models
{
    public class TrainingDay
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DayOfWeek Day { get; set; }
        public List<RoutineExercise> RoutineExercises { get; set; }
        public int TrainingWeekID { get; set; }
    }
}
