using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class RoutineUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Exercises { get; set; }        
    }
}
