using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class ClientUpdateDTO
    {   
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string  PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? TrainerID { get; set; }        
    }
}
