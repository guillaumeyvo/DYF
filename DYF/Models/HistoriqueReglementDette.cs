using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class HistoriqueReglementDette
    {
        public int Id { get; set; }
        public DateTime DateReglement { get; set; }
        public int IdDette { get; set; }
        [ForeignKey("IdDette")]
        public Dette Dette { get; set; }
    }
}