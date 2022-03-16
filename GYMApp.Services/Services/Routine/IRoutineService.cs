using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IRoutineService
    {
        public void CreateRoutine(RoutineCreateDTO newRoutineDTO);
        public void UpdateRoutine(int RoutineID, RoutineUpdateDTO newRoutineDTO);
        public void DeleteRoutine(int RoutineID);
        public GetRoutineDTO GetCurrentRoutine(int ClientID);

    }
}
