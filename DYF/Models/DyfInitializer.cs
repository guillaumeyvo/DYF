using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class DyfInitializer : DropCreateDatabaseIfModelChanges<DyfContext> // DropCreateDatabaseAlways
    {
        protected override void Seed(DyfContext context)
        {
            #region TypeVolaille
            List<TypeVolaille> listeTypeVolaille = new List<TypeVolaille>
            {
                new TypeVolaille { Nom = "Pondeuse"},
                new TypeVolaille { Nom = "Poulet de chair"},
                new TypeVolaille { Nom = "Pintade"}
            };
            foreach (TypeVolaille item in listeTypeVolaille)
                context.TypeVolaille.Add(item);
            context.SaveChanges();
            #endregion
            #region RaceVollaille

            context.RaceVolaille.Add(new RaceVolaille { Nom = "Loman" });
            context.SaveChanges();

            #endregion

            #region TypeProduit

            context.TypeProduit.Add(new TypeProduit { Nom = "Volailles" });
            context.SaveChanges();

            #endregion

            #region Produit

            context.Produit.Add(new Produit {
                Nom = "Pondeuses",
                LibelleUnite = "Sujets",
                IdTypeProduit = context.TypeProduit.FirstOrDefault(t => t.Nom == "Volailles").Id,
            });
            context.SaveChanges();

            #endregion

            #region Fournisseur

            context.Fournisseur.Add(new Fournisseur { Nom = "FACI" });
            context.SaveChanges();

            #endregion

            #region Achat
            // Achat bande de pondeuses
            context.Achat.Add(new Achat {
                PrixUnitaire = 570,
                Quantite = 3000,
                CoutTotal = 3000 * 570,
                MontantRegle = 3000 * 570 ,
                DateAchat = new DateTime(2017,5,1),
                DateLivraison = new DateTime(2017,5,10),
                IdFournisseur = context.Fournisseur.FirstOrDefault(t => t.Nom == "FACI").Id,
                IdProduit = context.Produit.FirstOrDefault(t => t.Nom == "Pondeuses").Id,
                IdTypeProduit = context.TypeProduit.FirstOrDefault(t => t.Nom == "Volailles").Id
            });
            context.SaveChanges();

            #endregion

            #region Batiment

            context.Batiment.Add(new Batiment {
                B_Occupe = true,
                Effectif_Maximum = 1500,
                Nom ="A"
            });
            context.Batiment.Add(new Batiment
            {
                B_Occupe = true,
                Effectif_Maximum = 1500,
                Nom = "B"
            });
            context.SaveChanges();

            #endregion

            #region Bande
            context.Bande.Add(new Bande
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
            context.RepartitionBande.AddRange(new List<RepartitionBande>
            {
                new RepartitionBande
                {
                   IdBatiment = context.Batiment.FirstOrDefault(b => b.Nom == "A").Id,
                   EffectifInitial = 1500,
                   EffectifActuel = 1500,
                   TotalMortalite = 0,
                   IdBande = context.Bande.FirstOrDefault().Id
                },
                new RepartitionBande
                {
                   IdBatiment = context.Batiment.FirstOrDefault(b => b.Nom == "B").Id,
                   EffectifInitial = 1500,
                   EffectifActuel = 1500,
                   TotalMortalite = 0,
                   IdBande = context.Bande.FirstOrDefault().Id
                }
            });
            context.SaveChanges();


            #endregion
            base.Seed(context);
        }
    }
}