namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdddTestingTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meeting_Participants", "Id", "dbo.Meeting");
            DropIndex("dbo.Meeting_Participants", new[] { "Id" });
            CreateTable(
                "dbo.Testing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
           // DropTable("dbo.Meeting_Participants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Meeting_Participants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Tbl_Id = c.Int(nullable: false),
                        Prticipants_Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Testing");
            CreateIndex("dbo.Meeting_Participants", "Id");
            AddForeignKey("dbo.Meeting_Participants", "Id", "dbo.Meeting", "Id");
        }
    }
}
