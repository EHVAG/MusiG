namespace EHVAG.MusiGModel
{
    using System.Data.Entity;

    public class MusiGDBContext : DbContext
    {
        public MusiGDBContext()
            : base("name=MusiGDev")
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<OAuth2Token> OAuth2Token { get; set; }
        public virtual DbSet<Channel> Channel { get; set; }

    }
}
