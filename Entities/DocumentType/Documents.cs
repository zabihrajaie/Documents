using System;
using System.Collections.Generic;
using Entities.Common;

namespace Entities.DocumentType
{
    public class Documents : BaseEntity<long>
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

        public virtual DocumentTypes DocumentType { get; set; }
        public virtual ICollection<DocEvents> DocEvents { get; set; }
    }
}
