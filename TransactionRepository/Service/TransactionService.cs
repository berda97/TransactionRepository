using Microsoft.EntityFrameworkCore;
using TransactionRepository.Data;
using TransactionRepository.Interface;
using TransactionRepository.Model;

namespace TransactionRepository.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionDatabaseContext transactionDatabaseContext;
        
        public TransactionService(TransactionDatabaseContext context)
        {
            transactionDatabaseContext = context;
            
        }
        public async Task<TransactionResponseDto> ProcessTransactionAsync(TransactionRequestDto request)
        {

            var user = await transactionDatabaseContext.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if (user == null)
            {
                return new TransactionResponseDto { Message = "User not found.", Status = 1 };
            }
            var account = transactionDatabaseContext.Accounts.FirstOrDefault(a => a.AccountId == request.UserId);

            if (account == null)
            {
                throw new Exception("User account not found.");// TODO vrati status 
            }

            if (account.Currency != request.Currency)//
            {
                return new TransactionResponseDto { Message = "Valuta nije podržana.", Status = 2 };// TODO ON ENGLISH
               
            }
            account.Balance = account.Balance + request.Amount;
            var transactionId = Guid.NewGuid();
            await transactionDatabaseContext.Tranasctions.AddAsync(new Transaction { AccountId=account.AccountId, TransactionId= transactionId });
            await transactionDatabaseContext.SaveChangesAsync();

            return new TransactionResponseDto { TransactionId = transactionId.ToString(), Message = "Successful transaction", Status = 0 };
        }
    }
}




