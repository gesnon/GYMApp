﻿using GYMApp.Services.DTO;
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

        [HttpPut("UpdateClient")]
        public void UpdateClient([FromBody] ClientUpdateDTO newClientDTO)
        {
            clientService.UpdateClient(newClientDTO);
        }

        [HttpGet("{ClientID}")]
        public ClientProfileDTO GetClient(int ClientID)
        {
            return clientService.GetClient(ClientID);
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

        [HttpGet("GetClientsByName/{Name?}")]
        public List<GetTrainerDTO> GetAllClientsDTO(string Name)
        {
           return  clientService.GetAllClientsDTO(Name);
        }
    }
}
