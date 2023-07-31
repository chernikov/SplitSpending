using SplitSpendingWeb.Dtos;

namespace SplitSpendingWeb.Business.Queries;

public class GetSummaryHandler : IRequestHandler<GetSummary, IEnumerable<SummaryItemDto>>
{
    private IMediator _mediator;

    public GetSummaryHandler(IMediator mediator) {
        _mediator = mediator;
    }

    public async Task<IEnumerable<SummaryItemDto>> Handle(GetSummary request, CancellationToken cancellationToken)
    {
        var totalItems = await _mediator.Send(new GetTotal());

        if (totalItems.Count() == 0) {
            return new List<SummaryItemDto>();
        }
        var average = totalItems.Sum(p => p.Total) / totalItems.Count();

        var result = totalItems.Select(p => new SummaryItemDto() {
                Summary = p.Total > average ? $"{p.Name}, others owe you {p.Total - average}" : $"{p.Name}, you owe others {average - p.Total}"});
        
        return result;
    }
}