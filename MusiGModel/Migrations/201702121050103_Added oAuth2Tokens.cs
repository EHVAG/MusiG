namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedoAuth2Tokens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.oAuth2Token",
                c => new
                    {
                        oAuth2TokenId = c.Int(nullable: false, identity: true),
                        ChannelId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AccessToken = c.String(),
                        TokenType = c.String(),
                        RefreshToken = c.String(),
                        CreatedDateTime = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.oAuth2TokenId)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ChannelId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.oAuth2Token", "UserId", "dbo.Users");
            DropForeignKey("dbo.oAuth2Token", "ChannelId", "dbo.Channels");
            DropIndex("dbo.oAuth2Token", new[] { "UserId" });
            DropIndex("dbo.oAuth2Token", new[] { "ChannelId" });
            DropTable("dbo.oAuth2Token");
        }
    }
}
