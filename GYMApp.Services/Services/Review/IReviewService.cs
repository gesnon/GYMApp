using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IReviewService
    {

        public void UpdateReview(ReviewUpdateDTO newReviewDTO);
        public void DeleteReview(int ReviewID);
        public void AddNewReview(ReviewCreateDTO newReviewDTO);

    }
}
