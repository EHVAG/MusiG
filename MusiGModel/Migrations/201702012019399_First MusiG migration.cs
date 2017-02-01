namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMusiGmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ArtistId = c.Int(nullable: false),
                        ReleaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AlbumId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Playlist_PlaylistId = c.Int(),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Playlists", t => t.Playlist_PlaylistId)
                .Index(t => t.AlbumId)
                .Index(t => t.ArtistId)
                .Index(t => t.Playlist_PlaylistId);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
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
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserAccountId = c.Int(nullable: false, identity: true),
                        SourceId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAccountId)
                .ForeignKey("dbo.Sources", t => t.SourceId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SourceId)
                .Index(t => t.UserId);
            
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
                "dbo.UserPlaylists",
                c => new
                    {
                        UserPlaylistId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PlaylistTitle = c.String(),
                        PlaylistDescription = c.String(),
                    })
                .PrimaryKey(t => t.UserPlaylistId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPlaylists", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAccounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAccounts", "SourceId", "dbo.Sources");
            DropForeignKey("dbo.Songs", "Playlist_PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Songs", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropIndex("dbo.UserPlaylists", new[] { "UserId" });
            DropIndex("dbo.UserAccounts", new[] { "UserId" });
            DropIndex("dbo.UserAccounts", new[] { "SourceId" });
            DropIndex("dbo.Songs", new[] { "Playlist_PlaylistId" });
            DropIndex("dbo.Songs", new[] { "ArtistId" });
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropTable("dbo.UserPlaylists");
            DropTable("dbo.Users");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Sources");
            DropTable("dbo.Playlists");
            DropTable("dbo.Songs");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
