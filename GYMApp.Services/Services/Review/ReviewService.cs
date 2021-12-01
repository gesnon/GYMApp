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
        private readonly IClientService clientService;
        public ReviewService(ContextDB context, IClientService clientService)
        {
            this.context = context;
            this.clientService = clientService;
        }

        public Review CreateReview(ReviewDTO newReviewDTO)
        {
            return new Review
            {
                Text = newReviewDTO.Text,
                DateOfCreation = newReviewDTO.DateOfCreation,
                ReviewCreator = clientService.CreateClient(newReviewDTO.ReviewCreatorDTO)
            };
        }

        public void UpdateReview(int reviewID, ReviewDTO newReviewDTO)
        {
            Review OldRewiew = context.Reviews.FirstOrDefault(_ => _.ID == reviewID);

            if (newReviewDTO.Text != null)
            {
                OldRewiew.Text = newReviewDTO.Text;
            }
            if (newReviewDTO.DateOfCreation != null)
            {
                OldRewiew.DateOfCreation = newReviewDTO.DateOfCreation;
            }
            if (newReviewDTO.ReviewCreatorDTO != null)
            {
                OldRewiew.ReviewCreator = clientService.CreateClient(newReviewDTO.ReviewCreatorDTO);
            }

            context.SaveChanges();
        }

        public void DeleteReview(int ReviewID)
        {
            context.Reviews.Remove(context.Reviews.FirstOrDefault(_ => _.ID == ReviewID));

            context.SaveChanges();
        }

    }
}
