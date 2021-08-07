namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TblNameChange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Metadata", newName: "Venue");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Venue", newName: "Metadata");
        }
    }
}
