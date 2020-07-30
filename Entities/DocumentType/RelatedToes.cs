namespace Entities.DocumentType
{
    public class RelatedToes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RightSideAttributes { get; set; }
        public string LeftSideAttributes { get; set; }
        public bool IsCausal { get; set; }
        public int MinParticipation { get; set; }
        public int MaxParticipation { get; set; }
        public long RightDocumentTypeId { get; set; }
        public long LeftDocumentTypeId { get; set; }
        public int PolicyOnChangeId { get; set; }

        public virtual DocumentTypes LeftDocumentType { get; set; }
        public virtual DocumentTypes RightDocumentType { get; set; }
    }
}
