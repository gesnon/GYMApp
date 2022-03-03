using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDB.Models
{
    public  class ClientRoutine
    {
        public int ClientRoutineID { get; set; }
        public int ClientID { get; set; }
        public int RoutineID { get; set; }
        public Routine Routine { get; set; }
        public DateTime RoutineDate { get; set; }
            }
}
