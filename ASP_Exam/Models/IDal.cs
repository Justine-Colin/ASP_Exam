using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_Exam.Models;

namespace ASP_Exam.Models
{
    public interface IDal : IDisposable
    {
        //Livres :
        List<Livres> SearchLivre(string str);
        List<Genres> GetGenres(int? id);
    }
}