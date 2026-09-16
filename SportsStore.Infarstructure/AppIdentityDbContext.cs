// Trong SportsStore.Infrastructure/AppIdentityDbContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsStore.Domain; // Phải tham chiếu đến project Domain

namespace SportsStore.Infrastructure
{
    // Kế thừa từ IdentityDbContext<AppUser>
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public
        AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        : base(options) { }
    }
}