using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IExerciseService
    {        
        public void CreateExercise(ExerciseCreateDTO newExerciseCreateDTO);
        public void UpdateExercise(int ID, ExerciseUpdateDTO newExerciseUpdateDTO);
        public void DeleteExercise(int ExerciseID);      
        public List<ExerciseGetDTO> GetExercisesByName(string Name);
        public ExerciseGetDTO GetExercise(int ExerciseID);

    }
}
