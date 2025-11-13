using TechnicalExercise.Models;

namespace TechnicalExercise.Services;

public class MockPaymentGateway : IPaymentGateway
{
    private static readonly Random Random = new();
    private static readonly string[] ErrorCodes = { "INSUFFICIENT_FUNDS", "ACCOUNT_LOCKED", "INVALID_ACCOUNT", "NETWORK_ERROR", "TIMEOUT" };

    public async Task<TransactionResult> ProcessPaymentAsync(Transaction transaction)
    {
        // Simulate network latency
        await Task.Delay(Random.Next(50, 200));

        // Simulate various failure scenarios (20% failure rate)
        if (Random.Next(100) < 20)
        {
            var errorCode = ErrorCodes[Random.Next(ErrorCodes.Length)];
            return new TransactionResult
            {
                TransactionId = transaction.TransactionId,
                Success = false,
                ErrorCode = errorCode,
                ErrorMessage = GetErrorMessage(errorCode),
                ProcessedAt = DateTime.UtcNow
            };
        }

        // Simulate occasional timeout (5% chance)
        if (Random.Next(100) < 5)
        {
            await Task.Delay(5000); // Simulate timeout
            throw new TimeoutException($"Payment gateway timeout for transaction {transaction.TransactionId}");
        }

        // Simulate transient network errors (3% chance)
        if (Random.Next(100) < 3)
        {
            throw new HttpRequestException($"Network error processing transaction {transaction.TransactionId}");
        }

        // Success case
        return new TransactionResult
        {
            TransactionId = transaction.TransactionId,
            Success = true,
            ProcessedAt = DateTime.UtcNow
        };
    }

    private static string GetErrorMessage(string errorCode) => errorCode switch
    {
        "INSUFFICIENT_FUNDS" => "Account has insufficient funds for this transaction",
        "ACCOUNT_LOCKED" => "Account is locked and cannot process transactions",
        "INVALID_ACCOUNT" => "Account ID is invalid or does not exist",
        "NETWORK_ERROR" => "Network error communicating with payment processor",
        "TIMEOUT" => "Request timed out while processing payment",
        _ => "Unknown error occurred"
    };
}
