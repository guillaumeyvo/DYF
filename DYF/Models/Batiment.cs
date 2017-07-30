using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class Batiment
    {
        public int Id { get; set; }
        public bool B_Occupe { get; set; }
        public int Effectif_Maximum { get; set; }
        public string Description { get; set; }
        public string Nom { get; set; }

    }
}