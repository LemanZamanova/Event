using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewEvent.Models;

namespace NewEvent.DAL;

public class AppDbContext:IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Position> Position { get; set; }

}
