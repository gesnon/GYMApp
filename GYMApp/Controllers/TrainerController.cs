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
    [Route("API/Trainer")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            this.trainerService = trainerService;
        }

        [HttpGet("{TrainerID}")]
        public Trainer GetTrainer(int TrainerID)
        {
            return trainerService.GetTrainer(TrainerID);
        }
        [HttpPost]
        public void CreateTrainer([FromBody] TrainerDTO newTrainerDTO)
        {
            trainerService.CreateTrainer(newTrainerDTO);
        }
        // хз какой атрибут писать
        public List<ClientDTO> GetAllTrainerClients(int TrainerID)
        {
            return trainerService.GetAllTrainerClients(TrainerID);
        }

        [HttpPut("{TrainerID}")]
        public void UpdateTrainer(int TrainerID, [FromBody] TrainerDTO newTrainerDTO)
        {
            trainerService.UpdateTrainer(TrainerID, newTrainerDTO);
        }
        [HttpDelete("{TrainerID}")]
        public void DeleteTrainer(int TrainerID)
        {
            trainerService.DeleteTrainer(TrainerID);
        }

        [HttpGet]
        public List<TrainerDTO> GetTrainersDTO()
        {
            return trainerService.GetTrainersDTO();
        }

    }
}
