namespace PythonJsonDeserializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrelloMembers", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrelloMembers", "Username");
        }
    }
}
