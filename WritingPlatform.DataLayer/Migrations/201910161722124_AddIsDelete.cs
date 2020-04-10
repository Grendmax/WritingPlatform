namespace WritingPlatform.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDelete");
        }
    }
}
