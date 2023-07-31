using MediatR;
using SplitSpendingWeb.Model;

namespace SplitSpendingWeb.Business.Queries;

public class GetSpendingDetailsQuery : IRequest<IEnumerable<Spending>>
{

}