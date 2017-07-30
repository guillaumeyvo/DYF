using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class VenteVolailles
    {
        public int Id { get; set; }
        public int NombreDeVolailles { get; set; }
        public DateTime Date { get; set; }
        public double PrixUnitaire { get; set; }
        public int IdRepartitionBande { get; set; }
        [ForeignKey("IdRepartitionBande")]
        public RepartitionBande RepartitionBande { get; set; }
    }
}