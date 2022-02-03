using GYMApp.Services.DTO;
using GYMApp.Services.Services;
using GYMDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReviewController
    {

        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        //public Review CreateReview(ReviewDTO newReviewDTO)
        //{
        //    return reviewService.CreateReview(newReviewDTO);
        //}

        //public void UpdateReview(int reviewID, ReviewDTO newReviewDTO)
        //{
        //    reviewService.UpdateReview(reviewID, newReviewDTO);
        //}

        //public void DeleteReview(int ReviewID)
        //{
        //    reviewService.DeleteReview(ReviewID);
        //}
    }
}
