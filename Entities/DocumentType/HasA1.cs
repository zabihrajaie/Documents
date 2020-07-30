namespace Entities.DocumentType
{
    public class HasA1
    {
        public int Id { get; set; }
        public bool IsRequired { get; set; }
        public long ParrentDocumentTypeId { get; set; }
        public long ChildDocumentTypeId { get; set; }

        public virtual DocumentTypes ChildDocumentType { get; set; }
        public virtual DocumentTypes ParrentDocumentType { get; set; }
    }
}
