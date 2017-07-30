using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class Dette
    {
        public int Id { get; set; }
        public DateTime DateContractation { get; set; }
        public bool B_Actif { get; set; }
        public int MontantInitial { get; set; }

        public int IdAchat { get; set; }
        [ForeignKey("IdAchat")]
        public Achat Achat { get; set; }
        public ICollection<HistoriqueReglementDette> HistoriqueReglementDette { get; set; }
    }
}