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

        public void ChooseTrainer(int ClientID, int TrainerID); // по идее можно использовать как для выбора тренера, так и для смены

        public Client GetClient(int ClientID);

        public  List<Measurement> GetMeasurements(int ID);  // Мне кажется что этот метод можно сделать статичным и вообще не передавать параметр, но я не смог
    }
}
