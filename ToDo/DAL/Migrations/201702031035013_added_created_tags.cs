namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_created_tags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "Created");
        }
    }
}
