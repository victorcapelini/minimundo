﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VictorCapelini19092018.Contexto;

namespace VictorCapelini19092018.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180924015726_Modelo1.3")]
    partial class Modelo13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VictorCapelini19092018.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cargo")
                        .IsRequired();

                    b.Property<DateTime>("DataDeContratacao");

                    b.Property<DateTime>("DataDeDemissao");

                    b.Property<int>("EmpresaId");

                    b.Property<int>("PessoaId");

                    b.Property<double>("Salario");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("VictorCapelini19092018.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ")
                        .IsRequired();

                    b.Property<DateTime>("DataDeCadastro");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("RazaoSocial")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("VictorCapelini19092018.Models.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ColaboradorId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("EmpresaId");

                    b.Property<int>("PessoaId");

                    b.Property<string>("TipoMovimentacao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Movimentacao");
                });

            modelBuilder.Entity("VictorCapelini19092018.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<DateTime>("DataDeCadastro");

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("VictorCapelini19092018.Models.Colaborador", b =>
                {
                    b.HasOne("VictorCapelini19092018.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VictorCapelini19092018.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VictorCapelini19092018.Models.Movimentacao", b =>
                {
                    b.HasOne("VictorCapelini19092018.Models.Colaborador")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("ColaboradorId");

                    b.HasOne("VictorCapelini19092018.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VictorCapelini19092018.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
