using Microsoft.EntityFrameworkCore;
using StudentApp.Entities;

namespace StudentApp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BookPaymentHistory> BookPaymentHistory { get; set; }
    }
}
