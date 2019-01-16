using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Exam.Models
{
    public class Livres
    {
        [Key]
        public int ID_Livres { get; set; }
        [Required(ErrorMessage = "Le champs doit être rempli.")]
        [Display(Name = "Titre")]
        public string L_Titre { get; set; }
        [Display(Name = "Edition")]
        public string L_Edition { get; set; }
        [Required(ErrorMessage = "Le champs doit être rempli.")]
        [Display(Name = "Auteur")]
        public int ID_Auteur { get; set; }
        [Display(Name = "Serie")]
        public int ID_Serie { get; set; }
        [Display(Name = "Genre")]
        public int ID_Genre { get; set; }



        public virtual Auteurs Auteur { get; set; }
        public virtual Series Serie { get; set; }
        public virtual ICollection<Liaisons_Genres> ID_LGenre { get; set; }
    }
}