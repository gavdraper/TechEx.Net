using TechnicalExercise.Models;

namespace TechnicalExercise.Services;

public interface IPaymentGateway
{
    Task<TransactionResult> ProcessPaymentAsync(Transaction transaction);
}
