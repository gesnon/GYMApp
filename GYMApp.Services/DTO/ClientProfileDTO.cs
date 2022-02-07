using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class ClientProfileDTO
    {   
        public string FullName { get; set; }
        public string Trainer { get; set; }
        public int? TrainerID { get; set; }
        public string Program { get; set; }
    }
}
