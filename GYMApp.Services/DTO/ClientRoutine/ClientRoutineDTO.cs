using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class ClientRoutineDTO
    {
        public string RoutineName { get; set; }
        public List<string> Exercises { get; set; }
        public DateTime RoutineDate { get; set; }
    }
}
