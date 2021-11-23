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

        public ClientService (ContextDB context, IMeasurementService measurementService, ITrainerService trainerService)
        {
            this.context = context;
            this.measurementService = measurementService;
            this.trainerService = trainerService;
        }

        public Client GetClient(int ClientID)
        {
            return context.Clients.FirstOrDefault(_ => _.ID == ClientID);
        }
        public void AddNewMeasurement(int ClientID, MeasurementDTO newMeasurementDTO)
        {
            GYMDB.Models.Client Client = new GYMDB.Models.Client();
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

        public void ChooseTrainer(int ClientID,  int TrainerID)
        {
            this.GetClient(ClientID).Trainer = trainerService.GetTrainer(TrainerID).FullName;
            this.GetClient(ClientID).TrainerID = TrainerID;
        }
    }
}
