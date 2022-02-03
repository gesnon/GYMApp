using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface ITrainerService
    {
        public Trainer GetTrainer(int TrainerID);

        public void CreateTrainer(TrainerDTO newTrainerDTO);
        
        public void UpdateTrainer(int ID, TrainerDTO newTrainerDTO);

        public void AddNewReview(int ID,ReviewDTO newReviewDTO); // возможно надо перенести в ReviewService

        public void DeleteTrainer(int TrainerID);

        public List<TrainerDTO> GetTrainersDTO();

    }
}
