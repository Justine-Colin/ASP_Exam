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
        public string A_Nom { get; set; }
        public string A_Prenom { get; set; }

        public virtual ICollection<Livres> A_Livres { get; set; }
    }
}