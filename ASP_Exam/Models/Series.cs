using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Exam.Models
{
    public class Series
    {
        [Key]
        public int ID_Serie { get; set; }
        [Required(ErrorMessage = "Le champs doit être rempli.")]
        [Display(Name = "Titre")]
        public string S_Nom { get; set; }
        [Display(Name = "Nombre de tomes parus")]
        public int S_Taille { get; set; }
        [Display(Name = "Parution terminée")]
        public bool S_Fini { get; set; }
        [Display(Name = "Tous les tomes possédés")]
        public bool S_Complet { get; set; }

        public virtual ICollection<Livres> S_Livres { get; set; }
    }
}