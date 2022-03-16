using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDB.Models
{
    public class Routine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TrainingWeek> TrainingW { get; set; }        
        public int ClientID { get; set; }
        public bool Current { get; set; }
    }
}
