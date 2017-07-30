using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class TypeVolaille
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<Bande> Bandes { get; set; }
    }
}