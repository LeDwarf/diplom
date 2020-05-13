namespace PythonJsonDeserializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membersMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrelloMembers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberCards",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(),
                        CardId = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemberCards");
            DropTable("dbo.TrelloMembers");
        }
    }
}
