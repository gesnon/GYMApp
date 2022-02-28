using GYMApp.Services.DTO;
using GYMApp.Services.Services;
using GYMDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMApp.Controllers
{
    [ApiController]
    [Route("API/Client")]
    public class ClientController : ControllerBase
    {        
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {            
            this.clientService = clientService;
        }

        [HttpPut("{ClientID}")]
        public void UpdateClient(int ClientID, [FromBody] ClientCreateDTO newClientDTO)
        {
            clientService.UpdateClient(ClientID, newClientDTO);
        }

        [HttpGet("{ClientID}")]
        public Client GetClient(int ClientID)
        {
            return clientService.GetClient(ClientID);
        }

        [HttpGet("GetClientsByName/{Name}")]
        public List<Client> GetClientsByName(string Name)
        {
            return clientService.GetClientsByName(Name);
        }

        [HttpPost]
        public void CreateClient([FromBody] ClientCreateDTO newClientDTO)
        {
            clientService.CreateClient(newClientDTO);
        }

        [HttpDelete("{ClientID}")]
        public void DeleteClient(int ClientID)
        {
            clientService.DeleteClient(ClientID);
        }

        [HttpGet]
        public List<ClientsListDTO> GetAllClientsDTO()
        {
           return  clientService.GetAllClientsDTO();
        }
    }
}
