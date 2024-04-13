using TransactionRepository.Model;

namespace TransactionRepository.Data
{
    public class AccountSeedData
    {
        public static async Task InitializeAsync(TransactionDatabaseContext context)
        {
            //TODO OKRENI USLOV DA IMAM RETURNE 
            if (!context.Accounts.Any())
            {
                context.Accounts.AddRange(
                    new Account { AccountId = 1,  Balance = 1000, Currency = "USD", OpeningDate = DateTime.Now },
                    new Account { AccountId = 2,  Balance = 500, Currency = "EUR", OpeningDate = DateTime.Now },
                    new Account { AccountId = 3,  Balance = 1250, Currency = "RSD", OpeningDate = DateTime.Now },
                    new Account { AccountId = 4,  Balance = 1200, Currency = "EUR", OpeningDate = DateTime.Now },
                    new Account { AccountId = 5,  Balance = 750, Currency = "RSD", OpeningDate = DateTime.Now }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
