using System;
using System.Collections.Generic;
using System.Text;

namespace GYMDB.Models
{
    public class Measurement
    {
        public DateTime DateOfCreation { get; set; }
        public int LeftArm { get; set; }

        public int RightArm { get; set; }

        public int LeftLeg { get; set; }

        public int RightLeg { get; set; }

        public int Chest { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int ID { get; set; } // не уверен что тут это нужно, ведь замеров будет довольно много

    }
}
