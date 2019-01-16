namespace ASP_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Livres", "L_Titre", c => c.String(nullable: false));
            DropColumn("dbo.Livres", "Nom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livres", "Nom", c => c.String(nullable: false));
            AlterColumn("dbo.Livres", "L_Titre", c => c.String());
        }
    }
}
