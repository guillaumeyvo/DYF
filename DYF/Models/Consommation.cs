using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class Consommation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NombreDeKilos { get; set; }
        public double CoutConsommation { get; set; }
        public int IdRepartitionBande { get; set; }

        [ForeignKey("IdRepartitionBande")]
        public virtual RepartitionBande RepartitionBande { get; set; }
        public int IdProductionAliment { get; set; }

        [ForeignKey("IdProductionAliment")]
        public virtual ProductionAliment ProductionAliment { get; set; }
        public int IdFormule { get; set; }

        [ForeignKey("IdFormule")]
        public virtual Formule Formule { get; set; }
    }
}