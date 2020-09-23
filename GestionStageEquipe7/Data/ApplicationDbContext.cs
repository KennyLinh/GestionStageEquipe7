using System;
using System.Collections.Generic;
using System.Text;
using GestionStageEquipe7.Areas.Stages.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionStageEquipe7.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        #region Employeurs
        public DbSet<Employeur> Employeur { get; set; }
        public DbSet<TypeEmployeur> TypeEmployeur { get; set; }
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
                
        }

    }
}
