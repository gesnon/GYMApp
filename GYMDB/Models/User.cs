using System;
using System.Collections.Generic;
using System.Text;

namespace GYMDB.Models
{
    public class User
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }        
        public DateTime BirthDate { get; set; }
        public int ID { get; set; }

    }
}
