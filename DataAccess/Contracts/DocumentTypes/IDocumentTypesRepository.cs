using System.Threading.Tasks;
using DataAccess.Contracts.Pattern;

namespace DataAccess.Contracts.DocumentTypes
{
    public interface IDocumentTypesRepository : IRepository<Entities.DocumentType.DocumentTypes>
    {
        
    }
}