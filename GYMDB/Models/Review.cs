using System;
using System.Collections.Generic;
using System.Text;

namespace GYMDB.Models
{
    public class Review
    {
        public string Text { get; set; }
        public int ID { get; set; }
        public DateTime DateOfCreation { get; set; }
        public Client ReviewCreator { get; set; }

    }
}
