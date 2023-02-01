using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories.Query
{
    public interface IIdempotenceQueryRepository
    {
        Task<Idempotence> Get(string id);
    }
}
