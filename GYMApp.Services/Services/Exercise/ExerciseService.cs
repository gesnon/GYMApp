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
    public class ExerciseService : IExerciseService
    {
        private readonly ContextDB context;


        public ExerciseService(ContextDB context)
        {
            this.context = context;
        }

        public void CreateExercise(ExerciseCreateDTO newExerciseCreateDTO)
        {
            context.Exercises.Add(new Exercise
            {
                Name = newExerciseCreateDTO.Name,
                Description = newExerciseCreateDTO.Description
            });
            context.SaveChanges();
        }

        public void UpdateExercise(int ExerciseID, ExerciseUpdateDTO newExerciseUpdateDTO)
        {
            Exercise OldExercise = context.Exercises.FirstOrDefault(_ => _.ID == ExerciseID);

            if (OldExercise == null)
            {
                throw new Exception("Упражнение не найдёно");
            }

            OldExercise.Name = newExerciseUpdateDTO.Name;
            OldExercise.Description = newExerciseUpdateDTO.Description;

            context.SaveChanges();
        }
        public void DeleteExercise(int ExerciseID)
        {
            if (context.Exercises.FirstOrDefault(_ => _.ID == ExerciseID) == null)
            {
                throw new Exception("Упражнение не найдёно");
            }

            context.Exercises.Remove(context.Exercises.FirstOrDefault(_ => _.ID == ExerciseID));

            context.SaveChanges();
        }

        public List<ExerciseGetDTO> GetExercisesByName(string name)
        {
            var query = context.Exercises.AsQueryable();
            
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(_ => _.Name.Contains(name));
            }

            List<ExerciseGetDTO> list = query.Select(_ => new ExerciseGetDTO
            {
                Name = _.Name,
                Description = _.Description,
                ExerciseID = _.ID
            }).ToList();

            return list;


        }
        public ExerciseGetDTO GetExercise(int ExerciseID)
        {
            Exercise exercise = context.Exercises.FirstOrDefault(_ => _.ID == ExerciseID);
            if (exercise == null)
            {
                throw new Exception("Упражнение не найдено");
            }

            return new ExerciseGetDTO { Name=exercise.Name, Description=exercise.Description };
        }
    }
}
