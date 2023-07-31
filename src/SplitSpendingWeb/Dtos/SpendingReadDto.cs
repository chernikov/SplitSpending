namespace SplitSpendingWeb.Dtos;

public class SpendingReadDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Amount { get; set; }
}