namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_createdToTagToDoLists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TagToDoLists", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TagToDoLists", "Created");
        }
    }
}
