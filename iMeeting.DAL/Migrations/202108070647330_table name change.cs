namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablenamechange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VenueModels", newName: "Metadata");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Metadata", newName: "VenueModels");
        }
    }
}
