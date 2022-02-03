using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IClientService
    {        
        public void CreateClient(ClientDTO newClientDTO);
        public void UpdateClient(int ID, ClientDTO newClientDTO);
        public Client GetClient(int ClientID);
        public List<Client> GetClientsByName(string Name); // ищет contains, а не ==
        public void DeleteClient(int ClientID);
    }
}
