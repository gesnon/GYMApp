using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class RoutineCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClientID { get; set; }
    }
}
