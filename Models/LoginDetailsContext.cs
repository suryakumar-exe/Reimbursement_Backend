using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication4.Models
{
    public class LoginDetailsContext : DbContext
    {
        public LoginDetailsContext(DbContextOptions<LoginDetailsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<LoginDetails> LoginDetailsDB { get; set; } //del
    }
}
