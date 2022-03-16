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
    public class TrainingWeekController
    {
        private readonly ITrainingWeekService trainingWeekService;

        public TrainingWeekController(ITrainingWeekService trainingWeekService)
        {
            this.trainingWeekService = trainingWeekService;
        }

        [HttpPost]
        public void CreateTrainingWeek([FromBody] TrainingWeekCreateDTO newTrainingWeekDTO)
        {
            trainingWeekService.AddNewTrainingWeek(newTrainingWeekDTO);
        }
        [HttpPut]
        public void UpdateTrainingWeek([FromBody] TrainingWeekUpdateDTO newTrainingWeekDTO)
        {
            trainingWeekService.UpdateTrainingWeek(newTrainingWeekDTO);
        }

        [HttpDelete("{RoutineID}")]
        public void DeleteTrainingDay(int TrainingDayID)
        {
            trainingWeekService.DeleteTrainingWeek(TrainingDayID);
        }
        
    }
}
