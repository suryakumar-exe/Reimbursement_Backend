using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class ReimbursementContext : DbContext
    {
        public ReimbursementContext(DbContextOptions<ReimbursementContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Reimbursement> reimbursements { get; set; } //del
    }
}
