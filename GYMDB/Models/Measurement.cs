using System;
using System.Collections.Generic;
using System.Text;

namespace GYMDB.Models
{
    public class Measurement
    {
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        public int LeftArm { get; set; }

        public int RightArm { get; set; }

        public int LeftLeg { get; set; }

        public int RightLeg { get; set; }

        public int Chest { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int ID { get; set; }

        public int ClientID { get; set; }
    }
}
