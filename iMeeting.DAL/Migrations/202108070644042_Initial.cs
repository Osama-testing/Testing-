namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VenueModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        Location = c.String(),
                        Limit = c.Int(nullable: false),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VenueModels");
        }
    }
}
