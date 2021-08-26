namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());

        }

        public override void Down()
        {
        }
    }
}
