namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedrelationbetweenChannelandChannelAuthMethod : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChannelChannelAuthMethods", "Channel_ChannelId", "dbo.Channels");
            DropForeignKey("dbo.ChannelChannelAuthMethods", "ChannelAuthMethod_ChannelAuthMethodID", "dbo.ChannelAuthMethods");
            DropIndex("dbo.ChannelChannelAuthMethods", new[] { "Channel_ChannelId" });
            DropIndex("dbo.ChannelChannelAuthMethods", new[] { "ChannelAuthMethod_ChannelAuthMethodID" });
            AddColumn("dbo.Channels", "ChannelAuthMethodId_ChannelAuthMethodID", c => c.Int());
            CreateIndex("dbo.Channels", "ChannelAuthMethodId_ChannelAuthMethodID");
            AddForeignKey("dbo.Channels", "ChannelAuthMethodId_ChannelAuthMethodID", "dbo.ChannelAuthMethods", "ChannelAuthMethodID");
            DropColumn("dbo.Channels", "ChannelAuthMethodId");
            DropTable("dbo.ChannelChannelAuthMethods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ChannelChannelAuthMethods",
                c => new
                    {
                        Channel_ChannelId = c.Int(nullable: false),
                        ChannelAuthMethod_ChannelAuthMethodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Channel_ChannelId, t.ChannelAuthMethod_ChannelAuthMethodID });
            
            AddColumn("dbo.Channels", "ChannelAuthMethodId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Channels", "ChannelAuthMethodId_ChannelAuthMethodID", "dbo.ChannelAuthMethods");
            DropIndex("dbo.Channels", new[] { "ChannelAuthMethodId_ChannelAuthMethodID" });
            DropColumn("dbo.Channels", "ChannelAuthMethodId_ChannelAuthMethodID");
            CreateIndex("dbo.ChannelChannelAuthMethods", "ChannelAuthMethod_ChannelAuthMethodID");
            CreateIndex("dbo.ChannelChannelAuthMethods", "Channel_ChannelId");
            AddForeignKey("dbo.ChannelChannelAuthMethods", "ChannelAuthMethod_ChannelAuthMethodID", "dbo.ChannelAuthMethods", "ChannelAuthMethodID", cascadeDelete: true);
            AddForeignKey("dbo.ChannelChannelAuthMethods", "Channel_ChannelId", "dbo.Channels", "ChannelId", cascadeDelete: true);
        }
    }
}
