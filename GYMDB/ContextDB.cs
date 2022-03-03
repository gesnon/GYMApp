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
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<RoutineExercise> RoutineExercises { get; set; }
        public DbSet<ClientRoutine> ClientRoutines { get; set; }
        public ContextDB(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();                      // если базы нет, то она создастся
        }
    }
}



