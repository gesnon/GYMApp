﻿using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IClientService
    {        
        public void CreateClient(ClientCreateDTO newClientDTO);
        public void UpdateClient(int ID, ClientUpdateDTO newClientUpdateDTO);
        public ClientProfileDTO GetClient(int ClientID);
        public List<Client> GetClientsByName(string Name); // ищет contains, а не ==
        public List<GetAllClientsDTO> GetAllClientsDTO();
        public void DeleteClient(int ClientID);
    }
}
