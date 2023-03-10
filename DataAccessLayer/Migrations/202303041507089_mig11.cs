namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminName", c => c.String(maxLength: 30));
            AddColumn("dbo.Admins", "AdminPhoneNumber", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminPhoneNumber");
            DropColumn("dbo.Admins", "AdminName");
        }
    }
}
