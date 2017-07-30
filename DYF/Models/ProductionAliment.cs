using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class ProductionAliment
    {
        public int Id { get; set; }
        public int NombreDeTonne { get; set; }
        public DateTime Date { get; set; }
        public double CoutDeRevientParSac { get; set; }
        public int NombreDeSac { get; set; }
        public int IdFormule { get; set; }

        [ForeignKey("IdFormule")]
        public Formule Formule { get; set; }

        public virtual ICollection<Consommation> Consommation { get; set; }
    }
}