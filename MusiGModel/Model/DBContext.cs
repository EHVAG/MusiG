namespace MusiGModel
{
    using System.Data.Entity;

    public class DBContext : DbContext
    {
        // Your context has been configured to use a 'MusiGDatabase' connection string from your application's
        // configuration file (App.config or Web.config). By default, this connection string targets the
        // 'MusiGModel.MusiGDatabase' database on your LocalDb instance.
        //
        // If you wish to target a different database and/or database provider, modify the 'MusiGDatabase'
        // connection string in the application configuration file.
        public DBContext()
            : base("name=MusiGDatabase")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Playlist> UsPlaylisters { get; set; }
        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<Source> Source { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<UserPlaylist> UserPlaylist { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}