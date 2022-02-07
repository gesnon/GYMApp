using System;
using System.Collections.Generic;
using System.Text;

namespace GYMDB.Models
{
    public class Review
    {
        public string Text { get; set; }
        public int ID { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public Client ReviewCreator { get; set; }
        public int ReviewCreatorID { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainerID { get; set; }
    }
}
