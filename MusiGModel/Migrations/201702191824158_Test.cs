namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.oAuth2Token", "TokenExpiresAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Channels", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Channels", "Name", unique: true);
            DropColumn("dbo.oAuth2Token", "CreatedDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.oAuth2Token", "CreatedDateTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropIndex("dbo.Channels", new[] { "Name" });
            AlterColumn("dbo.Channels", "Name", c => c.String());
            DropColumn("dbo.oAuth2Token", "TokenExpiresAt");
        }
    }
}
