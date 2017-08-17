using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class Pesee
    {
        public int Id { get; set; }
        public int NombreDeSujetsPeses { get; set; }
        public double PoidsMoyen { get; set; }
        public double Homogeneite { get; set; }
        public DateTime Date { get; set; }
        public int AgeDesSujetEnSemaine { get; set; }
        public int IdRepartitionBande { get; set; }
        [ForeignKey("IdRepartitionBande")]
        public RepartitionBande RepartitionBande { get; set; }
        public int IdTypePesee { get; set; }
        [ForeignKey("IdTypePesee")]
        public TypePesee TypePesee { get; set; }
    }
}