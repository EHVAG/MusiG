namespace MusiGModel
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public int SourceId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Source Source { get; set; }
    }
}