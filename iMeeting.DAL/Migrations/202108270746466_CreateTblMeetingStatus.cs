namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTblMeetingStatus : DbMigration
    {
        public override void Up()
        {
          //  DropForeignKey("dbo.ParticipantsMeeting", "Id", "dbo.Meeting");
          //  DropIndex("dbo.ParticipantsMeeting", new[] { "Id" });
            CreateTable(
                "dbo.Meeting_Participants",
                c => new
                    {
                        Table_Id = c.Int(nullable: false, identity: true),
                        Prticipants_Id = c.String(),
                        Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Table_Id)
                .ForeignKey("dbo.Meeting", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
           // DropTable("dbo.ParticipantsMeeting");
            DropTable("dbo.Testing");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Testing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParticipantsMeeting",
                c => new
                    {
                        Tbl_Id = c.Int(nullable: false, identity: true),
                        Prticipants_Id = c.String(),
                        Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Tbl_Id);
            
            DropForeignKey("dbo.Meeting_Participants", "Id", "dbo.Meeting");
            DropIndex("dbo.Meeting_Participants", new[] { "Id" });
            DropTable("dbo.Meeting_Participants");
            CreateIndex("dbo.ParticipantsMeeting", "Id");
            AddForeignKey("dbo.ParticipantsMeeting", "Id", "dbo.Meeting", "Id", cascadeDelete: true);
        }
    }
}
