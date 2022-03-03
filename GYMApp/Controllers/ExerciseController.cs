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

        [HttpDelete("{MeasurementID}")]
        public void DeleteExercise(int ExerciseID)
        {
            exerciseService.DeleteExercise(ExerciseID);
        }

        [HttpGet("{Name}")]
        public List<Exercise> GetExerciseByName(string Name)
        {          
            return exerciseService.GetExerciseByName(Name);
        }

        [HttpGet]
        public List<ExerciseGetDTO> GetAllExerciseDTO()
        {
            return exerciseService.GetAllExerciseDTO();
        }
    }
}
