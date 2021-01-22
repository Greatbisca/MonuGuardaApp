﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonuGuardaApp.Data;

namespace MonuGuardaApp.Migrations
{
    [DbContext(typeof(MonuGuardaAppContext))]
    partial class MonuGuardaAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MonuGuardaApp.Models.Guia", b =>
                {
                    b.Property<int>("GuiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Telemovel")
                        .HasColumnType("int");

                    b.HasKey("GuiaId");

                    b.ToTable("Guia");
                });

            modelBuilder.Entity("MonuGuardaApp.Models.PontosVisita", b =>
                {
                    b.Property<int>("PontosVisitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.Property<int>("PontosdeInteresseId")
                        .HasColumnType("int");

                    b.Property<int>("VisitasGuiadasId")
                        .HasColumnType("int");

                    b.HasKey("PontosVisitaId");

                    b.HasIndex("PontosdeInteresseId");

                    b.HasIndex("VisitasGuiadasId");

                    b.ToTable("PontosVisita");
                });

            modelBuilder.Entity("MonuGuardaApp.Models.PontosdeInteresse", b =>
                {
                    b.Property<int>("PontosdeInteresseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Concelho")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Coordenadas")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Freguesia")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("PontosdeInteresseId");

                    b.ToTable("PontosdeInteresse");
                });

            modelBuilder.Entity("MonuGuardaApp.Models.ReservaVisita", b =>
                {
                    b.Property<int>("ReservaVisitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("NPessoas")
                        .HasColumnType("int");

                    b.Property<int?>("TuristaId")
                        .HasColumnType("int");

                    b.Property<int>("VisitasGuiadasId")
                        .HasColumnType("int");

                    b.HasKey("ReservaVisitaId");

                    b.HasIndex("TuristaId");

                    b.HasIndex("VisitasGuiadasId");

                    b.ToTable("ReservaVisita");
                });

            modelBuilder.Entity("MonuGuardaApp.Models.Turista", b =>
                {
                    b.Property<int>("TuristaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NIF")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telemovel")
                        .HasColumnType("int");

                    b.HasKey("TuristaId");

                    b.ToTable("Turista");
                });

            modelBuilder.Entity("MonuGuardaApp.Models.VisitasGuiadas", b =>
                {
                    b.Property<int>("VisitasGuiadasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DatadaVisita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("GuiaId")
                        .HasColumnType("int");

                    b.Property<int>("NMaxPessoas")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("VisitasGuiadasId");

                    b.HasIndex("GuiaId");

                    b.ToTable("VisitasGuiadas");
                });

            modelBuilder.Entity("MonuGuardaApp.Models.PontosVisita", b =>
                {
                    b.HasOne("MonuGuardaApp.Models.PontosdeInteresse", "PontosdeInteresse")
                        .WithMany()
                        .HasForeignKey("PontosdeInteresseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MonuGuardaApp.Models.VisitasGuiadas", "VisitasGuiadas")
                        .WithMany()
                        .HasForeignKey("VisitasGuiadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonuGuardaApp.Models.ReservaVisita", b =>
                {
                    b.HasOne("MonuGuardaApp.Models.Turista", "Turista")
                        .WithMany("ReservaVisitas")
                        .HasForeignKey("TuristaId");

                    b.HasOne("MonuGuardaApp.Models.VisitasGuiadas", "VisitasGuiadas")
                        .WithMany("ReservasVisita")
                        .HasForeignKey("VisitasGuiadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonuGuardaApp.Models.VisitasGuiadas", b =>
                {
                    b.HasOne("MonuGuardaApp.Models.Guia", "Guia")
                        .WithMany()
                        .HasForeignKey("GuiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
