using System.Collections.Generic;

namespace DYF.Models
{
    public class TypeProduit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
    }
}