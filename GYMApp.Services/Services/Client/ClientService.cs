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
        public ClientService(ContextDB context)
        {
            this.context = context;
        }

        public void UpdateClient(ClientUpdateDTO newClientUpdateDTO)
        {
            Client OldClient = context.Clients.FirstOrDefault(_ => _.ID == newClientUpdateDTO.ClientID);

            if (OldClient == null)
            {
                throw new Exception("Клиент не найдён");
            }

            OldClient.FullName = newClientUpdateDTO.FullName;
            OldClient.PhoneNumber = newClientUpdateDTO.PhoneNumber;
            OldClient.Email = newClientUpdateDTO.Email;
            //OldClient.BirthDate = newClientUpdateDTO.BirthDate;
            //OldClient.TrainerID = newClientUpdateDTO.TrainerID;

            context.SaveChanges();
        }

        public ClientProfileDTO GetClient(int ClientID)
        {
            if (context.Clients.FirstOrDefault(_ => _.ID == ClientID) == null)
            {
                throw new Exception("Клиент не найдён");
            }

            Client client = context.Clients.Include(_ => _.Trainer).FirstOrDefault(_ => _.ID == ClientID);



            return new ClientProfileDTO
            {
                FullName = client.FullName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                BirthDate = client.BirthDate,
                Trainer = client.Trainer?.FullName,
                TrainerID = client.TrainerID,
                Id = client.ID
            };
        }

        public List<GetTrainerDTO> GetClientsByName(string Name)
        {
            List<Client> clients = context.Clients
                .Include(_ => _.Trainer).Include(_ => _.Measurement)
                .Where(_=>_.FullName.Contains(Name)).ToList();
           
            List<GetTrainerDTO> clientDTOs = new List<GetTrainerDTO>();

            clientDTOs = clients.Select(
                _ => new GetTrainerDTO
                {
                    FullName = _.FullName,
                    Trainer = _.Trainer.FullName,
                    LastMeasurementDate = _.Measurement.OrderByDescending(_ => _.DateOfCreation).FirstOrDefault()?.DateOfCreation.ToString("dd.MM.yyyy"),
                    PhoneNumber = _.PhoneNumber,
                    Email = _.Email,
                    Id = _.ID
                }).ToList();

            return clientDTOs;
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

        public List<GetTrainerDTO> GetAllClientsDTO(string name)
        {
            var query = context.Clients
                .Include(_ => _.Trainer).Include(_ => _.Measurement).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(_ => _.FullName.Contains(name));
            }

            return query.Select(
                _ => new GetTrainerDTO
                {
                    FullName = _.FullName,
                    Trainer = _.Trainer.FullName,
                    LastMeasurementDate = _.Measurement.Any() ? _.Measurement.OrderByDescending(_ => _.DateOfCreation).FirstOrDefault().DateOfCreation.ToString("dd.MM.yyyy") : "",
                    PhoneNumber = _.PhoneNumber,
                    Email = _.Email,
                    Id = _.ID
                }).ToList();        
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
