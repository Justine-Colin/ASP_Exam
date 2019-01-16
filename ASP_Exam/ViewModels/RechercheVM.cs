using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_Exam.Models;

namespace ASP_Exam.ViewModels
{
    public class RechercheVM
    {
        public List<Genres> LGenres { get; set; }
        public List<Livres> LLivres { get; set; }
    }
}