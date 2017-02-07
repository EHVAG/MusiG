namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUserfromChannel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Channels", "UserAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Channels", "UserAccountId", c => c.Int(nullable: false));
        }
    }
}
