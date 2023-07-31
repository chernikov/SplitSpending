using Microsoft.EntityFrameworkCore;
using SplitSpendingWeb.Dtos;

namespace SplitSpendingWeb.Business.Queries;

public class GetTotalHandler : IRequestHandler<GetTotal, IEnumerable<TotalItemDto>>
{
    private readonly IAppDbContext _context;

    public GetTotalHandler(IAppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<TotalItemDto>> Handle(GetTotal request, CancellationToken cancellationToken)
    {
        var records = await _context.Spendings.ToListAsync();

        var totalItems = records.GroupBy(p => p.Name)
                            .Select(p => new TotalItemDto() {
                                  Name = p.Key,
                                  Total = p.Sum(p => p.Amount)
                            });
        return totalItems;
    }
}