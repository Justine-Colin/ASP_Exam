namespace ASP_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livres", "Nom", c => c.String(nullable: false));
            AlterColumn("dbo.Auteurs", "A_Nom", c => c.String(nullable: false));
            AlterColumn("dbo.Auteurs", "A_Prenom", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "G_Nom", c => c.String(nullable: false));
            AlterColumn("dbo.Series", "S_Nom", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Series", "S_Nom", c => c.String());
            AlterColumn("dbo.Genres", "G_Nom", c => c.String());
            AlterColumn("dbo.Auteurs", "A_Prenom", c => c.String());
            AlterColumn("dbo.Auteurs", "A_Nom", c => c.String());
            DropColumn("dbo.Livres", "Nom");
        }
    }
}
