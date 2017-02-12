namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMistake : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Channels", "ChannelAuthMethodId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Channels", "ChannelAuthMethodId", c => c.Int(nullable: false));
        }
    }
}
