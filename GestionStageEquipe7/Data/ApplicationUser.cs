using GestionStageEquipe7.Areas.Stages.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Data
{
    public class ApplicationUser : IdentityUser
    {
        //
        [StringLength(500)]
        public string Notes { get; set; }

        public ICollection<EtudiantOffreStage> EtudiantOffreStage { get; set; }
    }
}
