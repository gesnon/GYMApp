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

        public void UpdateClient(int ClientID, ClientUpdateDTO newClientUpdateDTO)
        {
            Client OldClient = context.Clients.FirstOrDefault(_ => _.ID == ClientID);

            if (OldClient == null)
            {
                throw new Exception("Клиент не найдён");
            }

            OldClient.FullName = newClientUpdateDTO.FullName;
            OldClient.PhoneNumber = newClientUpdateDTO.PhoneNumber;
            OldClient.Email = newClientUpdateDTO.Email;
            OldClient.BirthDate = newClientUpdateDTO.BirthDate;
            OldClient.TrainerID = newClientUpdateDTO.TrainerID;

            context.SaveChanges();
        }

        public ClientProfileDTO GetClient(int ClientID)
        {
            if (context.Clients.FirstOrDefault(_ => _.ID == ClientID) == null)
            {
                throw new Exception("Клиент не найдён");
            }

            Client client = context.Clients.Include(_ => _.Trainer).Include(_ => _.ClientRoutines).ThenInclude(_ => _.Routine).ThenInclude(_=>_.RoutineExercises).ThenInclude(_=>_.Exercise).FirstOrDefault(_ => _.ID == ClientID);

            ClientRoutine clientRoutine = client.ClientRoutines.OrderByDescending(_ => _.RoutineDate).First();


            
            return new ClientProfileDTO
            {
                FullName = client.FullName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                BirthDate = client.BirthDate,
                Trainer = client.Trainer.FullName,
                TrainerID = client.TrainerID,
                ClientRoutineDTO = new ClientRoutineDTO
                {
                    Exercises = clientRoutine.Routine.RoutineExercises.Select(_=>_.Exercise.Name).ToList(),                    
                    RoutineDate = clientRoutine.RoutineDate
                }
            };
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

        public List<GetAllClientsDTO> GetAllClientsDTO()
        {
            List<Client> clients = context.Clients.Include(_ => _.Trainer).Include(_ => _.Measurement).ToList();

            List<GetAllClientsDTO> clientDTOs = new List<GetAllClientsDTO>();

            clientDTOs = clients.Select(
                _ => new GetAllClientsDTO
                {
                    FullName = _.FullName,
                    Trainer = _.Trainer.FullName,
                    LastMeasurementDate = _.Measurement.OrderByDescending(_ => _.DateOfCreation).FirstOrDefault()?.DateOfCreation.ToString("dd.MM.yyyy"),
                    PhoneNumber = _.PhoneNumber,
                    Email = _.Email
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
