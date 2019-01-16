using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Exam.Models
{
    public class Genres
    {
        [Key]
        public int ID_Genres { get; set; }
        [Required(ErrorMessage = "Le champs doit être rempli.")]
        [Display(Name = "Genre")]
        public string G_Nom { get; set; }

        public virtual ICollection<Liaisons_Genres> LGenre { get; set; }
    }
}