using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class MonDbContext : DbContext
    {
        #region Constructeur
        public MonDbContext(DbContextOptions<MonDbContext> options) : base(options)
        {

        }
        #endregion

        public DbSet<Formation> Formations { get; set; }

        public DbSet<Avis> Avis { get; set; }

        public DbSet<ContactMessage> Messages { get; set; }

        // pour lettre une contrainte
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formation>()
                .Property(f => f.Description)
                .HasMaxLength(500);

            // pour ajouter des données dans la bdd
            modelBuilder.Entity<Formation>().HasData(
                new
                {
                    Id = 1,
                    Nom = "Créer votre site web avec ASP.NET Core",
                    NomSeo = "asp-net-core",
                    Description = "Grace à cette formation vous saurez créer votre propre sit web en très peu de temps"
                },
                new { Id = 2, Nom = "Créer votre site web avec PHP", NomSeo = "php", Description = "Grace à cette formation vous saurez créer votre propre sit web en très peu de temps" },
                new { Id = 3, Nom = "Devenez un pro du jardiange", NomSeo = "pro-jardiange", Description = "Apprenez à cultiver des tomates, courgettes, ..." },
                new { Id = 4, Nom = "Photo Pro", NomSeo = "pro-photo", Description = "Apprenez à prendre de belles photos" }
                );



        }


    }
}
