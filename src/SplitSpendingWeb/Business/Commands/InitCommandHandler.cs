namespace SplitSpendingWeb.Business.Commands;

public class InitCommandHandler : IRequestHandler<InitCommand, int> {
    private readonly IAppDbContext _context;

    public InitCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    async Task<int> IRequestHandler<InitCommand, int>.Handle(InitCommand request, CancellationToken cancellationToken)
    {
        var isExists = _context.Spendings.Any(p => p.Name == request.Name);
        if (!isExists) {
            var initSpending = new Spending() {
                Amount = 0,
                Name = request.Name
            };
            await _context.Spendings.AddAsync(initSpending);
            await _context.SaveChangesAsync();

            return initSpending.Id;
        }
        return 0;
    }
}