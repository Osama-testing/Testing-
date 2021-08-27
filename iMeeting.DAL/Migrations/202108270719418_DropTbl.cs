namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTbl : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ParticipantsMeeting");
        }

        public override void Down()
        {
            AlterColumn("dbo.ParticipantsMeeting", "Prticipants_Id", c => c.Int(nullable: false));
        }
    }
}
