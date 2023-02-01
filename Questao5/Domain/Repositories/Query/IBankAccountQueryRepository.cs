using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories.Query
{
    public interface IBankAccountQueryRepository
    {
        Task<BankAccount> GetBalanceByIdAsync(string id);
    }
}
