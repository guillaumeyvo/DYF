using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class VenteOeuf
    {
        public int Id { get; set; }
        public int NombreDePlaquettes { get; set; }
        public int NombreDOeuf { get; set; }
        public DateTime DateDeVente { get; set; }
        public int PrixUnitaire { get; set; }
        public int IdRepartitionBande { get; set; }
        [ForeignKey("IdRepartitionBande")]
        public RepartitionBande RepartitionBande { get; set; }
    }
}