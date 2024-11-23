using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace question.Models
{
    public class appcontext :IdentityDbContext<applicant>
    {
        public DbSet<job> jobs { get; set; }
        public DbSet<application> applications  { get; set; }
        public appcontext() : base() { }
        public appcontext (DbContextOptions options) : base(options) { }
        
    }
}
