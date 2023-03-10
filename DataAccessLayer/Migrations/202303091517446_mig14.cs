namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogTitle2", c => c.String(maxLength: 100));
            AddColumn("dbo.Blogs", "BlogTitle3", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogTitle3");
            DropColumn("dbo.Blogs", "BlogTitle2");
        }
    }
}
