using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IClientRoutineService
    {
        public void CreateClientRoutine(ClientRoutineCreateDTO newClientRoutineDTO);
        public void DeleteClientRoutine(int ClientRoutineID);
        public List<ClientRoutineDTO> GetAllClientRoutine(int ClientID);

    }
}
