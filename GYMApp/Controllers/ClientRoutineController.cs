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
    public class ClientRoutineController
    {
        private readonly IClientRoutineService clientRoutineService;

        public ClientRoutineController(IClientRoutineService clientRoutineService)
        {
            this.clientRoutineService = clientRoutineService;
        }

        [HttpPost]
        public void CreateClientRoutine([FromBody] ClientRoutineCreateDTO newClientRoutineDTO)
        {
            clientRoutineService.CreateClientRoutine(newClientRoutineDTO);

        }

        [HttpDelete("{ClientRoutineID}")]
        public void DeleteClientRoutine(int ClientRoutineID)
        {
            clientRoutineService.DeleteClientRoutine(ClientRoutineID);
        }

        [HttpGet("{ClientID}")]
        public List<ClientRoutineDTO> GetAllClientRoutine(int ClientID)
        {
            return clientRoutineService.GetAllClientRoutine(ClientID);
        }

    }
}
