﻿using JetBrains.Annotations;
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


            modelBuilder.Entity<Movimentacao>().HasKey(t => t.Id);
            modelBuilder.Entity<Movimentacao>().HasOne(t => t.Pessoa);
            modelBuilder.Entity<Movimentacao>().HasOne(t => t.Empresa);

            modelBuilder.Entity<Colaborador>().HasKey(t => t.Id);
            modelBuilder.Entity<Colaborador>().HasOne(t => t.Pessoa);
            modelBuilder.Entity<Colaborador>().HasOne(t => t.Empresa);
            modelBuilder.Entity<Colaborador>().HasMany(t => t.Movimentacoes);
                                    
        }

        public DbSet<VictorCapelini19092018.Models.Empresa> Empresa { get; set; }

        public DbSet<VictorCapelini19092018.Models.Pessoa> Pessoa { get; set; }

        public DbSet<VictorCapelini19092018.Models.Colaborador> Colaborador { get; set; }

        public DbSet<VictorCapelini19092018.Models.Movimentacao> Movimentacao { get; set; }
    }
}
