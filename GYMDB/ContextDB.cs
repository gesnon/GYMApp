using Microsoft.EntityFrameworkCore;
using System;
using GYMDB.Models;
using GYMApp.Services.Services;

namespace GYMDB{

        public class ContextDB : DbContext
        {
            public DbSet<Client> Clients { get; set; }
            public DbSet<Measurement> Measurements { get; set; }
            public DbSet<Role> Role { get; set; }
            public DbSet<User> Users { get; set; }
            public ContextDB(DbContextOptions options) : base(options)
            {
                Database.EnsureCreated();                      // если базы нет, то она создастся
            }
    }
}



