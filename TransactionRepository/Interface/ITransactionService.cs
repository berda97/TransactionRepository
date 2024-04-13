using TransactionRepository.Model;

namespace TransactionRepository.Interface
{
    public interface ITransactionService
    {
        Task<TransactionResponseDto> ProcessTransactionAsync(TransactionRequestDto request);
    }
}
