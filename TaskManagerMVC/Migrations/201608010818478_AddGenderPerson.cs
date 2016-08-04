namespace TaskManagerMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddGenderPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("Person", "Gender", p => p.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("Person", "Gender");
        }
    }
}
