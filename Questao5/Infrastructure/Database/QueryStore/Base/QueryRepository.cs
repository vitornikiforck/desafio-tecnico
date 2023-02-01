using Questao5.Domain.Repositories.Query.Base;

namespace Questao5.Infrastructure.Database.QueryStore.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
    }
}
