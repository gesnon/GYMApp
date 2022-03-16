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
    public class TrainingDayController
    {
        private readonly ITrainingDayService trainingDayService;

        public TrainingDayController(ITrainingDayService trainingDayService)
        {
            this.trainingDayService = trainingDayService;
        }

        [HttpPost]
        public void CreateTrainingDay([FromBody] TrainingDayCreateDTO newTrainingDayDTO)
        {
            trainingDayService.AddNewTrainingDay(newTrainingDayDTO);
        }
        [HttpPut]
        public void UpdateTrainingDay([FromBody] TrainingDayUpdateDTO newTrainingDayDTO)
        {
            trainingDayService.UpdateTrainingDay(newTrainingDayDTO);
        }

        [HttpDelete("{RoutineID}")]
        public void DeleteTrainingDay(int TrainingDayID)
        {
            trainingDayService.DeleteTrainingDay(TrainingDayID);
        }
        
    }
}
