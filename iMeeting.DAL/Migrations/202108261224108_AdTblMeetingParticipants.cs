namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdTblMeetingParticipants : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meeting_Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prticipants_Id = c.Int(nullable: false),
                        Meeting_Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Meeting_Participants");
        }
    }
}
