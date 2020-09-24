using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Areas.Stages.Models
{
    

        [Table("EmployeursMissionsEmployeur", Schema = "dbo")]
    public class EmployeurMissionEmployeur
    {

        
        [Key]
        public int EmployeurMissionEmployeurId { get; set; }

        public Guid EmployeurId { get; set; }

        public int MissionEmployeurId { get; set; }

        public Employeur Employeurs { get; set; }

        public MissionEmployeur MissionsEmployeur { get; set; }
    }
}
