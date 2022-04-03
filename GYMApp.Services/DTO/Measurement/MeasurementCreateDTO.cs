using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class MeasurementCreateDTO
    {
        public int LeftArm { get; set; }

        public int RightArm { get; set; }

        public int LeftLeg { get; set; }

        public int RightLeg { get; set; }

        public int Chest { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int ClientID { get; set; }

    }
}
