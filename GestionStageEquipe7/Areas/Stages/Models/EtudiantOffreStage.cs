using GestionStageEquipe7.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Areas.Stages.Models
{
    [Table("EtudiantsOffresStage", Schema = "dbo")]
    public class EtudiantOffreStage
    {

        //
        [Key]
        public Guid OffresStageEtudiantId { get; set; }

        [StringLength(450)]
        [Required]

        public string Id { get; set; }

        public Guid OffreStageId { get; set; }

        [Display(Name = "Date de candidature")]
        public DateTime DateCandidature { get; set; }

        [ForeignKey("Id")]
        [Display(Name = "Utilisateur")]
        public ApplicationUser ApplicationUser { get; set; }



        [ForeignKey("OffreStageId")]
        [Display(Name = "Offres Stage")]
        public OffresStage OffresStage { get; set; }


        [Required(ErrorMessage = "Veuillez indiquer un statut")]
        [Display(Name = "Statut de la candidature")]

        public bool Actif { get; set; }


    }
}
