namespace StudentApp.Entities
{
    public class BookPaymentHistory : BaseEntity
    {
        public string BookName { get; set; }
        public Guid UserId { get; set; }
        public decimal? Price { get; set; }
    }
}
