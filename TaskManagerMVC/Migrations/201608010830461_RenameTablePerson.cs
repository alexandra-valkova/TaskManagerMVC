namespace TaskManagerMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenameTablePerson : DbMigration
    {
        public override void Up()
        {
            RenameTable("Person", "Persons");
        }
        
        public override void Down()
        {
            RenameTable("Persons", "Person");
        }
    }
}
