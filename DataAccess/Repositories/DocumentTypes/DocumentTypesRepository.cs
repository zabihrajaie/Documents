using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Contracts.DocumentTypes;
using DataAccess.DbContext;
using DataAccess.Repositories.Pattern;

namespace DataAccess.Repositories.DocumentTypes
{
    public class DocumentTypesRepository : Repository<Entities.DocumentType.DocumentTypes>, IDocumentTypesRepository
    {
        public DocumentTypesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
