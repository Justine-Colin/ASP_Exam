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
        public string S_Nom { get; set; }
        public int S_Taille { get; set; }
        public bool S_Fini { get; set; }
        public bool S_Complet { get; set; }

        public virtual ICollection<Livres> S_Livres { get; set; }
    }
}