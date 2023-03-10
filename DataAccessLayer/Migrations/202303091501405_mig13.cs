namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogContent2", c => c.String());
            AddColumn("dbo.Blogs", "BlogContent3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogContent3");
            DropColumn("dbo.Blogs", "BlogContent2");
        }
    }
}
