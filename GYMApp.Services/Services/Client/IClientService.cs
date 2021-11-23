using GYMApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IClientService
    {
        public void CreateClient();

        public void UpdateClient(int ID, ClientDTO newClientDTO);

        public void AddNewClient(ClientDTO newClientDTO);

        public void AddNewMeasurement(int ClientID,MeasurementDTO measurementDTO);

        public void ChooseTrainer(int ClientID, int TrainerID);

        public GYMDB.Models.Client GetClient(int ClientID);
    }
}
