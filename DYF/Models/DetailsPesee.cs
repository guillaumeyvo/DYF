using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class DetailsPesee
    {
        public int Id { get; set; }
        public int Poids { get; set; }
        public int NombreDeSujets { get; set; }
        public int IdPesee { get; set; }
        [ForeignKey("IdPesee")]
        public virtual Pesee Pesee { get; set; }
    }
}