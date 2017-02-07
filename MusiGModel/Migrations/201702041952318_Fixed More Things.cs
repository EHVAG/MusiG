namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedMoreThings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Channels", "ChannelAuthMethodId_ChannelAuthMethodID", "dbo.ChannelAuthMethods");
            DropIndex("dbo.Channels", new[] { "ChannelAuthMethodId_ChannelAuthMethodID" });
            RenameColumn(table: "dbo.Channels", name: "ChannelAuthMethodId_ChannelAuthMethodID", newName: "ChannelAuthMethodId");
            AlterColumn("dbo.Channels", "ChannelAuthMethodId", c => c.Int(nullable: false));
            CreateIndex("dbo.Channels", "ChannelAuthMethodId");
            AddForeignKey("dbo.Channels", "ChannelAuthMethodId", "dbo.ChannelAuthMethods", "ChannelAuthMethodID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Channels", "ChannelAuthMethodId", "dbo.ChannelAuthMethods");
            DropIndex("dbo.Channels", new[] { "ChannelAuthMethodId" });
            AlterColumn("dbo.Channels", "ChannelAuthMethodId", c => c.Int());
            RenameColumn(table: "dbo.Channels", name: "ChannelAuthMethodId", newName: "ChannelAuthMethodId_ChannelAuthMethodID");
            CreateIndex("dbo.Channels", "ChannelAuthMethodId_ChannelAuthMethodID");
            AddForeignKey("dbo.Channels", "ChannelAuthMethodId_ChannelAuthMethodID", "dbo.ChannelAuthMethods", "ChannelAuthMethodID");
        }
    }
}
