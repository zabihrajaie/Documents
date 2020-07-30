namespace Entities.DocumentType
{
    public class HasAns
    {
        public int Id { get; set; }
        public int MinParticipation { get; set; }
        public int MaxParticipation { get; set; }
        public long ParentDocumentTypeId { get; set; }
        public long ChildDocumentTypeId { get; set; }

        public virtual DocumentTypes ChildDocumentType { get; set; }
        public virtual DocumentTypes ParentDocumentType { get; set; }
    }
}
