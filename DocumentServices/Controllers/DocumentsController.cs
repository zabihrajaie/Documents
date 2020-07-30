using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityServices.Contracts.DocumentTypes;
using Infrastructure.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DocumentServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        public DocumentsController(IDocumentsService documentService)
        {
            DocumentService = documentService;
        }

        private IDocumentsService DocumentService { get; }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var list = await DocumentService.GetAll(new PageInfo(), cancellationToken);
            var myJObject = JObject.Parse(list?.DocumentDtoSelects[0]?.DataAsJson);

            foreach (var (key, value) in myJObject)
            {
            }

            return Ok(list);
        }

        [HttpGet("GetByInquiryId")]
        public async Task<IActionResult> GetByInquiryId(CancellationToken cancellationToken)
        {
            var list = await DocumentService.GetAll(new PageInfo(), cancellationToken);
            return Ok(list);
        }
    }
}
