using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYF.Models
{
    public class ReferencePoidsMoyen
    {
        public int Id { get; set; }
        public int AgeEnSeamine { get; set; }
        public double PoidsMoyen { get; set; }
        public int IdRaceVolaille { get; set; }
        [ForeignKey("IdRaceVolaille")]
        public RaceVolaille RaceVolaille { get; set; }

    }
}