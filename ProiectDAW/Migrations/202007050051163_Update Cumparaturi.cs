namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCumparaturi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Marks", "StudentId", "dbo.Students");
            DropIndex("dbo.Marks", new[] { "StudentId" });
            CreateTable(
                "dbo.Shoppings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Price = c.Single(nullable: false),
                        Basket = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Marks");
            DropTable("dbo.Students");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CNP = c.String(maxLength: 13),
                        Email = c.String(nullable: false),
                        City = c.String(),
                        Vocation = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        MarkId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MarkId);
            
            DropTable("dbo.Shoppings");
            CreateIndex("dbo.Marks", "StudentId");
            AddForeignKey("dbo.Marks", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
    }
}
