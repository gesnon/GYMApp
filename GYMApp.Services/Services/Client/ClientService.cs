using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public List<ClientsListDTO> GetAllClientsDTO()
        {
            List<Client> clients = context.Clients.Include(_=>_.Trainer).Include(_=>_.Measurement).ToList();

            List<ClientsListDTO> clientDTOs = new List<ClientsListDTO>();

            clientDTOs = clients.Select(
                _ => new ClientsListDTO
                {
                    FullName=_.FullName,
                    Trainer=_.Trainer.FullName,
                    LastMeasurementDate = _.Measurement.OrderByDescending(_=>_.DateOfCreation).FirstOrDefault()?.DateOfCreation.ToString("dd.MM.yyyy")
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
