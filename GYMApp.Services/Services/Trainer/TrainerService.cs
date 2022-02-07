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
        private readonly IReviewService reviewService;

        public TrainerService(ContextDB context, IReviewService reviewService)
        {
            this.context = context;
            this.reviewService = reviewService;
        }
        public Trainer GetTrainer(int TrainerID)
        {
            return context.Trainers.FirstOrDefault(_ => _.ID == TrainerID);
        }

        public List<TrainerCreateDTO> GetTrainersDTO()
        {
            List<Trainer> trainers = context.Trainers.ToList();

            List<TrainerCreateDTO> trainerDTOs = new List<TrainerCreateDTO>();

            trainerDTOs = trainers.Select(
                _ => new TrainerCreateDTO
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
            context.Trainers.Remove(context.Trainers.FirstOrDefault(_ => _.ID == TrainerID));

            context.SaveChanges();
        }


    }
}
