namespace SplitSpendingWeb.Business.Commands;

public class CreateSpendingCommandHandler : IRequestHandler<CreateSpendingCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateSpendingCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSpendingCommand request, CancellationToken cancellationToken)
    {
        var isExists = _context.Spendings.Any(p => p.Name == request.Name);
        if (!isExists) {
            throw new ArgumentException($"User with {nameof(request.Name)} {request.Name} wasn't found");
        }
        var spending = new Spending() {
            Amount = request.Amount,
            Name = request.Name
        };
        await _context.Spendings.AddAsync(spending);
        await _context.SaveChangesAsync();

        return spending.Id;
    }
}