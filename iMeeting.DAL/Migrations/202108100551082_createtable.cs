namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meeting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Agenda = c.String(maxLength: 1000),
                        Notes = c.String(maxLength: 1000),
                        File = c.String(),
                        Links = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Location = c.String(),
                        Participants = c.String(),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Meeting");
        }
    }
}
