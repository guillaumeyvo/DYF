using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class HistoriqueUtilisationProduit
    {
        public int Id { get; set; }
        public double PourcentageUtilise { get; set; }
        public DateTime Date { get; set; }
        public int IdAchat { get; set; }
        [ForeignKey("IdAchat")]
        public Achat Achat { get; set; }
        public int IdProduit { get; set; }
        [ForeignKey("IdProduit")]
        public Produit Produit { get; set; }
        public int IdRepartitionBande { get; set; }
        [ForeignKey("IdRepartitionBande")]
        public RepartitionBande RepartitionBande { get; set; }
    }
}