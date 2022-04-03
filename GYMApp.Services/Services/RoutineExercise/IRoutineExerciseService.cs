using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IRoutineExerciseService
    {
        public void CreateRoutineExercise(RoutineExerciseCreateDTO newRoutineExerciseCreateDTO);
        public void DeleteRoutineExercise(int RoutineExerciseID);
        public void UpdateRoutineExercise(RoutineExerciseUpdateDTO newRoutineExerciseUpdateDTO);
        public void AddRoutineExerciseToTrainingDay(int TrainingDayID, RoutineExerciseCreateDTO newRoutineExerciseCreateDTO);
                
    }
}
