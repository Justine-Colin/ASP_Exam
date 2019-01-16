namespace ASP_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Liaisons_Genres", "LG_Genre_ID_Genres", "dbo.Genres");
            DropForeignKey("dbo.Liaisons_Genres", "LG_Livre_ID_Livres", "dbo.Livres");
            DropIndex("dbo.Liaisons_Genres", new[] { "LG_Genre_ID_Genres" });
            DropIndex("dbo.Liaisons_Genres", new[] { "LG_Livre_ID_Livres" });
            CreateTable(
                "dbo.GenresLivres",
                c => new
                    {
                        Genres_ID_Genres = c.Int(nullable: false),
                        Livres_ID_Livres = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genres_ID_Genres, t.Livres_ID_Livres })
                .ForeignKey("dbo.Genres", t => t.Genres_ID_Genres, cascadeDelete: true)
                .ForeignKey("dbo.Livres", t => t.Livres_ID_Livres, cascadeDelete: true)
                .Index(t => t.Genres_ID_Genres)
                .Index(t => t.Livres_ID_Livres);
            
            DropColumn("dbo.Livres", "ID_LGenre");
            DropTable("dbo.Liaisons_Genres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Liaisons_Genres",
                c => new
                    {
                        ID_Liaisons_Genres = c.Int(nullable: false, identity: true),
                        LG_Genre_ID_Genres = c.Int(),
                        LG_Livre_ID_Livres = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Liaisons_Genres);
            
            AddColumn("dbo.Livres", "ID_LGenre", c => c.Int(nullable: false));
            DropForeignKey("dbo.GenresLivres", "Livres_ID_Livres", "dbo.Livres");
            DropForeignKey("dbo.GenresLivres", "Genres_ID_Genres", "dbo.Genres");
            DropIndex("dbo.GenresLivres", new[] { "Livres_ID_Livres" });
            DropIndex("dbo.GenresLivres", new[] { "Genres_ID_Genres" });
            DropTable("dbo.GenresLivres");
            CreateIndex("dbo.Liaisons_Genres", "LG_Livre_ID_Livres");
            CreateIndex("dbo.Liaisons_Genres", "LG_Genre_ID_Genres");
            AddForeignKey("dbo.Liaisons_Genres", "LG_Livre_ID_Livres", "dbo.Livres", "ID_Livres");
            AddForeignKey("dbo.Liaisons_Genres", "LG_Genre_ID_Genres", "dbo.Genres", "ID_Genres");
        }
    }
}
