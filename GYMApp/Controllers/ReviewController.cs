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

        [HttpPost]
        public void AddNewReview([FromBody] ReviewCreateDTO newReviewDTO)
        {
            reviewService.AddNewReview(newReviewDTO);
        }

        [HttpPut]
        public void UpdateReview([FromBody] ReviewUpdateDTO newReviewDTO)
        {
            reviewService.UpdateReview(newReviewDTO);
        }

        [HttpDelete("{ReviewID}")]
        public void DeleteReview(int ReviewID)
        {
            reviewService.DeleteReview(ReviewID);
        }
    }
}
