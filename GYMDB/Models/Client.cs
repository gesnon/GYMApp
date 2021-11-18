using GYMApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMDB.Models
{
    public class Client
    {
        public User User { get; set; }
        public int UserID { get; set; }
        public User Trainer { get; set; }
        public int? TrainerID { get; set; }
        public List <Measurement> Measurement { get; set; }
        public int ID { get; set; }

        public Role Role { get; set; }
        
    }
}
