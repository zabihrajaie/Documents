using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Paging;
using Models.Dto.DocumentTypes;

namespace EntityServices.Contracts.DocumentTypes
{
    public interface IDocumentsService
    {
        Task<DocumentsDto> GetAll(PageInfo pageInfo, CancellationToken cancellationToken);
        Task<DocumentsDto> GetByInquiryId(CancellationToken cancellationToken);
    }
}