namespace PythonJsonDeserializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateDueCompleteMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrelloCards", "DueComplete", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrelloCards", "DueComplete");
        }
    }
}
