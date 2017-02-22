namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class Added_position_forLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoLists", "Position", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoLists", "Position");
        }
    }
}
