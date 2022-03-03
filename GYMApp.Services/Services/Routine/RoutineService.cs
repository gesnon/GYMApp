using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GYMApp.Services.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly ContextDB context;
        public RoutineService(ContextDB context)
        {
            this.context = context;
        }


        public void CreateRoutine(RoutineCreateDTO newRoutineDTO)
        {

            context.Routines.Add(new Routine
            {
                Name = newRoutineDTO.Name,
                Description = newRoutineDTO.Description,
                RoutineExercises = newRoutineDTO.Exercises
                .Select(_ => new RoutineExercise { ExerciseID = _ }).ToList()
            });
            context.SaveChanges();
        }
        public void UpdateRoutine(int RoutineID, RoutineUpdateDTO newRoutineDTO)
        {
            Routine OldRoutine = context.Routines.Include(_ => _.RoutineExercises).FirstOrDefault(_ => _.ID == RoutineID);

            if (OldRoutine == null)
            {
                throw new Exception("Программа не найдена");
            }

            OldRoutine.Name = newRoutineDTO.Name;
            OldRoutine.Description = newRoutineDTO.Description;

            foreach (RoutineExercise routineExercise in OldRoutine.RoutineExercises)
            {                
                    context.RoutineExercises.Remove(routineExercise);                              
            }
            OldRoutine.RoutineExercises = newRoutineDTO.Exercises

                .Select(_ => new RoutineExercise { ExerciseID = _ }).ToList();

            context.SaveChanges();
        }

        public void DeleteRoutine(int RoutineID)
        {
            if (context.Routines.FirstOrDefault(_ => _.ID == RoutineID) == null)
            {
                throw new Exception("Упражнение не найдёно");
            }

            context.Routines.Remove(context.Routines.FirstOrDefault(_ => _.ID == RoutineID));

            context.SaveChanges();
        }

    }
}