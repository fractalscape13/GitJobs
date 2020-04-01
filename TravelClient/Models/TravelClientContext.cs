using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TravelClient.Models
{
    public class TravelClientContext : IdentityDbContext<ApplicationUser>
    {
      public TravelClientContext(DbContextOptions options) : base(options) { }
    }
}