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
    public class TrainerController
    {
        private readonly ITrainerService trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            this.trainerService = trainerService;
        }

        public Trainer GetTrainer(int TrainerID)
        {
            return trainerService.GetTrainer(TrainerID);
        }

        public Trainer CreateTrainer(TrainerDTO newTrainerDTO)
        {
            return trainerService.CreateTrainer(newTrainerDTO);
        }

        public void UpdateTrainer(int TrainewID, TrainerDTO newTrainerDTO)
        {
            trainerService.UpdateTrainer(TrainewID, newTrainerDTO);
        }

        public void DeleteTrainer(int TrainerID)
        {
            trainerService.DeleteTrainer(TrainerID);
        }

        public void AddNewReview(int TrainerID, ReviewDTO newRewievDTO)
        {
            trainerService.AddNewReview(TrainerID, newRewievDTO);
        }
    }
}
