using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GitJobs.Models
{
    public class GitJobsContext : IdentityDbContext<ApplicationUser>
    {
      public DbSet<Job> Jobs { get; set; }
      public GitJobsContext(DbContextOptions options) : base(options) { }
    }
}