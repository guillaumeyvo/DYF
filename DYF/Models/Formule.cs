using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class Formule
    {
        public int Id { get; set; }
        public int Quantite { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MatierePremiere> MatierePremiere { get; set; }
        public virtual ICollection<Consommation> Consommation { get; set; }

    }
}