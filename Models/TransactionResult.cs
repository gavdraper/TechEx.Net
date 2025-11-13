namespace TechnicalExercise.Models;

public record TransactionResult
{
    public string TransactionId { get; init; } = string.Empty;
    public bool Success { get; init; }
    public string? ErrorMessage { get; init; }
    public string? ErrorCode { get; init; }
    public DateTime ProcessedAt { get; init; }
}
