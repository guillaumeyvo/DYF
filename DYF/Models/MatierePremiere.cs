using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class MatierePremiere
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Unite { get; set; }
        public virtual ICollection<Achat> Achats { get; set; }
        public virtual ICollection<Formule> Formules { get; set; }

    }
}