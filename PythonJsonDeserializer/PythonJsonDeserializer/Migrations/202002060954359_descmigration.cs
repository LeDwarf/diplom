namespace PythonJsonDeserializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class descmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrelloCards", "Desc", c => c.String());
            DropColumn("dbo.TrelloCards", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrelloCards", "Description", c => c.String());
            DropColumn("dbo.TrelloCards", "Desc");
        }
    }
}
