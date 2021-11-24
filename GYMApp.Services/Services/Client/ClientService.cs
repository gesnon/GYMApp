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
        private readonly ITrainerService trainerService;

        public ClientService(ContextDB context, IMeasurementService measurementService, ITrainerService trainerService)
        {
            this.context = context;
            this.measurementService = measurementService;
            this.trainerService = trainerService;
        }

        public void UpdateClient(int ClientID, ClientDTO newClientDTO)
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

        }

        public Client GetClient(int ClientID)
        {
            return context.Clients.FirstOrDefault(_ => _.ID == ClientID);
        }
        public void AddNewMeasurement(int ClientID, MeasurementDTO newMeasurementDTO)
        {
            Client Client = new Client();
            Client.Measurement.Add(measurementService.CreateMeasurement(newMeasurementDTO));
        }

        public void AddNewClient(ClientDTO newClientDTO)   // Не уверен что этот медот должен быть в сервисе клиента 
        {
            this.context.Clients.Add(new Client
            {
                FullName = newClientDTO.FullName,
                Trainer = this.context.Trainers.FirstOrDefault(_ => _.FullName == newClientDTO.Trainer).FullName, //возможно надо сравнивать не через ==, а через Contains    
                TrainerID = this.context.Trainers.FirstOrDefault(_ => _.FullName == newClientDTO.Trainer).ID,
            });
        }

        public void ChooseTrainer(int ClientID, int TrainerID)
        {
            this.GetClient(ClientID).Trainer = trainerService.GetTrainer(TrainerID).FullName;
            this.GetClient(ClientID).TrainerID = TrainerID;
        }
        public Client CreateClient(ClientDTO newClientDTO)
        {           
            return new Client
            {
                FullName = newClientDTO.FullName,
                Program = newClientDTO.Program,
                Measurement = new List<Measurement> { measurementService.CreateMeasurement(newClientDTO.MeasurementDTO[0]) },
                Trainer = newClientDTO.Trainer,
                TrainerID = context.Trainers.FirstOrDefault(_ => _.FullName == newClientDTO.Trainer).ID,

            };
        }

        public List<Measurement> GetMeasurements(int ClientID)
        {
            return context.Clients.FirstOrDefault(_ => _.ID == ClientID).Measurement;
        }
    }
}
