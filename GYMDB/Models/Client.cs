using System;
using System.Collections.Generic;
using System.Text;

namespace GYMDB.Models
{
    public class Client: User
    {
        public Trainer Trainer { get; set; }
        public int? TrainerID { get; set; }
        public List<Measurement> Measurement { get; set; }
        public List<ClientRoutine> ClientRoutines { get; set; }         

    }
}

