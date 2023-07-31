using Microsoft.EntityFrameworkCore;

namespace SplitSpendingWeb.Data;
public interface IAppDbContext
{
    DbSet<Spending> Spendings { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
