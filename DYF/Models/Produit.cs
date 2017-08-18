using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYF.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string LibelleUnite { get; set; }
        public int IdTypeProduit { get; set; }

        [ForeignKey("IdTypeProduit")]
        public TypeProduit TypeProduit { get; set; }
        public virtual ICollection<CoutProduit> CoutProduit { get; set; }
        public virtual ICollection<Achat> Achats { get; set; }
        public virtual ICollection<Fournisseur> Fournisseurs { get; set; }


    }
}