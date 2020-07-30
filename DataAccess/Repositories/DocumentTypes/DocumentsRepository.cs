using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Contracts.DocumentTypes;
using DataAccess.DbContext;
using DataAccess.Repositories.Pattern;
using Entities.DocumentType;
using Infrastructure.Extensions;
using Infrastructure.Paging;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.DocumentTypes
{
    public class DocumentsRepository : Repository<Documents>, IDocumentsRepository
    {
        public DocumentsRepository(ApplicationDbContext dbContext) : base(dbContext)
        { 
        }

        public async Task<PagedList<Documents>> GetAllAsync(PageInfo pageInfo, CancellationToken cancellationToken)
        {
            var pagedList = new PagedList<Documents>();

            //Expression<Func<Client, bool>> searchCondition = x => x.ClientId.Contains(search) || x.ClientName.Contains(search);
            
            var documents = await TableNoTracking
                .PageBy(x => x.Id, pageInfo.Page, pageInfo.PageSize).ToListAsync(cancellationToken);

            pagedList.Data.AddRange(documents);
            pagedList.TotalCount = await TableNoTracking.CountAsync(cancellationToken);
            pagedList.PageSize = pageInfo.PageSize;

            return pagedList;
        }
    }
}