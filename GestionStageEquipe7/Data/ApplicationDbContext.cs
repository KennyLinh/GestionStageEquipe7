using System;
using System.Collections.Generic;
using System.Text;
using GestionStageEquipe7.Areas.Stages.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionStageEquipe7.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        #region Employeurs
        public DbSet<Employeur> Employeur { get; set; }
        public DbSet<TypeEmployeur> TypeEmployeur { get; set; }


        public DbSet<MissionEmployeur> MissionEmployeur { get; set; }
        public DbSet<EmployeurMissionEmployeur> EmployeurMissionEmployeur { get; set; }

        #endregion Employeurs

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Employeur>()
                .Property(e => e.EmployeurId)
                .HasDefaultValueSql("newid()");

          
            modelBuilder
                .Entity<OffresStage>()
                .Property(e => e.OffreStageId)
                .HasDefaultValueSql("newid()");

        
            modelBuilder
                .Entity<EtudiantOffreStage>()
                .Property(e => e.OffresStageEtudiantId)
                .HasDefaultValueSql("newid()");

            modelBuilder.Entity<EmployeurMissionEmployeur>().HasKey(cle => new { cle.EmployeurMissionEmployeurId });

            // Établir la relation 1:N d'un coté
            modelBuilder.Entity<EmployeurMissionEmployeur>()
                .HasOne(info => info.Employeurs)
                .WithMany(info => info.EmployeursMissionEmployeur)
                .HasForeignKey(cle => cle.EmployeurId);


            // Établir la relation 1:N de l'autre coté
            modelBuilder.Entity<EmployeurMissionEmployeur>()
                .HasOne(info => info.MissionsEmployeur)
                .WithMany(info => info.EmployeursMissionEmployeur)
                .HasForeignKey(cle => cle.MissionEmployeurId);


            // Créer la supression en cascade entre la table du milieu et la table Employeur
            modelBuilder.Entity<EmployeurMissionEmployeur>()
                .HasOne(b => b.Employeurs)
                .WithMany(a => a.EmployeursMissionEmployeur)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);




        }

        public DbSet<GestionStageEquipe7.Areas.Stages.Models.OffresStage> OffresStage { get; set; }

    }
}
