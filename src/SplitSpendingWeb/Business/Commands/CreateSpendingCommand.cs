namespace SplitSpendingWeb.Business.Commands;

public class CreateSpendingCommand : IRequest<int> {
    public string Name {get; set;} = null!;

    public decimal Amount {get; set; }
}