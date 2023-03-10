namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogImage2", c => c.String(maxLength: 200));
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(maxLength: 100));
            DropColumn("dbo.Blogs", "BlogImage2");
        }
    }
}
