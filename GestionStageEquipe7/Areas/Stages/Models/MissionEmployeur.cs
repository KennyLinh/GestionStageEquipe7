using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Areas.Stages.Models
{

    [Table("MissionsEmployeur", Schema = "dbo")]
    public class MissionEmployeur
    {

        public int MissionEmployeurId { get; set; }

        [StringLength(10, ErrorMessage ="Veuillez entrer moins de caratères")]
        [Required(ErrorMessage ="Veuillez entrer une description detaillé")]

        public string DescriptionMissionEmployeur { get; set; }

        public ICollection<EmployeurMissionEmployeur> EmployeursMissionEmployeur { get; set; }

    }
}
