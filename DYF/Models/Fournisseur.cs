using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class Fournisseur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public DateTime DateAjout { get; set; }
        public virtual ICollection<Achat> Achats { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }


    }
}