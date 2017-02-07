namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuthMethodsforchannels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAccounts", "SourceId", "dbo.Sources");
            DropIndex("dbo.UserAccounts", new[] { "SourceId" });
            CreateTable(
                "dbo.ChannelAuthMethods",
                c => new
                    {
                        ChannelAuthMethodID = c.Int(nullable: false, identity: true),
                        ChannelId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        AuthUrl = c.String(),
                        ResponseType = c.String(),
                        ClientId = c.String(),
                        RedirectUri = c.String(),
                        Scope = c.String(),
                        State = c.String(),
                        AccessType = c.String(),
                        Promt = c.String(),
                        LoginHint = c.String(),
                        IncludeGrantedScopes = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ChannelAuthMethodID);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        ChannelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserAccountId = c.Int(nullable: false),
                        ChannelAuthMethodId = c.Int(nullable: false),
                        Description = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.ChannelId);
            
            CreateTable(
                "dbo.ChannelChannelAuthMethods",
                c => new
                    {
                        Channel_ChannelId = c.Int(nullable: false),
                        ChannelAuthMethod_ChannelAuthMethodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Channel_ChannelId, t.ChannelAuthMethod_ChannelAuthMethodID })
                .ForeignKey("dbo.Channels", t => t.Channel_ChannelId, cascadeDelete: true)
                .ForeignKey("dbo.ChannelAuthMethods", t => t.ChannelAuthMethod_ChannelAuthMethodID, cascadeDelete: true)
                .Index(t => t.Channel_ChannelId)
                .Index(t => t.ChannelAuthMethod_ChannelAuthMethodID);
            
            AddColumn("dbo.UserAccounts", "Source_ChannelId", c => c.Int());
            CreateIndex("dbo.UserAccounts", "Source_ChannelId");
            AddForeignKey("dbo.UserAccounts", "Source_ChannelId", "dbo.Channels", "ChannelId");
            DropTable("dbo.Sources");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        SourceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserAccountId = c.Int(nullable: false),
                        Description = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.SourceId);
            
            DropForeignKey("dbo.UserAccounts", "Source_ChannelId", "dbo.Channels");
            DropForeignKey("dbo.ChannelChannelAuthMethods", "ChannelAuthMethod_ChannelAuthMethodID", "dbo.ChannelAuthMethods");
            DropForeignKey("dbo.ChannelChannelAuthMethods", "Channel_ChannelId", "dbo.Channels");
            DropIndex("dbo.ChannelChannelAuthMethods", new[] { "ChannelAuthMethod_ChannelAuthMethodID" });
            DropIndex("dbo.ChannelChannelAuthMethods", new[] { "Channel_ChannelId" });
            DropIndex("dbo.UserAccounts", new[] { "Source_ChannelId" });
            DropColumn("dbo.UserAccounts", "Source_ChannelId");
            DropTable("dbo.ChannelChannelAuthMethods");
            DropTable("dbo.Channels");
            DropTable("dbo.ChannelAuthMethods");
            CreateIndex("dbo.UserAccounts", "SourceId");
            AddForeignKey("dbo.UserAccounts", "SourceId", "dbo.Sources", "SourceId", cascadeDelete: true);
        }
    }
}
