namespace SplitSpendingWeb.Business.Commands;

public class InitCommand : IRequest<int> 
{
    public string Name {get; set; } = null!;

}