using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Areas.Stages.Models
{
    public class Employeur
    {
        public Guid intmployeurId { get; set; }
        public string NomEmployeur { get; set; }
        public bool Actif { get; set; }
    }
}
