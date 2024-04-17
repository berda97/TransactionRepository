using Microsoft.EntityFrameworkCore;
using TransactionRepository.Data;
using TransactionRepository.Interface;
using TransactionRepository.Model;

namespace TransactionRepository.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionDatabaseContext transactionDatabaseContext;
        private readonly ILogger<TransactionService> _logger;
        public TransactionService(TransactionDatabaseContext context, ILogger<TransactionService> logger)
        {
            transactionDatabaseContext = context;
           _logger = logger;
        }
        public async Task<TransactionResponseDto> ProcessTransactionAsync(TransactionRequestDto request)
        {
            var user = await transactionDatabaseContext.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if (user == null)
            {
                var response = new TransactionResponseDto { Message = "User not found.", Status = 1 };
                _logger.LogError("User not found: {@id}", request.UserId);
                return response;
            }
            var account = transactionDatabaseContext.Accounts.FirstOrDefault(a => a.AccountId == user.AccountId);

            if (account == null)
            {
                var response = new TransactionResponseDto { Message = "Account not found.", Status = 3 };
                _logger.LogError("Account not found: {@id}", user.AccountId);
                return response;
            }

            if (account.Currency != request.Currency)
            {
                var response = new TransactionResponseDto { Message = "Currency not supported.", Status = 2 };
                _logger.LogError("For Account {@id} currency not supported: {@Currency}",account.AccountId, request.Currency);
                return response;
            }
            account.Balance += request.Amount;
            var transactionId = Guid.NewGuid();
            await transactionDatabaseContext.Tranasctions.AddAsync(new Transaction { AccountId=account.AccountId, TransactionId= transactionId });
            await transactionDatabaseContext.SaveChangesAsync();

            var successfulResponse = new TransactionResponseDto { TransactionId = transactionId.ToString(), Message = "Successful transaction", Status = 0 };
           _logger.LogInformation("Successful transaction: {@id}", transactionId);

            return successfulResponse;
        }
    }
}




