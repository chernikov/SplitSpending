using Microsoft.EntityFrameworkCore;
using Moq;
using SplitSpendingWeb.Business.Queries;
using SplitSpendingWeb.Data;
using SplitSpendingWeb.Model;

namespace SplitSpendingTests.Business;

public class GetTotalTests
{

    private Mock<DbSet<Spending>> mockSpendings = null!;

    private Mock<IAppDbContext> mockAppDbContext = null!;

    private List<Spending> emptyList = new List<Spending>();

    private List<Spending> regularList = new List<Spending>() {
        new Spending() {Name = "Alex", Amount = 300},
        new Spending() {Name = "Becca", Amount = 0},
        new Spending() {Name = "Ryan", Amount = 0},
        new Spending() {Name = "Alex", Amount = 200}
    };

    [Fact]
    public async void EmptyList_ShouldReturnEmpty()
    {

        MockSpendingDbSet(emptyList);
        MockAppDbContext();

        var sut = new GetTotalHandler(mockAppDbContext.Object);

        var request = new GetTotal();
        var result = await sut.Handle(request, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async void RegularList_ShouldReturnThreeString()
    {

        MockSpendingDbSet(regularList);
        MockAppDbContext();

        var sut = new GetTotalHandler(mockAppDbContext.Object);

        var request = new GetTotal();
        var result = await sut.Handle(request, CancellationToken.None);

        var first = result.ToList()[0];
        Assert.Equal(result.Count(), 3);
        Assert.Equal(first.Name, "Alex");
        Assert.Equal(first.Total, 500);
    }


    private void MockSpendingDbSet(List<Spending> list)
    {

        mockSpendings = new Mock<DbSet<Spending>>();
        mockSpendings.As<IAsyncEnumerable<Spending>>()
               .Setup(m => m.GetAsyncEnumerator(CancellationToken.None))
               .Returns(new AsyncEnumerator<Spending>(list.GetEnumerator()));
    }

    private void MockAppDbContext()
    {
        mockAppDbContext = new Mock<IAppDbContext>();
        mockAppDbContext.Setup(p => p.Spendings)
            .Returns(mockSpendings.Object);
    }

}