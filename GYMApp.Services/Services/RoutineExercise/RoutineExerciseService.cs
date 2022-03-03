using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GYMApp.Services.Services
{
    public class RoutineExerciseService : IRoutineExerciseService
    {
        private readonly ContextDB context;
        public RoutineExerciseService(ContextDB context)
        {
            this.context = context;
        }

        public void CreateRoutineExercise(RoutineExerciseCreateDTO newRoutineExerciseDTO)
        {

            context.RoutineExercises.Add(new RoutineExercise
            {
            ExerciseID = newRoutineExerciseDTO.ExerciseID,
            RoutineID = newRoutineExerciseDTO.RoutineID,
            Exercise = context.Exercises
                .FirstOrDefault(_ => _.ID == newRoutineExerciseDTO.ExerciseID)
        });
            context.SaveChanges();
        }

        public void DeleteRoutineExercise(int RoutineExerciseID)
        {
            if (context.RoutineExercises.FirstOrDefault(_ => _.RoutineExerciseID == RoutineExerciseID) == null)
            {
                throw new Exception("Упражнение не найдёно");
            }

            context.RoutineExercises.Remove(context.RoutineExercises
                .FirstOrDefault(_ => _.RoutineExerciseID == RoutineExerciseID));

            context.SaveChanges();
        }

    }
}