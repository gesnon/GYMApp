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
        private readonly IMeasurementService measurementService;


        public ClientService(ContextDB context, IMeasurementService measurementService)
        {
            this.context = context;
            this.measurementService = measurementService;
        }

        public void UpdateClient(int ClientID, ClientCreateDTO newClientDTO)
        {
            Client OldClient = context.Clients.FirstOrDefault(_ => _.ID == ClientID);

            if (newClientDTO.FullName != null)
            {
                OldClient.FullName = newClientDTO.FullName;

            }

            if (newClientDTO.Program != null)
            {
                OldClient.Program = newClientDTO.Program;

            }

            if (newClientDTO.Trainer != null)
            {
                OldClient.Trainer = newClientDTO.Trainer;

                OldClient.TrainerID = context.Trainers.FirstOrDefault(_ => _.FullName == newClientDTO.Trainer).ID;
            }

            context.SaveChanges();
        }

        public Client GetClient(int ClientID)
        {
            return context.Clients.FirstOrDefault(_ => _.ID == ClientID);
        }

        public List<Client> GetClientsByName(string Name)
        {
            return context.Clients.Where(_ => _.FullName.Contains(Name)).ToList();
        }


        public void CreateClient(ClientCreateDTO newClientDTO)   // Не уверен что этот медот должен быть в сервисе клиента 
        {
            context.Clients.Add(new Client
            {
                FullName = newClientDTO.FullName,
                Program = newClientDTO.Program,
                Measurement = new List<Measurement>(),
                Trainer = newClientDTO.Trainer
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
                    MeasurementDTO=new List<MeasurementDTO>(),
                    Program=_.Program,
                    Trainer=_.Trainer
                }).ToList();

            return clientDTOs;
        }

        public void DeleteClient(int ClientID)
        {
            context.Clients.Remove(context.Clients.FirstOrDefault(_ => _.ID == ClientID));

            context.SaveChanges();
        }
    }
}
