using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GYMApp.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ContextDB context;
        public ReviewService(ContextDB context, IClientService clientService)
        {
            this.context = context;
        }

        public void AddNewReview(ReviewCreateDTO newReviewDTO)
        {
            context.Reviews.Add(new Review
            {
                ReviewCreatorID = newReviewDTO.CreatorID,
                Text = newReviewDTO.Text,
                TrainerID = newReviewDTO.TrainerID
            });
            context.SaveChanges();
        }

        public void UpdateReview(ReviewUpdateDTO newReviewDTO)
        {
            Review OldReview = context.Reviews.FirstOrDefault(_ => _.ID == newReviewDTO.ReviewID);
            OldReview.Text = newReviewDTO.Text;
            OldReview.DateOfCreation = DateTime.Now;
            context.SaveChanges();
        }

        public void DeleteReview(int ReviewID)
        {
            context.Reviews.Remove(context.Reviews.FirstOrDefault(_ => _.ID == ReviewID));

            context.SaveChanges();
        }

    }
}
