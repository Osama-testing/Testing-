namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MeetingModels", newName: "Meeting");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Meeting", newName: "MeetingModels");
        }
    }
}
