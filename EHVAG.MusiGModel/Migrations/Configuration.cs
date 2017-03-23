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

        protected override void Seed(EHVAG.MusiGModel.MusiGDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Channel.Add(new Channel { Name = "YouTube", Description = "YouTube", FontAwesomeIconClass = "fa fa-youtube-square", Link = "", State = ChannelState.Active, });
            //context.Channel.Add(new Channel { Name = "SoundCloud", Description = "YouTubeSoundCloud", FontAwesomeIconClass = "fa fa-soundcloud", Link = "", State = ChannelState.Active, });
            //context.Channel.Add(new Channel { Name = "Spotify", Description = "Spotify", FontAwesomeIconClass = "fa fa-spotify", Link = "", State = ChannelState.Active, });
            //context.Channel.Add(new Channel { Name = "USB", Description = "USB", FontAwesomeIconClass = "fa fa-usb", Link = "", State = ChannelState.CommingSoon, });
            //context.Channel.Add(new Channel { Name = "Twitch", Description = "Twitch", FontAwesomeIconClass = "fa fa-twitch", Link = "", State = ChannelState.CommingSoon, });
            //context.Channel.Add(new Channel { Name = "PayPal", Description = "PayPal", FontAwesomeIconClass = "fa fa-paypal", Link = "", State = ChannelState.CommingSoon, });
            //context.SaveChanges();

        }
    }
}
