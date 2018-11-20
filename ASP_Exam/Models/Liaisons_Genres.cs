using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Exam.Models
{
    public class Liaisons_Genres
    {
        [Key]
        public int ID_Liaisons_Genres { get; set; }

        public virtual Livres LG_Livre { get; set; }
        public virtual Genres LG_Genre { get; set; }
    }
}