namespace TaskManagerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        TaskID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tasks", t => t.TaskID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.TaskID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        WorkingHours = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LastEditDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatorID = c.Int(nullable: false),
                        ResponsibleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.CreatorID)
                .ForeignKey("dbo.Users", t => t.ResponsibleID)
                .Index(t => t.CreatorID)
                .Index(t => t.ResponsibleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logworks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkingHours = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        TaskID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tasks", t => t.TaskID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.TaskID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ResponsibleID", "dbo.Users");
            DropForeignKey("dbo.Tasks", "CreatorID", "dbo.Users");
            DropForeignKey("dbo.Logworks", "UserID", "dbo.Users");
            DropForeignKey("dbo.Logworks", "TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "TaskID", "dbo.Tasks");
            DropIndex("dbo.Logworks", new[] { "UserID" });
            DropIndex("dbo.Logworks", new[] { "TaskID" });
            DropIndex("dbo.Tasks", new[] { "ResponsibleID" });
            DropIndex("dbo.Tasks", new[] { "CreatorID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "TaskID" });
            DropTable("dbo.Logworks");
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Comments");
        }
    }
}
