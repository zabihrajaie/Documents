using System.Threading;
using System.Threading.Tasks;
using DataAccess.Contracts.Pattern;
using Entities.DocumentType;
using Infrastructure.Paging;

namespace DataAccess.Contracts.DocumentTypes
{
    public interface IDocumentsRepository : IRepository<Documents>
    {
        Task<PagedList<Documents>> GetAllAsync(PageInfo pageInfo, CancellationToken cancellationToken);
    }
}