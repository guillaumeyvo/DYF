using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class HistoriqueRepartitionBande
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NombreDeSujetAjoute { get; set; }
        public int IdBatiment { get; set; }
        [ForeignKey("IdBatiment")]
        public virtual Batiment Batiment { get; set; }
        public int IdRepartitionBande { get; set; }
        [ForeignKey("IdRepartitionBande")]
        public virtual RepartitionBande RepartitionBande { get; set; }
    }
}