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
    public class RoutineExerciseController
    {
        private readonly IRoutineExerciseService routineExerciseService;

        public RoutineExerciseController(IRoutineExerciseService routineExerciseService)
        {
            this.routineExerciseService = routineExerciseService;
        }

        [HttpPost]
        public void CreateRoutineExercise([FromBody] RoutineExerciseCreateDTO newRoutineExerciseCreateDTO)
        {
            routineExerciseService.CreateRoutineExercise(newRoutineExerciseCreateDTO);

        }

        [HttpDelete("{RoutineExerciseID}")]
        public void DeleteRoutineExercise(int RoutineExerciseID)
        {
            routineExerciseService.DeleteRoutineExercise(RoutineExerciseID);
        }
        
    }
}
