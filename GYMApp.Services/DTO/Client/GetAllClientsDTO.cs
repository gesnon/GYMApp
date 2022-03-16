using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class GetTrainerDTO
    {   
        public string FullName { get; set; }
        public string Trainer { get; set; }
        public DateTime BirthDate { get; set; }
        public string LastMeasurementDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

    }
}
