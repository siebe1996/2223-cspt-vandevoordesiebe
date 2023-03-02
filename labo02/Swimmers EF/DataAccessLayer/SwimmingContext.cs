using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globals.Interfaces;
using Globals.Entities;
using SharpRepository.EfCoreRepository;

namespace DataAccessLayer
{
    public class SwimmingContext : DbContext
    {

        public SwimmingContext() { }
        public SwimmingContext(DbContextOptions<SwimmingContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Swimmer> Swimmers { get; set;}
        public DbSet<SwimmingPool> SwimmingPools { get; set;}
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .UseLazyLoadingProxies()
        .UseMySQL("server=localhost;database=SwimmerDb;user=root;password=Azerty123");
    }
}
