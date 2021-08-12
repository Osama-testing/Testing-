namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatatype1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meeting", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meeting", "DateTime", c => c.String());
        }
    }
}
