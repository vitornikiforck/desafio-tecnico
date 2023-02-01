using Questao5.Domain.Entities;
using Questao5.Domain.Repositories.Query;
using Questao5.Infrastructure.Database.QueryStore.Base;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public class BankAccountQueryRepository : QueryRepository<BankAccount>, IBankAccountQueryRepository
    {
        protected readonly BankAccountContext _context;

        public BankAccountQueryRepository(BankAccountContext context)
        {
            _context = context;
        }

        public async Task<BankAccount> GetBalanceByIdAsync(string id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount != null)
                bankAccount.FinancialMovements = _context.FinancialMovements.Where(x => x.BankAccountId == bankAccount.Id).ToList();

            return bankAccount;
        }
    }
}
