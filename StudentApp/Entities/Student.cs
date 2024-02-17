namespace StudentApp.Entities
{
    public class Student : BaseEntity
    {
        public string MatricNumber { get; set; }
        public string Level { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
