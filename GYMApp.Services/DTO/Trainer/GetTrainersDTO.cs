using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class GetTrainersDTO
    {   
        public string FullName { get; set; }        
        public DateTime BirthDate { get; set; }
        public int Id { get; set; }
        public int NumberOfClients { get; set; }

    }
}
