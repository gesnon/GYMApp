using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services.Client
{
    public class ClientService: IClientSetvice
    {
        private readonly ContextDB context;

        public void AddNewClient (ClientDTO newClientDTO)
        {
            this.context.Clients.Add(new GYMDB.Models.Client
            {
                User= new GYMDB.Models.User { FullName=newClientDTO.FullNAme, Role=Role.Sportsman}
                  
            });
        }
    }
}
