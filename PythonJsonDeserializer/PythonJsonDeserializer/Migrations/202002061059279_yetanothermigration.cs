namespace PythonJsonDeserializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yetanothermigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CardTerms", "Frequency", c => c.Int(nullable: false));
            AddColumn("dbo.CardTerms", "CardId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CardTerms", "CardId");
            DropColumn("dbo.CardTerms", "Frequency");
        }
    }
}
