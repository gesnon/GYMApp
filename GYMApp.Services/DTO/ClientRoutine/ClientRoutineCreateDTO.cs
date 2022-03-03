using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class ClientRoutineCreateDTO
    {
        public int ClientID { get; set; }
        public int RoutineID { get; set; }
        public DateTime RoutineDate { get; set; }
    }
}
