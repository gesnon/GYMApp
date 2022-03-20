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
    [Route("API/Exercise")]
    public class ExerciseController
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpPost]
        public void CreateExercise([FromBody] ExerciseCreateDTO newExerciseCreateDTO)
        {
            exerciseService.CreateExercise(newExerciseCreateDTO);

        }

        [HttpPut]
        public void UpdateExercise(int ExerciseID, [FromBody] ExerciseUpdateDTO newExerciseUpdateDTO)
        {
            exerciseService.UpdateExercise(ExerciseID,newExerciseUpdateDTO);
        }

        [HttpDelete("{ExerciseID}")]
        public void DeleteExercise(int ExerciseID)
        {
            exerciseService.DeleteExercise(ExerciseID);
        }

        [HttpGet("GetExercisesByName/{Name?}")]
        public List<ExerciseGetDTO> GetExercisesByName(string Name)
        {          
            return exerciseService.GetExercisesByName(Name);
        }

        [HttpGet("{ExerciseID}")]
        public ExerciseGetDTO GetExercise(int ExerciseID)
        {
            return exerciseService.GetExercise(ExerciseID);
        }

    }
}
