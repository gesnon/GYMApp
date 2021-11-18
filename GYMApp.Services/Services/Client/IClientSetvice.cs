using GYMApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services.Client
{
    public interface IClientSetvice
    {
        public void CreateClient();
        public void UpdateClient(int ID, ClientDTO newClientDTO);

        public void AddNewClient(ClientDTO newClientDTO);

        
    }
}
