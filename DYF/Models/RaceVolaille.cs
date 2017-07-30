using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class RaceVolaille
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public ICollection<Bande> Bande { get; set; }
    }
}