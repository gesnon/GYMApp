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
        public void UpdateClient(int ID, ClientCreateDTO newClientDTO);
        public Client GetClient(int ClientID);
        public List<Client> GetClientsByName(string Name); // ищет contains, а не ==
        public List<ClientCreateDTO> GetAllClientsDTO();
        public void DeleteClient(int ClientID);
    }
}
