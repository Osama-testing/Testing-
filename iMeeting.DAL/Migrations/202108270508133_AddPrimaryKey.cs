namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrimaryKey : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Meeting", newName: "MeetingModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MeetingModels", newName: "Meeting");
        }
    }
}
