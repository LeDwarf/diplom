namespace PythonJsonDeserializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrelloBoards",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrelloCards",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Closed = c.String(),
                        DateLastActivity = c.String(),
                        ListId = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrelloLists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Closed = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrelloLists");
            DropTable("dbo.TrelloCards");
            DropTable("dbo.TrelloBoards");
        }
    }
}
