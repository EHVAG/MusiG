namespace EHVAG.MusiGModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EHVAG.MusiGModel.MusiGDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusiGDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Channel.AddOrUpdate(
            c => c.Id,
            new Channel
            {
                Id = Channels.YouTube,
                Description = "YouTube",
                FontAwesomeIconClass = "fa fa-youtube-square",
                URL = "https://youtube.com",
            },
            new Channel
            {
                Id = Channels.Soundcloud,
                Description = "YouTubeSoundCloud",
                FontAwesomeIconClass = "fa fa-soundcloud",
                URL = "https://soundcloud.com",
            },

            new Channel
            {
                Id = Channels.Spotify,
                Description = "Spotify",
                FontAwesomeIconClass = "fa fa-spotify",
                URL = "https://spotify.com",
            },

            new Channel
            {
                Id = Channels.USB,
                Description = "USB",
                FontAwesomeIconClass = "fa fa-usb",
                URL = ""
            });

            context.SaveChanges();
        }
    }
}
