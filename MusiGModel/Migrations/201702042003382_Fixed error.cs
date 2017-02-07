namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixederror : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ChannelAuthMethods", "ChannelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChannelAuthMethods", "ChannelId", c => c.Int(nullable: false));
        }
    }
}
