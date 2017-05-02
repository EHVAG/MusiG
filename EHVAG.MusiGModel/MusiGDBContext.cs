namespace EHVAG.MusiGModel
{
    using System.Data.Entity;

    public class MusiGDBContext : DbContext
    {
        public MusiGDBContext()
            : base("name=MusiGDev")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusiGDBContext, EHVAG.MusiGModel.Migrations.Configuration>("MusiGDev"));
        }

        public virtual DbSet<GoogleUser> GoogleUser { get; set; }
        public virtual DbSet<OAuth2Token> OAuth2Token { get; set; }
        public virtual DbSet<Channel> Channel { get; set; }

    }
}
