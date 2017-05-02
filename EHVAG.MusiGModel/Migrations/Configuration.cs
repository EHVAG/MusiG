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
            c => c.Name,
            new Channel
            {
                Name = "YouTube",
                Description = "YouTube",
                FontAwesomeIconClass = "fa fa-youtube-square",
                URL = "",
                State = ChannelState.Connected,
            },
            new Channel
            {
                Name = "SoundCloud",
                Description = "YouTubeSoundCloud",
                FontAwesomeIconClass = "fa fa-soundcloud",
                URL = "",
                State = ChannelState.Connected,
            },

            new Channel
            {
                Name = "Spotify",
                Description = "Spotify",
                FontAwesomeIconClass = "fa fa-spotify",
                URL = "",
                State = ChannelState.Connected,
            },

            new Channel
            {
                Name = "USB",
                Description = "USB",
                FontAwesomeIconClass = "fa fa-usb",
                URL = "",
                State = ChannelState.Connected,
            },

            new Channel
            {
                Name = "Twitch",
                Description = "Twitch",
                FontAwesomeIconClass = "fa fa-twitch",
                URL = "",
                State = ChannelState.Connected,
            },

            new Channel
            {
                Name = "PayPal",
                Description = "PayPal",
                FontAwesomeIconClass = "fa fa-paypal",
                URL = "",
                State = ChannelState.Connected,
            });

            context.SaveChanges();
        }
    }
}
