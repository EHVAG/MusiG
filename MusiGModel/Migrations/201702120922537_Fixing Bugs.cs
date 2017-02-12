namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingBugs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAccounts", "Source_ChannelId", "dbo.Channels");
            DropForeignKey("dbo.UserAccounts", "UserId", "dbo.Users");
            DropIndex("dbo.UserAccounts", new[] { "UserId" });
            DropIndex("dbo.UserAccounts", new[] { "Source_ChannelId" });
            CreateTable(
                "dbo.UserChannels",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Channel_ChannelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Channel_ChannelId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Channels", t => t.Channel_ChannelId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Channel_ChannelId);
            
            DropTable("dbo.UserAccounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserAccountId = c.Int(nullable: false, identity: true),
                        SourceId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Source_ChannelId = c.Int(),
                    })
                .PrimaryKey(t => t.UserAccountId);
            
            DropForeignKey("dbo.UserChannels", "Channel_ChannelId", "dbo.Channels");
            DropForeignKey("dbo.UserChannels", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserChannels", new[] { "Channel_ChannelId" });
            DropIndex("dbo.UserChannels", new[] { "User_UserId" });
            DropTable("dbo.UserChannels");
            CreateIndex("dbo.UserAccounts", "Source_ChannelId");
            CreateIndex("dbo.UserAccounts", "UserId");
            AddForeignKey("dbo.UserAccounts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserAccounts", "Source_ChannelId", "dbo.Channels", "ChannelId");
        }
    }
}
