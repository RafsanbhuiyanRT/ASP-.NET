using BildWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BildWebApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
}
