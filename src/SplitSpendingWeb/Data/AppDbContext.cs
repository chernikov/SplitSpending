using Microsoft.EntityFrameworkCore;
using SplitSpendingWeb.Model;

namespace SplitSpendingWeb.Data;

public class AppDbContext : DbContext 
{
     public DbSet<Spending> Spendings {get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}