using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class RepartitionBande
    {
        public int Id { get; set; }
        public int EffectifInitial { get; set; }
        public int EffectifActuel { get; set; }
        public int TotalMortalite { get; set; }
        public string Description { get; set; }
        public string Nom { get; set; }
        public int IdBande { get; set; }
        [ForeignKey("IdBande")]
        public Bande Bande { get; set; }
        public int IdBatiment { get; set; }                                                 
        [ForeignKey("IdBatiment")]
        public Batiment Batiment { get; set; }
        public virtual ICollection<Mortalite> Mortalites { get; set; }
        public virtual ICollection<Consommation> Consommations { get; set; }
        public virtual ICollection<HistoriquePathologie> HistoriquePathologie { get; set; }
        public virtual ICollection<Pesee> Pesees { get; set; }
        public virtual ICollection<ProductionOeuf> ProductionOeufs { get; set; }
        public virtual ICollection<VenteVolailles> VenteVolailles { get; set; }
    }
}