namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OAuth2Token", "ChannelId", "dbo.Channels");
            DropForeignKey("dbo.OAuth2Token", "UserId", "dbo.Users");
            DropIndex("dbo.OAuth2Token", new[] { "ChannelId" });
            DropIndex("dbo.OAuth2Token", new[] { "UserId" });
            CreateTable(
                "dbo.OAuth2Token123",
                c => new
                    {
                        OAuth2TokenId123 = c.Int(nullable: false, identity: true),
                        ChannelId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AccessToken = c.String(),
                        TokenType = c.String(),
                        RefreshToken = c.String(),
                        TokenExpiresAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.OAuth2TokenId123)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ChannelId)
                .Index(t => t.UserId);
            
            DropTable("dbo.OAuth2Token");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.OAuth2TokenId);
            
            DropForeignKey("dbo.OAuth2Token123", "UserId", "dbo.Users");
            DropForeignKey("dbo.OAuth2Token123", "ChannelId", "dbo.Channels");
            DropIndex("dbo.OAuth2Token123", new[] { "UserId" });
            DropIndex("dbo.OAuth2Token123", new[] { "ChannelId" });
            DropTable("dbo.OAuth2Token123");
            CreateIndex("dbo.OAuth2Token", "UserId");
            CreateIndex("dbo.OAuth2Token", "ChannelId");
            AddForeignKey("dbo.OAuth2Token", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.OAuth2Token", "ChannelId", "dbo.Channels", "ChannelId", cascadeDelete: true);
        }
    }
}
