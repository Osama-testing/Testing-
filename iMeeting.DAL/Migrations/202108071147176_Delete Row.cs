namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRow : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Venue", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venue", "IsActive", c => c.Int(nullable: false));
        }
    }
}
