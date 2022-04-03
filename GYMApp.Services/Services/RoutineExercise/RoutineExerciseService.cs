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
                TrainingDayID = newRoutineExerciseDTO.TrainingDayID,
                Set = newRoutineExerciseDTO.Set,
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

        public void UpdateRoutineExercise(RoutineExerciseUpdateDTO newRoutineExerciseUpdateDTO)
        {
            RoutineExercise routineExercise = context.RoutineExercises.
                FirstOrDefault(_ => _.RoutineExerciseID == newRoutineExerciseUpdateDTO.RoutineExerciseID);

            if (routineExercise == null)
            {
                throw new Exception("RoutineExercise не найден");
            }
            routineExercise.Set = newRoutineExerciseUpdateDTO.Set;
            routineExercise.ExerciseID = newRoutineExerciseUpdateDTO.ExerciseID;

            context.SaveChanges();
        }
        public void AddRoutineExerciseToTrainingDay(int TrainingDayID, RoutineExerciseCreateDTO newRoutineExerciseCreateDTO)
        {
            TrainingDay trainingDay = context.TrainingDays.FirstOrDefault(_=>_.ID == TrainingDayID);
            Exercise exercise = context.Exercises.FirstOrDefault(_ => _.ID == newRoutineExerciseCreateDTO.ExerciseID);

            trainingDay.RoutineExercises.Add(new RoutineExercise
            {
                Exercise = exercise,
                ExerciseID = newRoutineExerciseCreateDTO.ExerciseID,
                TrainingDayID = newRoutineExerciseCreateDTO.TrainingDayID,
                Set = newRoutineExerciseCreateDTO.Set
            });

            context.SaveChanges();
        }
        
    }
}