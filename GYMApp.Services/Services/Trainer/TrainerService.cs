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
        public Trainer CreateTrainer(TrainerDTO newTrainerDTO)
        {
            return new Trainer
            {
                FullName = newTrainerDTO.FullName,
                Comments = newTrainerDTO.Comments,
                Reviews = new List<Review> { reviewService.CreateReview(newTrainerDTO.ReviewsDTO[0]) }
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
           
            foreach(ReviewDTO review in newTrainerDTO.ReviewsDTO)
            {
                OldTrainer.Reviews.Add(reviewService.CreateReview(review));//не уверен что это будет правильно работать
            }
            context.SaveChanges();
        }

        public void DeleteTrainer(int TrainerID)
        {
            context.Trainers.Remove(context.Trainers.FirstOrDefault(_ => _.ID == TrainerID));

            context.SaveChanges();
        }

        public void AddNewReview(int TrainerID,ReviewDTO newRewievDTO)
        {
            context.Trainers.FirstOrDefault(_ => _.ID == TrainerID).Reviews.Add(reviewService.CreateReview(newRewievDTO));
        }
    }
}
