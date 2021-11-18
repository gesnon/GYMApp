using GYMApp.Services.DTO;
using GYMApp.Services.Queries.Client;
using GYMDB;
using GYMDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ContextDB ContextDB;

        public ClientController(ILogger<ClientController> logger, ContextDB contextDB)
        {
            this.ContextDB = contextDB;
            //  _logger = logger;
        }


        [HttpPost]
        public void CreateClient(int ID)
        {
            this.ContextDB.Clients.Add(new Client() { UserID = ID });
        }

        [HttpGet]
        public ClientDTO GetClientByID(int ID)
        {
            GetClient query = new GetClient();

            return query.Execute(ID, ContextDB);
        }


    }
}
