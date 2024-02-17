namespace StudentApp.Entities
{
    public class Wallet : BaseEntity
    {
        public decimal Amount { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
