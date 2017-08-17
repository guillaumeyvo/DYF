namespace DYF.Migrations
{
    using DYF.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DYF.Models.DyfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
            CodeGenerator = new MySql.Data.Entity.MySqlMigrationCodeGenerator();
        }

        protected override void Seed(DYF.Models.DyfContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            #region TypeVolaille
            List<TypeVolaille> listeTypeVolaille = new List<TypeVolaille>
            {
                new TypeVolaille { Nom = "Pondeuse"},
                new TypeVolaille { Nom = "Poulet de chair"},
                new TypeVolaille { Nom = "Pintade"}
            };
            foreach (TypeVolaille item in listeTypeVolaille)
                context.TypeVolaille.AddOrUpdate(p => p.Nom, item);
            context.SaveChanges();
            #endregion
            #region RaceVollaille

            context.RaceVolaille.AddOrUpdate(p => p.Nom, new RaceVolaille { Nom = "Loman" });
            context.SaveChanges();

            #endregion

            #region TypeProduit

            context.TypeProduit.AddOrUpdate(p => p.Nom, new TypeProduit { Nom = "Volailles" });
            context.SaveChanges();

            #endregion

            #region Produit

            context.Produit.AddOrUpdate(p => p.Nom, new Produit
            {
                Nom = "Pondeuses",
                LibelleUnite = "Sujets",
                IdTypeProduit = context.TypeProduit.FirstOrDefault(t => t.Nom == "Volailles").Id,
            });
            context.SaveChanges();

            #endregion

            #region Fournisseur

            context.Fournisseur.AddOrUpdate(p => p.Nom, new Fournisseur { Nom = "FACI" });
            context.SaveChanges();

            #endregion

            #region Achat
            // Achat bande de pondeuses
            context.Achat.AddOrUpdate(p => p.Quantite, new Achat
            {
                PrixUnitaire = 570,
                Quantite = 3000,
                CoutTotal = 3000 * 570,
                MontantRegle = 3000 * 570,
                DateAchat = new DateTime(2017, 5, 1),
                DateLivraison = new DateTime(2017, 5, 10),
                IdFournisseur = context.Fournisseur.FirstOrDefault(t => t.Nom == "FACI").Id,
                IdProduit = context.Produit.FirstOrDefault(t => t.Nom == "Pondeuses").Id,
                IdTypeProduit = context.TypeProduit.FirstOrDefault(t => t.Nom == "Volailles").Id
            });
            context.SaveChanges();

            #endregion

            #region Batiment

            context.Batiment.AddOrUpdate(p => p.Nom, new Batiment
            {
                B_Occupe = true,
                Effectif_Maximum = 1500,
                Nom = "A"
            });
            context.Batiment.AddOrUpdate(p => p.Nom, new Batiment
            {
                B_Occupe = true,
                Effectif_Maximum = 1500,
                Nom = "B"
            });
            context.SaveChanges();

            #endregion

            #region Bande
            context.Bande.AddOrUpdate(p => p.Nom, new Bande
            {
                IdAchat = context.Achat.FirstOrDefault(a => a.PrixUnitaire == 570).Id,
                IdRaceVolaille = context.RaceVolaille.FirstOrDefault().Id,
                EffectifInitial = 3000,
                DateArrivee = context.Achat.FirstOrDefault(a => a.PrixUnitaire == 570).DateLivraison,
                Nom = "BandeTest",
                B_Actif = true,
                B_VenteTotale = false,
                IdTypeVolaille = context.TypeVolaille.FirstOrDefault(tv => tv.Nom == "Pondeuse").Id

            });
            context.SaveChanges();
            #endregion

            #region Repartition
            context.RepartitionBande.AddOrUpdate(p => p.IdBatiment, new RepartitionBande
            {
                IdBatiment = context.Batiment.FirstOrDefault(b => b.Nom == "A").Id,
                EffectifInitial = 1500,
                EffectifActuel = 1500,
                TotalMortalite = 0,
                IdBande = context.Bande.FirstOrDefault().Id,
                Nom = "Batiment A"
            });
            context.RepartitionBande.AddOrUpdate(p => p.IdBatiment, new RepartitionBande
            {
                IdBatiment = context.Batiment.FirstOrDefault(b => b.Nom == "B").Id,
                EffectifInitial = 1500,
                EffectifActuel = 1500,
                TotalMortalite = 0,
                IdBande = context.Bande.FirstOrDefault().Id,
                Nom = "Batiment B"
            });
            context.SaveChanges();

            #endregion

            #region TypePesee

            context.TypePesee.AddOrUpdate(p => p.Libelle, new TypePesee
            {
                Libelle = "Groupée"
            });
            context.SaveChanges();
            context.TypePesee.AddOrUpdate(p => p.Libelle, new TypePesee
            {
                Libelle = "Individuelle"
            });
            context.SaveChanges();
            #endregion

            #region Pesees
            context.Pesee.AddOrUpdate(p => p.Date, new Pesee
            {
                NombreDeSujetsPeses = 124,
                PoidsMoyen = 1558,
                Homogeneite = 84,
                Date = new DateTime(2017, 08, 8),
                IdRepartitionBande = context.RepartitionBande.FirstOrDefault().Id,
                IdTypePesee = context.TypePesee.FirstOrDefault(t => t.Libelle == "Individuelle").Id
                
            });

            context.Pesee.AddOrUpdate(p => p.Date, new Pesee
            {
                NombreDeSujetsPeses = 136,
                PoidsMoyen = 1610,
                Homogeneite = 89,
                Date = new DateTime(2017, 08, 15),
                IdRepartitionBande = context.RepartitionBande.FirstOrDefault().Id,
                IdTypePesee = context.TypePesee.FirstOrDefault(t => t.Libelle == "Individuelle").Id

            });

            #endregion
        }
    }
}
