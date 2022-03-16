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
    public class RoutineController
    {
        private readonly IRoutineService routineService;

        public RoutineController(IRoutineService routineService)
        {
            this.routineService = routineService;
        }

        [HttpPost]
        public void CreateRoutine([FromBody] RoutineCreateDTO newRoutineDTO)
        {
            routineService.CreateRoutine(newRoutineDTO);

        }
        [HttpPut]
        public void UpdateRoutine(int RoutineID, [FromBody] RoutineUpdateDTO newRoutineDTO)
        {
            routineService.UpdateRoutine(RoutineID, newRoutineDTO);
        }

        [HttpDelete("{RoutineID}")]
        public void DeleteMeasurement(int RoutineID)
        {
            routineService.DeleteRoutine(RoutineID);
        }

        [HttpGet("{ClientID}")]
        public GetRoutineDTO GetCurrentRoutine(int ClientID)
        {
           return routineService.GetCurrentRoutine(ClientID);
        }

    }
}
