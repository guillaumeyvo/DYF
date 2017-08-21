using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class CoutProduit
    {
        public int Id { get; set; }
        public double PrixUnitaire { get; set; }
        public DateTime Date { get; set; }
        public int IdProduit { get; set; }
        [ForeignKey("IdProduit")]
        public virtual  Produit Produit { get; set; }
        public int IdTypeProduit { get; set; }
        [ForeignKey("IdTypeProduit")]
        public virtual  TypeProduit TypeProduit { get; set; }
        public int IdFournisseur { get; set; }
        [ForeignKey("IdFournisseur")]
        public virtual Fournisseur Fournisseur { get; set; }
    }
}