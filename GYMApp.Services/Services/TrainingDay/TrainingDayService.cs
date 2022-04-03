using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GYMApp.Services.Services
{
    public class TrainingDayService : ITrainingDayService
    {
        private readonly ContextDB context;
        public TrainingDayService(ContextDB context)
        {
            this.context = context;
        }

        public void AddNewTrainingDay(TrainingDayCreateDTO newTrainingDayDTO)
        {
            context.TrainingDays.Add(new TrainingDay
            {
                Description = newTrainingDayDTO.Name,
                TrainingWeekID = newTrainingDayDTO.TrainingWeekID
            });
            context.SaveChanges();
        }

        public void UpdateTrainingDay(TrainingDayUpdateDTO newTrainingDayDTO)
        {
            TrainingDay OldTrainingDay = context.TrainingDays.FirstOrDefault(_ => _.ID == newTrainingDayDTO.ID);

            if (OldTrainingDay == null)
            {
                throw new Exception("Тренировочный день не найден");
            }

            OldTrainingDay.Description = newTrainingDayDTO.Name;
        }

        public void DeleteTrainingDay(int TrainingDayID)
        {
            if (context.TrainingDays.FirstOrDefault(_ => _.ID == TrainingDayID) == null)
            {
                throw new Exception("Тренитовочный день не найден");
            }
        
            context.TrainingDays.Remove(context.TrainingDays.FirstOrDefault(_ => _.ID == TrainingDayID));

            context.SaveChanges();
        }

    }
}
