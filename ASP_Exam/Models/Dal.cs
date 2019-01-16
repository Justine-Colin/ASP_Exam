using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_Exam.Models;

namespace ASP_Exam.Models
{
    public class Dal : IDal
    {
        private BiblioContext bdd;

        public Dal()
        {
            bdd = new BiblioContext();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        //Livres :
        public List<Livres> SearchLivre(string str)
        {
            List<Livres> ListeComplete = bdd.Livres.ToList();
            List<Livres> Recherche = new List<Livres>();
            foreach (Livres l in ListeComplete)
            {
                if(l.L_Titre.Contains(str))
                {
                    Recherche.Add(l);
                }
            }
            return Recherche;
        }

        public List<Genres> GetGenres(int? id)
        {
            //List<Liaisons_Genres> ListeComplete = bdd.Liaisons_Genres.ToList();
            List<Genres> GenresLivre = new List<Genres>();
            /*foreach ( Liaisons_Genres g in ListeComplete)
            {
                if(g.LG_Livre.ID_Livres ==  id)
                {
                    GenresLivre.Add(g.LG_Genre);
                }
            }*/
            return GenresLivre;
        } 
    }
}