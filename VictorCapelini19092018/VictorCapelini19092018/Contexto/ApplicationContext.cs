using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictorCapelini19092018.Models;

namespace VictorCapelini19092018.Contexto
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>().HasKey(t => t.Id);

            modelBuilder.Entity<Pessoa>().HasKey(t => t.Id);

            modelBuilder.Entity<Colaborador>().HasKey(t => t.Id);
            modelBuilder.Entity<Colaborador>().HasOne(t => t.Pessoa);
            modelBuilder.Entity<Colaborador>().HasOne(t => t.Empresa);
        }

        public DbSet<VictorCapelini19092018.Models.Empresa> Empresa { get; set; }
    }
}
