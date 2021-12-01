using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IClientService
    {
        // public void CreateClient();

        public Client CreateClient(ClientDTO newClientDTO);
        public void UpdateClient(int ID, ClientDTO newClientDTO);

        public void AddNewClient(ClientDTO newClientDTO);

        public void AddNewMeasurement(int ClientID,MeasurementDTO measurementDTO);

        public Client GetClient(int ClientID);

        public List<Client> GetClientsByName(string Name); // ищет contains, а не ==

        public  List<Measurement> GetMeasurements(int ClientID);  

        public List<Client> GetAllTrainerClients(int TrainerID);  // Возможно этот метод должен быть в сервисе тренера, да и вообще возможно проще тренеру добавить List<Client>

        public void DeleteClient(int ClientID);
    }
}
