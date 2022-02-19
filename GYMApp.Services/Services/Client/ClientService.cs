using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace GYMApp.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly ContextDB context;



        public ClientService(ContextDB context, IMeasurementService measurementService)
        {
            this.context = context;
        }

        public void UpdateClient(int ClientID, ClientCreateDTO newClientDTO)
        {
            Client OldClient = context.Clients.FirstOrDefault(_ => _.ID == ClientID);

            if (OldClient == null)
            {
                throw new Exception("Клиент не найдён");
            }

            if (newClientDTO.FullName != null)
            {
                OldClient.FullName = newClientDTO.FullName;

            }
    

            context.SaveChanges();
        }

        public Client GetClient(int ClientID)
        {
            if (context.Clients.FirstOrDefault(_ => _.ID == ClientID) == null)
            {
                throw new Exception("Клиент не найдён");
            }

            return context.Clients.FirstOrDefault(_ => _.ID == ClientID);
        }

        public List<Client> GetClientsByName(string Name)
        {
            List<Client> clients = context.Clients.Where(_ => _.FullName.Contains(Name)).ToList();

            if (clients.Count == 0)
            {
                throw new Exception("Клиенты с таким именем не найдёны"); // Не уверен что это правильно
            }
            
            return clients;
        }


        public void CreateClient(ClientCreateDTO newClientDTO)   // Не уверен что этот медот должен быть в сервисе клиента 
        {
            context.Clients.Add(new Client
            {
                FullName = newClientDTO.FullName,
                Measurement = new List<Measurement>(),

            });

            context.SaveChanges();
        }

        public List<ClientCreateDTO> GetAllClientsDTO()
        {
            List<Client> clients = context.Clients.ToList();

            List<ClientCreateDTO> clientDTOs = new List<ClientCreateDTO>();

            clientDTOs = clients.Select(
                _ => new ClientCreateDTO
                {
                    FullName=_.FullName,
                }).ToList();

            return clientDTOs;
        }

        public void DeleteClient(int ClientID)
        {
            if (context.Clients.FirstOrDefault(_ => _.ID == ClientID) == null)
            {
                throw new Exception("Клиент не найдён");
            }

            context.Clients.Remove(context.Clients.FirstOrDefault(_ => _.ID == ClientID));

            context.SaveChanges();
        }
    }
}
