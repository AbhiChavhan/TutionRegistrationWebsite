namespace TutionRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approvedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Approved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Approved");
        }
    }
}
