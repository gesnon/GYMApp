using GYMApp.Services.DTO;
using GYMApp.Services.Services;
using GYMDB;
using GYMDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientController : ControllerBase
    {        
        private readonly IClientService clientService;

        public ClientController(IMeasurementService measurementService, IClientService clientService)
        {            
            this.clientService = clientService;
        }

        [HttpPut]
        public void UpdateClient(int ClientID, ClientDTO newClientDTO)
        {
            clientService.UpdateClient(ClientID, newClientDTO);
        }
        [HttpGet]
        public Client GetClient(int ClientID)
        {
            return clientService.GetClient(ClientID);
        }
        // хз какой атрибут писать
        public List<Client> GetClientsByName(string Name)
        {
            return clientService.GetClientsByName(Name);
        }
        // хз какой атрибут писать
        public void AddNewMeasurement(int ClientID, MeasurementDTO newMeasurementDTO)
        {

            clientService.AddNewMeasurement(ClientID, newMeasurementDTO);
        }

        [HttpPost]
        public void AddNewClient(ClientDTO newClientDTO)
        {
            clientService.AddNewClient(newClientDTO);
        }
        // хз какой атрибут писать
        public Client CreateClient(ClientDTO newClientDTO)
        {
            return clientService.CreateClient(newClientDTO);
        }
        // хз какой атрибут писать
        public List<Measurement> GetMeasurements(int ClientID)
        {
            return clientService.GetMeasurements(ClientID);
        }
        // хз какой атрибут писать
        public List<Client> GetAllTrainerClients(int TrainerID)
        {
            return clientService.GetAllTrainerClients(TrainerID);
        }
        // хз какой атрибут писать
        public void DeleteClient(int ClientID)
        {
            clientService.DeleteClient(ClientID);
        }
    }
}
