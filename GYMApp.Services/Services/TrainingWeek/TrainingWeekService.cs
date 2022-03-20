using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GYMApp.Services.Services
{
    public class TrainingWeekService : ITrainingWeekService
    {
        private readonly ContextDB context;
        public TrainingWeekService(ContextDB context)
        {
            this.context = context;
        }

        public void AddNewTrainingWeek(TrainingWeekCreateDTO newTrainingWeekCreateDTO)
        {
            context.TrainingWeeks.Add(new TrainingWeek
            {
                Name = newTrainingWeekCreateDTO.Name,
                RoutineID = newTrainingWeekCreateDTO.RoutineID,
                TrainingDays= newTrainingWeekCreateDTO.TrainingDaysCreateDTO.Select(_=> new TrainingDay 
                { Name=_.Name,
                  RoutineExercises=_.RoutineExercises.Select(_=> new RoutineExercise
                  {
                      ExerciseID=_.ExerciseID,
                      TrainingDayID=_.TrainingDayID
                  }).ToList(),
                   TrainingWeekID=_.TrainingWeekID                   
                }
                ).ToList()
            });
            context.SaveChanges();
        }

        public void UpdateTrainingWeek(TrainingWeekUpdateDTO newTrainingWeekDTO)
        {
            TrainingWeek OldTrainingWeek = context.TrainingWeeks.FirstOrDefault(_ => _.ID == newTrainingWeekDTO.ID);

            if (OldTrainingWeek == null)
            {
                throw new Exception("Тренировочная неделя не найдена");
            }

            OldTrainingWeek.Name = newTrainingWeekDTO.Name;
        }

        public void DeleteTrainingWeek(int TrainingWeekID)
        {
            if (context.TrainingWeeks.FirstOrDefault(_ => _.ID == TrainingWeekID) == null)
            {
                throw new Exception("Тренировочная неделя не найдена");
            }
        
            context.TrainingWeeks.Remove(context.TrainingWeeks.FirstOrDefault(_ => _.ID == TrainingWeekID));

            context.SaveChanges();
        }

    }
}
