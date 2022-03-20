using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IClientService
    {        
        public void CreateClient(ClientCreateDTO newClientDTO);
        public void UpdateClient(ClientUpdateDTO newClientUpdateDTO);
        public ClientProfileDTO GetClient(int ClientID);
        public List<GetTrainerDTO> GetAllClientsDTO(string Name);
        public void DeleteClient(int ClientID);
    }
}
