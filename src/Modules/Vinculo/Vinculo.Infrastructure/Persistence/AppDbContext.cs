﻿using Microsoft.EntityFrameworkCore;
using Vinculo.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Vinculo.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Users { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
                Console.WriteLine("x: " + connectionString);
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }

}
