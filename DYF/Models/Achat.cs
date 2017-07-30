using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class Achat
    {
        public int Id { get; set; }
        
        public int PrixUnitaire { get; set; }
        public int Quantite { get; set; }
        public int CoutTotal { get; set; }

        public int MontantRegle { get; set; }

        public DateTime DateAchat { get; set; }
        public DateTime DateLivraison { get; set; }

        public string Commentaires { get; set; }

        public int IdFournisseur { get; set; }

        [ForeignKey("IdFournisseur")]
        public Fournisseur Fournisseur { get; set; }

        public int IdProduit { get; set; }

        [ForeignKey("IdProduit")]
        public Produit Produit { get; set; }
        public int IdTypeProduit { get; set; }

        [ForeignKey("IdTypeProduit")]
        public TypeProduit TypeProduit { get; set; }
        public virtual ICollection<HistoriqueUtilisationProduit> HistoriqueUtilisationProduit { get; set; }
    }
}