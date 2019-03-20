namespace TutionRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keyFieldAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ExamKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ExamKey");
        }
    }
}
