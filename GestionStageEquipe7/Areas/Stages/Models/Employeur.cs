using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Areas.Stages.Models
{
    [Table("Employeurs", Schema = "dbo")]

    public class Employeur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        

        public Guid EmployeurId { get; set; }
        [StringLength(200,ErrorMessage ="Vous devez entrez moins de caractères")]
     

        [Display(Name = "Nom")]
        public string NomEmployeur { get; set; }


        public int? TypeEmployeurId { get; set; }

        [Display(Name = "Type employé")]
        public TypeEmployeur TypeEmployeur { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer un statut")]
        [Display(Description = "Statut de l'employé")]

        public bool Actif { get; set; }

        public ICollection<EmployeurMissionEmployeur> EmployeursMissionEmployeur { get; set; }

    }
}
