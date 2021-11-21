using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class ClientDTO
    {
        public string FullName { get; set; }

        public string Trainer { get; set; }

        public List<MeasurementDTO> MeasurementDTO { get; set; }

        public string Program { get; set; }
    }
}
