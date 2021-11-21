using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GYMApp.Services.Services.Trainer
{
    public class TrainerService: ITrainerService
    {
        private readonly ContextDB context;
        public GYMDB.Models.Trainer GetTrainer(int TrainerID)
        {
            return context.Trainers.FirstOrDefault(_ => _.ID == TrainerID);
        }
    }
}
