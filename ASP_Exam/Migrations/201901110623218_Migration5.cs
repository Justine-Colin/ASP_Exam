namespace ASP_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GenresLivres", "Genres_ID_Genres", "dbo.Genres");
            DropForeignKey("dbo.GenresLivres", "Livres_ID_Livres", "dbo.Livres");
            DropIndex("dbo.GenresLivres", new[] { "Genres_ID_Genres" });
            DropIndex("dbo.GenresLivres", new[] { "Livres_ID_Livres" });
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
            
            AddColumn("dbo.Livres", "ID_Genre", c => c.Int(nullable: false));
            DropTable("dbo.GenresLivres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenresLivres",
                c => new
                    {
                        Genres_ID_Genres = c.Int(nullable: false),
                        Livres_ID_Livres = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genres_ID_Genres, t.Livres_ID_Livres });
            
            DropForeignKey("dbo.Liaisons_Genres", "LG_Livre_ID_Livres", "dbo.Livres");
            DropForeignKey("dbo.Liaisons_Genres", "LG_Genre_ID_Genres", "dbo.Genres");
            DropIndex("dbo.Liaisons_Genres", new[] { "LG_Livre_ID_Livres" });
            DropIndex("dbo.Liaisons_Genres", new[] { "LG_Genre_ID_Genres" });
            DropColumn("dbo.Livres", "ID_Genre");
            DropTable("dbo.Liaisons_Genres");
            CreateIndex("dbo.GenresLivres", "Livres_ID_Livres");
            CreateIndex("dbo.GenresLivres", "Genres_ID_Genres");
            AddForeignKey("dbo.GenresLivres", "Livres_ID_Livres", "dbo.Livres", "ID_Livres", cascadeDelete: true);
            AddForeignKey("dbo.GenresLivres", "Genres_ID_Genres", "dbo.Genres", "ID_Genres", cascadeDelete: true);
        }
    }
}
