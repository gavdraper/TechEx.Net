namespace TechnicalExercise.Models;

public record Transaction
{
    public string TransactionId { get; init; } = string.Empty;
    public string AccountId { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public string Currency { get; init; } = "USD";
    public string Description { get; init; } = string.Empty;
    public DateTime Timestamp { get; init; }
}
