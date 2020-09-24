using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GestionStageEquipe7.Areas.Stages.Models
{

    [Table("TypesEmployeur", Schema = "dbo") ]
    public class TypeEmployeur
    {

        [Key]
        public int TypeEmployeurId { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Veuillez indiquer un type d'employeur")]
        [Display(Description = "Type de l'employeur")]

        public string DescriptionTypeEmployeur { get; set; }

        public ICollection<Employeur> Employeurs { get; set; }



    }
}
