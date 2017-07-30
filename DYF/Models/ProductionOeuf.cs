using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class ProductionOeuf
    {
        public int Id { get; set; }
        public int NombreDOeufs { get; set; }
        public int NombreDOeufsCasses { get; set; }
        public int IdRepartitionBande { get; set; }
        [ForeignKey("IdRepartitionBande")]
        public RepartitionBande RepartitionBande { get; set; }

    }
}