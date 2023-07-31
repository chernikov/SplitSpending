using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitSpendingWeb.Data;
using SplitSpendingWeb.Model;

namespace SplitSpendingWeb.Business.Queries;

public class GetSpendingDetailsQueryHandler : IRequestHandler<GetSpendingDetailsQuery, IEnumerable<Spending>>
{
    private AppDbContext _context;

    public GetSpendingDetailsQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Spending>> Handle(GetSpendingDetailsQuery request, CancellationToken cancellationToken)
    =>  await _context.Spendings.ToListAsync();
}