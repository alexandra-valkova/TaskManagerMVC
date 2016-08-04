namespace TaskManagerMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPerson : DbMigration
    {
        public override void Up()
        {
            CreateTable("Person", p => new { ID = p.Int(identity: true) });
            AddColumn("Person", "Age", p => p.Int()); ;
        }
        
        public override void Down()
        {
            DropTable("Person");
        }
    }
}
