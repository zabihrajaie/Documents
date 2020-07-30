using System.Collections.Generic;
using Entities.Common;

namespace Entities.DocumentType
{
    public sealed class DocumentTypes : BaseEntity<long>
    {
        public DocumentTypes()
        {
            Attributes = new HashSet<Attributes>();
            Documents = new HashSet<Documents>();
            HasA1ChildDocumentType = new HashSet<HasA1>();
            HasA1ParrentDocumentType = new HashSet<HasA1>();
            HasAnsChildDocumentType = new HashSet<HasAns>();
            HasAnsParentDocumentType = new HashSet<HasAns>();
            IsAsSubDocumentTypeId1Navigation = new HashSet<IsAs>();
            IsAsSuperDocumentType = new HashSet<IsAs>();
            RelatedToesLeftDocumentType = new HashSet<RelatedToes>();
            RelatedToesRightDocumentType = new HashSet<RelatedToes>();
        }
        
        public string Name { get; set; }
        public bool IsInterface { get; set; }
        public bool OwnerDataType { get; set; }
        public bool IsUsed { get; set; }
        public int ScopeId { get; set; }

        public Scopes Scope { get; set; }
        public ICollection<Attributes> Attributes { get; set; }
        public ICollection<Documents> Documents { get; set; }
        public ICollection<HasA1> HasA1ChildDocumentType { get; set; }
        public ICollection<HasA1> HasA1ParrentDocumentType { get; set; }
        public ICollection<HasAns> HasAnsChildDocumentType { get; set; }
        public ICollection<HasAns> HasAnsParentDocumentType { get; set; }
        public ICollection<IsAs> IsAsSubDocumentTypeId1Navigation { get; set; }
        public ICollection<IsAs> IsAsSuperDocumentType { get; set; }
        public ICollection<RelatedToes> RelatedToesLeftDocumentType { get; set; }
        public ICollection<RelatedToes> RelatedToesRightDocumentType { get; set; }
    }
}
