namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParticipantsMeeting",
                c => new
                    {
                        Tbl_Id = c.Int(nullable: false, identity: true),
                        Prticipants_Id = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Tbl_Id)
                .ForeignKey("dbo.Meeting", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParticipantsMeeting", "Id", "dbo.Meeting");
            DropIndex("dbo.ParticipantsMeeting", new[] { "Id" });
            DropTable("dbo.ParticipantsMeeting");
        }
    }
}
