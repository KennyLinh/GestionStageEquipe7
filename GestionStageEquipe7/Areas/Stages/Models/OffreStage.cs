using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Areas.Stages.Models
{
    public class OffresStage
    {

        //
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid OffreStageId { get; set; }

        [ForeignKey("EmployeurId")]
        public Employeur Employeur { get; set; }

        [StringLength(50, ErrorMessage = "Vous devez entrer moins de caractères")]
        [Required(ErrorMessage = "Veuillez indiquer le titre de l'offre de stage")]
        public string TitreOffreStage { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer la date de début de stage")]
        [Display(Name = "Date début du stage")]
        public DateTime OffreStageDateDebut { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer la date de fin de stage")]
        [Display(Name = "Date fin du stage")]
        public DateTime OffreStageDateFin { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer un statut")]
        [Display(Name = "Statut de l'offre de stage")]
        public bool Actif { get; set; }



        public ICollection<EtudiantOffreStage> EtudiantOffreStages { get;set; }
    }
}
