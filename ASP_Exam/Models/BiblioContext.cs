using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ASP_Exam.Models
{
    public class BiblioContext : DbContext
    {
        public DbSet<Auteurs> Auteurs { get; set; }        
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Livres> Livres { get; set; }
        public DbSet<Series> Series { get; set; }

    }
}