using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class TypePesee
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<Pesee> Pesee { get; set; }
    }
}