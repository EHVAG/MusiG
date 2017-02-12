namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Authnotneeded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Channels", "ChannelAuthMethodId", "dbo.ChannelAuthMethods");
            DropIndex("dbo.Channels", new[] { "ChannelAuthMethodId" });
            DropTable("dbo.ChannelAuthMethods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ChannelAuthMethods",
                c => new
                    {
                        ChannelAuthMethodID = c.Int(nullable: false, identity: true),
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
            
            CreateIndex("dbo.Channels", "ChannelAuthMethodId");
            AddForeignKey("dbo.Channels", "ChannelAuthMethodId", "dbo.ChannelAuthMethods", "ChannelAuthMethodID", cascadeDelete: true);
        }
    }
}
