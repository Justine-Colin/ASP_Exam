using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Exam.Models
{
    public class Auteurs
    {
        [Key]
        public int ID_Auteur { get; set; }
        [Required(ErrorMessage = "Le champs doit être rempli.")]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        [Display(Name = "Nom")]
        public string A_Nom { get; set; }
        [Required(ErrorMessage = "Le champs doit être rempli.")]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        [Display(Name = "Prénom")]
        public string A_Prenom { get; set; }

        public virtual ICollection<Livres> A_Livres { get; set; }
    }
}