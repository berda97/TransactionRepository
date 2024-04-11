using TransactionRepository.Interface;
using TransactionRepository.Model;

namespace TransactionRepository.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IHashService _hashService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TransactionService(IHashService hashService, IHttpContextAccessor httpContextAccessor)
        {
            _hashService = hashService;
            _httpContextAccessor = httpContextAccessor;
        }
        public TransactionResponseDto ProcessTransaction(TransactionRequestDto request)
        {
            string receivedHash = _httpContextAccessor.HttpContext.Request.Headers["hash"];
            string requestData = $"{request.ExternalTransactionId}{request.UserId}{request.Amount}{request.Currency}";
            if (!_hashService.IsValidHash(receivedHash, requestData, "your_secret_key"))
            {
                return new TransactionResponseDto { Message = "Invalide hash", Status = 1 };
            }
           
            return new TransactionResponseDto { TransactionId = "generated_transaction_id", Message = "Successful transaction", Status = 0 };
        }
    }
}
