using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface ITrainingWeekService
    {

        public void UpdateTrainingWeek(TrainingWeekUpdateDTO newTrainingWeekDTO);
        public void DeleteTrainingWeek(int TrainingWeekID);
        public void AddNewTrainingWeek(TrainingWeekCreateDTO newTrainingWeekDTO);

    }
}
