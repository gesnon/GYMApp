using GYMApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMDB.Models
{
    public class User
    {
        public string FullName { get; set; }

        public int ID { get; set; }

        public Role Role { get; set; }
   
    }
}
