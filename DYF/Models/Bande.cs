using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class Bande
    {
        public int Id { get; set; }
        public int EffectifInitial { get; set; }
        public DateTime DateArrivee { get; set; }
        public DateTime DateSortie { get; set; }
        public String Nom { get; set; }
        public string Description { get; set; }
        public bool B_Actif { get; set; }
        public bool B_VenteTotale { get; set; }
        public int IdTypeVolaille { get; set; }
        [ForeignKey("IdTypeVolaille")]
        public TypeVolaille TypeVolaille { get; set; }

        public int IdRaceVolaille { get; set; }
        [ForeignKey("IdRaceVolaille")]
        public RaceVolaille RaceVolaille { get; set; }
            
        public int IdAchat { get; set; }

        [ForeignKey("IdAchat")]
        public Achat Achat { get; set; }

        public virtual ICollection<RepartitionBande> RepartitionBande { get; set; }
        public virtual ICollection<VenteOeuf> VenteOeuf { get; set; }

    }
}
