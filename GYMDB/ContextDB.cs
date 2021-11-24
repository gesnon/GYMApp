using Microsoft.EntityFrameworkCore;
using System;
using GYMDB.Models;

namespace GYMDB
{

    public class ContextDB : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public ContextDB(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();                      // если базы нет, то она создастся
        }
    }
}



