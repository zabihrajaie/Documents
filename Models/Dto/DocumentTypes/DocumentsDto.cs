using System;
using System.Collections.Generic;

namespace Models.Dto.DocumentTypes
{
    public class DocumentsDto
    {
        public List<DocumentDtoSelect> DocumentDtoSelects { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
    }

    public class DocumentDtoSelect
    {
        public long InquiryId { get; set; }
        public string FullInquiryId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string DataAsJson { get; set; }
        public string ImageId { get; set; }
        public string RegistrationUserId { get; set; }
        public long DocumentTypeId { get; set; }
        public bool AllowChange { get; set; }
        public string NextVersion { get; set; }
        public string PrevVersion { get; set; }
    }
}