namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTable : DbMigration
    {
        public override void Up()
        {
            DropTable("Meeting_Participants");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meeting_Participants", "Id", "dbo.Meeting");
            DropIndex("dbo.Meeting_Participants", new[] { "Id" });
            DropPrimaryKey("dbo.Meeting_Participants");
            AlterColumn("dbo.Meeting_Participants", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Meeting_Participants", "Id");
        }
    }
}
