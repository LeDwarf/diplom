namespace PythonJsonDeserializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateDueMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrelloCards", "Due", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrelloCards", "Due");
        }
    }
}
