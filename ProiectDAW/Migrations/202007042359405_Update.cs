namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Vocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Vocation");
        }
    }
}
