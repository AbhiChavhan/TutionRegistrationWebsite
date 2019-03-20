namespace TutionRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Batches", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Batches", "Duration", c => c.String(nullable: false));
            AlterColumn("dbo.Batches", "Timing", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Batches", "Timing", c => c.String());
            AlterColumn("dbo.Batches", "Duration", c => c.String());
            AlterColumn("dbo.Batches", "Name", c => c.String());
        }
    }
}
