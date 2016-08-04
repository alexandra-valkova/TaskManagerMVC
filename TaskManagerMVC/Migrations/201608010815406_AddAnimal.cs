namespace TaskManagerMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddAnimal : DbMigration
    {
        public override void Up()
        {
            CreateTable("Animals", a => new { ID = a.Int(identity: true), Kind = a.String() });
        }
        
        public override void Down()
        {
            DropTable("Animals");
        }
    }
}
