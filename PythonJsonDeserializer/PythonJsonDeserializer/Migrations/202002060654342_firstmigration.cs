namespace PythonJsonDeserializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrelloLists", "BoardId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrelloLists", "BoardId");
        }
    }
}
