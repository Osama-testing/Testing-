namespace iMeeting.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Designation", c => c.String());

        }

        public override void Down()
        {
        }
    }
}
