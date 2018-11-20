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
        public string L_Titre { get; set; }
        public string L_Edition { get; set; }
        public int ID_Auteur { get; set; }
        public int ID_Serie { get; set; }
        public int ID_LGenre { get; set; }

        public virtual Auteurs Auteur { get; set; }
        public virtual ICollection<Liaisons_Genres> LGenre { get; set; }
    }
}