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
        public string Program { get; set; } // можно сделать как отдельный класс (Список из 7 записей, день недели + программа на день)
    

    }
}

// можно добавить поля // диета,