using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class DyfContext : DbContext
    {
        public DyfContext() : base("name=mysqlcs")
        {
            //Database.SetInitializer<DyfContext>(new CreateDatabaseIfNotExists<DyfContext>());

            //Database.SetInitializer<DyfContext>(new DropCreateDatabaseIfModelChanges<DyfContext>());
            //Database.SetInitializer<DyfContext>(new DropCreateDatabaseAlways<DyfContext>());
            //Database.SetInitializer<DyfContext>(new DyfInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DyfContext, DYF.Migrations.Configuration>("mysqlcs"));


            //Database.SetInitializer<DyfContext>(new SchoolDBInitializer());
        }

        public DbSet<Achat> Achat { get; set; }
        public DbSet<Bande> Bande { get; set; }
        public DbSet<Batiment> Batiment { get; set; }
        public DbSet<Consommation> Consommation { get; set; }
        public DbSet<CoutProduit> CoutProduit { get; set; }
        public DbSet<Dette> Dette { get; set; }
        public DbSet<Formule> Formule { get; set; }
        public DbSet<Fournisseur> Fournisseur { get; set; }
        public DbSet<HistoriquePathologie> HistoriquePathologie { get; set; }
        public DbSet<HistoriqueReglementDette> HistoriqueReglementDette { get; set; }
        public DbSet<HistoriqueRepartitionBande> HistoriqueRepartitionBande { get; set; }
        public DbSet<MatierePremiere> MatierePremiere { get; set; }
        public DbSet<Mortalite> Mortalite { get; set; }
        public DbSet<Pathologie> Pathologie { get; set; }
        public DbSet<Pesee> Pesee { get; set; }
        public DbSet<ProductionAliment> ProductionAliment { get; set; }
        public DbSet<ProductionOeuf> ProductionOeuf { get; set; }
        public DbSet<Produit> Produit { get; set; }
        public DbSet<RaceVolaille> RaceVolaille { get; set; }
        public DbSet<ReferencePoidsMoyen> ReferencePoidsMoyen { get; set; }
        public DbSet<RepartitionBande> RepartitionBande { get; set; }
        public DbSet<TraitementPathologie> TraitementPathologie { get; set; }
        public DbSet<TypeProduit> TypeProduit { get; set; }
        public DbSet<TypeVolaille> TypeVolaille { get; set; }
        public DbSet<VenteOeuf> VenteOeuf { get; set; }
        public DbSet<VenteVolailles> VenteVolailles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("dyftest");

            base.OnModelCreating(modelBuilder);
        }
    }
}