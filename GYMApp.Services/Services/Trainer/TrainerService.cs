using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GYMApp.Services.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ContextDB context;

        public TrainerService(ContextDB context)
        {
            this.context = context;
        }
        public Trainer GetTrainer(int TrainerID)
        {
            return context.Trainers.FirstOrDefault(_ => _.ID == TrainerID);
        }
        public Trainer CreateTrainer(TrainerDTO newTrainerDTO)
        {
            return new Trainer
            {
                FullName = newTrainerDTO.FullName,
                Comments = newTrainerDTO.Comments,
                Reviews = newTrainerDTO.Reviews
            };
        }
        public void UpdateTrainer(int TrainewID, TrainerDTO newTrainerDTO)
        {
            Trainer OldTrainer = context.Trainers.FirstOrDefault(_ => _.ID == TrainewID);

            if (newTrainerDTO.FullName != null)
            {
                OldTrainer.FullName = newTrainerDTO.FullName;
            }
            if (newTrainerDTO.Comments != null)
            {
                OldTrainer.Comments = newTrainerDTO.Comments;
            }

            OldTrainer.Reviews = newTrainerDTO.Reviews; //не уверен что это будет правильно работать

        }

        public void AddNewReview(int TrainerID,string newRewiev)
        {
            context.Trainers.FirstOrDefault(_ => _.ID == TrainerID).Reviews.Add(newRewiev);
        }
    }
}
