namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColoumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meeting", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meeting", "EndTime");
        }
    }
}
