using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Contracts.DocumentTypes;
using EntityServices.Contracts.DocumentTypes;
using Infrastructure.Paging;
using Models.Dto.DocumentTypes;

namespace EntityServices.Services.DocumentTypes
{
    public class DocumentsService : IDocumentsService
    {
        public IDocumentsRepository DocumentsRepository { get; set; }

        public DocumentsService(IDocumentsRepository documentsRepository)
        {
            DocumentsRepository = documentsRepository;
        }

        public async Task<DocumentsDto> GetAll(PageInfo pageInfo, CancellationToken cancellationToken)
        {
            var data = await DocumentsRepository.GetAllAsync(pageInfo, cancellationToken);
            var dto = new List<DocumentDtoSelect>();
            foreach (var document in data.Data)
            {
                dto.Add(new DocumentDtoSelect
                {
                    AllowChange = document.AllowChange,
                    DataAsJson = document.DataAsJson,
                    ExpireDate = document.ExpireDate,
                    FullInquiryId = document.FullInquiryId,
                    DocumentTypeId = document.DocumentTypeId
                });
            }
            return new DocumentsDto
            {
                TotalCount = data.TotalCount,
                PageSize = data.PageSize,
                DocumentDtoSelects = dto
            };
        }

        public Task<DocumentsDto> GetByInquiryId(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}