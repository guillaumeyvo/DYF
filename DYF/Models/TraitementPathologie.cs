using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class TraitementPathologie
    {
        public int Id { get; set; }
        public int IdHistoriquePathologie { get; set; }
        [ForeignKey("IdHistoriquePathologie")]
        public HistoriquePathologie HistoriquePathologie { get; set; }
        public int IdProduit { get; set; }
        [ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }
    }
}