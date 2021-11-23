using GYMApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface ITrainerService
    {
        public GYMDB.Models.Trainer GetTrainer(int TrainerID);


    }
}
