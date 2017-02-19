namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        ChannelId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.ChannelId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.OAuth2Token",
                c => new
                    {
                        OAuth2TokenId = c.Int(nullable: false, identity: true),
                        ChannelId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AccessToken = c.String(),
                        TokenType = c.String(),
                        RefreshToken = c.String(),
                        TokenExpiresAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.OAuth2TokenId)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ChannelId)
                .Index(t => t.UserId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OAuth2Token", "UserId", "dbo.Users");
            DropForeignKey("dbo.OAuth2Token", "ChannelId", "dbo.Channels");
            DropForeignKey("dbo.UserChannels", "Channel_ChannelId", "dbo.Channels");
            DropForeignKey("dbo.UserChannels", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserChannels", new[] { "Channel_ChannelId" });
            DropIndex("dbo.UserChannels", new[] { "User_UserId" });
            DropIndex("dbo.OAuth2Token", new[] { "UserId" });
            DropIndex("dbo.OAuth2Token", new[] { "ChannelId" });
            DropIndex("dbo.Channels", new[] { "Name" });
            DropTable("dbo.UserChannels");
            DropTable("dbo.OAuth2Token");
            DropTable("dbo.Users");
            DropTable("dbo.Channels");
        }
    }
}
