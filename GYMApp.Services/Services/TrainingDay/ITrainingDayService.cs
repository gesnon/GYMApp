using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface ITrainingDayService
    {

        public void UpdateTrainingDay(TrainingDayUpdateDTO newTrainingDayDTO);
        public void DeleteTrainingDay(int TrainingDayID);
        public void AddNewTrainingDay(TrainingDayCreateDTO newTrainingDayDTO);

    }
}
