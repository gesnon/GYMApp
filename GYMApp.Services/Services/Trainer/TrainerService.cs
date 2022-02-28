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

        public TrainerService(ContextDB context, IReviewService reviewService)
        {
            this.context = context;
        }
        public Trainer GetTrainer(int TrainerID)
        {
            if (context.Trainers.FirstOrDefault(_ => _.ID == TrainerID) == null)
            {
                throw new Exception("Тренер не найдён");
            }

            return context.Trainers.FirstOrDefault(_ => _.ID == TrainerID);
        }

        public List<TrainerProfileDTO> GetTrainersDTO()
        {
            List<Trainer> trainers = context.Trainers.ToList();

            List<TrainerProfileDTO> trainerDTOs = new List<TrainerProfileDTO>();

            trainerDTOs = trainers.Select(
                _ => new TrainerProfileDTO
                {
                    FullName = _.FullName,
                    Comments = _.Comments,
                    ReviewsDTO = new List<ReviewDTO>()
                }).ToList();

            return trainerDTOs;

        }

        public void CreateTrainer(TrainerCreateDTO newTrainerDTO)
        {
            Trainer newTrainer = new Trainer
            {
                FullName = newTrainerDTO.FullName,
                Comments = newTrainerDTO.Comments,
            };
            context.Trainers.Add(newTrainer);
            context.SaveChanges();
        }
        public void UpdateTrainer(int TrainerID, TrainerCreateDTO newTrainerDTO)
        {
            Trainer OldTrainer = context.Trainers.FirstOrDefault(_ => _.ID == TrainerID);

            if (OldTrainer == null)
            {
                throw new Exception("Тренер не найдён");
            }

            if (newTrainerDTO.FullName != null)
            {
                OldTrainer.FullName = newTrainerDTO.FullName;
            }
            if (newTrainerDTO.Comments != null)
            {
                OldTrainer.Comments = newTrainerDTO.Comments;
            }

            context.SaveChanges();
        }

        public void DeleteTrainer(int TrainerID)
        {
            if (context.Trainers.FirstOrDefault(_ => _.ID == TrainerID) == null)
            {
                throw new Exception("Тренер не найдён");
            }

            context.Trainers.Remove(context.Trainers.FirstOrDefault(_ => _.ID == TrainerID));

            context.SaveChanges();
        }


    }
}
