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

        public void CreateTrainer(TrainerCreateDTO newTrainerDTO);
        
        public void UpdateTrainer(int ID, TrainerCreateDTO newTrainerDTO);

        public void DeleteTrainer(int TrainerID);

        public List<TrainerCreateDTO> GetTrainersDTO();

    }
}
