using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class TrainerDTO
    {
        public string FullName { get; set; }
        public string Comment { get; set; }
        public List<string> Reviews { get; set; }
    }
}
