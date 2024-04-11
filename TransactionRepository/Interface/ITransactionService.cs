using TransactionRepository.Model;

namespace TransactionRepository.Interface
{
    public interface ITransactionService
    {
        TransactionResponseDto ProcessTransaction(TransactionRequestDto request);
    }
}
