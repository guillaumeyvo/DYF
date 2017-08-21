using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class HistoriquePathologie
    {
        public int Id { get; set; }
        public DateTime DateDebutPathologie { get; set; }
        public DateTime DateDebutTraitementPathologie { get; set; }
        public bool B_Curratif { get; set; }
        public int IdPathologie { get; set; }
        [ForeignKey("IdPathologie")]
        public virtual Pathologie Pathologie { get; set; }
        public int IdRepartitionBande { get; set; }
        [ForeignKey("IdRepartitionBande")]
        public virtual RepartitionBande RepartitionBande { get; set; }
        public ICollection<TraitementPathologie> TraitementPathologie { get; set; }
    }
}