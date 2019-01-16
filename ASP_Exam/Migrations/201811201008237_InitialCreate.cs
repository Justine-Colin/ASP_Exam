namespace ASP_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auteurs",
                c => new
                    {
                        ID_Auteur = c.Int(nullable: false, identity: true),
                        A_Nom = c.String(),
                        A_Prenom = c.String(),
                    })
                .PrimaryKey(t => t.ID_Auteur);
            
            CreateTable(
                "dbo.Livres",
                c => new
                    {
                        ID_Livres = c.Int(nullable: false, identity: true),
                        L_Titre = c.String(),
                        L_Edition = c.String(),
                        ID_Auteur = c.Int(nullable: false),
                        ID_Serie = c.Int(nullable: false),
                        ID_LGenre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Livres)
                .ForeignKey("dbo.Auteurs", t => t.ID_Auteur, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.ID_Serie, cascadeDelete: true)
                .Index(t => t.ID_Auteur)
                .Index(t => t.ID_Serie);
            
            CreateTable(
                "dbo.Liaisons_Genres",
                c => new
                    {
                        ID_Liaisons_Genres = c.Int(nullable: false, identity: true),
                        LG_Genre_ID_Genres = c.Int(),
                        LG_Livre_ID_Livres = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Liaisons_Genres)
                .ForeignKey("dbo.Genres", t => t.LG_Genre_ID_Genres)
                .ForeignKey("dbo.Livres", t => t.LG_Livre_ID_Livres)
                .Index(t => t.LG_Genre_ID_Genres)
                .Index(t => t.LG_Livre_ID_Livres);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID_Genres = c.Int(nullable: false, identity: true),
                        G_Nom = c.String(),
                    })
                .PrimaryKey(t => t.ID_Genres);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        ID_Serie = c.Int(nullable: false, identity: true),
                        S_Nom = c.String(),
                        S_Taille = c.Int(nullable: false),
                        S_Fini = c.Boolean(nullable: false),
                        S_Complet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Serie);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livres", "ID_Serie", "dbo.Series");
            DropForeignKey("dbo.Liaisons_Genres", "LG_Livre_ID_Livres", "dbo.Livres");
            DropForeignKey("dbo.Liaisons_Genres", "LG_Genre_ID_Genres", "dbo.Genres");
            DropForeignKey("dbo.Livres", "ID_Auteur", "dbo.Auteurs");
            DropIndex("dbo.Liaisons_Genres", new[] { "LG_Livre_ID_Livres" });
            DropIndex("dbo.Liaisons_Genres", new[] { "LG_Genre_ID_Genres" });
            DropIndex("dbo.Livres", new[] { "ID_Serie" });
            DropIndex("dbo.Livres", new[] { "ID_Auteur" });
            DropTable("dbo.Series");
            DropTable("dbo.Genres");
            DropTable("dbo.Liaisons_Genres");
            DropTable("dbo.Livres");
            DropTable("dbo.Auteurs");
        }
    }
}
