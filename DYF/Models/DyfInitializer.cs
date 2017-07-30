using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class DyfInitializer : DropCreateDatabaseAlways<DyfContext>
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
            // Creer RaceVolaille
            //Achat bande de pondeuse
            // creer batiment
            //Creer une bande

            #region Bande
            List<RepartitionBande> listeRepartitionBande = new List<RepartitionBande>
            {
                new RepartitionBande { Nom = "Pondeuse"},
                new RepartitionBande { Nom = "Poulet de chair"},
                new RepartitionBande { Nom = "Pintade"}
            };
            foreach (TypeVolaille item in listeTypeVolaille)
                context.TypeVolaille.Add(item);
            #endregion


            base.Seed(context);
        }
    }
}