using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GYMApp.Services.Services
{
    public class TrainerService: ITrainerService
    {
        private readonly ContextDB context;

        public TrainerService (ContextDB context)
        {
            this.context = context;
        }
        public Trainer GetTrainer(int TrainerID)
        {
            return context.Trainers.FirstOrDefault(_ => _.ID == TrainerID);
        }
    }
}
